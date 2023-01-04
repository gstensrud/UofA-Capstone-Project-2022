using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class HardwareDeviceController : Controller
    {
        private readonly DatabaseContext _context;

        public HardwareDeviceController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: HardwareDevice
        public async Task<IActionResult> Index()
        {
            return View(await _context.HardwareDevices.ToListAsync());
        }

        //Search TypeOfHardware
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.HardwareDevices
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.TypeOfHardware.Contains(SearchString));

        //    }
        //    return View(Info);
        //}

        // GET: HardwareDevice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HardwareDevices == null)
            {
                return NotFound();
            }

            var hardwareDevice = await _context.HardwareDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardwareDevice == null)
            {
                return NotFound();
            }

            return View(hardwareDevice);
        }

        // GET: HardwareDevice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HardwareDevice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfHardware")] HardwareDevice hardwareDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardwareDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardwareDevice);
        }

        // GET: HardwareDevice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HardwareDevices == null)
            {
                return NotFound();
            }

            var hardwareDevice = await _context.HardwareDevices.FindAsync(id);
            if (hardwareDevice == null)
            {
                return NotFound();
            }
            return View(hardwareDevice);
        }

        // POST: HardwareDevice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeOfHardware")] HardwareDevice hardwareDevice)
        {
            if (id != hardwareDevice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardwareDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareDeviceExists(hardwareDevice.Id))
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
            return View(hardwareDevice);
        }

        // GET: HardwareDevice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HardwareDevices == null)
            {
                return NotFound();
            }

            var hardwareDevice = await _context.HardwareDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardwareDevice == null)
            {
                return NotFound();
            }

            return View(hardwareDevice);
        }

        // POST: HardwareDevice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HardwareDevices == null)
            {
                return Problem("Entity set 'DatabaseContext.HardwareDevices'  is null.");
            }
            var hardwareDevice = await _context.HardwareDevices.FindAsync(id);
            if (hardwareDevice != null)
            {
                _context.HardwareDevices.Remove(hardwareDevice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareDeviceExists(int id)
        {
            return _context.HardwareDevices.Any(e => e.Id == id);
        }
    }
}
