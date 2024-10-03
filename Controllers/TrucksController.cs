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

            _truckService.Remove(id);

            return NoContent();
        }


        [HttpGet("available")]
        public ActionResult<List<Truck>> GetAvailableTrucks()
        {
            return _truckService.GetAvailableTrucks();
        }

        [HttpPost("{truckId}/assign-driver/{driverId}")]
        public IActionResult AssignDriverToTruck(string truckId, string driverId)
        {
            try
            {
                _truckService.AssignDriverToTruck(truckId, driverId);
                return Ok(new { message = "Driver assigned successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
