using BookATable.Data.Repositories;
using BookATable.Entity;
using BookATable.Filters;
using BookATable.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATable.Controllers
{
    [AuthenticationFilter(RequireAdminRole = false)]
    public class ReservationController : Controller
    {
        public ActionResult Index()
        {
            ReservationRepository repository = new ReservationRepository();
            List<Reservation> reservations = repository.GetAll();

            ReservationsListViewModel model = new ReservationsListViewModel();
            model.Reservations = reservations;

            return View(model);
        }

        public ActionResult Create()
        {
            ReservationsCreateViewModel model = new ReservationsCreateViewModel();
            model.Restaurants = PopulateRestaurantsList();
            model.Users = PopulateUsersList();
            model.PeopleCount = model.PeopleCount;
            model.ReservationTime = model.ReservationTime.Date;
            model.Comment = model.Comment;


            return View(model);
        }

        private List<SelectListItem> PopulateUsersList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            UserRepository userRepo = new UserRepository();
            List<User> users = userRepo.GetAll();
            foreach (User user in users)
            {
                SelectListItem item = new SelectListItem();
                item.Value = user.ID.ToString();
                item.Text = $"{user.FirstName} {user.LastName}";

                result.Add(item);
            }

            return result;
        }

        private List<SelectListItem> PopulateRestaurantsList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            RestaurantRepository restaurantRepo = new RestaurantRepository();
            List<Restaurant> restaurants = restaurantRepo.GetAll();
            foreach (Restaurant restaurant in restaurants)
            {
                SelectListItem item = new SelectListItem();
                item.Value = restaurant.ID.ToString();
                item.Text = $"{restaurant.Name}";

                result.Add(item);
            }

            return result;
        }

        [HttpPost]
        public ActionResult Create(ReservationsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Reservation reservation = new Reservation();
            reservation.ID = model.ID;
            if (AdminFilter.IsAdmin())
            {
                reservation.UserId = model.UserId;
            }
            else
            {
                reservation.UserId = AdminFilter.GetUserId();
            }
            reservation.RestaurantId = model.RestaurantId;
            reservation.PeopleCount = model.PeopleCount;
            reservation.ReservationTime = model.ReservationTime.Date;
            reservation.Comment = model.Comment;
            
            var repository = new ReservationRepository();
            repository.Insert(reservation);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            ReservationRepository repository = new ReservationRepository();

            ReservationsEditViewModel model = new ReservationsEditViewModel();

            if (id.HasValue)
            {
                Reservation reservation = repository.GetByID(id.Value);
                model.ID = reservation.ID;
                model.Users = PopulateUsersList();
                model.Restaurants = PopulateRestaurantsList();
                model.PeopleCount = model.PeopleCount;
                model.ReservationTime = model.ReservationTime.Date;
                model.Comment = model.Comment;

            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(ReservationsEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ReservationRepository repository = new ReservationRepository();

            Reservation reservation = new Reservation();
            reservation.ID = model.ID;
            reservation.UserId = model.UserId;
            reservation.RestaurantId = model.RestaurantId;
            reservation.PeopleCount = model.PeopleCount;
            reservation.ReservationTime = model.ReservationTime;
            reservation.Comment = model.Comment;


            repository.Save(reservation);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {

            ReservationRepository repository = new ReservationRepository();

            Reservation reservation = repository.GetByID(id);

            ReservationsDeleteViewModel model = new ReservationsDeleteViewModel();
            model.ID = reservation.ID;
            model.UserId = reservation.UserId;
            model.RestaurantId = reservation.RestaurantId;
            model.ReservationTime = reservation.ReservationTime;
            model.PeopleCount = reservation.PeopleCount;
            model.Comment = reservation.Comment;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(ReservationsDeleteViewModel model)
        {

            ReservationRepository repository = new ReservationRepository();

            repository.Delete(model.ID);

            return RedirectToAction("Index");
        }

    }
}