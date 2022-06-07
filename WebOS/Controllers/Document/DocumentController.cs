using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QM.BussinessLogic.Interface.Documents;
using QM.BussinessLogic.Interface.Users;
using QM.Common.ViewModels.Documents.DocumentViewModels;
using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebOS.Controllers.Document
{
    /// <summary>
    /// Dosya kontrolü
    /// </summary>
    public class DocumentController : Controller
    {
        private readonly ArlentusBIContext _ArlentusBIContext;
        private readonly IDocumentService _DocumentService;
        private readonly IAppUserService _AppUserService;
        private readonly UserManager<AppUser> _UserManager;

        public DocumentController(ArlentusBIContext arlentusBIContext,
                                  UserManager<AppUser> userManager,
                                  IDocumentService documentService,
                                  IAppUserService appUserService)
        {
            _ArlentusBIContext = arlentusBIContext;
            _DocumentService = documentService;
            _AppUserService = appUserService;
            _UserManager = userManager;
        }

        #region UPLOAD

        /// <summary>
        /// Dosya yüklem işlemi
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="formType"></param>
        /// <returns></returns>
        public IActionResult Upload(int formId, string formType)
        {
            var fileuploadViewModel = LoadAllDocuments(formId, formType);
            ViewBag.Message = TempData["Message"];
            return View(fileuploadViewModel);
        }
        #endregion

        #region UPLOAD WORK ORDER DOCUMENTS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="description"></param>
        /// <param name="formId"></param>
        /// <param name="formType"></param>
        /// <param name="addOrUpdate"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadDocument(List<IFormFile> files, 
                                                        string description, 
                                                        int formId, 
                                                        string formType, 
                                                        string addOrUpdate)
        {
            var user = JsonConvert.DeserializeObject<AppUser>(HttpContext.Session.GetString("LoginUser"));
            ViewBag.LoginUserId = user.Id;//Oturum açan kullanıcı Id'si.
            ViewBag.LoginUserFullName = "" + user.FirstName + " " + user.LastName;//Oturum açan kullanıcı 'Ad-Soyad'.
            ViewBag.Department = "" + user.DepartmentName;//Oturum açan kullanıcının departmanı.
            var role = _UserManager.GetRolesAsync(user);
            ViewBag.Role = role.Result[0].ToString();
            ViewBag.UserList = new SelectList(_AppUserService.GetAll().ToList(), "Id", "FullName");

            foreach (var file in files)
            {
                var basePath = $"wwwroot/Files";
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(formType + formId + "_" + file.FileName);
                var filePath = Path.Combine(basePath, formType + formId + "_" + file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var fileModel = new QM.Entities.Concrete.Documents.Document
                    {
                        CreatedOn = DateTime.Now,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = fileName,
                        Description = description,
                        FilePath = filePath,
                        FormId = formId,
                        FormType = formType,
                        UploadedBy = ViewBag.LoginUserFullName
                    };
                    _ArlentusBIContext.Documents.Add(fileModel);
                    _ArlentusBIContext.SaveChanges();
                }
            }
            TempData["Message"] = "File successfully uploaded to File System.";
            if (formType == "WorkOrder" && addOrUpdate == "update")
                return RedirectToAction("WorkOrderDetail", "WorkOrder", new { id = formId });
            if (formType == "WorkOrder" && addOrUpdate == "add")
                return RedirectToAction("WorkOrderAllRecords", "WorkOrder");
            if (formType == "FinalQuality")
                return RedirectToAction("Detail", "FinalQuality", new { id = formId });
            return RedirectToAction("Upload", "Document", new { formId, formType });

        }
        #endregion

        #region LOAD DOCUMENT

        /// <summary>
        /// Dosyaları listelemek için kullanıldı.
        /// </summary>
        /// <param name="formId">Form Id</param>
        /// <param name="formType">Kulanılan form adı</param>
        /// <returns></returns>
        private List<DocumentListViewModel> LoadAllDocuments(int formId, string formType)
        {
            var viewModel = _DocumentService.GetAllDocumentById(formId, formType);
            return viewModel;
        }
        #endregion

        #region DOWNLOAD DOCUMENT

        /// <summary>
        /// Dosya yükleme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var file = await _ArlentusBIContext.Documents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
        }
        #endregion

        #region DELETE DOCUMENT

        /// <summary>
        /// Dosya silme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formId"></param>
        /// <param name="formType"></param>
        /// <param name="addOrUpdate">Verinin geldiği sayfa (ekleme veya güncelleme)</param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteDocument(int id, int formId, string formType, string addOrUpdate)
        {
            var file = await _ArlentusBIContext.Documents.Where(I => I.Id == id && I.FormId == formId && I.FormType == formType).FirstOrDefaultAsync();
            if (file == null) return null;
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            _ArlentusBIContext.Documents.Remove(file);
            _ArlentusBIContext.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from File System.";
            if (formType == "WorkOrder" && addOrUpdate == "update")
                return RedirectToAction("WorkOrderDetail", "WorkOrder", new { id = formId });
            if (formType == "WorkOrder" && addOrUpdate == "add")
                return RedirectToAction("WorkOrderAllRecords", "WorkOrder");
            if (formType == "FinalQuality")
                return RedirectToAction("Detail", "FinalQuality", new { id = formId });
            return RedirectToAction("Upload", "Document", new { formId, formType });
        }
        #endregion
    }
}