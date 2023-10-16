using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VehicleDBSystem.Models;

namespace VehicleDBSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}