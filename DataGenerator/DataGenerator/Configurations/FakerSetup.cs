using Bogus;
using DataGenerator.Data;

namespace DataGenerator.Configurations
{
    public static class FakerSetup
    {
        public static Faker<User> SetupUser(int? seed = null)
        {
            var testOrders = SetupOrder(seed);
            var addresses = SetupAddress(seed);
            var locations = SetupLocation(addresses, seed);

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

            if(seed is not null)
            {
                users.UseSeed(seed.Value);
            }

            return users;
        }

        public static Faker<Order> SetupOrder(int? seed = null)
        {
            var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };
            var orderIds = 1;
            var orders =  new Faker<Order>()
                .StrictMode(true)
                .RuleFor(o => o.OrderId, f => orderIds++)
                .RuleFor(o => o.Item, f => f.PickRandom(fruit))
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
                .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));
            
            if(seed is not null)
            {
                orders.UseSeed(seed.Value);
            }

            return orders;
        }

        public static Faker<Data.Address> SetupAddress(int? seed = null)
        {
            var addresses =  new Faker<Data.Address>()
                .StrictMode(true)
                .RuleFor(e => e.StreetName, f => f.Address.StreetName())
                .RuleFor(e => e.BuildingNumber, f => f.Address.BuildingNumber());

            if(seed is not null)
            {
                addresses.UseSeed(seed.Value);
            }

            return addresses;
        }

        public static Faker<Location> SetupLocation(Faker<Data.Address> addresses, int? seed = null)
        {
            var locations =  new Faker<Location>()
                .StrictMode(true)
                .RuleFor(e => e.City, f => f.Address.City())
                .RuleFor(e => e.Address, f => addresses.Generate(1).First());

            if(seed is not null)
            {
                locations.UseSeed(seed.Value);
            }
            
            return locations;
        }
    }
}
