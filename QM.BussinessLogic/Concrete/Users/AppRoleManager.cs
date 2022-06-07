using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QM.BussinessLogic.Interface.Users;
using QM.Common.ViewModels.Users.AppRoleViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Concrete.Users
{
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        private readonly RoleManager<AppRole> _RoleManager;

        public AppRoleManager(IUnitOfWork uow, RoleManager<AppRole> roleManager, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
            _RoleManager = roleManager;
        }

        /// <summary>
        /// Sisteme rol ekler.
        /// </summary>
        /// <param name="model">AppRoleAddViewModel.</param>
        public async Task<IdentityResult> AddAppRole(AppRoleAddViewModel model)
        {
            AppRole role = new AppRole
            {
                Name = model.Name
            };
            return await _RoleManager.CreateAsync(role);
        }

        /// <summary>
        /// Sistemden role siler.
        /// </summary>
        /// <param name="model">AppRoleListViewModel.</param>
        public void DeleteAppRole(AppRoleListViewModel model)
        {
            var toBeDeletedRole = _RoleManager.Roles.Where(I => I.Id == model.Id).FirstOrDefault();
            Delete(toBeDeletedRole);
            _Uow.SaveChange();
        }

        /// <summary>
        /// Sistemde bulunan tüm rolleri getirir.
        /// </summary>
        /// <returns>AppRoleListViewModel listesi.</returns>
        public List<AppRoleListViewModel> GetAllAppRoles()
        {
            return _Mapper.Map<List<AppRoleListViewModel>>(_RoleManager.Roles);
        }

        /// <summary>
        /// Güncellenecek rol bilgilerini getirir.
        /// </summary>
        /// <param name="roleId">Rol Id'si.</param>
        /// <returns>AppRoleUpdateViewModel.</returns>
        public AppRoleUpdateViewModel GetAppRoleInfoToUpdate(int roleId)
        {
            return _Mapper.Map<AppRoleUpdateViewModel>(_RoleManager.Roles.FirstOrDefault(I => I.Id == roleId));
        }

        /// <summary>
        /// Rol güncelleme.
        /// </summary>
        /// <param name="model">AppRoleUpdateViewModel.</param>
        public async Task<IdentityResult> UpdateAppRole(AppRoleUpdateViewModel model)
        {
            var toBeUpdatedRole = _RoleManager.Roles.Where(I => I.Id == model.Id).FirstOrDefault();
            toBeUpdatedRole.Name = model.Name;
            return await _RoleManager.UpdateAsync(toBeUpdatedRole);

        }
    }
}
