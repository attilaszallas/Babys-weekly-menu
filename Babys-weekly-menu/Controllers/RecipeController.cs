using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysWeeklyMenu.Controllers
{
    public class RecipeController : Controller
    {
        private readonly WeeklyMenuDbContext _dBcontext;

        public RecipeController(WeeklyMenuDbContext dbContext)
        {
            _dBcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var recipes = _dBcontext.Recipes.ToList();

            return View(recipes);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var recipe = _dBcontext.Recipes.Find(id);

            return View(recipe);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            _dBcontext.Recipes.Add(recipe);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recipe = _dBcontext.Recipes.Find(id);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            _dBcontext.Recipes.Update(recipe);

            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recipe = _dBcontext.Recipes.Find(id);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Delete(Recipe recipe)
        {
            _dBcontext.Remove(recipe);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
