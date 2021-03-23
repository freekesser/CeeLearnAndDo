﻿using CeeLearnAndDo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers.inheretance
{
    public class DefaultController : Controller
    {
        public DatabaseContex db = new DatabaseContex();
        public User user = null;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                int id = (int)HttpContext.Session.GetInt32("User");
                user = db.Users.Where(u => u.Id.Equals(id)).FirstOrDefault();
            }

            ViewData["User"] = user;
        }
        // filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary { { "controller", "Acount" }, { "action", "Login" } });
    }
}
