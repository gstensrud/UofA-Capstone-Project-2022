using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class VideoCardController : Controller
    {
        private readonly DatabaseContext _context;

        public VideoCardController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: VideoCard
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.VideoCards.Include(v => v.Device);
            return View(await databaseContext.ToListAsync());
        }

        //Search Brand
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.VideoCards
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.Brand.Contains(SearchString));
        //        //Info = Info.Where(i => i.RamSizeGb.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.SerialNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}

        // GET: VideoCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VideoCards == null)
            {
                return NotFound();
            }

            var videoCard = await _context.VideoCards
                .Include(v => v.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoCard == null)
            {
                return NotFound();
            }

            return View(videoCard);
        }

        // GET: VideoCard/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: VideoCard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Brand,RamSizeGb,SerialNumber,Destroyed,Notes")] VideoCard videoCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", videoCard.DeviceId);
            return View(videoCard);
        }

        // GET: VideoCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VideoCards == null)
            {
                return NotFound();
            }

            var videoCard = await _context.VideoCards.FindAsync(id);
            if (videoCard == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", videoCard.DeviceId);
            return View(videoCard);
        }

        // POST: VideoCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Brand,RamSizeGb,SerialNumber,Destroyed,Notes")] VideoCard videoCard)
        {
            if (id != videoCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoCardExists(videoCard.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", videoCard.DeviceId);
            return View(videoCard);
        }

        // GET: VideoCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VideoCards == null)
            {
                return NotFound();
            }

            var videoCard = await _context.VideoCards
                .Include(v => v.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoCard == null)
            {
                return NotFound();
            }

            return View(videoCard);
        }

        // POST: VideoCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VideoCards == null)
            {
                return Problem("Entity set 'DatabaseContext.VideoCards'  is null.");
            }
            var videoCard = await _context.VideoCards.FindAsync(id);
            if (videoCard != null)
            {
                _context.VideoCards.Remove(videoCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoCardExists(int id)
        {
            return _context.VideoCards.Any(e => e.Id == id);
        }
    }
}
