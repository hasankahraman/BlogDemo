using BlogDemo.Areas.Admin.Models;
using BussinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogManager manager = new BlogManager(new EFBlogDAL());
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BlogList");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Name";

                int BlogNumber = 2;

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogNumber, 1).Value=item.Id;
                    worksheet.Cell(BlogNumber, 2).Value = item.Title;
                    BlogNumber++;
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "exportedFile.xlsx");
                }
            }
        }
        List<Blog> GetBlogList()
        {
            return manager.GetAll();
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BlogList");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Name";

                int BlogNumber = 2;

                foreach (var item in GetDynamic())
                {
                    worksheet.Cell(BlogNumber, 1).Value = item.Id;
                    worksheet.Cell(BlogNumber, 2).Value = item.Name;
                    BlogNumber++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "exportedFile.xlsx");
                }
            }
        }

        List<BlogModel> GetDynamic()
        {
            List<BlogModel> bm = new List<BlogModel>();

            bm = manager.GetAll().Select(x => new BlogModel
            {
                Id = x.Id,
                Name = x.Title
            }).ToList();
            return bm;
        }

        public IActionResult BlogListExcelDynamic()
        {
            return View();
        }

        public IActionResult Index()
        {
            var blogs = manager.GetWithCategory();
            return View(blogs);
        }

    }

}
