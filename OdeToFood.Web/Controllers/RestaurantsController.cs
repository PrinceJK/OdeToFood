using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData _db;

        public RestaurantsController(IRestaurantData db)
        {
            _db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult Details(Guid? id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            if (ModelState.IsValid)
            {
                _db.Add(restaurant);
                return RedirectToAction("Details", new {id = restaurant.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant";
                return RedirectToAction("Details", new {id =restaurant.Id});
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, FormCollection form)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}