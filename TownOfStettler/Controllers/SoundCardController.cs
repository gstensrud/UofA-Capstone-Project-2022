using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class SoundCardController : Controller
    {
        private readonly DatabaseContext _context;

        public SoundCardController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: SoundCard
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.SoundCards.Include(s => s.Device);
            return View(await databaseContext.ToListAsync());
        }

        //Search Brand
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.SoundCards
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.Brand.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}


        // GET: SoundCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SoundCards == null)
            {
                return NotFound();
            }

            var soundCard = await _context.SoundCards
                .Include(s => s.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soundCard == null)
            {
                return NotFound();
            }

            return View(soundCard);
        }

        // GET: SoundCard/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: SoundCard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Brand,Destroyed,Notes")] SoundCard soundCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soundCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", soundCard.DeviceId);
            return View(soundCard);
        }

        // GET: SoundCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SoundCards == null)
            {
                return NotFound();
            }

            var soundCard = await _context.SoundCards.FindAsync(id);
            if (soundCard == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", soundCard.DeviceId);
            return View(soundCard);
        }

        // POST: SoundCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Brand,Destroyed,Notes")] SoundCard soundCard)
        {
            if (id != soundCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soundCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoundCardExists(soundCard.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", soundCard.DeviceId);
            return View(soundCard);
        }

        // GET: SoundCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SoundCards == null)
            {
                return NotFound();
            }

            var soundCard = await _context.SoundCards
                .Include(s => s.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soundCard == null)
            {
                return NotFound();
            }

            return View(soundCard);
        }

        // POST: SoundCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SoundCards == null)
            {
                return Problem("Entity set 'DatabaseContext.SoundCards'  is null.");
            }
            var soundCard = await _context.SoundCards.FindAsync(id);
            if (soundCard != null)
            {
                _context.SoundCards.Remove(soundCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoundCardExists(int id)
        {
            return _context.SoundCards.Any(e => e.Id == id);
        }
    }
}
