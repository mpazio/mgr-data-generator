namespace DataGenerator.Data
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public Location Location { get; set; } = null!;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
