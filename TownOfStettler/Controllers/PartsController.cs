using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class PartsController : Controller
    {
        private readonly DatabaseContext _context;

        public PartsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Parts.Include(p => p.DeviceHistory).Include(p => p.HardDrive).Include(p => p.OriginalDevice).Include(p => p.Ram).Include(p => p.MiscellaneousDrive).Include(p => p.SoundCard).Include(p => p.VideoCard);
            return View(await databaseContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Parts
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.OriginalDeviceId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.DeviceHistoryId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.RamId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.HardDriveId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.MiscellaneousDriveId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.VideoCardId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.SoundCardId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.ToString().Contains(SearchString));

        //    }
        //    return View(Info);
        //}


        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .Include(p => p.DeviceHistory)
                .Include(p => p.HardDrive)
                .Include(p => p.OriginalDevice)
                .Include(p => p.Ram)
                .Include(p => p.MiscellaneousDrive)
                .Include(p => p.SoundCard)
                .Include(p => p.VideoCard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            ViewData["DeviceHistoryId"] = new SelectList(_context.Histories, "Id", "Id");
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id");
            ViewData["OriginalDeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id");
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id");
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id");
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id");
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OriginalDeviceId,DeviceHistoryId,RamId,HardDriveId,MiscellaneousDriveId,VideoCardId,SoundCardId,Notes")] Part part)
        {
            if (ModelState.IsValid)
            {
                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceHistoryId"] = new SelectList(_context.Histories, "Id", "Id", part.DeviceHistoryId);
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id", part.HardDriveId);
            ViewData["OriginalDeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", part.OriginalDeviceId);
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id", part.RamId);
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id", part.MiscellaneousDriveId);
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id", part.SoundCardId);
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", part.VideoCardId);
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            ViewData["DeviceHistoryId"] = new SelectList(_context.Histories, "Id", "Id", part.DeviceHistoryId);
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id", part.HardDriveId);
            ViewData["OriginalDeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", part.OriginalDeviceId);
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id", part.RamId);
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id", part.MiscellaneousDriveId);
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id", part.SoundCardId);
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", part.VideoCardId);
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OriginalDeviceId,DeviceHistoryId,RamId,HardDriveId,MiscellaneousDriveId,VideoCardId,SoundCardId,Notes")] Part part)
        {
            if (id != part.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartExists(part.Id))
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
            ViewData["DeviceHistoryId"] = new SelectList(_context.Histories, "Id", "Id", part.DeviceHistoryId);
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id", part.HardDriveId);
            ViewData["OriginalDeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", part.OriginalDeviceId);
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id", part.RamId);
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id", part.MiscellaneousDriveId);
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id", part.SoundCardId);
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", part.VideoCardId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .Include(p => p.DeviceHistory)
                .Include(p => p.HardDrive)
                .Include(p => p.OriginalDevice)
                .Include(p => p.Ram)
                .Include(p => p.MiscellaneousDrive)
                .Include(p => p.SoundCard)
                .Include(p => p.VideoCard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parts == null)
            {
                return Problem("Entity set 'DatabaseContext.Parts'  is null.");
            }
            var part = await _context.Parts.FindAsync(id);
            if (part != null)
            {
                _context.Parts.Remove(part);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
    }
}
