using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class HardDriveController : Controller
    {
        private readonly DatabaseContext _context;

        public HardDriveController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: HardDrive
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.HardDrives.Include(h => h.Device);
            return View(await databaseContext.ToListAsync());
        }

        // Search SerialNumber
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.HardDrives
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Type.Contains(SearchString));
        //        //Info = Info.Where(i => i.SizeGb.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.SerialNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}

        // GET: HardDrive/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HardDrives == null)
            {
                return NotFound();
            }

            var hardDrive = await _context.HardDrives
                .Include(h => h.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardDrive == null)
            {
                return NotFound();
            }

            return View(hardDrive);
        }

        // GET: HardDrive/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: HardDrive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Type,SizeGb,SerialNumber,Destroyed,Notes")] HardDrive hardDrive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardDrive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", hardDrive.DeviceId);
            return View(hardDrive);
        }

        // GET: HardDrive/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HardDrives == null)
            {
                return NotFound();
            }

            var hardDrive = await _context.HardDrives.FindAsync(id);
            if (hardDrive == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", hardDrive.DeviceId);
            return View(hardDrive);
        }

        // POST: HardDrive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Type,SizeGb,SerialNumber,Destroyed,Notes")] HardDrive hardDrive)
        {
            if (id != hardDrive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardDrive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardDriveExists(hardDrive.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", hardDrive.DeviceId);
            return View(hardDrive);
        }

        // GET: HardDrive/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HardDrives == null)
            {
                return NotFound();
            }

            var hardDrive = await _context.HardDrives
                .Include(h => h.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardDrive == null)
            {
                return NotFound();
            }

            return View(hardDrive);
        }

        // POST: HardDrive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HardDrives == null)
            {
                return Problem("Entity set 'DatabaseContext.HardDrives'  is null.");
            }
            var hardDrive = await _context.HardDrives.FindAsync(id);
            if (hardDrive != null)
            {
                _context.HardDrives.Remove(hardDrive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardDriveExists(int id)
        {
            return _context.HardDrives.Any(e => e.Id == id);
        }
    }
}
