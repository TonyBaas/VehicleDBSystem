using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VehicleDBSystem.Models;

namespace VehicleDBSystem.Controllers
{
    public class HomeController : Controller
    {
        private VehicleContext context { get; set; }

        public HomeController(VehicleContext ctx){
            context = ctx;
        }

        public IActionResult Index()
        {
            var vehicles = context.Vehicles.OrderBy(m => m.Make).ToList();
            return View(vehicles);
        }
    }
}