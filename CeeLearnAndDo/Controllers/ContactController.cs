using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using CeeLearnAndDo.Models;
using CeeLearnAndDo.Controllers.inheretance;

namespace CeeLearnAndDo.Controllers
{
    public class ContactController : AuthController
    {
        public ContactController(DatabaseContex databaseContex) : base(databaseContex) { }

        public IActionResult Index()
        {
            if (user == null || user.Role == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Questions"] = db.Questions.ToList();
            return View();
        }

        public IActionResult Show(int Id)
        {
            if (user == null || user.Role == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Question"] = db.Questions.Find(Id);
            return View();
        }

        [HttpPost]
        public IActionResult SendAnswer(string Content, int Question)
        {
            if (user == null || user.Role == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            Question question = db.Questions.Find(Question);

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin",
            "info@ceelearnanddo.com");
            message.From.Add(from);

           
            MailboxAddress to = new MailboxAddress("User",
            question.Email);
            message.To.Add(to);

            message.Subject = "Answer to you question to CeeLearnAndDo";
            
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = Content;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp-relay.sendinblue.com", 587);
            client.Authenticate("freek.v.esser@gmail.com", "jO2ChIS5cXQGMTH8");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            db.Questions.Remove(question);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
