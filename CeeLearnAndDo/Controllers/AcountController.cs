using CeeLearnAndDo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeeLearnAndDo.Controllers
{
    public class AcountController : Controller
    {
        DatabaseContex db;

        public AcountController(DatabaseContex databaseContex)
        {
            this.db = databaseContex;
        }

        public IActionResult Login()
        {
            // if user isn't logged in redirect to Home
            if (HttpContext.Session.GetInt32("User") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            // Try finding user in db
            Password = EasyEncryption.MD5.ComputeMD5Hash(Password);
            User User = db.Users.Where(
                u => u.Email.Equals(Email) &&
                u.Password.Equals(Password)
            ).FirstOrDefault();

            // If the user is not found return with a messages
            if (User == null)
            {
                ViewData["Message"] = "The email address or password is incorrect. Please try again.";
                return View();
            }

            // Put id in the session and rederct to Home
            HttpContext.Session.SetInt32("User", User.Id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            // if user isn't logged in redirect to Home
            if (HttpContext.Session.GetInt32("User") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(string Email, string Password, string ConfirmPassword, string FirstName, string LastName)
        {
            // data validations
            if (Password != ConfirmPassword)
            {
                ViewData["Message"] = "Password and Confirm password are not the same.";
                return View();
            }

            if (db.Users.Where(u => u.Email.Equals(Email)).FirstOrDefault() != null)
            {
                ViewData["Message"] = "Email is already in use.";
                return View();
            }

            // Make new user
            db.Users.Add(new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = EasyEncryption.MD5.ComputeMD5Hash(Password)
            });
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");

            return RedirectToAction("Index", "Home");
        }
    }
}
