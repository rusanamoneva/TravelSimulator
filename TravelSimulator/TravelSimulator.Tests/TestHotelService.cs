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
    class TestHotelService
    {
        [Test]
        public void ChangeHotelPriceShouldChangePrice()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);
            var newHotelPrice = service.ChangeHotelPrice("Bulgaria", "Sunny Beach", "Jasmine", 50);

            int updatedPriceExpectedResult = 50;

            Assert.AreEqual(updatedPriceExpectedResult, newHotelPrice);
        }

        [Test]
        public void ChangeHotelPriceShouldThrowExceptionWithInvalidCountry()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ChangeHotelPrice("Romania", "Sunny Beach", "Jasmine", 50));
        }

        [Test]
        public void ChangeHotelPriceShouldThrowExceptionWithInvalidTown()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ChangeHotelPrice("Bulgaria", "Pernik", "Jasmine", 50));
        }

        [Test]
        public void ChangeHotelPriceShouldThrowExceptionWithInvalidHotel()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ChangeHotelPrice("Bulgaria", "Sunny Beach", "Hilton", 50));
        }

        [Test]
        public void AddStarToHotelShouldIncreaseStarsWith1()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);
            var updateStars = service.AddStarToHotel("Bulgaria", "Sunny Beach", "Victoria");

            int expectedStarCount = 5;

            Assert.AreEqual(expectedStarCount, updateStars);
        }

        [Test]
        public void AddStarToHotelShouldThrowExceptionWithInvalidCountry()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.AddStarToHotel("England", "Sunny Beach", "Helena"));
        }

        [Test]
        public void AddStarToHotelShouldThrowExceptionWithInvalidTown()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.AddStarToHotel("Bulgaria", "Vidin", "Helena"));
        }

        [Test]
        public void AddStarToHotelShouldThrowExceptionWithInvalidHotel()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.AddStarToHotel("Bulgaria", "Sunny Beach", "Sheraton"));
        }

        [Test]
        public void RemoveStarFromHotelShouldDecreaseStarsWith1()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);
            var decreaseStars = service.RemoveStarFromHotel("Bulgaria", "Sunny Beach", "Helena");

            int expectedStarCount = 4;

            Assert.AreEqual(expectedStarCount, decreaseStars);
        }

        [Test]
        public void RemoveStarFromHotelShouldThrowExceptionWithInvalidCountry()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.RemoveStarFromHotel("Serbia", "Sunny Beach", "Helena"));
        }

        [Test]
        public void RemoveStarFromHotelShouldThrowExceptionWithInvalidTown()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.RemoveStarFromHotel("Bulgaria", "Borovets", "Helena"));
        }

        [Test]
        public void RemoveStarFromHotelShouldThrowExceptionWithInvalidHotel()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.RemoveStarFromHotel("Bulgaria", "Sunny Beach", "Grand Hotel Sofia"));
        }

        [Test]
        public void ShowAllHotelsByTownShouldReturnAllHotelsInTown()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);
            var hotelsInTown = service.ShowAllHotelsInTown("Greece", "Kavala");

            int hotelsInTownCount = 1;

            Assert.AreEqual(hotelsInTownCount, hotelsInTown.Count);
        }

        [Test]
        public void ShowAllHotelsByTownShouldThrowExceptionWithNoHotels()
        {
            Mock<DbSet<Hotel>> mockSet;
            Mock<DbSet<Town>> mockSetTowns;
            SeedDataBase(out mockSet, out mockSetTowns);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ShowAllHotelsInTown("Bulgaria", "Velingrad"));
        }

        private static void SeedDataBase(out Mock<DbSet<Hotel>> mockSet, out Mock<DbSet<Town>> mockSetTowns)
        {
            Country country = new Country()
            {
                CountryName = "Bulgaria"
            };

            Country country2 = new Country()
            {
                CountryName = "Greece"
            };

            Country country3 = new Country()
            {
                CountryName = "France"
            };

            Town town = new Town()
            {
                Country = new Country() { CountryName = "Bulgaria" },
                TownName = "Sunny Beach"
            };

            Town town2 = new Town()
            {
                Country = new Country() { CountryName = "Greece" },
                TownName = "Kavala"
            };

            Town town3 = new Town()
            {
                TownName = "Bansko",
                Country = country
            };

            var dataTowns = new List<Town>
            {
                new Town { TownName = "Sofia", Country = country},
                new Town { TownName = "Sunny Beach", Country = country},
                new Town { TownName = "Kavala", Country = country2 },
                new Town { TownName = "Velingrad", Country = country},
                new Town { TownName = "Veliko Tarnovo", Country = country},
                new Town { TownName = "Stara Zagora", Country = country},
                new Town { TownName = "Pleven", Country = country},
                new Town { TownName = "Melnik", Country = country},
                new Town { TownName = "Kazanlak", Country = country},
                new Town { TownName = "Paris", Country = country3},
                new Town { TownName = "Lion", Country = country3},
                new Town { TownName = "Toulouse", Country = country3},
                new Town { TownName = "Reims", Country = country3},
                new Town { TownName = "Nice", Country = country3},
                new Town { TownName = "Athens", Country = country2},
                new Town { TownName = "Thessaloniki", Country = country2},
                new Town { TownName = "Alexandropolis", Country = country2}
            }.AsQueryable();

            var data = new List<Hotel>
            {
                new Hotel { Town = town, HotelName = "Jasmine", Stars = 3, PricePerNight = 40},
                new Hotel { Town = town, HotelName = "Helena", Stars = 5, PricePerNight = 140},
                new Hotel { Town = town, HotelName = "Victoria", Stars = 4, PricePerNight = 90},
                new Hotel { Town = town2, HotelName = "Kavala Plaza", Stars = 4, PricePerNight = 95},
                new Hotel { Town = town, HotelName = "Majestic", Stars = 5, PricePerNight = 120},
                new Hotel { Town = town, HotelName = "Baikal", Stars = 3, PricePerNight = 55},
                new Hotel { Town = town, HotelName = "Trakia", Stars = 4, PricePerNight = 75},
                new Hotel { Town = town, HotelName = "Kuban", Stars = 3, PricePerNight = 40},
                new Hotel { Town = town, HotelName = "Kalina Garden", Stars = 3, PricePerNight = 50},
                new Hotel { Town = town, HotelName = "Imperial", Stars = 4, PricePerNight = 90},
                new Hotel { Town = town3, HotelName = "Campanella", Stars = 3, PricePerNight = 65},
                new Hotel { Town = town3, HotelName = "Grand Hotel Bansko", Stars = 4, PricePerNight = 90},
                new Hotel { Town = town3, HotelName = "Marieta", Stars = 3, PricePerNight = 50},
                new Hotel { Town = town3, HotelName = "Maria Antoaneta", Stars = 3, PricePerNight = 55},
                new Hotel { Town = town3, HotelName = "Guinness", Stars = 4, PricePerNight = 75},
                new Hotel { Town = town3, HotelName = "Lucky Bansko", Stars = 4, PricePerNight = 85},
                new Hotel { Town = town3, HotelName = "Murite Club", Stars = 4, PricePerNight = 95}
            }.AsQueryable();

            mockSet = new Mock<DbSet<Hotel>>();
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSetTowns = new Mock<DbSet<Town>>();
            mockSetTowns.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(dataTowns.Provider);
            mockSetTowns.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(dataTowns.Expression);
            mockSetTowns.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(dataTowns.ElementType);
            mockSetTowns.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(dataTowns.GetEnumerator());
        }
    }
}
