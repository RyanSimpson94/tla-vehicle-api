using System.Collections.Generic;
using Vehicle.Data.Repositories;

namespace Vehicle.Business.Managers
{
    public class VehicleManager
    {
        private readonly IVehicleRepository _vehicleRepo;

        public VehicleManager(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public IList<Entities.Dto.VehicleGroup> GetVehicleGroups()
        {
            return _vehicleRepo.GetVehicleGroups();
        }

        public IList<Entities.Dto.Vehicle> GetVehicles()
        {
            return _vehicleRepo.GetVehicles();
        }

        public Entities.Dto.Vehicle GetVehicle(int vehicleId)
        {
			return _vehicleRepo.GetVehicle(vehicleId);
        }

		public Entities.Dto.Vehicle UpdateVehicle(int vehicleId, Vehicle.Entities.Dto.Vehicle vehicle)
		{
			return _vehicleRepo.UpdateVehicle(vehicleId, vehicle);
		}

        public Vehicle.Entities.Dto.Vehicle DeleteVehicle(int vehicleId)
        {
            return _vehicleRepo.DeleteVehicle(vehicleId);
        }
    }
}
