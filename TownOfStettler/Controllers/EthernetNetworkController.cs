using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TownOfStettler.Data;
using TownOfStettler.Models;

namespace TownOfStettler.Controllers
{
    public class EthernetNetworkController : Controller
    {
        private readonly DatabaseContext _context;

        public EthernetNetworkController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: EthernetNetwork
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.EthernetNetworks.Include(e => e.Device);
            return View(await databaseContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["Filter"] = SearchString;
        //    var Info = from i in _context.EthernetNetworks
        //               select i;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Info = Info.Where(i => i.DeviceId.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Speed.Contains(SearchString));
        //        //Info = Info.Where(i => i.Wireless.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Bluetooth.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.SerialNumber.Contains(SearchString));
        //        //Info = Info.Where(i => i.Destroyed.ToString().Contains(SearchString));
        //        //Info = Info.Where(i => i.Notes.Contains(SearchString));

        //    }
        //    return View(Info);
        //}



        // GET: EthernetNetwork/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EthernetNetworks == null)
            {
                return NotFound();
            }

            var ethernetNetwork = await _context.EthernetNetworks
                .Include(e => e.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ethernetNetwork == null)
            {
                return NotFound();
            }

            return View(ethernetNetwork);
        }

        // GET: EthernetNetwork/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id");
            return View();
        }

        // POST: EthernetNetwork/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceId,Speed,Wireless,Bluetooth,SerialNumber,Destroyed,Notes")] EthernetNetwork ethernetNetwork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ethernetNetwork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", ethernetNetwork.DeviceId);
            return View(ethernetNetwork);
        }

        // GET: EthernetNetwork/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EthernetNetworks == null)
            {
                return NotFound();
            }

            var ethernetNetwork = await _context.EthernetNetworks.FindAsync(id);
            if (ethernetNetwork == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", ethernetNetwork.DeviceId);
            return View(ethernetNetwork);
        }

        // POST: EthernetNetwork/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceId,Speed,Wireless,Bluetooth,SerialNumber,Destroyed,Notes")] EthernetNetwork ethernetNetwork)
        {
            if (id != ethernetNetwork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ethernetNetwork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EthernetNetworkExists(ethernetNetwork.Id))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceInformations, "Id", "Id", ethernetNetwork.DeviceId);
            return View(ethernetNetwork);
        }

        // GET: EthernetNetwork/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EthernetNetworks == null)
            {
                return NotFound();
            }

            var ethernetNetwork = await _context.EthernetNetworks
                .Include(e => e.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ethernetNetwork == null)
            {
                return NotFound();
            }

            return View(ethernetNetwork);
        }

        // POST: EthernetNetwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EthernetNetworks == null)
            {
                return Problem("Entity set 'DatabaseContext.EthernetNetworks'  is null.");
            }
            var ethernetNetwork = await _context.EthernetNetworks.FindAsync(id);
            if (ethernetNetwork != null)
            {
                _context.EthernetNetworks.Remove(ethernetNetwork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EthernetNetworkExists(int id)
        {
            return _context.EthernetNetworks.Any(e => e.Id == id);
        }
    }
}
