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
            ViewData["Knowledgebases"] = db.Knowledgebases.ToList();
            return View();
        }

        public IActionResult Show(int id)
        {
            ViewData["Knowledgebase"] = db.Knowledgebases.Where(k => k.Id == id).FirstOrDefault();
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
    }
}
