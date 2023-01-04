using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class DeviceInformationController : Controller
    {
        private readonly DatabaseContext _context;

        public DeviceInformationController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: DeviceInformation
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.DeviceInformations.Include(d => d.DeviceType).Include(d => d.OwnerLocationNavigation);
            
            return View(await databaseContext.ToListAsync());
        }

        //Search arbitrary string in all fields
        public IActionResult Index(string SearchString)
        {
            ViewData["Filter"] = SearchString;
            var Info = _context.DeviceInformations.ToList();
            if (!String.IsNullOrWhiteSpace(SearchString))
            {
                List<DeviceInformation> goodInfo = new List<DeviceInformation>();
                foreach (var item in Info)
                {
                    bool match = false;
                    var allProps = item.GetType().GetProperties();
                    foreach (var prop in allProps)
                    {
                        if (prop.GetValue(item) != null)
                        {
                            match = (prop.GetValue(item).ToString().ToUpper()).Contains(SearchString.Trim().ToUpper());
                        }
                        if (match)
                        {
                            goodInfo.Add(item);
                            break;
                        }
                    }
                }
                Info = goodInfo;
            }
            return View(Info);
        }

        // GET: DeviceInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeviceInformations == null)
            {
                return NotFound();
            }

            var deviceInformation = await _context.DeviceInformations
                .Include(d => d.DeviceType)
                .Include(d => d.OwnerLocationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceInformation == null)
            {
                return NotFound();
            }

            return View(deviceInformation);
        }

        // GET: DeviceInformation/Create
        public IActionResult Create()
        {
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id");
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id");
            return View();
        }

        // POST: DeviceInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


       
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceTypeId,OwnerLocation,TosNumber,SerialNumber,ModelNumber,PowerSupply,PurchaseStore,PurchasePrice,PurchaseDate,OperatingSystem,Destroyed,Notes")] DeviceInformation deviceInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id", deviceInformation.DeviceTypeId);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", deviceInformation.OwnerLocation);
       
            return View(deviceInformation);
        }

        // GET: DeviceInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeviceInformations == null)
            {
                return NotFound();
            }

            var deviceInformation = await _context.DeviceInformations.FindAsync(id);
            if (deviceInformation == null)
            {
                return NotFound();
            }
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id", deviceInformation.DeviceTypeId);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", deviceInformation.OwnerLocation);
            return View(deviceInformation);
        }

        // POST: DeviceInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceTypeId,OwnerLocation,TosNumber,SerialNumber,ModelNumber,PowerSupply,PurchaseStore,PurchasePrice,PurchaseDate,OperatingSystem,Destroyed,Notes")] DeviceInformation deviceInformation)
        {
            if (id != deviceInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceInformationExists(deviceInformation.Id))
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
            ViewData["DeviceTypeId"] = new SelectList(_context.HardwareDevices, "Id", "Id", deviceInformation.DeviceTypeId);
            ViewData["OwnerLocation"] = new SelectList(_context.OwnerLocations, "Id", "Id", deviceInformation.OwnerLocation);
            return View(deviceInformation);
        }

        // GET: DeviceInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeviceInformations == null)
            {
                return NotFound();
            }

            var deviceInformation = await _context.DeviceInformations
                .Include(d => d.DeviceType)
                .Include(d => d.OwnerLocationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceInformation == null)
            {
                return NotFound();
            }

            return View(deviceInformation);
        }

        // POST: DeviceInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeviceInformations == null)
            {
                return Problem("Entity set 'DatabaseContext.DeviceInformations'  is null.");
            }
            var deviceInformation = await _context.DeviceInformations.FindAsync(id);
            if (deviceInformation != null)
            {
                _context.DeviceInformations.Remove(deviceInformation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceInformationExists(int id)
        {
            return _context.DeviceInformations.Any(e => e.Id == id);
        }
    }
}
