using CeeLearnAndDo.Controllers.inheretance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers
{
    public class KnowledgebaseController : AuthController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
