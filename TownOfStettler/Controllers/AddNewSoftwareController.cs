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
    public class AddNewSoftwareController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
