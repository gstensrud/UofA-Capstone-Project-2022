using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class HistoryController : Controller
    {
        private readonly DatabaseContext _context;

        public HistoryController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: History
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Histories.Include(h => h.Device).Include(h => h.DeviceType).Include(h => h.PartsChangedNavigation).Include(h => h.PastOwnerSNavigation);
            return View(await databaseContext.ToListAsync());
        }


        // GET: History/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Histories == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.Device)
                .Include(h => h.DeviceType)
                .Include(h => h.PartsChangedNavigation)
                .Include(h => h.PastOwnerSNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: History/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id");
            ViewData["PartsChanged"] = new SelectList(_context.Modifications, "Id", "Id");
            ViewData["PastOwnerS"] = new SelectList(_context.OwnerLocations, "Id", "Id");
            return View();
        }

        // POST: History/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string DateOfChanges, string OutOfServiceDate, [Bind("Id,DeviceTypeId,DeviceId,PartsChanged,PastOwnerS,Wiped,PartsRemoved,DateOfChanges,OutOfServiceDate,Notes")] History history)
        {
            if (ModelState.IsValid)
            {
                history.DateOfChanges = DateOnly.Parse(DateOfChanges);
                history.OutOfServiceDate = DateOnly.Parse(OutOfServiceDate);
                _context.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", history.DeviceId);
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id", history.DeviceTypeId);
            ViewData["PartsChanged"] = new SelectList(_context.Modifications, "Id", "Id", history.PartsChanged);
            ViewData["PastOwnerS"] = new SelectList(_context.OwnerLocations, "Id", "Id", history.PastOwnerS);
            return View(history);
        }

        // GET: History/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Histories == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", history.DeviceId);
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id", history.DeviceTypeId);
            ViewData["PartsChanged"] = new SelectList(_context.Modifications, "Id", "Id", history.PartsChanged);
            ViewData["PastOwnerS"] = new SelectList(_context.OwnerLocations, "Id", "Id", history.PastOwnerS);
            return View(history);
        }

        // POST: History/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string DateOfChanges, string OutOfServiceDate,[Bind("Id,DeviceTypeId,DeviceId,PartsChanged,PastOwnerS,Wiped,PartsRemoved,Notes")] History history)
        {
            if (id != history.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    history.DateOfChanges = DateOnly.Parse(DateOfChanges);
                    history.OutOfServiceDate = DateOnly.Parse(OutOfServiceDate);
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", history.DeviceId);
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id", history.DeviceTypeId);
            ViewData["PartsChanged"] = new SelectList(_context.Modifications, "Id", "Id", history.PartsChanged);
            ViewData["PastOwnerS"] = new SelectList(_context.OwnerLocations, "Id", "Id", history.PastOwnerS);
            return View(history);
        }

        // GET: History/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Histories == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.Device)
                .Include(h => h.DeviceType)
                .Include(h => h.PartsChangedNavigation)
                .Include(h => h.PastOwnerSNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Histories == null)
            {
                return Problem("Entity set 'DatabaseContext.Histories'  is null.");
            }
            var history = await _context.Histories.FindAsync(id);
            if (history != null)
            {
                _context.Histories.Remove(history);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(int id)
        {
            return _context.Histories.Any(e => e.Id == id);
        }
    }
}
