using Microsoft.AspNetCore.Mvc;
using TruckPlanningApp.Models;
using TruckPlanningApp.Services;

namespace TruckPlanningApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly TruckService _truckService;

        public TrucksController(TruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet]
        public ActionResult<List<Truck>> Get() => _truckService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTruck")]
        public ActionResult<Truck> Get(string id)
        {
            var truck = _truckService.Get(id);

            if (truck == null)
            {
                return NotFound();
            }

            return truck;
        }

        [HttpPost]
        public ActionResult<Truck> Create(Truck truck)
        {
            _truckService.Create(truck);

            return CreatedAtRoute("GetTruck", new { id = truck.Id }, truck);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Truck truckIn)
        {
            var truck = _truckService.Get(id);

            if (truck == null)
            {
                return NotFound();
            }

            _truckService.Update(id, truckIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var truck = _truckService.Get(id);

            if (truck == null)
            {
                return NotFound();
            }

            _truckService.Remove(truck.Id);

            return NoContent();
        }
    }
}
