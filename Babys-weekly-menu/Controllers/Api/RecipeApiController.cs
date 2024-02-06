using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeApiController : ControllerBase
    {
        private readonly WeeklyMenuDbContext _context;

        public RecipeApiController(WeeklyMenuDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/recipes")]
        public async Task<ActionResult> GetAllRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();
            if (recipes == null)
            {
                return NotFound();
            }

            return new JsonResult(recipes);
        }

        [HttpGet]
        [Route("/api/recipe/{id}")]
        public async Task<ActionResult> GetRecipe(int id)
        {
            var selectedRecipe = await _context.Recipes.FindAsync(id);
            if (selectedRecipe == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedRecipe);
        }

        [HttpPost]
        [Route("/api/recipe/{id}")]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return new JsonResult(recipe);
        }

        [HttpPut]
        [Route("/api/recipe/{id}")]
        public async Task<ActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Recipes.Any(r => r.Id == id))
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
        [Route("/api/recipe/{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null) { return NotFound(); }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return new JsonResult(recipe);
        }
    }
}
