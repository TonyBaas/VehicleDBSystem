using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VehicleDBSystem.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

/*
    Tony R Baas
    Dec 5, 2023
    Vehicle Database System
*/

namespace VehicleDBSystem.Controllers
{
    public class HomeController : Controller
    {
        private VehicleContext context { get; set; }

        public HomeController(VehicleContext ctx){
            context = ctx;
        }

        public IActionResult Index(string filterType)
        {
            //var vehicles = context.Vehicles.OrderBy(m => m.Make).ToList();

            IQueryable<Vehicle> query = context.Vehicles.OrderBy(m => m.Make);


            if (!string.IsNullOrEmpty(filterType))
            {
                // Apply the filter if a type is selected
                query = query.Where(v => v.Type == filterType);
            }

            var vehicles = query.OrderBy(m => m.Year).ToList();

            return View(vehicles);
        }
    }
}