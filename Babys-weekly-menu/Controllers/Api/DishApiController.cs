using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DishApiController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/dishes")]
        public async Task<ActionResult> GetAllDishes()
        {
            var dishes = await _context.Dishes.ToListAsync();
            if (dishes == null)
            {
                return NotFound();
            }

            return new JsonResult(dishes);
        }

        [HttpGet]
        [Route("/api/dish/{id}")]
        public async Task<ActionResult> GetDish(int id)
        {
            var selectedDish = await _context.Dishes.FindAsync(id);
            if (selectedDish == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedDish);
        }

        [HttpPost]
        [Route("/api/dish/{id}")]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return new JsonResult(dish);
        }

        [HttpPut]
        [Route("/api/dish/{id}")]
        public async Task<ActionResult> PutDish(int id, Dish dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Dishes.Any(d => d.Id == id))
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
        [Route("/api/dish/{id}")]
        public async Task<ActionResult<Dish>> DeleteDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);

            if (dish == null) { return NotFound(); }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return new JsonResult(dish);
        }
    }
}
