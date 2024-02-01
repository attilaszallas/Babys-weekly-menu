using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    public class MealController : Controller
    {
        private readonly WeeklyMenuDbContext _dBcontext;

        public MealController(WeeklyMenuDbContext dbContext)
        {
            _dBcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var meals = _dBcontext.Meals.ToList();

            return View(meals);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var meal = _dBcontext.Meals.Find(id);

            return View(meal);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Meal meal)
        {
            _dBcontext.Meals.Add(meal);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var meal = _dBcontext.Meals.Find(id);

            return View(meal);
        }

        [HttpPost]
        public IActionResult Edit(Meal meal)
        {
            _dBcontext.Meals.Update(meal);

            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var meal = _dBcontext.Meals.Find(id);

            return View(meal);
        }

        [HttpPost]
        public IActionResult Delete(Meal meal)
        {
            _dBcontext.Remove(meal);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
