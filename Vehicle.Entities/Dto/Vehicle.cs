using System.Collections.Generic;

namespace Vehicle.Entities.Dto
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string DisplayName => $"{Manufacturer} {Name}";
		public decimal Price { get; set; }
		public string DisplayPrice => $"£{Price.ToString("#,##0.00")}";
        public IList<Vehicle> Trims { get; set; }
        public int Order { get; set; }
        public string ImgUrl { get; set; }
        public bool isActive { get; set; }
    }
}
