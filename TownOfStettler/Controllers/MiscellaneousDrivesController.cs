using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class MiscellaneousDrivesController : Controller
    {
        private readonly DatabaseContext _context;

        public MiscellaneousDrivesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: MiscellaneousDrives
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.MiscellaneousDrives.Include(s => s.Device);
            return View(await databaseContext.ToListAsync());
        }

        //Search SerialNumber
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.MiscellaneousDrives
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Type.Contains(SearchString));
        //        //Info = Info.Where(i => i.Removable.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.SerialNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));


        //    }
        //    return View(Info);
        //}


        // GET: MiscellaneousDrives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MiscellaneousDrives == null)
            {
                return NotFound();
            }

            var MiscellaneousDrive = await _context.MiscellaneousDrives
                .Include(s => s.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (MiscellaneousDrive == null)
            {
                return NotFound();
            }

            return View(MiscellaneousDrive);
        }

        // GET: MiscellaneousDrives/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: MiscellaneousDrives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Type,Removable,SerialNumber,Destroyed,Notes")] MiscellaneousDrive MiscellaneousDrive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(MiscellaneousDrive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", MiscellaneousDrive.DeviceId);
            return View(MiscellaneousDrive);
        }

        // GET: MiscellaneousDrives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MiscellaneousDrives == null)
            {
                return NotFound();
            }

            var MiscellaneousDrive = await _context.MiscellaneousDrives.FindAsync(id);
            if (MiscellaneousDrive == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", MiscellaneousDrive.DeviceId);
            return View(MiscellaneousDrive);
        }

        // POST: MiscellaneousDrives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Type,Removable,SerialNumber,Destroyed,Notes")] MiscellaneousDrive MiscellaneousDrive)
        {
            if (id != MiscellaneousDrive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MiscellaneousDrive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiscellaneousDriveExists(MiscellaneousDrive.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", MiscellaneousDrive.DeviceId);
            return View(MiscellaneousDrive);
        }

        // GET: MiscellaneousDrives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MiscellaneousDrives == null)
            {
                return NotFound();
            }

            var MiscellaneousDrive = await _context.MiscellaneousDrives
                .Include(s => s.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (MiscellaneousDrive == null)
            {
                return NotFound();
            }

            return View(MiscellaneousDrive);
        }

        // POST: MiscellaneousDrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MiscellaneousDrives == null)
            {
                return Problem("Entity set 'DatabaseContext.MiscellaneousDrives'  is null.");
            }
            var MiscellaneousDrive = await _context.MiscellaneousDrives.FindAsync(id);
            if (MiscellaneousDrive != null)
            {
                _context.MiscellaneousDrives.Remove(MiscellaneousDrive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiscellaneousDriveExists(int id)
        {
            return _context.MiscellaneousDrives.Any(e => e.Id == id);
        }
    }
}
