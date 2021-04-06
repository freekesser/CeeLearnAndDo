using CeeLearnAndDo.Controllers.inheretance;
using CeeLearnAndDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers
{
    public class ArticleController : AuthController
    {
        public ArticleController(DatabaseContex databaseContex) : base(databaseContex) { }
    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Description, string Content)
        {
            db.Articles.Add(new Article {
                Title = Title,
                Description = Description,
                Content = Content,
                User = user,
                CreatedAt = DateTime.UtcNow,
            });
            db.SaveChanges();

            return RedirectToAction("Articles", "Home");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Article article = db.Articles.Find(Id);
            List<ArticleReply> articleReplies = db.ArticleReplies.Where(a => a.Article.Equals(article)).ToList();

            db.RemoveRange(articleReplies);
            db.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Articles", "Home");
        }

        public IActionResult Reply()
        {
            return View();
        }
    }
}
