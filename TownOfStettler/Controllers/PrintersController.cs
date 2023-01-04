using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class PrintersController : Controller
    {
        private readonly DatabaseContext _context;

        public PrintersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Printers
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Printers.Include(p => p.Device).Include(p => p.HistoryNavigation).Include(p => p.OwnerLocationNavigation);
            return View(await databaseContext.ToListAsync());
        }

        //Search TosNumber
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Printers
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.TosNumber.Contains(SearchString));

        //    }
        //    return View(Info);
        //}


        // GET: Printers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Printers == null)
            {
                return NotFound();
            }

            var printer = await _context.Printers
                .Include(p => p.Device)
                .Include(p => p.HistoryNavigation)
                .Include(p => p.OwnerLocationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        // GET: Printers/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id");
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id");
            return View();
        }

        // POST: Printers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TosNumber,OwnerLocation,DeviceId,Type,ConnectionType,History,Notes")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(printer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", printer.DeviceId);
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id", printer.History);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", printer.OwnerLocation);
            return View(printer);
        }

        // GET: Printers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Printers == null)
            {
                return NotFound();
            }

            var printer = await _context.Printers.FindAsync(id);
            if (printer == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", printer.DeviceId);
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id", printer.History);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", printer.OwnerLocation);
            return View(printer);
        }

        // POST: Printers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TosNumber,OwnerLocation,DeviceId,Type,ConnectionType,History,Notes")] Printer printer)
        {
            if (id != printer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(printer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrinterExists(printer.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", printer.DeviceId);
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id", printer.History);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", printer.OwnerLocation);
            return View(printer);
        }

        // GET: Printers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Printers == null)
            {
                return NotFound();
            }

            var printer = await _context.Printers
                .Include(p => p.Device)
                .Include(p => p.HistoryNavigation)
                .Include(p => p.OwnerLocationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        // POST: Printers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Printers == null)
            {
                return Problem("Entity set 'DatabaseContext.Printers'  is null.");
            }
            var printer = await _context.Printers.FindAsync(id);
            if (printer != null)
            {
                _context.Printers.Remove(printer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrinterExists(int id)
        {
            return _context.Printers.Any(e => e.Id == id);
        }
    }
}
