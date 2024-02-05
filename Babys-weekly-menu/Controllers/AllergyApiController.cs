using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyApiController : ControllerBase
    {
        private readonly WeeklyMenuDbContext _context;

        public AllergyApiController(WeeklyMenuDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/allergies")]
        public async Task<ActionResult> GetAllAllergies()
        {
            var allergies = await _context.Allergies.ToListAsync();
            if (allergies == null)
            {
                return NotFound();
            }

            return new JsonResult(allergies);
        }

        [HttpGet]
        [Route("/api/allergy/{id}")]
        public async Task<ActionResult> GetAllergy(int id)
        {
            var selectedAllergy = await _context.Allergies.FindAsync(id);
            if (selectedAllergy == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedAllergy);
        }

        [HttpPost]
        [Route("/api/allergy/{id}")]
        public async Task<ActionResult<Allergy>> PostAllergy(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();

            return new JsonResult(allergy);
        }

        [HttpPut]
        [Route("/api/allergy/{id}")]
        public async Task<ActionResult> PutAllergy(int id, Allergy allergy)
        {
            if (id != allergy.Id)
            {
                return BadRequest();
            }

            _context.Entry(allergy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Allergies.Any(a => a.Id == id))
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
        [Route("/api/allergy/{id}")]
        public async Task<ActionResult<Allergy>> DeleteAllergy(int id)
        {
            var allergy = await _context.Allergies.FindAsync(id);

            if (allergy == null) { return NotFound(); }

            _context.Allergies.Remove(allergy);
            await _context.SaveChangesAsync();

            return new JsonResult(allergy);
        }
    }
}
