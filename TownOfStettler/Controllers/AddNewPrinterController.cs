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
using static System.Formats.Asn1.AsnWriter;

namespace TownOfStettler.Controllers
{
    public class AddNewPrinterController : Controller
    {
        private readonly DatabaseContext _context;
        public AddNewPrinterController(DatabaseContext context)
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
        public IActionResult EnterNewPrinter(string ownerLocationName, string ownerAddress, string ownerPhoneNumber, string printerType, string connectionType, string warrantyType, string warrantyLength, string warrantyExpiryDate, string tiedToDevice, string printerTOS, string printerSerNum, string printerModel, string store, string price, string date, string notes, string notesPrinter, string notesWarrenty)
        {
            ValidationException validationState = new ValidationException();

            if (string.IsNullOrEmpty(printerTOS))
            {
                validationState.SubExceptions.Add(new Exception("Printer TOS Number can not be empty."));
            }

            if (string.IsNullOrEmpty(printerSerNum))
            {
                validationState.SubExceptions.Add(new Exception("Printer Serial Number can not be empty."));
            }

            if (string.IsNullOrEmpty(printerModel))
            {
                validationState.SubExceptions.Add(new Exception("Printer Model can not be empty."));
            }

            if (string.IsNullOrEmpty(store))
            {
                validationState.SubExceptions.Add(new Exception("Purchase Store can not be empty."));
            }

            if (string.IsNullOrEmpty(price))
            {
                validationState.SubExceptions.Add(new Exception("Purchase Price can not be empty."));
            }

            if (string.IsNullOrEmpty(date))
            {
                validationState.SubExceptions.Add(new Exception("Purchase Date can not be empty."));
            }

            if (string.IsNullOrEmpty(printerType))
            {
                validationState.SubExceptions.Add(new Exception("Printer Type can not be empty."));
            }

            if (string.IsNullOrEmpty(connectionType))
            {
                validationState.SubExceptions.Add(new Exception("Printer Connection Type can not be empty."));
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

            DeviceInformation deviceId = null;
            foreach (DeviceInformation info in _context.DeviceInformations)
            {
                int tiedDevice = int.Parse(tiedToDevice);
                if (info.Id == tiedDevice)
                {
                    deviceId = info;
                };
                if (deviceId != null)
                {
                    DeviceInformation deviceInformation = new DeviceInformation()
                    {
                        DeviceTypeId = 5,  //int PK
                        OwnerLocation = ownerLocation.Id,  //int FK
                        TosNumber = printerTOS, // varchar(25) not null
                        SerialNumber = printerSerNum,  //varchar(30)
                        ModelNumber = printerModel,  //varchar(50)
                        PurchaseStore = store,  //varchar(30)
                        PurchasePrice = Math.Round(Decimal.Parse(price), 2),  //decimal(6,2)
                        PurchaseDate = DateOnly.Parse(date),  //date
                        OperatingSystem = "none",  //varchar(30)
                        Destroyed = false,  //bool
                        Notes = notes,  //text (nullable)
                    };

                    _context.DeviceInformations.Add(deviceInformation);
                    _context.SaveChanges();
                }
            if (printerType != null || connectionType != null)
            {
                Printer printer = new Printer()
                {
                    OwnerLocation = ownerLocation.Id,  //int FK
                    TosNumber = printerTOS,
                    DeviceId = tiedDevice,
                    Type = printerType,  //varchar(20)
                    ConnectionType = connectionType,  //varchar(15)
                    Notes = notesPrinter,  //text (nullable)
                };
                _context.Printers.Add(printer);
                _context.SaveChanges();
            }
            }
            //if (warrantyType != null || warrantyLength != null)
            //{
            //    Warranty warranty = new Warranty()
            //    {
            //        TypeOfWarranty = warrantyType,  //varchar(100)
            //        LengthOfWarranty = warrantyLength,  //varchar(15)
            //        WarrantyExpiryDate = DateOnly.Parse(warrantyExpiryDate),  //date (nullable)
            //        Notes = notesWarrenty,  //text (nullable)
            //    };
            //    _context.Warranties.Add(warranty);
            //}
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
