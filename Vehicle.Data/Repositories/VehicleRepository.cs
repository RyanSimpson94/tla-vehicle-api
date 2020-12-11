using Vehicle.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Vehicle.Data.Mock;

namespace Vehicle.Data.Repositories
{
    public class MockVehicleRepository : IVehicleRepository
    {
        private readonly MockVehicle _mockVehicle = new MockVehicle();

        public MockVehicleRepository()
        {
         
        }

        public IList<Entities.Dto.Vehicle> GetVehicles()
        {
            return _mockVehicle.vehicles.Where(v => v.isActive).OrderBy(v => v.Order).ToList();
		}

		public Entities.Dto.Vehicle GetVehicle(int vehicleId)
        {
            return _mockVehicle.vehicles.FirstOrDefault(v => v.Id == vehicleId);
		}

		public Entities.Dto.Vehicle UpdateVehicle(int vehicleid, Entities.Dto.Vehicle vehicle)
		{
			throw new NotImplementedException();
		}

		public Entities.Dto.Vehicle DeleteVehicle(int vehicleId)
        {
			throw new NotImplementedException();
        }

        public IList<VehicleGroup> GetVehicleGroups()
        {
            return _mockVehicle.vehicleGroups;
        }
    }
}
