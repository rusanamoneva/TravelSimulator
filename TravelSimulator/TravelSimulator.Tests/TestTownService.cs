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
            Mock<DbSet<Town>> mockSet;
            Mock<DbSet<Country>> mockSetCountries;
            SeedDataBase(out mockSet, out mockSetCountries);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            mockContext.Setup(x => x.Countries).Returns(mockSetCountries.Object);

            var service = new TownService(mockContext.Object);
            var town = service.GetTownByName("Bulgaria", "Sofia");

            Assert.AreEqual("Sofia", town.TownName);
        }

        [Test]
        public void GetTownByNameShouldThrowExceptionWithInvalidTown()
        {
            Mock<DbSet<Town>> mockSet;
            Mock<DbSet<Country>> mockSetCountries;
            SeedDataBase(out mockSet, out mockSetCountries);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            mockContext.Setup(x => x.Countries).Returns(mockSetCountries.Object);

            var service = new TownService(mockContext.Object);

            Assert.Throws<ArgumentException>(() => service.GetTownByName("Bulgaria", "Vidin"));
        }

        [Test]
        public void ShowAllTownsInCountryReturnAllTownsInCountry()
        {
            Mock<DbSet<Town>> mockSet;
            Mock<DbSet<Country>> mockSetCountries;
            SeedDataBase(out mockSet, out mockSetCountries);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            mockContext.Setup(x => x.Countries).Returns(mockSetCountries.Object);

            var service = new TownService(mockContext.Object);
            var town = service.ShowAllTownsInCountry("Italy");

            int expectedTownCountInCountry = 3;

            Assert.AreEqual(expectedTownCountInCountry, town.Count);
        }

        [Test]
        public void ShowAllTownsInCountryThrowsExceptionWithInvalidCountry()
        {
            Mock<DbSet<Town>> mockSet;
            Mock<DbSet<Country>> mockSetCountries;
            SeedDataBase(out mockSet, out mockSetCountries);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            mockContext.Setup(x => x.Countries).Returns(mockSetCountries.Object);

            var service = new TownService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ShowAllTownsInCountry("America"));
        }

        [Test]
        public void ShowAllTownsInCountryThrowsExceptionWithNoTowns()
        {
            Mock<DbSet<Town>> mockSet;
            Mock<DbSet<Country>> mockSetCountries;
            SeedDataBase(out mockSet, out mockSetCountries);

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);
            mockContext.Setup(x => x.Countries).Returns(mockSetCountries.Object);

            var service = new TownService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ShowAllTownsInCountry("Russia"));
        }

        private static void SeedDataBase(out Mock<DbSet<Town>> mockSet, out Mock<DbSet<Country>> mockSetCountries)
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
                new Town { TownName = "Milano", Country = country1 },
                new Town { TownName = "Velingrad", Country = country},
                new Town { TownName = "Veliko Tarnovo", Country = country},
                new Town { TownName = "Stara Zagora", Country = country},
                new Town { TownName = "Pleven", Country = country},
                new Town { TownName = "Melnik", Country = country},
                new Town { TownName = "Kazanlak", Country = country},
                new Town { TownName = "Burgas", Country = country},
                new Town { TownName = "Varna", Country = country},
                new Town { TownName = "Nessebar", Country = country},
                new Town { TownName = "Sozopol", Country = country},
                new Town { TownName = "Sunny Beach", Country = country},
                new Town { TownName = "Pomorie", Country = country},
            }.AsQueryable();

            mockSet = new Mock<DbSet<Town>>();
            mockSet.As<IQueryable<Town>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Town>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Town>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Town>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dataCountries = new List<Country>
            {
                new Country { CountryName = "Bulgaria"},
                new Country { CountryName = "Germany"},
                new Country { CountryName = "England"},
                new Country { CountryName = "Greece"},
                new Country { CountryName = "Serbia"},
                new Country { CountryName = "France"},
                new Country { CountryName = "Russia"},
                new Country { CountryName = "Turkey"},
                new Country { CountryName = "Hungary"},
                new Country { CountryName = "Austria"},
                new Country { CountryName = "Norway"},
                new Country { CountryName = "Sweeden"},
                new Country { CountryName = "Ukraine"},
                new Country { CountryName = "Spain"},
                new Country { CountryName = "Italy"}
            }.AsQueryable();

            mockSetCountries = new Mock<DbSet<Country>>();
            mockSetCountries.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSetCountries.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSetCountries.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSetCountries.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(dataCountries.GetEnumerator());
        }

    }
}
