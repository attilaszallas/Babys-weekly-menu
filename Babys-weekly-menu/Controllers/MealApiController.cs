using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealApiController : ControllerBase
    {
        private readonly WeeklyMenuDbContext _context;

        public MealApiController(WeeklyMenuDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/meals")]
        public async Task<ActionResult> GetAllMeals()
        {
            var meals = await _context.Meals.ToListAsync();
            if (meals == null)
            {
                return NotFound();
            }

            return new JsonResult(meals);
        }

        [HttpGet]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult> GetMeal(int id)
        {
            var selectedMeals = await _context.Meals.FindAsync(id);
            if (selectedMeals == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedMeals);
        }

        [HttpPost]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return new JsonResult(meal);
        }

        [HttpPut]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult> PutMeal(int id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Meals.Any(m => m.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("/api/meal/{id}")]
        public async Task<ActionResult<Meal>> DeleteMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);

            if (meal == null) { return NotFound(); }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return new JsonResult(meal);
        }
    }
}
