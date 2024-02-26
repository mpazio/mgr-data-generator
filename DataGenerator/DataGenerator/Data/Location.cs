namespace DataGenerator.Data
{
    public class Location
    {
        public string City { get; set; } = string.Empty;
        public Address Address { get; set; } = null!;
    }

    public class Address
    {
        public string StreetName { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
    }
}
