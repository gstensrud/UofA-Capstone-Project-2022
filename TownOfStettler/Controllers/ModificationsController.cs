using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class ModificationsController : Controller
    {
        private readonly DatabaseContext _context;

        public ModificationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Modifications
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Modifications.Include(m => m.HardDrive).Include(m => m.Processor).Include(m => m.Ram).Include(m => m.MiscellaneousDrive).Include(m => m.SoundCard).Include(m => m.VideoCard);
            return View(await databaseContext.ToListAsync());
        }


        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Modifications
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.ProcessorId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.RamId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.HardDriveId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.MiscellaneousDriveId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.SoundCardId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.VideoCardId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}


        // GET: Modifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modifications == null)
            {
                return NotFound();
            }

            var modification = await _context.Modifications
                .Include(m => m.HardDrive)
                .Include(m => m.Processor)
                .Include(m => m.Ram)
                .Include(m => m.MiscellaneousDrive)
                .Include(m => m.SoundCard)
                .Include(m => m.VideoCard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modification == null)
            {
                return NotFound();
            }

            return View(modification);
        }

        // GET: Modifications/Create
        public IActionResult Create()
        {
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id");
            ViewData["ProcessorId"] = new SelectList(_context.Processors, "Id", "Id");
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id");
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id");
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id");
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id");
            return View();
        }

        // POST: Modifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessorId,RamId,HardDriveId,MiscellaneousDriveId,SoundCardId,VideoCardId,Notes")] Modification modification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id", modification.HardDriveId);
            ViewData["ProcessorId"] = new SelectList(_context.Processors, "Id", "Id", modification.ProcessorId);
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id", modification.RamId);
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id", modification.MiscellaneousDriveId);
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id", modification.SoundCardId);
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", modification.VideoCardId);
            return View(modification);
        }

        // GET: Modifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modifications == null)
            {
                return NotFound();
            }

            var modification = await _context.Modifications.FindAsync(id);
            if (modification == null)
            {
                return NotFound();
            }
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id", modification.HardDriveId);
            ViewData["ProcessorId"] = new SelectList(_context.Processors, "Id", "Id", modification.ProcessorId);
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id", modification.RamId);
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id", modification.MiscellaneousDriveId);
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id", modification.SoundCardId);
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", modification.VideoCardId);
            return View(modification);
        }

        // POST: Modifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessorId,RamId,HardDriveId,MiscellaneousDriveId,SoundCardId,VideoCardId,Notes")] Modification modification)
        {
            if (id != modification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModificationExists(modification.Id))
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
            ViewData["HardDriveId"] = new SelectList(_context.HardDrives, "Id", "Id", modification.HardDriveId);
            ViewData["ProcessorId"] = new SelectList(_context.Processors, "Id", "Id", modification.ProcessorId);
            ViewData["RamId"] = new SelectList(_context.Rams, "Id", "Id", modification.RamId);
            ViewData["MiscellaneousDriveId"] = new SelectList(_context.MiscellaneousDrives, "Id", "Id", modification.MiscellaneousDriveId);
            ViewData["SoundCardId"] = new SelectList(_context.SoundCards, "Id", "Id", modification.SoundCardId);
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", modification.VideoCardId);
            return View(modification);
        }

        // GET: Modifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modifications == null)
            {
                return NotFound();
            }

            var modification = await _context.Modifications
                .Include(m => m.HardDrive)
                .Include(m => m.Processor)
                .Include(m => m.Ram)
                .Include(m => m.MiscellaneousDrive)
                .Include(m => m.SoundCard)
                .Include(m => m.VideoCard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modification == null)
            {
                return NotFound();
            }

            return View(modification);
        }

        // POST: Modifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modifications == null)
            {
                return Problem("Entity set 'DatabaseContext.Modifications'  is null.");
            }
            var modification = await _context.Modifications.FindAsync(id);
            if (modification != null)
            {
                _context.Modifications.Remove(modification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModificationExists(int id)
        {
            return _context.Modifications.Any(e => e.Id == id);
        }
    }
}
