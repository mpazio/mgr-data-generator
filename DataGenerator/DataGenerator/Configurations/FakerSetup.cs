using Bogus;
using Bogus.DataSets;
using DataGenerator.Data;

namespace DataGenerator.Configurations
{
    public static class FakerSetup
    {
        public static Faker<User> SetupUser()
        {
            var testOrders = SetupOrder();
            var addresses = SetupAddress();
            var locations = SetupLocation(addresses);

            int userIDs = 1;
            var users = new Faker<User>()
                .StrictMode(true)
                .RuleFor(e => e.ID, f => userIDs++)
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.Orders, f => testOrders.Generate(5).ToList())
                .RuleFor(u => u.Location, f => locations.Generate(1).First());

            return users;
        }

        public static Faker<Order> SetupOrder()
        {
            var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };
            var orderIds = 1;
            return new Faker<Order>()
                .StrictMode(true)
                .RuleFor(o => o.OrderId, f => orderIds++)
                .RuleFor(o => o.Item, f => f.PickRandom(fruit))
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
                .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));
        }

        public static Faker<Data.Address> SetupAddress()
        {
            return new Faker<Data.Address>()
                .RuleFor(e => e.StreetName, f => f.Address.StreetName())
                .RuleFor(e => e.BuildingNumber, f => f.Address.BuildingNumber());
        }

        public static Faker<Location> SetupLocation(Faker<Data.Address> addresses)
        {
            return new Faker<Location>()
                .StrictMode(true)
                .RuleFor(e => e.City, f => f.Address.City())
                .RuleFor(e => e.Address, f => addresses.Generate(1).First());
        }
    }
}
