using BookATable.Data.Repositories;
using BookATable.Entity;
using BookATable.ViewModels.Login;
using LibrarySystem.NotificationServices;
using LibrarySystem.Web.ViewModels.EmailSendingViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("IndexPage", "Home");
        }

        [HttpGet]
        public ActionResult IndexPage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            List<User> items = repo.GetAll(i => i.Email == model.Email && i.Password == model.Password);
            Session["LoggedUser"] = items.Count > 0 ? items[0] : null;

            if (items.Count <= 0)
                this.ModelState.AddModelError("failedLogin", "Login failed!");

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("IndexPage", "Home");
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["LoggedUser"] = null;
            return RedirectToAction("IndexPage", "Home");
        }

        [HttpPost]
        public ActionResult IndexPage(EmailSendingViewModel emailSendingViewModel)
        {
            EmailSender emailSender = new EmailSender();

            if (emailSendingViewModel.Comment == null || emailSendingViewModel.Name == null || emailSendingViewModel.Email == null)
            {
                ModelState.AddModelError("error_contact", "  You have to enter all the needed information for sending an email!");
                return View();
            }
            else
            {
                emailSender.SendEmail(emailSendingViewModel.Email, emailSendingViewModel.Name, emailSendingViewModel.Comment);
                TempData["Email"] = "You have send the email successfully!";
                return View("Contacts");
            }

        }
    }
}