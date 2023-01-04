using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class InstalledSoftwareController : Controller
    {
        private readonly DatabaseContext _context;

        public InstalledSoftwareController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: InstalledSoftware
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.InstalledSoftwares.Include(i => i.Device).Include(i => i.Software);
            return View(await databaseContext.ToListAsync());
        }

        //Search SoftwareId
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.InstalledSoftwares
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        //Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        Info = Info.Where(i => i.SoftwareId.ToString().Contains(SearchString));
        //    }
        //    return View(Info);
        //}


        // GET: InstalledSoftware/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InstalledSoftwares == null)
            {
                return NotFound();
            }

            var installedSoftware = await _context.InstalledSoftwares
                .Include(i => i.Device)
                .Include(i => i.Software)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installedSoftware == null)
            {
                return NotFound();
            }

            return View(installedSoftware);
        }

        // GET: InstalledSoftware/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "Id", "Id");
            return View();
        }

        // POST: InstalledSoftware/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,SoftwareId")] InstalledSoftware installedSoftware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(installedSoftware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", installedSoftware.DeviceId);
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "Id", "Id", installedSoftware.SoftwareId);
            return View(installedSoftware);
        }

        // GET: InstalledSoftware/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InstalledSoftwares == null)
            {
                return NotFound();
            }

            var installedSoftware = await _context.InstalledSoftwares.FindAsync(id);
            if (installedSoftware == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", installedSoftware.DeviceId);
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "Id", "Id", installedSoftware.SoftwareId);
            return View(installedSoftware);
        }

        // POST: InstalledSoftware/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,SoftwareId")] InstalledSoftware installedSoftware)
        {
            if (id != installedSoftware.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(installedSoftware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstalledSoftwareExists(installedSoftware.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", installedSoftware.DeviceId);
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "Id", "Id", installedSoftware.SoftwareId);
            return View(installedSoftware);
        }

        // GET: InstalledSoftware/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InstalledSoftwares == null)
            {
                return NotFound();
            }

            var installedSoftware = await _context.InstalledSoftwares
                .Include(i => i.Device)
                .Include(i => i.Software)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installedSoftware == null)
            {
                return NotFound();
            }

            return View(installedSoftware);
        }

        // POST: InstalledSoftware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InstalledSoftwares == null)
            {
                return Problem("Entity set 'DatabaseContext.InstalledSoftwares'  is null.");
            }
            var installedSoftware = await _context.InstalledSoftwares.FindAsync(id);
            if (installedSoftware != null)
            {
                _context.InstalledSoftwares.Remove(installedSoftware);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstalledSoftwareExists(int id)
        {
          return _context.InstalledSoftwares.Any(e => e.Id == id);
        }
    }
}
