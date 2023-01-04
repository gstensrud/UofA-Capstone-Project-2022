using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class OtherHardwareController : Controller
    {
        private readonly DatabaseContext _context;

        public OtherHardwareController(DatabaseContext context)
        {
            _context = context;
        }

        //// GET: OtherHardware
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.OtherHardwares.Include(o => o.HistoryNavigation).Include(o => o.OwnerLocationNavigation);
            return View(await databaseContext.ToListAsync());
        }

        //Search TosNumber
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.OtherHardwares
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.OwnerLocation.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.TosNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.TypeOfDevice.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.History.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));
        //    }
        //    return View(Info);
        //}

        // GET: OtherHardware/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OtherHardwares == null)
            {
                return NotFound();
            }

            var otherHardware = await _context.OtherHardwares
                .Include(o => o.HistoryNavigation)
                .Include(o => o.OwnerLocationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otherHardware == null)
            {
                return NotFound();
            }

            return View(otherHardware);
        }

        // GET: OtherHardware/Create
        public IActionResult Create()
        {
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id");
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id");
            return View();
        }

        // POST: OtherHardware/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnerLocation,TosNumber,TypeOfDevice,Destroyed,History,Notes")] OtherHardware otherHardware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otherHardware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id", otherHardware.History);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", otherHardware.OwnerLocation);
            return View(otherHardware);
        }

        // GET: OtherHardware/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OtherHardwares == null)
            {
                return NotFound();
            }

            var otherHardware = await _context.OtherHardwares.FindAsync(id);
            if (otherHardware == null)
            {
                return NotFound();
            }
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id", otherHardware.History);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", otherHardware.OwnerLocation);
            return View(otherHardware);
        }

        // POST: OtherHardware/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnerLocation,TosNumber,TypeOfDevice,Destroyed,History,Notes")] OtherHardware otherHardware)
        {
            if (id != otherHardware.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otherHardware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherHardwareExists(otherHardware.Id))
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
            ViewData["History"] = new SelectList(_context.Histories, "Id", "Id", otherHardware.History);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", otherHardware.OwnerLocation);
            return View(otherHardware);
        }

        // GET: OtherHardware/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OtherHardwares == null)
            {
                return NotFound();
            }

            var otherHardware = await _context.OtherHardwares
                .Include(o => o.HistoryNavigation)
                .Include(o => o.OwnerLocationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otherHardware == null)
            {
                return NotFound();
            }

            return View(otherHardware);
        }

        // POST: OtherHardware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OtherHardwares == null)
            {
                return Problem("Entity set 'DatabaseContext.OtherHardwares'  is null.");
            }
            var otherHardware = await _context.OtherHardwares.FindAsync(id);
            if (otherHardware != null)
            {
                _context.OtherHardwares.Remove(otherHardware);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherHardwareExists(int id)
        {
            return _context.OtherHardwares.Any(e => e.Id == id);
        }
    }
}
