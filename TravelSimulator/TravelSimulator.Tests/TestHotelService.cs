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
            Country country = new Country()
            {
                CountryName = "Bulgaria"
            };

            Town town = new Town()
            {
                Country = new Country() { CountryName = "Bulgaria" },
                TownName = "Sunny Beach"
            };

            var dataTowns = new List<Town>
            {
                new Town { TownName = "Sofia", Country = country},
                new Town {TownName = "Sunny Beach", Country = country}
            };

            var data = new List<Hotel>
            {
                new Hotel { Town = town, HotelName = "Jasmine", Stars = 3, PricePerNight = 40},
                new Hotel { Town = town, HotelName = "Helena", Stars = 5, PricePerNight = 140},
                new Hotel { Town = town, HotelName = "Victoria", Stars = 4, PricePerNight = 90},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Hotel>>();
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Hotel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSetTowns = new Mock<DbSet<Town>>();
            //mockSetTowns.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(dataTowns.Provider);
            //mockSetTowns.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(dataTowns.Expression);
            //mockSetTowns.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(dataTowns.ElementType);
            mockSetTowns.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(dataTowns.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Hotels).Returns(mockSet.Object);
            mockContext.Setup(m => m.Towns).Returns(mockSetTowns.Object);

            var service = new HotelService(mockContext.Object);
            var newHotelPrice = service.ChangeHotelPrice("Bulgaria", "Sunny Beach", "Jasmine", 50);

            Assert.AreEqual(50, newHotelPrice);
        }
    }
}
