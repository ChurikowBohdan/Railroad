using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Entities;

namespace Railroad.DAL.Data
{
    public class RailroadDbContext : DbContext
    {
        public RailroadDbContext(DbContextOptions<RailroadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            // -------- Persons --------
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Ivan", Surname = "Petrenko", PhoneNumber = "380931234567", Country = "Ukraine", City = "Kyiv", BirthDate = new DateTime(1990, 5, 20) },
                new Person { Id = 2, Name = "Olena", Surname = "Shevchenko", PhoneNumber = "380671112233", Country = "Ukraine", City = "Lviv", BirthDate = new DateTime(1995, 10, 12) }
            );

            // -------- Customers --------
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, PersonId = 1, DiscountValue = 10, Email = "ivan@mail.com", RegistrationDate = new DateTime(2023, 8, 28) },
                new Customer { Id = 2, PersonId = 2, DiscountValue = 5, Email = "olena@mail.com", RegistrationDate = new DateTime(2022, 2, 1) }
            );

            // -------- Trains --------
            modelBuilder.Entity<Train>().HasData(
                new Train { Id = 1, Name = "Intercity-1", NumberOfSeats = 200 },
                new Train { Id = 2, Name = "Express-5", NumberOfSeats = 150 }
            );

            // -------- TrainRoutes --------
            modelBuilder.Entity<TrainRoute>().HasData(
                new TrainRoute { Id = 1, Name = "Kyiv - Lviv Route", TrainId = 1 },
                new TrainRoute { Id = 2, Name = "Lviv - Odesa Route", TrainId = 2 }
            );

            // -------- Stations --------
            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, Name = "Central Station", CityName = "Kyiv", DistrictName = "Podil", NuberOfPlatforms = 5 },
                new Station { Id = 2, Name = "South Station", CityName = "Lviv", DistrictName = "Halych", NuberOfPlatforms = 3 }
            );

            // -------- Price --------
            modelBuilder.Entity<Price>().HasData(
                new Price { Id = 1, PriceForKGOfCarriageWeight = 2.5m, PriceForKilometer = 0.5m }
            );

            // -------- Tickets --------
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1,
                    TrainRouteId = 1,
                    PriceId = 1,
                    DepartureStationId = 1,
                    DestinationStationId = 2,
                    CustomerId = 1,
                    CarriageWeight = 10,
                    Seat = 12,
                    CarriagePrice = 25m,
                    RoadPrice = 270m,
                    FinalPrice = 295m,
                    PurchaseDate = new DateTime(2024, 9, 12, 5, 2, 3)
                },
                new Ticket
                {
                    Id = 2,
                    TrainRouteId = 2,
                    PriceId = 1,
                    DepartureStationId = 2,
                    DestinationStationId = 1,
                    CustomerId = 2,
                    CarriageWeight = 15,
                    Seat = 8,
                    CarriagePrice = 37.5m,
                    RoadPrice = 270m,
                    FinalPrice = 307.5m,
                    PurchaseDate = new DateTime(2025, 8, 28, 9, 1, 1)
                },
                new Ticket
                {
                    Id = 3,
                    TrainRouteId = 1,
                    PriceId = 1,
                    DepartureStationId = 2,
                    DestinationStationId = 1,
                    CustomerId = 2,
                    CarriageWeight = 12,
                    Seat = 9,
                    CarriagePrice = 30m,
                    RoadPrice = 270m,
                    FinalPrice = 300m,
                    PurchaseDate = new DateTime(2024, 7, 28, 8, 11, 12)
                }
            );

            // -------- RoutePoints --------
            modelBuilder.Entity<RoutePoint>().HasData(
                new RoutePoint
                {
                    Id = 1,
                    TrainRouteId = 1,
                    StationId = 1,
                    ArrivalTime = new DateTime(2025, 8, 28, 9, 0, 0),
                    DepartureTime = new DateTime(2025, 8, 28, 9, 15, 0),
                    Platform = 1,
                    Order = 1,
                    DistanceFromPreviousStation = 0
                },
                new RoutePoint
                {
                    Id = 2,
                    TrainRouteId = 1,
                    StationId = 2,
                    ArrivalTime = new DateTime(2025, 8, 28, 12, 0, 0),
                    DepartureTime = new DateTime(2025, 8, 28, 12, 10, 0),
                    Platform = 2,
                    Order = 2,
                    DistanceFromPreviousStation = 540
                }
            );

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TrainRoute> TrainRoutes { get; set; }
        public DbSet<Train> Trains { get; set; }

    }
}
