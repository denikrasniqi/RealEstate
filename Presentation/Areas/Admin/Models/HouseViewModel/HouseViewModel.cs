namespace Presentation.Areas.Admin.Models.HouseViewModel
{
    public class ApartmentViewModel
    {
        public string? Id { get; set; }
        public string? Type { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public string? City { get; set; } = null!;
        public int? Rooms { get; set; }
        public int? Kitchens { get; set; }
        public int? Bathrooms { get; set; }
        public string? PhoneNumber { get; set; } = null!;
        public int? Price { get; set; }
    }
}
