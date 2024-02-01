using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    public class DishController : Controller
    {
        private readonly WeeklyMenuDbContext _dBcontext;

        public DishController(WeeklyMenuDbContext dbContext)
        {
            _dBcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dishes = _dBcontext.Dishes.ToList();

            return View(dishes);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var dish = _dBcontext.Dishes.Find(id);

            return View(dish);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dish dish)
        {
            _dBcontext.Dishes.Add(dish);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dish = _dBcontext.Dishes.Find(id);

            return View(dish);
        }

        [HttpPost]
        public IActionResult Edit(Dish dish)
        {
            _dBcontext.Dishes.Update(dish);

            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dish = _dBcontext.Dishes.Find(id);

            return View(dish);
        }

        [HttpPost]
        public IActionResult Delete(Dish dish)
        {
            _dBcontext.Remove(dish);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
