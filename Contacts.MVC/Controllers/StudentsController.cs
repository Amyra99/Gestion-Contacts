using Contacts.MVC.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Contacts.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult Index( List<Student> students=null)
        {
            students=students==null?new List<Student>() : students;


            return View(students);
        }
        [HttpPost]  
        public async Task<List<string>> Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment ,
            Statistic stat)

           
          
        {
              string fileName = $"{hostingEnvironment.WebRootPath}//files//{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName+"2022"))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();
            lines = System.IO.File.ReadAllLines(fileName).ToList();
            
            foreach (string i in lines)
            {
               // string line = lines.ElementAt(i);
                Console.WriteLine(i+"for console");
                stat.Data = i;
                _context.Statistic.Add(stat);


                await _context.SaveChangesAsync();

 

            }
           // await _context.SaveChangesAsync();




            return (lines);
        }
        private List<Student> GetStudentsList(string fname)
        {
            List<Student> students = new List<Student>();   
            var fileName=$"{Directory.GetCurrentDirectory()} {@"/wwwroot/files"}" + fname;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
           
            return students;

        }
    }



 





}
