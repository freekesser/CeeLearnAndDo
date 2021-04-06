using CeeLearnAndDo.Controllers.inheretance;
using CeeLearnAndDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers
{
    public class KnowledgebaseController : AuthController
    {
        public KnowledgebaseController(DatabaseContex databaseContex) : base(databaseContex) { }

        public IActionResult Index()
        {
            if (user.Role == 0)
            {
                ViewData["Knowledgebases"] = db.Knowledgebases.Where(k => k.PublishedAt != null).ToList();
            }
            else
            {
                ViewData["Knowledgebases"] = db.Knowledgebases.ToList();
            }
            return View();
        }

        public IActionResult Show(int id)
        {
            Knowledgebase knowledgebase = db.Knowledgebases.Where(k => k.Id == id).FirstOrDefault();

            ViewData["Replys"] = db.KnowledgebaseReplies.Where(k => k.Knowledgebase.Id == id).ToList();
            ViewData["Knowledgebase"] = knowledgebase;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Content)
        {
            db.Knowledgebases.Add(new Knowledgebase {
                Title = Title,
                Content = Content,
                User = user,
            });
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Publish(int Id)
        {
            Knowledgebase knowledgebase = db.Knowledgebases.Where(k => k.Id.Equals(Id)).FirstOrDefault();
            knowledgebase.PublishedAt = DateTime.UtcNow;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Knowledgebase knowledgebase = db.Knowledgebases.Where(k => k.Id.Equals(Id)).FirstOrDefault();
            db.Knowledgebases.Remove(knowledgebase);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reply(int Id, string Content)
        {
            Knowledgebase knowledgebase = db.Knowledgebases.Find(Id);
            db.KnowledgebaseReplies.Add(new KnowledgebaseReply
            {
                User = user,
                Content = Content,
                Knowledgebase = knowledgebase,
                CreatedAt = DateTime.UtcNow,
            });

            db.SaveChanges();

            return RedirectToAction("Show", new { id = Id });
        }
    }
}
