using BlogDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChartIAR()
        {
            List<CategoryChart> list = new List<CategoryChart>();
            list.Add(new CategoryChart
            {
                Count = 10,
                Name = "Technology"
            });
            list.Add(new CategoryChart
            {
                Count = 5,
                Name = "Edebiyat"
            });
            list.Add(new CategoryChart
            {
                Count = 13,
                Name = "Sinema"
            });
            list.Add(new CategoryChart
            {
                Count = 4,
                Name = "Haber"
            });

            return Json(new {jsonlist = list});
        }
    }
}
