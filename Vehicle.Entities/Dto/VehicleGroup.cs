using System.Collections.Generic;

namespace Vehicle.Entities.Dto
{
    public class VehicleGroup
    {
        public int Id { get; set; }
        public IList<Vehicle> Vehicles { get; set; }
        public int Order { get; set; }
    }
}
