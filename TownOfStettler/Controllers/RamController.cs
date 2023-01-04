using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class RamController : Controller
    {
        private readonly DatabaseContext _context;

        public RamController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Ram
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Rams.Include(r => r.Device);
            return View(await databaseContext.ToListAsync());
        }

        //Search SerialNumber
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Rams
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Type.Contains(SearchString));
        //        //Info = Info.Where(i => i.SizeGb.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.SpeedMhz.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.SerialNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}


        // GET: Ram/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rams == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .Include(r => r.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        // GET: Ram/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: Ram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Type,SizeGb,SpeedMhz,SerialNumber,Destroyed,Notes")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", ram.DeviceId);
            return View(ram);
        }

        // GET: Ram/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rams == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams.FindAsync(id);
            if (ram == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", ram.DeviceId);
            return View(ram);
        }

        // POST: Ram/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Type,SizeGb,SpeedMhz,SerialNumber,Destroyed,Notes")] Ram ram)
        {
            if (id != ram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamExists(ram.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", ram.DeviceId);
            return View(ram);
        }

        // GET: Ram/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rams == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .Include(r => r.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        // POST: Ram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rams == null)
            {
                return Problem("Entity set 'DatabaseContext.Rams'  is null.");
            }
            var ram = await _context.Rams.FindAsync(id);
            if (ram != null)
            {
                _context.Rams.Remove(ram);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamExists(int id)
        {
            return _context.Rams.Any(e => e.Id == id);
        }
    }
}
