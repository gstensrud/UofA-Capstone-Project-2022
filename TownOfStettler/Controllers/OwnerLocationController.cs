using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class OwnerLocationController : Controller
    {
        private readonly DatabaseContext _context;

        public OwnerLocationController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: OwnerLocation
        public async Task<IActionResult> Index()
        {
            return View(await _context.OwnerLocations.ToListAsync());
        }

        //Search Name
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.OwnerLocations
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.Name.Contains(SearchString));
        //        //Info = Info.Where(i => i.Address.Contains(SearchString));
        //        //Info = Info.Where(i => i.PhoneNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));
        //    }
        //    return View(Info);
        //}


        // GET: OwnerLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OwnerLocations == null)
            {
                return NotFound();
            }

            var ownerLocation = await _context.OwnerLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerLocation == null)
            {
                return NotFound();
            }

            return View(ownerLocation);
        }

        // GET: OwnerLocation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnerLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,PhoneNumber,Notes")] OwnerLocation ownerLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownerLocation);
        }

        // GET: OwnerLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OwnerLocations == null)
            {
                return NotFound();
            }

            var ownerLocation = await _context.OwnerLocations.FindAsync(id);
            if (ownerLocation == null)
            {
                return NotFound();
            }
            return View(ownerLocation);
        }

        // POST: OwnerLocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PhoneNumber,Notes")] OwnerLocation ownerLocation)
        {
            if (id != ownerLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerLocationExists(ownerLocation.Id))
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
            return View(ownerLocation);
        }

        // GET: OwnerLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OwnerLocations == null)
            {
                return NotFound();
            }

            var ownerLocation = await _context.OwnerLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerLocation == null)
            {
                return NotFound();
            }

            return View(ownerLocation);
        }

        // POST: OwnerLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OwnerLocations == null)
            {
                return Problem("Entity set 'DatabaseContext.OwnerLocations'  is null.");
            }
            var ownerLocation = await _context.OwnerLocations.FindAsync(id);
            if (ownerLocation != null)
            {
                _context.OwnerLocations.Remove(ownerLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerLocationExists(int id)
        {
            return _context.OwnerLocations.Any(e => e.Id == id);
        }
    }
}
