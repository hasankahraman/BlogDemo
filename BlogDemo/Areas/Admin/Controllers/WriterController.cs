using BlogDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Linq;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);

        }

        [HttpPost]
        public IActionResult Add(WriterClass writer)
        {
            writers.Add(writer);
            var  jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }

        public IActionResult Delete(int id)
        {
            var wrToDelete = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(wrToDelete);
            return Json(wrToDelete);
        }
        public IActionResult Update(WriterClass writer)
        {
            var wrToUpdate = writers.FirstOrDefault(x => x.Id == writer.Id);
            wrToUpdate.Name = writer.Name;
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Hasan"
            },
            new WriterClass
            {
                Id=2,
                Name="Arzu"
            },
            new WriterClass
            {
                Id=3,
                Name="Toffee"
            }
        };
    }
}
