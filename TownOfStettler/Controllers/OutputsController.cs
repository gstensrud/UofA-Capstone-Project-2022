using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class OutputsController : Controller
    {
        private readonly DatabaseContext _context;

        public OutputsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Outputs
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Outputs.Include(o => o.VideoCard);
            return View(await databaseContext.ToListAsync());
        }

        //Search Type
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.Outputs
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.Type.Contains(SearchString));
        //        //Info = Info.Where(i => i.VideoCardId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.NumberOfOutputs.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}

        // GET: Outputs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs
                .Include(o => o.VideoCard)
                .FirstOrDefaultAsync(m => m.Type == id);
            if (output == null)
            {
                return NotFound();
            }

            return View(output);
        }

        // GET: Outputs/Create
        public IActionResult Create()
        {
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id");
            return View();
        }

        // POST: Outputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,VideoCardId,NumberOfOutputs,Notes")] Output output)
        {
            if (ModelState.IsValid)
            {
                _context.Add(output);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", output.VideoCardId);
            return View(output);
        }

        // GET: Outputs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs.FindAsync(id);
            if (output == null)
            {
                return NotFound();
            }
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", output.VideoCardId);
            return View(output);
        }

        // POST: Outputs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Type,VideoCardId,NumberOfOutputs,Notes")] Output output)
        {
            if (id != output.Type)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(output);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutputExists(output.Type))
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
            ViewData["VideoCardId"] = new SelectList(_context.VideoCards, "Id", "Id", output.VideoCardId);
            return View(output);
        }

        // GET: Outputs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs
                .Include(o => o.VideoCard)
                .FirstOrDefaultAsync(m => m.Type == id);
            if (output == null)
            {
                return NotFound();
            }

            return View(output);
        }

        // POST: Outputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Outputs == null)
            {
                return Problem("Entity set 'DatabaseContext.Outputs'  is null.");
            }
            var output = await _context.Outputs.FindAsync(id);
            if (output != null)
            {
                _context.Outputs.Remove(output);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutputExists(string id)
        {
            return _context.Outputs.Any(e => e.Type == id);
        }
    }
}
