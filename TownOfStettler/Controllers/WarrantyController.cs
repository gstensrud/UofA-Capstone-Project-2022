using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly DatabaseContext _context;

        public WarrantyController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Warranty
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Warranties.Include(w => w.Device);
            return View(await databaseContext.ToListAsync());
        }

        //Search TypeOfWarranty
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Warranties
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.TypeOfWarranty.Contains(SearchString));
        //        //Info = Info.Where(i => i.LengthOfWarranty.Contains(SearchString));
        //        //Info = Info.Where(i => i.WarrantyExpiryDate.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}

        // GET: Warranty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Warranties == null)
            {
                return NotFound();
            }

            var warranty = await _context.Warranties
                .Include(w => w.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warranty == null)
            {
                return NotFound();
            }

            return View(warranty);
        }

        // GET: Warranty/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: Warranty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,TypeOfWarranty,LengthOfWarranty,WarrantyExpiryDate,Notes")] Warranty warranty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warranty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", warranty.DeviceId);
            return View(warranty);
        }

        // GET: Warranty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Warranties == null)
            {
                return NotFound();
            }

            var warranty = await _context.Warranties.FindAsync(id);
            if (warranty == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", warranty.DeviceId);
            return View(warranty);
        }

        // POST: Warranty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string WarrantyExpiryDate, [Bind("Id,DeviceId,TypeOfWarranty,LengthOfWarranty,WarrantyExpiryDate,Notes")] Warranty warranty)
        {
            if (id != warranty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    warranty.WarrantyExpiryDate = DateOnly.Parse(WarrantyExpiryDate);
                    _context.Update(warranty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarrantyExists(warranty.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", warranty.DeviceId);
            return View(warranty);
        }

        // GET: Warranty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Warranties == null)
            {
                return NotFound();
            }

            var warranty = await _context.Warranties
                .Include(w => w.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warranty == null)
            {
                return NotFound();
            }

            return View(warranty);
        }

        // POST: Warranty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Warranties == null)
            {
                return Problem("Entity set 'DatabaseContext.Warranties'  is null.");
            }
            var warranty = await _context.Warranties.FindAsync(id);
            if (warranty != null)
            {
                _context.Warranties.Remove(warranty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarrantyExists(int id)
        {
            return _context.Warranties.Any(e => e.Id == id);
        }
    }
}
