using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Business.Managers;
using Vehicle.Entities;
using Vehicle.Entities.Responses;

namespace Vehicle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleManager _vehicleManager;

        public VehicleController(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpGet(Name = "GetAllVehicles")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Entities.Dto.Vehicle))]
        [AllowAnonymous]
        public IActionResult GetAllVehicles()
        {
            var v = _vehicleManager.GetVehicles();
            return Ok(v);
        }

        [HttpGet("{vehicleId:int}", Name = "GetVehicleById")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Entities.Dto.Vehicle))]
        [AllowAnonymous]
        public IActionResult GetVehicleById(int vehicleId)
        {
            var v = _vehicleManager.GetVehicle(vehicleId);
            return Ok(v);
        }

        [HttpPut("{vehicle:int}", Name = "UpdateVehicle")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult UpdateVehicle(int vehicleId, [FromBody] Entities.Dto.Vehicle vehicle)
        {
			var v = _vehicleManager.UpdateVehicle(vehicleId, vehicle);
			if (v == null) return BadRequest(new Message { Text = "Failed to update the vehicle, please try again." });
			return Ok(v);
        }

        [HttpDelete("{vehicleId:int}", Name = "DeleteVehicle")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult DeleteVehicle(int vehicleId)
        {
            var v = _vehicleManager.DeleteVehicle(vehicleId);
            if (v == null) return NotFound();
            return Ok(v);
        }
    }
}
