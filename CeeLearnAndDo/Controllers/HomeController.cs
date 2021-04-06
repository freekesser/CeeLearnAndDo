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
            Article article = db.Articles.Find(Id);
            ViewData["ArticleReplies"] = db.ArticleReplies.Where(a => a.Article.Equals(article)).ToList();
            ViewData["Article"] = article;

            return View();
        }

        [HttpPost]
        public IActionResult Reply(int Id, string Content)
        {
            Article article = db.Articles.Find(Id);
            db.ArticleReplies.Add(new ArticleReply {
                User = user,
                Article = article,
                Content = Content,
                CreatedAt = DateTime.UtcNow,
            });
            db.SaveChanges();

            return RedirectToAction("Article", new { Id = Id });
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
