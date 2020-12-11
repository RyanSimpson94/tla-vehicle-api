using System.Collections.Generic;

namespace Vehicle.Data.Mock
{
    public class MockVehicle
    {
        public List<Vehicle.Entities.Dto.Vehicle> vehicles { get; set; }
        public List<Vehicle.Entities.Dto.VehicleGroup> vehicleGroups { get; set; }

        public MockVehicle()
        {
            vehicles = getVehicles();
            vehicleGroups = new List<Vehicle.Entities.Dto.VehicleGroup>()
            {
                new Vehicle.Entities.Dto.VehicleGroup
                {
                    Id = 1,
                    Vehicles = getVehicles()
                }
            };
        }

        private List<Vehicle.Entities.Dto.Vehicle> getVehicles()
        {
            return new List<Vehicle.Entities.Dto.Vehicle>
            {
                new Vehicle.Entities.Dto.Vehicle()
                {
                    Id = 1,
                    Manufacturer = "Ford",
                    Name = "Fiesta",
                    Price = 17000,
                    ImgUrl = "https://www.gpas-cache.ford.com/guid/82b31e6f-06b4-3c63-bad8-5b6880f53640.png",
                    Order = 1,
                    isActive = true
                },
                new Vehicle.Entities.Dto.Vehicle()
                {
                    Id = 2,
                    Manufacturer = "Ford",
                    Name = "Focus",
                    Price = 22000,
                    ImgUrl = "https://www.gpas-cache.ford.com/guid/fb4f9f83-2063-387e-b23e-4728cd41fe15.png",
                    Order = 2,
                    isActive = true
                },
                new Vehicle.Entities.Dto.Vehicle()
                {
                    Id = 3,
                    Manufacturer = "Ford",
                    Name = "Mondeo",
                    Price = 23000,
                    ImgUrl = "https://www.gpas-cache.ford.com/guid/d51e9848-a912-3950-be76-77d933ec7558.png",
                    Order = 3,
                    isActive = false
                },
                new Vehicle.Entities.Dto.Vehicle()
                {
                    Id = 4,
                    Manufacturer = "Ford",
                    Name = "Kuga",
                    Price = 25500,
                    ImgUrl = "https://www.gpas-cache.ford.com/guid/e1e3937c-5190-32c7-b2cc-86697894e4e7.png",
                    Order = 4,
                    isActive = true
                },
                new Vehicle.Entities.Dto.Vehicle()
                {
                    Id = 5,
                    Manufacturer = "Ford",
                    Name = "Mustang Mach-E",
                    Price = 41000,
                    ImgUrl = "https://www.gpas-cache.ford.com/guid/d7afc86b-6ee3-332c-a23e-6df31812282b.png",
                    Order = 5,
                    isActive = true
                },
                new Vehicle.Entities.Dto.Vehicle()
                {
                    Id = 6,
                    Manufacturer = "Ford",
                    Name = "Mustang",
                    Price = 43000,
                    ImgUrl = "https://www.gpas-cache.ford.com/guid/e023a809-6c35-343c-88c2-f6728763852d.png",
                    Order = 6,
                    isActive = true
                }
            };
        }
    }
}
