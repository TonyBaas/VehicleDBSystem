using Microsoft.AspNetCore.Mvc;
using VehicleDBSystem.Models;


namespace VehicleDBSystem.Controllers
{
    public class VehicleController : Controller
    {
        private VehicleContext context { get; set; }

        public VehicleController(VehicleContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Vehicle());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit"; 
            var vehicle = context.Vehicles.Find(id); 
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (vehicle.VehicleId == 0) context.Vehicles.Add(vehicle);
                else
                    context.Vehicles.Update(vehicle); 
                    context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (vehicle.VehicleId == 0) ? "Add" : "Edit"; 
                return View(vehicle);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vehicle = context.Vehicles.Find(id); 
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
