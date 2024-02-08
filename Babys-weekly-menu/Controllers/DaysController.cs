using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BabysWeeklyMenu.Data;
using BabysWeeklyMenu.Models;

namespace BabysWeeklyMenu.Controllers
{
    public class DaysController : Controller
    {
        private readonly WeeklyMenuDbContext _context;

        public DaysController(WeeklyMenuDbContext context)
        {
            _context = context;
        }

        // GET: Days
        public async Task<IActionResult> Index()
        {
            return View(await _context.Days.ToListAsync());
        }

        // GET: Days/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days
                .FirstOrDefaultAsync(m => m.Id == id);
            if (day == null)
            {
                return NotFound();
            }

            return View(day);
        }

        // GET: Days/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Days/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Day day)
        {
            if (ModelState.IsValid)
            {
                _context.Add(day);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(day);
        }

        // GET: Days/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }
            return View(day);
        }

        // POST: Days/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Day day)
        {
            if (id != day.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(day);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayExists(day.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(day);
        }

        // GET: Days/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var day = await _context.Days
                .FirstOrDefaultAsync(m => m.Id == id);
            if (day == null)
            {
                return NotFound();
            }

            return View(day);
        }

        // POST: Days/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var day = await _context.Days.FindAsync(id);
            if (day != null)
            {
                _context.Days.Remove(day);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayExists(int id)
        {
            return _context.Days.Any(e => e.Id == id);
        }
    }
}
