using CeeLearnAndDo.Controllers.inheretance;
using CeeLearnAndDo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers
{
    public class HomeController : DefaultController
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(DatabaseContex databaseContex) : base(databaseContex) { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Articles()
        {
            ViewData["Articles"] = db.Articles.ToList();
            return View();
        }

        public IActionResult Article(int Id)
        {
            ViewData["Article"] = db.Articles.Find(Id);
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string FirstName, string LastName, string Email, string Question)
        {
            db.Questions.Add(new Question {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Content = Question,
            });
            db.SaveChanges();

            ViewData["Message"] = "We have received your Question and we will contact you with a respone as soon as possible.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
