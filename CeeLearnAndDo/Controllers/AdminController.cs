using CeeLearnAndDo.Controllers.inheretance;
using CeeLearnAndDo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers
{
    public class AdminController : AuthController
    {
        public AdminController(DatabaseContex databaseContex) : base(databaseContex) { }

        public IActionResult Acounts()
        {
            if (user == null || user.Role != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Users"] = db.Users.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Acounts(string search)
        {
            List<User> users = db.Users.Where(u => u.Email.Contains(search)).ToList();
            if (users.Count == 0 && search != null)
            {
                users = db.Users.ToList();
                ViewData["Message"] = "Geen email gevonden die " +search +" bevat";
            }

            if (search == null)
            {
                users = db.Users.ToList();
            }

            ViewData["Users"] = users;
            return View();
        }

        public IActionResult ChangeActivation(int id)
        {
            User user = db.Users.Find(id);
            if (user.IsActive)
            {
                user.IsActive = false;
            } else
            {
                user.IsActive = true;
            }
            db.SaveChanges();

            return RedirectToAction("Acounts");
        }

        public IActionResult ChangeRoleUp(int Id)
        {
            User user = db.Users.Find(Id);

            if (user.Role != 2)
            {
                user.Role++;
            }

            db.SaveChanges();
            return RedirectToAction("Acounts");
        }

        public IActionResult ChangeRoleDown(int Id)
        {
            User user = db.Users.Find(Id);

            if (user.Role != 0)
            {
                user.Role--;
            }

            db.SaveChanges();
            return RedirectToAction("Acounts");
        }
    }
}
