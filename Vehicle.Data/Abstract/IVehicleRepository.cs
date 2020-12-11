using System.Collections.Generic;

namespace Vehicle.Data.Repositories
{
    public interface IVehicleRepository
    {
        IList<Entities.Dto.VehicleGroup> GetVehicleGroups();
        IList<Entities.Dto.Vehicle> GetVehicles();
        Entities.Dto.Vehicle GetVehicle(int vehicleId);
        Entities.Dto.Vehicle UpdateVehicle(int vehicleId, Entities.Dto.Vehicle vehicle);
        Entities.Dto.Vehicle DeleteVehicle(int vehicleId);
    }
}
