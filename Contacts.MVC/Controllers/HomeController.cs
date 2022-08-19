using Contacts.MVC.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

namespace Contacts.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            return View();

        }
        public string Welcome()
        {

            string filePath = @"C:\demo\text.txt";

            System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();
            lines = System.IO.File.ReadAllLines(filePath).ToList();
            string line = lines.ElementAt(0);
            return line;
        
           // string[] lines = System.IO.File.ReadAllLines(filePath);



          //  return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {x}");

        }

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

    }
}