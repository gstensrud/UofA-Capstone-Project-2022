using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TownOfStettler.Data;
using TownOfStettler.Models;
using TownOfStettler.Models.Exceptions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MessagePack;
using ValidationException = TownOfStettler.Models.Exceptions.ValidationException;

namespace TownOfStettler.Controllers
{
    public class AddNewMonitorController : Controller
    {
        private readonly DatabaseContext _context;
        public AddNewMonitorController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // If there are exceptions, store them in the view data/bag
            if (TempData["Exceptions"] != null)
            {
                ViewData["Exceptions"] =
                     JsonConvert.DeserializeObject(TempData["Exceptions"].ToString(), typeof(ValidationException));
            }

            return View();
        }

        public IActionResult EnterNewMonitor(string ownerLocationName, string ownerAddress, string ownerPhoneNumber, string TosNumber, string monitorSize, string monitorType, string monitorResolution, string monitorRefreshRate, string monitorSerialNumber, string monitorOutput, string monOutNum, string warrantyType, string warrantyLength, string warrantyExpiryDate, string notes)
        {
            ValidationException validationState = new ValidationException();

            if (string.IsNullOrEmpty(TosNumber))
            {
                validationState.SubExceptions.Add(new Exception("TOS Number can not be empty."));
            }
            if (string.IsNullOrEmpty(monitorSize))
            {
                validationState.SubExceptions.Add(new Exception("Monitor Size can not be empty."));
            }
            if (string.IsNullOrEmpty(monitorType))
            {
                validationState.SubExceptions.Add(new Exception("Monitor Type can not be empty."));
            }
            if (string.IsNullOrEmpty(monitorSerialNumber))
            {
                validationState.SubExceptions.Add(new Exception("Monitor Serial Number can not be empty."));
            }
            if (string.IsNullOrEmpty(warrantyType))
            {
                validationState.SubExceptions.Add(new Exception("Warrenty Type can not be empty."));
            }
            if (string.IsNullOrEmpty(warrantyLength))
            {
                validationState.SubExceptions.Add(new Exception("Warrenty Length can not be empty."));
            }

            OwnerLocation ownerLocation = null;
            foreach (OwnerLocation entry in _context.OwnerLocations)
            {
                if (entry.Name == ownerLocationName)
                {
                    ownerLocation = entry;
                };
            }
            if (ownerLocation is null)
            {
                ownerLocation = new OwnerLocation()
                {
                    Name = ownerLocationName,  //varchar(60)
                    Address = ownerAddress,  //varchar(75)
                    PhoneNumber = ownerPhoneNumber,  //text (nullable)
                };

                _context.OwnerLocations.Add(ownerLocation);
                _context.SaveChanges();
            }

            if (monitorSize != null || monitorType != null || monitorSerialNumber != null)
            {
                DisplayMonitor displayMonitor = new DisplayMonitor()
            {
                TosNumber = TosNumber, //varchar(25)
                ViewSizeInches = Decimal.Parse(monitorSize),  //decimal (3,2)
                ViewType = monitorType,  //varchar (30)
                Resolution = monitorResolution,  //varchar(20) (nullable)
                RefreshRateHz = int.Parse(monitorRefreshRate),  //int(3) (nullable)
                SerialNumber = monitorSerialNumber,  //varchar(50)
                OutputType = monitorOutput,  //varchar(10) (nullable)
                NumberOfOutputs = int.Parse(monOutNum),  //int (nullable)
                Notes = notes,  //text (nullable)
                };
            _context.DisplayMonitors.Add(displayMonitor);
            _context.SaveChanges();
            }
            // need code here to find out if the monitor is in use or not, if so, add to the in-use monitors table

            //if (warrantyType != null || warrantyLength != null)
            //{
            //    Warranty warranty = new Warranty()
            //    {
            //        TypeOfWarranty = warrantyType,  //varchar(100)
            //        LengthOfWarranty = warrantyLength,  //varchar(15)
            //        WarrantyExpiryDate = DateOnly.Parse(warrantyExpiryDate),  //date (nullable)
            //        Notes = notes,  //text (nullable)
            //    };
            //    _context.Warranties.Add(warranty);
            //}

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
