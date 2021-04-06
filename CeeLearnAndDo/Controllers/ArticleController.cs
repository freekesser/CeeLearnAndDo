using CeeLearnAndDo.Controllers.inheretance;
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

        public IActionResult Show()
        {
            return View();
        }

        public IActionResult Reply()
        {
            return View();
        }
    }
}
