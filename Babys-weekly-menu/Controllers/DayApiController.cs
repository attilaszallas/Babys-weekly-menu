using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayApiController : ControllerBase
    {
        private readonly WeeklyMenuDbContext _context;

        public DayApiController(WeeklyMenuDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/days")]
        public async Task<ActionResult> GetAllDays()
        {
            var days = await _context.Days.ToListAsync();
            if (days == null)
            {
                return NotFound();
            }

            return new JsonResult(days);
        }

        [HttpGet]
        [Route("/api/day/{id}")]
        public async Task<ActionResult> GetDay(int id)
        {
            var selectedDay = await _context.Days.FindAsync(id);
            if (selectedDay == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedDay);
        }

        [HttpPost]
        [Route("/api/day/{id}")]
        public async Task<ActionResult<Day>> PostDay(Day day)
        {
            _context.Days.Add(day);
            await _context.SaveChangesAsync();

            return new JsonResult(day);
        }

        [HttpPut]
        [Route("/api/day/{id}")]
        public async Task<ActionResult> PutDay(int id, Day day)
        {
            if (id != day.Id)
            {
                return BadRequest();
            }

            _context.Entry(day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Days.Any(d => d.Id == id))
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
        [Route("/api/day/{id}")]
        public async Task<ActionResult<Day>> DeleteDay(int id)
        {
            var day = await _context.Days.FindAsync(id);

            if (day == null) { return NotFound(); }

            _context.Days.Remove(day);
            await _context.SaveChangesAsync();

            return new JsonResult(day);
        }
    }
}
