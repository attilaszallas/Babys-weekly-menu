using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    public class DayController : Controller
    {
        private readonly WeeklyMenuDbContext _dBcontext;

        public DayController(WeeklyMenuDbContext dbContext)
        {
            _dBcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var days = _dBcontext.Days.ToList();

            return View(days);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var day = _dBcontext.Days.Find(id);

            return View(day);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Day day)
        {
            _dBcontext.Days.Add(day);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var day = _dBcontext.Days.Find(id);

            return View(day);
        }

        [HttpPost]
        public IActionResult Edit(Day day)
        {
            _dBcontext.Days.Update(day);

            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var day = _dBcontext.Days.Find(id);

            return View(day);
        }

        [HttpPost]
        public IActionResult Delete(Day day)
        {
            _dBcontext.Remove(day);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
