using BookATable.Data.Repositories;
using BookATable.Entity;
using BookATable.Filters;
using BookATable.Helpers;
using BookATable.Service;
using BookATable.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookATable.Controllers
{


    public class UsersController : Controller
    {
        private SendConfirmEmail sendConfirmEmail = new SendConfirmEmail();

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Index()
        {
            UserRepository repository = new UserRepository();
            List<User> users = repository.GetAll();

            UsersListViewModel model = new UsersListViewModel();
            model.Users = users;

            return View(model);
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Profile()
        {

            int id = AdminFilter.GetUserId();
            UserRepository repository = new UserRepository();
            UsersEditViewModel model = new UsersEditViewModel();
            User user = repository.GetByID(id);

            model.ID = AdminFilter.GetUserId();
            model.ImgURL = user.ImgURL;
            model.Email = user.Email;
            model.Username = user.Username;
            model.Password = user.Password;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.IsAdmin = user.IsAdmin;
            //model.IsEmailConfirmed = user.IsEmailConfirmed;
            // model.ValidationCode = user.ValidationCode;

            return View(model);
        }

        [HttpPost]
        public ActionResult Profile(UsersEditViewModel model)
        {
            UserRepository repository = new UserRepository();

            //User testUser = repository.GetById(model.Id);

            User user = repository.GetByID(model.ID);

            user.ID = model.ID;
            user.ImgURL = model.ImgURL;
            user.Email = model.Email;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsAdmin = model.IsAdmin;


            repository.Save(user);

            return RedirectToAction("IndexPage", "Home");
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UsersCreateViewModel model)
        {
            string validationCode = HashUtils.CreateReferralCode();
            var repository = new UserRepository();
            List<User> users = repository.GetAll();

            SendConfirmEmail emailSender = new SendConfirmEmail();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (users.Where(u => u.Email == model.Email).Any())
            {
                ModelState.AddModelError("error_email", "This email is already taken!");
                return View();
                //return View("Error");
            }
            else if (users.Where(u => u.Username == model.Username).Any())
            {

                ModelState.AddModelError("error_msg", "This username is already taken!");
                return View();
                // return View("Error");
            }
            else
            {
                User user = new User();
                user.ImgURL = model.ImgURL;
                user.Email = model.Email;
                user.Username = model.Username;
                user.Password = model.Password;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.IsAdmin = model.IsAdmin;
                user.IsEmailConfirmed = false;
                user.ValidationCode = validationCode;

                repository.Insert(user);

                sendConfirmEmail.SendConfirmationEmailAsync(user);

            }
            return RedirectToAction("IndexPage", "Home");
        }

        [HttpPost]
        public ActionResult Create(UsersCreateViewModel model)
        {
            string validationCode = HashUtils.CreateReferralCode();
            var repository = new UserRepository();
            SendConfirmEmail emailSender = new SendConfirmEmail();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User();
            user.ImgURL = model.ImgURL;
            user.Email = model.Email;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsAdmin = model.IsAdmin;
            user.IsEmailConfirmed = false;
            user.ValidationCode = validationCode;

            repository.Insert(user);

            sendConfirmEmail.SendConfirmationEmailAsync(user);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter(RequireAdminRole = true)]

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            UserRepository repository = new UserRepository();

            UsersEditViewModel model = new UsersEditViewModel();

            if (id.HasValue)
            {
                User user = repository.GetByID(id.Value);
                model.ID = user.ID;
                model.ImgURL = user.ImgURL;
                model.Email = user.Email;
                model.Username = user.Username;
                model.Password = user.Password;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.IsAdmin = user.IsAdmin;
                //model.IsEmailConfirmed = user.IsEmailConfirmed;
                //model.ValidationCode = user.ValidationCode;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserRepository repository = new UserRepository();

            User user = repository.GetByID(model.ID);
            user.ID = model.ID;
            user.ImgURL = model.ImgURL;
            user.Email = model.Email;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsAdmin = model.IsAdmin;
            //user.IsEmailConfirmed = model.IsEmailConfirmed;
            //user.ValidationCode = model.ValidationCode;

            repository.Save(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            UserRepository repository = new UserRepository();

            User user = repository.GetByID(id);

            UsersDeleteViewModel model = new UsersDeleteViewModel();
            model.ImgURL = user.ImgURL;
            model.Username = user.Username;
            model.Password = user.Password;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            //model.isAdmin = user.IsAdmin;
            //model.IsEmailConfirmed = user.IsEmailConfirmed;


            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(UsersDeleteViewModel model)
        {

            UserRepository repository = new UserRepository();
            if (model.ID.ToString() != String.Empty)
            {
                repository.Delete(model.ID);
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ValidateEmail(string userId, string validationCode)
        {
            if (userId == null || validationCode == null)
            {
                return RedirectToAction("IndexPage", "Home");
            }

            UserRepository repository = new UserRepository();

            User user = repository.GetByID(Int32.Parse(userId));
            if (user == null || validationCode != user.ValidationCode)
            {
                return RedirectToAction("IndexPage", "Home");
            }

            user.ID = Int32.Parse(userId);
            user.ValidationCode = validationCode;
            user.IsEmailConfirmed = true;

            repository.Update(user);

            return View("ConfirmEmail");
        }
        public ActionResult ConfirmEmail()
        {
            return View();
        }
    }
}