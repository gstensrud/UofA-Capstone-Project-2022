using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class ProcessorsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProcessorsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Processors
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Processors.Include(p => p.Device);
            return View(await databaseContext.ToListAsync());
        }

        //Search Type
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Processors
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.Type.Contains(SearchString));
        //        //Info = Info.Where(i => i.SpeedGhz.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.SerialNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Generation.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.CoreCount.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}

        // GET: Processors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Processors == null)
            {
                return NotFound();
            }

            var processor = await _context.Processors
                .Include(p => p.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processor == null)
            {
                return NotFound();
            }

            return View(processor);
        }

        // GET: Processors/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: Processors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Type,SpeedGhz,SerialNumber,Generation,CoreCount,Destroyed,Notes")] Processor processor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", processor.DeviceId);
            return View(processor);
        }

        // GET: Processors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Processors == null)
            {
                return NotFound();
            }

            var processor = await _context.Processors.FindAsync(id);
            if (processor == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", processor.DeviceId);
            return View(processor);
        }

        // POST: Processors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Type,SpeedGhz,SerialNumber,Generation,CoreCount,Destroyed,Notes")] Processor processor)
        {
            if (id != processor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessorExists(processor.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", processor.DeviceId);
            return View(processor);
        }

        // GET: Processors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Processors == null)
            {
                return NotFound();
            }

            var processor = await _context.Processors
                .Include(p => p.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processor == null)
            {
                return NotFound();
            }

            return View(processor);
        }

        // POST: Processors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Processors == null)
            {
                return Problem("Entity set 'DatabaseContext.Processors'  is null.");
            }
            var processor = await _context.Processors.FindAsync(id);
            if (processor != null)
            {
                _context.Processors.Remove(processor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessorExists(int id)
        {
            return _context.Processors.Any(e => e.Id == id);
        }
    }
}
