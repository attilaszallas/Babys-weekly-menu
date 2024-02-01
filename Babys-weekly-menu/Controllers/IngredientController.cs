using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    public class IngredientController : Controller
    {
        private readonly WeeklyMenuDbContext _dBcontext;

        public IngredientController(WeeklyMenuDbContext dbContext)
        {
            _dBcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ingredients = _dBcontext.Ingredients.ToList();

            return View(ingredients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ingredient ingredient)
        {
            _dBcontext.Ingredients.Add(ingredient);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ingredient = _dBcontext.Ingredients.Find(id);

            return View(ingredient);
        }

        [HttpPost]
        public IActionResult Edit(Ingredient ingredient)
        {
            _dBcontext.Ingredients.Update(ingredient);

            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ingredient = _dBcontext.Ingredients.Find(id);

            return View(ingredient);
        }

        [HttpPost]
        public IActionResult Delete(Ingredient ingredient)
        {
            _dBcontext.Remove(ingredient);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
