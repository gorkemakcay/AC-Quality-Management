using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using OfficeOpenXml;
using QM.BussinessLogic.Interface;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace QM.BussinessLogic.Concrete
{
    public class FileManager : IFileService
    {

        public byte[] GenerateExcel<T>(List<T> list) where T : class, new()
        {
            try
            {
                var excelPackage = new ExcelPackage();
                var excelBlank = excelPackage.Workbook.Worksheets.Add("Work1");
                excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);
                return excelPackage.GetAsByteArray();
            }
            catch (Exception)
            {
                throw new Exception("Hata!");
            }
        }

        public string GeneratePDF(string html)
        {
            try
            {
                var fileName = Guid.NewGuid() + ".pdf";
                var returnPath = "/doc/" + fileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/doc/" + fileName);
                var stream = new FileStream(path, FileMode.Create);
                var cssFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/StyleSheet.css");
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                //cssFiles.ForEach(i => cssResolver.AddCssFile(Path.Combine(webRoot, i), true));
                cssResolver.AddCssFile(cssFile, true);

                //cssResolver.AddCss(@"body{width: 900px;margin: 50px 510px 0 510px;border: 3px solid black;}", true);
                //cssResolver.AddCss(@"img{width: 160px;height: 90px;}",true);
                //cssResolver.AddCss(@".header{border-bottom: 3px solid black;width: 100%;height: 100px;}",true);
                //cssResolver.AddCss(@".header .header-logo{width: 150px;height: 100%;float: left;}",true);
                //cssResolver.AddCss(@".header .header-text{text - align: center;width: 750px;height: 100 %;float: left;}", true);
                //cssResolver.AddCss(@".quality{border-bottom: 3px solid black;width: 100%;height: 500px;}", true);
                //cssResolver.AddCss(@".quality .customer{width: 50%;height: 10%;}",true);
                //cssResolver.AddCss(@".quality .customer .customerLabel{float: left;width: 40%;height: 100%;}", true);
                //cssResolver.AddCss(@".quality .customer .customerLabel h3{margin-left: 15px;}",true);
                //cssResolver.AddCss(@".quality .customer .customerName{float: left;width: 60%;height: 100%;}", true);
                //cssResolver.AddCss("table{width:725px;}", true);
                //cssResolver.AddCss("table{width:900px;}", true);
                //cssResolver.AddCss("table{border: 2px solid black;}", true);
                //cssResolver.AddCss("#head{border-bottom: 3px solid black;}", true);
                //cssResolver.AddCss("#head{width:720px;}", true);
                //cssResolver.AddCss("#head{text-align:center;}", true);

                //cssResolver.AddCss("#container{border: 2px solid blue;}", true);

                IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(doc, writer)));

                XMLWorker worker = new XMLWorker(pipeline, true);
                XMLParser xmlParser = new XMLParser(worker);

                doc.Open();
                xmlParser.Parse(new StringReader(html));
                doc.Close();

                //string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                //BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                //Font font = new Font(baseFont, 10, Font.NORMAL);
                //var css = new StyleSheet();
                //css.LoadStyle("tr","border","5px");
                //var doc = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
                //PdfWriter.GetInstance(doc,stream);
                //doc.Open();
                //var htmlWorker = new HtmlWorker(doc);
                //htmlWorker.Style = css;
                //var sr = new StringReader(html);
                //htmlWorker.Parse(sr);
                //doc.Close();
                return returnPath;
            }
            catch (Exception)
            {
                throw new Exception("Hata!");
            }
        }

        public string GeneratePDF<T>(List<T> list) where T : class, new()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(ObjectReader.Create(list));
                var fileName = Guid.NewGuid() + ".pdf";
                var returnPath = "/doc/" + fileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/doc/" + fileName);
                var stream = new FileStream(path, FileMode.Create);



                string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, 10, Font.NORMAL);


                Document doc = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
                PdfWriter.GetInstance(doc, stream);

                doc.Open();
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dt.Columns[i].ColumnName, font));
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        table.AddCell(new Phrase(dt.Rows[i][j].ToString(), font));
                    }
                }
                doc.Add(table);
                doc.Close();



                return returnPath;
            }
            catch (Exception)
            {
                throw new Exception("Hata!");
            }
        }

        public string GeneratePDF(FinalQualityListViewModel model)
        {
            try
            {
                var fileName = Guid.NewGuid() + ".pdf";
                var returnPath = "/doc/" + fileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/doc/" + fileName);
                var stream = new FileStream(path, FileMode.Create);

                string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, 10, Font.NORMAL);

                Document doc = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
                PdfWriter.GetInstance(doc, stream);

                doc.Open();
                PdfPTable table = new PdfPTable(2);
                //for (int i = 0; i < 15; i++)
                //{
                //    table.AddCell(new Phrase(dt.Columns[i].ColumnName, font));
                //}
                //for (int i = 0; i < 15; i++)
                //{
                //    for (int j = 0; j < 10; j++)
                //    {
                //        table.AddCell(new Phrase(model.Customer, font));
                //    }
                //}
                PdfPCell cell1 = new PdfPCell(new Phrase("FİNAL KALİTE KONTROL FORMU", font));
                cell1.Colspan = 10;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("Müşteri Adı:", font));
                table.AddCell(cell2);
                cell2.Colspan = 2;
                PdfPCell cell3 = new PdfPCell(new Phrase(model.Customer, font));
                table.AddCell(cell3);
                cell3.Colspan = 3;
                PdfPCell cell4 = new PdfPCell(new Phrase("İş Emri Numarası:", font));
                table.AddCell(cell4);
                cell4.Colspan = 2;
                PdfPCell cell5 = new PdfPCell(new Phrase(model.WorkOrderNo.ToString(), font));
                table.AddCell(cell5);
                cell3.Colspan = 3;
                //table.AddCell(new Phrase("Müşteri Adı:", font));
                //table.AddCell(new Phrase(model.Customer, font));
                doc.Add(table);
                doc.Close();

                return returnPath;
            }
            catch (Exception)
            {
                throw new Exception("Hata!");
            }
        }
    }
}
