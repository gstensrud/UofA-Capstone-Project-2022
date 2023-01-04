using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class InuseMonitorsController : Controller
    {
        private readonly DatabaseContext _context;

        public InuseMonitorsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: InuseMonitors
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.InuseMonitors.Include(i => i.Device).Include(i => i.Monitor);
            return View(await databaseContext.ToListAsync());
        }

        //Search MonitorId
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.InuseMonitors
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.MonitorId.ToString().Contains(SearchString));
        //    }
        //    return View(Info);
        //}


        // GET: InuseMonitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InuseMonitors == null)
            {
                return NotFound();
            }

            var inuseMonitor = await _context.InuseMonitors
                .Include(i => i.Device)
                .Include(i => i.Monitor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inuseMonitor == null)
            {
                return NotFound();
            }

            return View(inuseMonitor);
        }

        // GET: InuseMonitors/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            ViewData["MonitorId"] = new SelectList(_context.DisplayMonitors, "Id", "Id");
            return View();
        }

        // POST: InuseMonitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,MonitorId")] InuseMonitor inuseMonitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inuseMonitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", inuseMonitor.DeviceId);
            ViewData["MonitorId"] = new SelectList(_context.DisplayMonitors, "Id", "Id", inuseMonitor.MonitorId);
            return View(inuseMonitor);
        }

        // GET: InuseMonitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InuseMonitors == null)
            {
                return NotFound();
            }

            var inuseMonitor = await _context.InuseMonitors.FindAsync(id);
            if (inuseMonitor == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", inuseMonitor.DeviceId);
            ViewData["MonitorId"] = new SelectList(_context.DisplayMonitors, "Id", "Id", inuseMonitor.MonitorId);
            return View(inuseMonitor);
        }

        // POST: InuseMonitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,MonitorId")] InuseMonitor inuseMonitor)
        {
            if (id != inuseMonitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inuseMonitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InuseMonitorExists(inuseMonitor.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", inuseMonitor.DeviceId);
            ViewData["MonitorId"] = new SelectList(_context.DisplayMonitors, "Id", "Id", inuseMonitor.MonitorId);
            return View(inuseMonitor);
        }

        // GET: InuseMonitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InuseMonitors == null)
            {
                return NotFound();
            }

            var inuseMonitor = await _context.InuseMonitors
                .Include(i => i.Device)
                .Include(i => i.Monitor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inuseMonitor == null)
            {
                return NotFound();
            }

            return View(inuseMonitor);
        }

        // POST: InuseMonitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InuseMonitors == null)
            {
                return Problem("Entity set 'DatabaseContext.InuseMonitors'  is null.");
            }
            var inuseMonitor = await _context.InuseMonitors.FindAsync(id);
            if (inuseMonitor != null)
            {
                _context.InuseMonitors.Remove(inuseMonitor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InuseMonitorExists(int id)
        {
          return _context.InuseMonitors.Any(e => e.Id == id);
        }
    }
}
