using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelSimulator.Data;
using TravelSimulator.Models;
using TravelSimulator.Services;

namespace TravelSimulator.Tests
{
    class TestTownService
    {
        [Test]
        public void GetTownByNameShouldReturnTown()
        {
            Country country = new Country()
            {
                CountryName = "Bulgaria"
            };

            var data = new List<Town>
            {
                new Town { TownName = "Sofia", Country = country },
                new Town { TownName = "Plovdiv", Country = country },
                new Town { TownName = "Burgas", Country = country },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);

            var service = new TownService(mockContext.Object);
            var town = service.GetTownByName("Bulgaria", "Sofia");

            Assert.AreEqual("Sofia", town.TownName);
        }

        [Test]
        public void GetTownByNameShouldThrowExceptionWithInvalidTown()
        {
            Country country = new Country()
            {
                CountryName = "Bulgaria"
            };

            var data = new List<Town>
            {
                new Town { TownName = "Sofia", Country = country },
                new Town { TownName = "Plovdiv", Country = country },
                new Town { TownName = "Burgas", Country = country },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);

            var service = new TownService(mockContext.Object);

            Assert.Throws<ArgumentException>(() => service.GetTownByName("Bulgaria", "Velingrad"));
        }

        [Test]
        public void ShowAllTownsInCountryReturnAllTownsInCountry()
        {
            Country country = new Country()
            {
                CountryName = "Bulgaria"
            };
            Country country1 = new Country()
            {
                CountryName = "Italy"
            };

            var data = new List<Town>
            {
                new Town { TownName = "Sofia", Country = country },
                new Town { TownName = "Plovdiv", Country = country },
                new Town { TownName = "Rome", Country = country1 },
                new Town { TownName = "Venice", Country = country1 },
                new Town { TownName = "Milano", Country = country1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);

            var service = new TownService(mockContext.Object);
            var town = service.ShowAllTownsInCountry("Italy");

            Assert.AreEqual(3, town.Count);
        }

        
    }
}
