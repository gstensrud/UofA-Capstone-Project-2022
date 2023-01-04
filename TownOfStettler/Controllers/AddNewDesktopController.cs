//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using TownOfStettler.Data;
//using TownOfStettler.Models;
//using TownOfStettler.Models.Exceptions;
//using Newtonsoft.Json;
//using System.ComponentModel.DataAnnotations;
//using MessagePack;
//using ValidationException = TownOfStettler.Models.Exceptions.ValidationException;
//using static System.Formats.Asn1.AsnWriter;

//namespace TownOfStettler.Controllers
//{
//    public class AddNewDesktopController : Controller
//    {
//        private readonly DatabaseContext _context;
//        public AddNewDesktopController(DatabaseContext context)
//        {
//            _context = context;
//        }

//        //        public IActionResult Index()
//        //        {
//        //            // If there are exceptions, store them in the view data/bag
//        //            if (TempData["Exceptions"] != null)
//        //            {
//        //                ViewData["Exceptions"] =
//        //                     JsonConvert.DeserializeObject(TempData["Exceptions"].ToString(), typeof(ValidationException));
//        //            }

//        //            return View();
//        //        }

//        public IActionResult EnterNewDesktop(string ownerLocationName, string ownerAddress, string ownerPhoneNumber, string TOSnumber, string serverSerNumber, string serverModel, string pwrSupply, string store, string price, string date, string serverOS, string notes, string networkCardSpeed, string networkCardWireless, string networkCardBluetooth, string networkCardSerNum, string networkNotes, string hardDriveType, string hardDriveSize, string HDDserNum, string hardDriveNotes, string processorType, string processorSpeed, string processorSerNum, string processorGeneration, string processorCoreCount, string processorNotes, string RamSize, string ramType, string ramSpeed, string ramSerNum, string ramNotes, string miscellaneousDriveType, string miscellaneousDriveRemoveable, string miscDriveSerNum, string miscNotes, string soundCardBrand, string soundNotes, string videoCardBrand, string videoCardRamSize, string vidCardSerNum, string vidCardNotes, string videoCardOutputType, string videoCardOutputNumber, string outputNotes, string warrantyType, string warrantyLength, string warrantyExpiryDate, string warrantyNotes)
//        {
//            ValidationException validationState = new ValidationException();

//            //if (string.IsNullOrEmpty(ownerLocationName))
//            //{
//            //    validationState.SubExceptions.Add(new Exception("Error Message Here."));
//            //}
//            //if (string.IsNullOrEmpty(ownerAddress))
//            //{
//            //    validationState.SubExceptions.Add(new Exception("Error Message Here."));
//            //}
//            //if (string.IsNullOrEmpty(ownerPhoneNumber))
//            //{
//            //    validationState.SubExceptions.Add(new Exception("Error Message Here."));
//            //}
//            if (string.IsNullOrEmpty(TOSnumber))
//            {
//                validationState.SubExceptions.Add(new Exception("Server TOS Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(serverSerNumber))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Serial Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(serverModel))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Model Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(store))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Purchase Store can not be empty."));
//            }
//            if (string.IsNullOrEmpty(price))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Purchase Price can not be empty."));
//            }
//            if (string.IsNullOrEmpty(date))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Purchase Date can not be empty."));
//            }
//            if (string.IsNullOrEmpty(serverOS))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Operating System can not be empty."));
//            }
//            if (string.IsNullOrEmpty(networkCardSpeed))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Network Card Speed can not be empty."));
//            }
//            if (string.IsNullOrEmpty(networkCardWireless))
//            {
//                validationState.SubExceptions.Add(new Exception("You must answer true or false if the Server has a Wireless Network Card."));
//            }
//            if (string.IsNullOrEmpty(networkCardBluetooth))
//            {
//                validationState.SubExceptions.Add(new Exception("You must answer true or false if the Server has Bluetooth connectivity"));
//            }
//            if (string.IsNullOrEmpty(networkCardSerNum))
//            {
//                validationState.SubExceptions.Add(new Exception("Server Network Card Serial Number can not be empty.  If unknown, enter `unknown`."));
//            }
//            if (string.IsNullOrEmpty(hardDriveType))
//            {
//                validationState.SubExceptions.Add(new Exception("Hard Drive Type can not be empty."));
//            }
//            if (string.IsNullOrEmpty(hardDriveSize))
//            {
//                validationState.SubExceptions.Add(new Exception("Hard Drive Size can not be empty."));
//            }
//            if (string.IsNullOrEmpty(HDDserNum))
//            {
//                validationState.SubExceptions.Add(new Exception("Hard Drive Serial Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(processorType))
//            {
//                validationState.SubExceptions.Add(new Exception("The Processor Type can not be empty."));
//            }
//            if (string.IsNullOrEmpty(processorSpeed))
//            {
//                validationState.SubExceptions.Add(new Exception("The Processor Speed can not be empty."));
//            }
//            if (string.IsNullOrEmpty(processorSerNum))
//            {
//                validationState.SubExceptions.Add(new Exception("The Processor Serial Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(ramType))
//            {
//                validationState.SubExceptions.Add(new Exception("The Ram Type can not be empty."));
//            }
//            if (string.IsNullOrEmpty(RamSize))
//            {
//                validationState.SubExceptions.Add(new Exception("The Ram Size can not be empty."));
//            }
//            if (string.IsNullOrEmpty(ramSerNum))
//            {
//                validationState.SubExceptions.Add(new Exception("The Ram Serial Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(miscellaneousDriveType))
//            {
//                validationState.SubExceptions.Add(new Exception("The Miscellaneous Drive Type can not be empty."));
//            }
//            if (string.IsNullOrEmpty(miscellaneousDriveRemoveable))
//            {
//                validationState.SubExceptions.Add(new Exception("You must answer true or false if the Miscellaneous Drive is Removeable."));
//            }
//            if (string.IsNullOrEmpty(miscDriveSerNum))
//            {
//                validationState.SubExceptions.Add(new Exception("The Miscellaneous Drive Serial Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(videoCardRamSize))
//            {
//                validationState.SubExceptions.Add(new Exception("The Video Card Ram Size can not be empty."));
//            }
//            if (string.IsNullOrEmpty(vidCardSerNum))
//            {
//                validationState.SubExceptions.Add(new Exception("The Video Card Serial Number can not be empty."));
//            }
//            if (string.IsNullOrEmpty(videoCardOutputNumber))
//            {
//                validationState.SubExceptions.Add(new Exception("You must enter the number of Outputs the Video Card has."));
//            }
//            if (string.IsNullOrEmpty(warrantyType))
//            {
//                validationState.SubExceptions.Add(new Exception("You must enter the Type of Warranty."));
//            }
//            if (string.IsNullOrEmpty(warrantyLength))
//            {
//                validationState.SubExceptions.Add(new Exception("You must enter the Warranty Length."));
//            }


//            //            OwnerLocation ownerLocation = null;
//            //            foreach (OwnerLocation entry in _context.OwnerLocations)
//            //            {
//            //                if (entry.Name == ownerLocationName)
//            //                {
//            //                    ownerLocation = entry;
//            //                };
//            //            }
//            //            if (ownerLocation is null)
//            //            {
//            //                ownerLocation = new OwnerLocation()
//            //                {
//            //                    Name = ownerLocationName,  //varchar(60)
//            //                    Address = ownerAddress,  //varchar(75)
//            //                    PhoneNumber = ownerPhoneNumber,  //text (nullable)
//            //                };

//            //                _context.OwnerLocations.Add(ownerLocation);
//            //                _context.SaveChanges();
//            //            }

//            DeviceInformation deviceInformation = new DeviceInformation()
//            {
//                DeviceTypeId = 2,  //int FK
//                OwnerLocation = ownerLocation.Id,  //int FK
//                TosNumber = TOSnumber,  //varchar(25)
//                SerialNumber = serverSerNumber,  //varchar(30)
//                ModelNumber = serverModel,  //varchar(50)
//                PowerSupply = pwrSupply,  //varchar(75) (nullable)
//                PurchaseStore = store,  //varchar(30)
//                PurchasePrice = Math.Round(Decimal.Parse(price), 2),  //decimal(6,2)
//                PurchaseDate = DateOnly.Parse(date),  //date
//                OperatingSystem = serverOS,  //varchar(30)
//                Destroyed = false,  //bool
//                Notes = notes,  //text  (nullable)
//            };
//            _context.DeviceInformations.Add(deviceInformation);
//            _context.SaveChanges();

//            //            if (networkCardSpeed != null || networkCardBluetooth != null || networkCardWireless != null || networkCardSerNum != null || networkCardSerNum != null)
//            //            {
//            //                EthernetNetwork ethernetNetwork = new EthernetNetwork()
//            //                {
//            //                    DeviceId = deviceInformation.Id,  //int FK
//            //                    Speed = networkCardSpeed,  //varchar (30)
//            //                    Wireless = bool.Parse(networkCardWireless),  //bool
//            //                    Bluetooth = bool.Parse(networkCardBluetooth),  //bool
//            //                    SerialNumber = networkCardSerNum,  //varchar(30)
//            //                    Destroyed = false,  //bool
//            //                    Notes = networkNotes  //text (nullable)
//            //                };
//            //                _context.EthernetNetworks.Add(ethernetNetwork);
//            //                _context.SaveChanges();

//            if (hardDriveType != null || hardDriveSize != null || HDDserNum != null)
//            {
//                HardDrive hardDrive = new HardDrive()
//                {
//                    DeviceId = deviceInformation.Id,  //int FK
//                    Type = hardDriveType,  //varchar(20)
//                    SizeGb = int.Parse(hardDriveSize),  //int(7)
//                    SerialNumber = HDDserNum,  //varchar(30)
//                    Destroyed = false,
//                    Notes = hardDriveNotes  //text  (nullable)
//                };
//                _context.HardDrives.Add(hardDrive);
//                _context.SaveChanges();
//            }
//            if (processorType != null || processorSpeed != null || processorSerNum != null)
//            {
//                Processor processor = new Processor()
//                {
//                    DeviceId = deviceInformation.Id,  //int FK
//                    Type = processorType,  //varchar(25)
//                    SpeedGhz = Math.Round(Decimal.Parse(processorSpeed), 2),  //decimal(5,3)
//                    SerialNumber = processorSerNum,  //varchar(30)
//                    Generation = int.Parse(processorGeneration),  //int(11) (nullable)
//                    CoreCount = int.Parse(processorCoreCount),  //int(11) (nullable)
//                    Destroyed = false,  //bool
//                    Notes = processorNotes
//                };
//                _context.Processors.Add(processor);
//                _context.SaveChanges();
//            }
//            if (ramType != null || RamSize != null || ramSerNum != null)
//            {
//                Ram ram = new Ram()
//                {
//                    DeviceId = deviceInformation.Id,  //int FK
//                    Type = ramType,  //varchar(15)
//                    SizeGb = int.Parse(RamSize),  //int(11)
//                    SpeedMhz = int.Parse(ramSpeed),  //int(5) (nullable)
//                    SerialNumber = ramSerNum,  //varchar(30)
//                    Destroyed = false,  //bool
//                    Notes = ramNotes
//                };
//                _context.Rams.Add(ram);
//                _context.SaveChanges();
//            }
//            if (miscellaneousDriveType != null || miscellaneousDriveRemoveable != null || miscDriveSerNum != null)
//            {
//                MiscellaneousDrive MiscellaneousDrive = new MiscellaneousDrive()
//                {
//                    DeviceId = deviceInformation.Id,  //int FK
//                    Type = miscellaneousDriveType,  //varchar(30)
//                    Removable = bool.Parse(miscellaneousDriveRemoveable),  //bool
//                    SerialNumber = miscDriveSerNum,  //varchar(30)
//                    Destroyed = false,  //bool
//                    Notes = miscNotes  //text  (nullable)
//                };
//                _context.MiscellaneousDrives.Add(MiscellaneousDrive);
//                _context.SaveChanges();
//            }
//            if (soundCardBrand != null)
//            {
//                SoundCard soundCard = new SoundCard()
//                {
//                    DeviceId = deviceInformation.Id,  //int FK
//                    Brand = soundCardBrand,  //varchar(20) (nullable)
//                    Destroyed = false, //bool
//                    Notes = soundNotes
//                };
//                _context.SoundCards.Add(soundCard);
//                _context.SaveChanges();
//            }
//            while (videoCardRamSize != null)
//            {
//                if (videoCardRamSize != null || vidCardSerNum != null)
//                {
//                    VideoCard videoCard = new VideoCard()
//                    {
//                        DeviceId = deviceInformation.Id,  //int FK
//                        Brand = videoCardBrand,  //varchar(20) (nullable)
//                        RamSizeGb = int.Parse(videoCardRamSize),  //int(11)
//                        SerialNumber = vidCardSerNum,  //varchar(30)
//                        Destroyed = false,  //bool
//                        Notes = vidCardNotes  //text  (nullable)
//                    };
//                    _context.VideoCards.Add(videoCard);
//                    _context.SaveChanges();

//                    //                        if (videoCardOutputNumber != null)
//                    //                        {
//                    //                            // if statement to check to see if the input (PK) is on the table is needed here
//                    //                            Output output = new Output()
//                    //                            {
//                    //                                Type = videoCardOutputType,  //varchar(10) PK
//                    //                                VideoCardId = videoCard.Id,  //_context.VideoCards.Id,  //int FK
//                    //                                NumberOfOutputs = int.Parse(videoCardOutputNumber),  //int(2)
//                    //                                Notes = outputNotes  //text  (nullable)
//                    //                            };
//                    //                            _context.Outputs.Add(output);
//                    //                            _context.SaveChanges();
//                    //                        }
//                    //                    }

//                    //                }
//                    //                if (warrantyType != null || warrantyLength != null)
//                    //                {
//                    //                    Warranty warranty = new Warranty()
//                    //                    {
//                    //                        DeviceId = deviceInformation.Id,  //int FK
//                    //                        TypeOfWarranty = warrantyType,  //varchar(100)
//                    //                        LengthOfWarranty = warrantyLength,  //varchar(15)
//                    //                        WarrantyExpiryDate = DateOnly.Parse(warrantyExpiryDate),  //date (nullable)
//                    //                        Notes = warrantyNotes  //text  (nullable)
//                    //                    };
//                    //                    _context.Warranties.Add(warranty);
//                    //                }


//                    //                _context.SaveChanges();
//                    //                return RedirectToAction("Index");

//                }
//            }
//        }
//    }
//}