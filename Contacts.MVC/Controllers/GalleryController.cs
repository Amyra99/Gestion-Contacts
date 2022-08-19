using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.MVC.Controllers
{
    public class Gallerycontroller : Controller
    {
        private readonly string wwwrootdirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public IActionResult Index()
        {
            List<string> images = Directory.GetFiles(wwwrootdirectory, "*.*")
                                           .Select(Path.GetFileName)
                                           .ToList();
 
            return View(images);
        }
        [HttpPost]
        public async Task <IActionResult> Index(IFormFile myFile)
        {

            if (myFile != null)
            {
                var path=Path.Combine(wwwrootdirectory,DateTime.Now.Ticks.ToString()+Path.GetExtension(myFile.FileName));
           

            using (var stream=new FileStream(path, FileMode.Create))
            {
                await myFile.CopyToAsync(stream);
                  
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DownloadFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
            var memory=new MemoryStream();
            using(var stream=new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
               ;
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }

    }
}
