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

            // ---------- decimal precision ----------
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            // ---------- Stations ----------
            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, Name = "Central Station", CityName = "Kyiv", DistrictName = "Podil", NumberOfPlatforms = 5 },
                new Station { Id = 2, Name = "South Station", CityName = "Lviv", DistrictName = "Halych", NumberOfPlatforms = 3 },
                new Station { Id = 3, Name = "North Station", CityName = "Odesa", DistrictName = "Primorsky", NumberOfPlatforms = 4 },
                new Station { Id = 4, Name = "East Station", CityName = "Dnipro", DistrictName = "Novokodatsky", NumberOfPlatforms = 2 },
                new Station { Id = 5, Name = "West Station", CityName = "Kharkiv", DistrictName = "Kholodnohirsk", NumberOfPlatforms = 3 },
                new Station { Id = 6, Name = "Central Vinnytsia", CityName = "Vinnytsia", DistrictName = "Center", NumberOfPlatforms = 2 },
                new Station { Id = 7, Name = "Cherkasy Station", CityName = "Cherkasy", DistrictName = "Center", NumberOfPlatforms = 2 },
                new Station { Id = 8, Name = "Zhytomyr Station", CityName = "Zhytomyr", DistrictName = "Center", NumberOfPlatforms = 2 },
                new Station { Id = 9, Name = "Poltava Station", CityName = "Poltava", DistrictName = "Center", NumberOfPlatforms = 2 }
            );

            // ---------- Trains ----------
            modelBuilder.Entity<Train>().HasData(
                new Train { Id = 1, Name = "Intercity-1", NumberOfSeats = 200 },
                new Train { Id = 2, Name = "Express-5", NumberOfSeats = 150 },
                new Train { Id = 3, Name = "Rapid-3", NumberOfSeats = 180 },
                new Train { Id = 4, Name = "Local-2", NumberOfSeats = 100 },
                new Train { Id = 5, Name = "NightLine-7", NumberOfSeats = 220 }
            );

            // ---------- Persons ----------
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Ivan", Surname = "Petrenko", Email = "Petrenko1@gmail.com", PhoneNumber = "380931234567", Country = "Ukraine", City = "Kyiv", BirthDate = new DateTime(1990, 5, 20) },
                new Person { Id = 2, Name = "Olena", Surname = "Shevchenko", Email = "Shevchenko2@gmail.com", PhoneNumber = "380671112233", Country = "Ukraine", City = "Lviv", BirthDate = new DateTime(1995, 10, 12) },
                new Person { Id = 3, Name = "Serhiy", Surname = "Koval", Email = "Koval3@gmail.com", PhoneNumber = "380501234567", Country = "Ukraine", City = "Odesa", BirthDate = new DateTime(1988, 3, 15) },
                new Person { Id = 4, Name = "Kateryna", Surname = "Bondarenko", Email = "Bondarenko4@gmail.com", PhoneNumber = "380631112233", Country = "Ukraine", City = "Dnipro", BirthDate = new DateTime(1992, 7, 22) },
                new Person { Id = 5, Name = "Mykola", Surname = "Shevtsov", Email = "Shevtsov5@gmail.com", PhoneNumber = "380671223344", Country = "Ukraine", City = "Kharkiv", BirthDate = new DateTime(1985, 12, 2) },
                new Person { Id = 6, Name = "Oksana", Surname = "Moroz", Email = "Moroz6@gmail.com", PhoneNumber = "380931556677", Country = "Ukraine", City = "Vinnytsia", BirthDate = new DateTime(1998, 1, 30) }
            );



            // ---------- TrainRoutes ----------
            modelBuilder.Entity<TrainRoute>().HasData(
                new TrainRoute { Id = 1, Name = "Kyiv - Lviv Route", TrainId = 1 },
                new TrainRoute { Id = 2, Name = "Lviv - Odesa Route", TrainId = 2 },
                new TrainRoute { Id = 3, Name = "Odesa - Kharkiv Route", TrainId = 3 },
                new TrainRoute { Id = 4, Name = "Dnipro - Kyiv Route", TrainId = 4 },
                new TrainRoute { Id = 5, Name = "Vinnytsia - Lviv Route", TrainId = 5 }
            );

            // ---------- Price ----------
            modelBuilder.Entity<Price>().HasData(
                new Price { Id = 1, PriceForKGOfCarriageWeight = 2.5m, PriceForKilometer = 0.5m },
                new Price { Id = 2, PriceForKGOfCarriageWeight = 3m, PriceForKilometer = 0.55m },
                new Price { Id = 3, PriceForKGOfCarriageWeight = 2.2m, PriceForKilometer = 0.45m }
            );

            // ---------- RoutePoints ----------
            modelBuilder.Entity<RoutePoint>().HasData(
                // Kyiv - Lviv (4 точки)
                new RoutePoint { Id = 1, TrainRouteId = 1, StationId = 1, ArrivalTime = new DateTime(2025, 8, 28, 9, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 9, 15, 0), Platform = 1, Order = 1, DistanceFromPreviousStation = 0 },
                new RoutePoint { Id = 2, TrainRouteId = 1, StationId = 8, ArrivalTime = new DateTime(2025, 8, 28, 10, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 10, 10, 0), Platform = 1, Order = 2, DistanceFromPreviousStation = 130 },
                new RoutePoint { Id = 3, TrainRouteId = 1, StationId = 7, ArrivalTime = new DateTime(2025, 8, 28, 11, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 11, 10, 0), Platform = 2, Order = 3, DistanceFromPreviousStation = 180 },
                new RoutePoint { Id = 4, TrainRouteId = 1, StationId = 2, ArrivalTime = new DateTime(2025, 8, 28, 12, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 12, 10, 0), Platform = 2, Order = 4, DistanceFromPreviousStation = 220 },

                // Lviv - Odesa (4 точки)
                new RoutePoint { Id = 5, TrainRouteId = 2, StationId = 2, ArrivalTime = new DateTime(2025, 8, 28, 13, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 13, 15, 0), Platform = 1, Order = 1, DistanceFromPreviousStation = 0 },
                new RoutePoint { Id = 6, TrainRouteId = 2, StationId = 6, ArrivalTime = new DateTime(2025, 8, 28, 14, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 14, 10, 0), Platform = 2, Order = 2, DistanceFromPreviousStation = 250 },
                new RoutePoint { Id = 7, TrainRouteId = 2, StationId = 8, ArrivalTime = new DateTime(2025, 8, 28, 15, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 15, 10, 0), Platform = 2, Order = 3, DistanceFromPreviousStation = 180 },
                new RoutePoint { Id = 8, TrainRouteId = 2, StationId = 3, ArrivalTime = new DateTime(2025, 8, 28, 16, 0, 0), DepartureTime = new DateTime(2025, 8, 28, 16, 10, 0), Platform = 3, Order = 4, DistanceFromPreviousStation = 200 },

                // Odesa - Kharkiv (4 точки)
                new RoutePoint { Id = 9, TrainRouteId = 3, StationId = 3, ArrivalTime = new DateTime(2025, 8, 29, 8, 0, 0), DepartureTime = new DateTime(2025, 8, 29, 8, 15, 0), Platform = 1, Order = 1, DistanceFromPreviousStation = 0 },
                new RoutePoint { Id = 10, TrainRouteId = 3, StationId = 4, ArrivalTime = new DateTime(2025, 8, 29, 10, 0, 0), DepartureTime = new DateTime(2025, 8, 29, 10, 10, 0), Platform = 1, Order = 2, DistanceFromPreviousStation = 400 },
                new RoutePoint { Id = 11, TrainRouteId = 3, StationId = 9, ArrivalTime = new DateTime(2025, 8, 29, 12, 0, 0), DepartureTime = new DateTime(2025, 8, 29, 12, 10, 0), Platform = 2, Order = 3, DistanceFromPreviousStation = 320 },
                new RoutePoint { Id = 12, TrainRouteId = 3, StationId = 5, ArrivalTime = new DateTime(2025, 8, 29, 14, 0, 0), DepartureTime = new DateTime(2025, 8, 29, 14, 10, 0), Platform = 3, Order = 4, DistanceFromPreviousStation = 600 },

                // Dnipro - Kyiv (4 точки)
                new RoutePoint { Id = 13, TrainRouteId = 4, StationId = 4, ArrivalTime = new DateTime(2025, 8, 30, 7, 0, 0), DepartureTime = new DateTime(2025, 8, 30, 7, 10, 0), Platform = 1, Order = 1, DistanceFromPreviousStation = 0 },
                new RoutePoint { Id = 14, TrainRouteId = 4, StationId = 9, ArrivalTime = new DateTime(2025, 8, 30, 9, 30, 0), DepartureTime = new DateTime(2025, 8, 30, 9, 40, 0), Platform = 2, Order = 2, DistanceFromPreviousStation = 300 },
                new RoutePoint { Id = 15, TrainRouteId = 4, StationId = 8, ArrivalTime = new DateTime(2025, 8, 30, 11, 0, 0), DepartureTime = new DateTime(2025, 8, 30, 11, 10, 0), Platform = 2, Order = 3, DistanceFromPreviousStation = 250 },
                new RoutePoint { Id = 16, TrainRouteId = 4, StationId = 1, ArrivalTime = new DateTime(2025, 8, 30, 13, 0, 0), DepartureTime = new DateTime(2025, 8, 30, 13, 15, 0), Platform = 1, Order = 4, DistanceFromPreviousStation = 500 },

                // Vinnytsia - Lviv (4 точки)
                new RoutePoint { Id = 17, TrainRouteId = 5, StationId = 6, ArrivalTime = new DateTime(2025, 8, 31, 9, 0, 0), DepartureTime = new DateTime(2025, 8, 31, 9, 15, 0), Platform = 1, Order = 1, DistanceFromPreviousStation = 0 },
                new RoutePoint { Id = 18, TrainRouteId = 5, StationId = 7, ArrivalTime = new DateTime(2025, 8, 31, 10, 0, 0), DepartureTime = new DateTime(2025, 8, 31, 10, 10, 0), Platform = 2, Order = 2, DistanceFromPreviousStation = 180 },
                new RoutePoint { Id = 19, TrainRouteId = 5, StationId = 8, ArrivalTime = new DateTime(2025, 8, 31, 11, 0, 0), DepartureTime = new DateTime(2025, 8, 31, 11, 10, 0), Platform = 2, Order = 3, DistanceFromPreviousStation = 130 },
                new RoutePoint { Id = 20, TrainRouteId = 5, StationId = 2, ArrivalTime = new DateTime(2025, 8, 31, 12, 0, 0), DepartureTime = new DateTime(2025, 8, 31, 12, 10, 0), Platform = 3, Order = 4, DistanceFromPreviousStation = 400 }
            );

            // ---------- Tickets ----------
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, TrainRouteId = 1, PriceId = 1, DepartureStationId = 1, DestinationStationId = 2, PersonId = 1, CarriageWeight = 10, Seat = 12, CarriagePrice = 25m, RoadPrice = 270m, FinalPrice = 295m, PurchaseDate = new DateTime(2024, 9, 12, 5, 2, 3) },
                new Ticket { Id = 2, TrainRouteId = 2, PriceId = 1, DepartureStationId = 2, DestinationStationId = 3, PersonId = 2, CarriageWeight = 15, Seat = 8, CarriagePrice = 37.5m, RoadPrice = 270m, FinalPrice = 307.5m, PurchaseDate = new DateTime(2025, 8, 28, 9, 1, 1) },
                new Ticket { Id = 3, TrainRouteId = 1, PriceId = 1, DepartureStationId = 8, DestinationStationId = 1, PersonId = 3, CarriageWeight = 12, Seat = 9, CarriagePrice = 30m, RoadPrice = 270m, FinalPrice = 300m, PurchaseDate = new DateTime(2024, 7, 28, 8, 11, 12) }
            );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TrainRoute> TrainRoutes { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
