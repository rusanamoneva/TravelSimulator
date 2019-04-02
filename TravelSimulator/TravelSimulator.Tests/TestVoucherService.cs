using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;
using TravelSimulator.Services;

namespace TravelSimulator.Tests
{
    public class TestVoucherService
    {
        [Test]
        public void CalculatePriceShouldCalculateTripPrice()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);
            decimal resultedTripPrice = service.CalculateTripPrice(1);

            decimal expectedTripPrice = 280;

            Assert.AreEqual(expectedTripPrice, resultedTripPrice);
        }

        [Test]
        public void CalculatePriceShouldThrowExceptionWithInvalidVoucherId()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.CalculateTripPrice(50));
        }

        [Test]
        public void GetArrivalsByDateShouldReturnAllArrivalsOnExactDate()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            DateTime arrivingDate = new DateTime(2019, 08, 03);

            var arrivals = service.GetArrtivalsByDate(arrivingDate);

            decimal expectedArrivalsCount = 2;

            Assert.AreEqual(expectedArrivalsCount, arrivals.Count);
        }

        [Test]
        public void GetArrivalsByDateShouldThrowExceptionWithNoArrivals()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            DateTime arrivingDate = new DateTime(2019, 01, 31);

            Assert.Throws<InvalidOperationException>(() => service.GetArrtivalsByDate(arrivingDate));
        }

        [Test]
        public void GetDeparturesByDateShouldReturnAllDeparturesOnExactDate()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            DateTime arrivingDate = new DateTime(2019, 08, 13);

            var departures = service.GetDeparturesByDate(arrivingDate);

            decimal expectedDeparturesCount = 2;

            Assert.AreEqual(expectedDeparturesCount, departures.Count);
        }

        [Test]
        public void GetDeparturesByDateShouldThrowExceptionWithNoDepartures()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            DateTime departuresDate = new DateTime(2019, 01, 31);

            Assert.Throws<InvalidOperationException>(() => service.GetDeparturesByDate(departuresDate));
        }

        [Test]
        public void GetAllTouristsByHotelShouldReturnTheTouristsInHotel()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            var tourists = service.GetAllTouristsByHotel("Greece", "Kavala", "Kavala Plaza");

            int expectedTouristsCount = 5;

            Assert.AreEqual(expectedTouristsCount, tourists.Count);
        }

        [Test]
        public void GetAllTouristsByHotelShouldThrowExceptionWithNoTouristsInHotel()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.GetAllTouristsByHotel("Bulgaria", "Sunny Beach", "Kokiche"));
        }

        [Test]
        public void GetPriceWithDiscountShouldReturnPriceWithDicountPercent()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            var resultedPrice = service.GetPriceWithDiscount(1, 10);

            decimal expectedPrice = 252M;

            Assert.AreEqual(expectedPrice, resultedPrice);
        }

        [Test]
        public void GetPriceWithDiscountShouldThrowExceptionWithInvalidId()
        {
            Mock<DbSet<Voucher>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Vouchers).Returns(mockSet.Object);

            var service = new VoucherService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.GetPriceWithDiscount(35, 10));
        }

        private static Mock<DbSet<Voucher>> SeedDataBase()
        {
            Town town = new Town() { TownName = "Sunny Beach", Country = new Country() { CountryName = "Bulgaria" } };
            Town town2 = new Town() { TownName = "Bansko", Country = new Country() { CountryName = "Bulgaria" } };
            Town town3 = new Town() { TownName = "Kavala", Country = new Country() { CountryName = "Greece" } };

            Tourist tourist = new Tourist() { TouristFirstName = "Ivan", TouristLastName = "Ivanov", CountryName = "Bulgaria", Age = 25 };
            Tourist tourist2 = new Tourist() { TouristFirstName = "Maria", TouristLastName = "Georgieva", CountryName = "Bulgaria", Age = 60 };
            Tourist tourist3 = new Tourist() { TouristFirstName = "John", TouristLastName = "Smith", CountryName = "England", Age = 35 };
            Tourist tourist4 = new Tourist() { TouristFirstName = "Alina", TouristLastName = "Zagitova", CountryName = "Russia", Age = 23 };
            Tourist tourist5 = new Tourist() { TouristFirstName = "Maksim", TouristLastName = "Lavrov", CountryName = "Russia", Age = 32 };
            Tourist tourist6 = new Tourist() { TouristFirstName = "Vika", TouristLastName = "Lavrova", CountryName = "Russia", Age = 30 };
            Tourist tourist7 = new Tourist() { TouristFirstName = "Sam", TouristLastName = "Coleman", CountryName = "England", Age = 55 };
            Tourist tourist8 = new Tourist() { TouristFirstName = "Annie", TouristLastName = "Wilson", CountryName = "England", Age = 21 };
            Tourist tourist9 = new Tourist() { TouristFirstName = "Naomi", TouristLastName = "Clark", CountryName = "England", Age = 21 };
            Tourist tourist10 = new Tourist() { TouristFirstName = "Erin", TouristLastName = "Silver", CountryName = "England", Age = 20 };
            Tourist tourist11 = new Tourist() { TouristFirstName = "Teddy", TouristLastName = "Montgomery", CountryName = "England", Age = 25 };
            Tourist tourist12 = new Tourist() { TouristFirstName = "Ekaterina", TouristLastName = "Nikolova", CountryName = "Bulgaria", Age = 37 };
            Tourist tourist13 = new Tourist() { TouristFirstName = "Simeon", TouristLastName = "Kovachev", CountryName = "Bulgaria", Age = 42 };
            Tourist tourist14 = new Tourist() { TouristFirstName = "Kalina", TouristLastName = "Dimitorova", CountryName = "Bulgaria", Age = 51 };
            Tourist tourist15 = new Tourist() { TouristFirstName = "Dimitur", TouristLastName = "Hristov", CountryName = "England", Age = 53 };

            Hotel hotel = new Hotel() { Town = town, HotelName = "Jasmine", Stars = 3, PricePerNight = 40 };
            Hotel hotel2 = new Hotel() { Town = town, HotelName = "Helena", Stars = 5, PricePerNight = 140 };
            Hotel hotel3 = new Hotel() { Town = town, HotelName = "Majestic", Stars = 5, PricePerNight = 120 };
            Hotel hotel4 = new Hotel() { Town = town3, HotelName = "Kavala Plaza", Stars = 4, PricePerNight = 95 };
            Hotel hotel5 = new Hotel() { Town = town2, HotelName = "Campanella", Stars = 3, PricePerNight = 65 };
            Hotel hotel6 = new Hotel() { Town = town2, HotelName = "Grand Hotel Bansko", Stars = 4, PricePerNight = 90 };
            Hotel hotel7 = new Hotel() { Town = town, HotelName = "Kokiche", Stars = 3, PricePerNight = 35 };

            var data = new List<Voucher>
            {
                new Voucher { Id = 1,
                    Tourist = tourist,
                    Hotel = hotel,
                    CancellationPeriod = 10,
                    DaysOfTrip = 7,
                    StartDate = new DateTime(2019, 07, 10),
                    EndDate = new DateTime(2019, 07, 17),
                    TripPrice = 280},
                new Voucher { Id = 2,
                    Tourist = tourist2,
                    Hotel = hotel,
                    CancellationPeriod = 20,
                    DaysOfTrip = 15,
                    StartDate = new DateTime(2019, 08, 01),
                    EndDate = new DateTime(2019, 08, 15) },
                new Voucher { Id = 3,
                    Tourist = tourist3,
                    Hotel = hotel,
                    CancellationPeriod = 7,
                    DaysOfTrip = 5,
                    StartDate = new DateTime(2019, 06, 21),
                    EndDate = new DateTime(2019, 06, 26) },
                new Voucher { Id = 4,
                    Tourist = tourist4,
                    Hotel = hotel5,
                    CancellationPeriod = 15,
                    DaysOfTrip = 12,
                    StartDate = new DateTime(2019, 10, 17),
                    EndDate = new DateTime(2019, 10, 29) },
                new Voucher { Id = 5,
                    Tourist = tourist5,
                    Hotel = hotel3,
                    CancellationPeriod = 10,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 08, 03),
                    EndDate = new DateTime(2019, 08, 13) },
                new Voucher { Id = 6,
                    Tourist = tourist6,
                    Hotel = hotel2,
                    CancellationPeriod = 15,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 08, 03),
                    EndDate = new DateTime(2019, 08, 13) },
                new Voucher { Id = 7,
                    Tourist = tourist7,
                    Hotel = hotel6,
                    CancellationPeriod = 7,
                    DaysOfTrip = 7,
                    StartDate = new DateTime(2019, 11, 21),
                    EndDate = new DateTime(2019, 11, 28) },
                new Voucher { Id = 8,
                    Tourist = tourist8,
                    Hotel = hotel5,
                    CancellationPeriod = 10,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 12, 01),
                    EndDate = new DateTime(2019, 12, 10) },
                new Voucher { Id = 9,
                    Tourist = tourist9,
                    Hotel = hotel6,
                    CancellationPeriod = 10,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 12, 01),
                    EndDate = new DateTime(2019, 12, 10) },
                new Voucher { Id = 10,
                    Tourist = tourist10,
                    Hotel = hotel4,
                    CancellationPeriod = 15,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 06, 10),
                    EndDate = new DateTime(2019, 06, 20) },
                new Voucher { Id = 11,
                    Tourist = tourist11,
                    Hotel = hotel4,
                    CancellationPeriod = 15,
                    DaysOfTrip = 7,
                    StartDate = new DateTime(2019, 07, 15),
                    EndDate = new DateTime(2019, 07, 22) },
                new Voucher { Id = 12,
                    Tourist = tourist12,
                    Hotel = hotel4,
                    CancellationPeriod = 15,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 06, 10),
                    EndDate = new DateTime(2019, 06, 20) },
                new Voucher { Id = 13,
                    Tourist = tourist13,
                    Hotel = hotel2,
                    CancellationPeriod = 20,
                    DaysOfTrip = 10,
                    StartDate = new DateTime(2019, 07, 10),
                    EndDate = new DateTime(2019, 07, 20) },
                new Voucher { Id = 14,
                    Tourist = tourist14,
                    Hotel = hotel4,
                    CancellationPeriod = 10,
                    DaysOfTrip = 5,
                    StartDate = new DateTime(2019, 08, 26),
                    EndDate = new DateTime(2019, 08, 31) },
                new Voucher { Id = 15,
                    Tourist = tourist15,
                    Hotel = hotel4,
                    CancellationPeriod = 15,
                    DaysOfTrip = 7,
                    StartDate = new DateTime(2019, 09, 07),
                    EndDate = new DateTime(2019, 09, 14) }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Voucher>>();
            mockSet.As<IQueryable<Voucher>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Voucher>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Voucher>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Voucher>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet;
        }
    }
}
