using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngredientApiController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/ingredients")]
        public async Task<ActionResult> GetAllIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            if (ingredients == null)
            {
                return NotFound();
            }

            return new JsonResult(ingredients);
        }

        [HttpGet]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult> GetIngredient(int id)
        {
            var selectedIngredient = await _context.Ingredients.FindAsync(id);
            if (selectedIngredient == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedIngredient);
        }

        [HttpPost]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return new JsonResult(ingredient);
        }

        [HttpPut]
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult> PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ingredients.Any(i => i.Id == id))
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
        [Route("/api/ingredient/{id}")]
        public async Task<ActionResult<Ingredient>> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient == null) { return NotFound(); }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return new JsonResult(ingredient);
        }
    }
}
