using Microsoft.AspNetCore.Mvc;
using TruckPlanningApp.Models;
using TruckPlanningApp.Services;

namespace TruckPlanningApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriversController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public ActionResult<List<Driver>> Get() => _driverService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDriver")]
        public ActionResult<Driver> Get(string id)
        {
            var driver = _driverService.Get(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        [HttpPost]
        public ActionResult<Driver> Create(Driver driver)
        {
            _driverService.Create(driver);
            return CreatedAtRoute("GetDriver", new { id = driver.Id }, driver);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Driver driverIn)
        {
            var driver = _driverService.Get(id);

            if (driver == null)
            {
                return NotFound();
            }

            _driverService.Update(id, driverIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var driver = _driverService.Get(id);

            if (driver == null)
            {
                return NotFound();
            }

            _driverService.Remove(id);
            return NoContent();
        }
    }
}
