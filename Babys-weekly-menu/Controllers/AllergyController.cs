using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    public class AllergyController : Controller
    {
        private readonly WeeklyMenuDbContext _dBcontext;

        public AllergyController(WeeklyMenuDbContext dbContext)
        {
            _dBcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allergies = _dBcontext.Allergies.ToList();

            return View(allergies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Allergy allergy)
        {
            _dBcontext.Allergies.Add(allergy);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var allergy = _dBcontext.Allergies.Find(id);

            return View(allergy);
        }

        [HttpPost]
        public IActionResult Edit(Allergy allergy)
        {
            _dBcontext.Allergies.Update(allergy);

            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var allergy = _dBcontext.Allergies.Find(id);

            return View(allergy);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var allergy = _dBcontext.Allergies.Find(id);

            return View(allergy);
        }

        [HttpPost]
        public IActionResult Delete(Allergy allergy)
        {
            _dBcontext.Remove(allergy);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
