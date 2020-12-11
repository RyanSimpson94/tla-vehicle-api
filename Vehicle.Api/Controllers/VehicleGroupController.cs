using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Entities.Dto;
using Vehicle.Entities.Responses;
using Vehicle.Business.Managers;

namespace Vehicle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class VehicleGroupController : ControllerBase
    {
        private readonly VehicleManager _vehicleManager;

        public VehicleGroupController(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpGet(Name = "GetAllVehicleGroups")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(VehicleGroup))]
        [AllowAnonymous]
        public IActionResult GetAllVehicleGroups()
        {
            var v = _vehicleManager.GetVehicleGroups();
            return Ok(v);
        }
    }
}
