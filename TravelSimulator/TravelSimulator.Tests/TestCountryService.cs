using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TravelSimulator.Data;
using TravelSimulator.Models;
using TravelSimulator.Services;

namespace TravelSimulator.Tests
{
    public class TestCountryService
    {
        [Test]
        public void TestAddingCountryWithNameNull()
        {
            var mockSet = new Mock<DbSet<Country>>();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(m => m.Countries).Returns(mockSet.Object);

            var countryService = new CountryService(mockContext.Object);

            string countryName = null;

            Assert.Throws<ArgumentException>(() => countryService.AddCountry(countryName));
        }

        //[Test]
        //public void AddExistingCountryThrowsException()
        //{
        //    var mockSet = new Mock<DbSet<Country>>();

        //    var mockContext = new Mock<TravelSimulatorContext>();
        //    mockContext.Setup(m => m.Countries).Returns(mockSet.Object);

        //    var countryService = new CountryService(mockContext.Object);

        //    string countryName = "Bulgaria";

        //    Assert.Throws<ArgumentException>(() => countryService.AddCountry(countryName));
        //}

        //[Test]
        //public void AddCountryShouldAddCountry()
        //{
        //    var mockSet = new Mock<DbSet<Country>>();

        //    var mockContext = new Mock<TravelSimulatorContext>();
        //    mockContext.Setup(m => m.Countries).Returns(mockSet.Object);

        //    var service = new CountryService(mockContext.Object);
        //    service.AddCountry("Bulgaria");

        //    mockSet.Verify(m => m.Add(It.IsAny<Country>()), Times.Once());
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //}

        [Test]
        public void GetCountryByName()
        {
            var data = new List<Country>
            {
                new Country { CountryName = "Bulgaria"},
                new Country { CountryName = "Germany"},
                new Country { CountryName = "Italy"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Country>>();
            mockSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Countries).Returns(mockSet.Object);

            var service = new CountryService(mockContext.Object);
            var country = service.GetCountryByName("Bulgaria");

            Assert.AreEqual("Bulgaria", country.CountryName);
        }

        [Test]
        public void GetCountryByNameThrowsExceptionWhitNoRegisteredCountry()
        {
            var data = new List<Country>
            {
                new Country { CountryName = "Bulgaria"},
                new Country { CountryName = "Germany"},
                new Country { CountryName = "Italy"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Country>>();
            mockSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Countries).Returns(mockSet.Object);

            var service = new CountryService(mockContext.Object);           

            Assert.Throws<ArgumentException>(() => service.GetCountryByName("Greece"));
        }

        [Test]
        public void ShowAllCountries()
        {
            var data = new List<Country>
            {
                new Country { CountryName = "Bulgaria"},
                new Country { CountryName = "Germany"},
                new Country { CountryName = "Italy"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Country>>();
            mockSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Countries).Returns(mockSet.Object);

            var service = new CountryService(mockContext.Object);
            var country = service.ShowAllCountries().ToList();

            Assert.AreEqual(3, country.Count);
        }

        [Test]
        public void ShowAllCountriesShouldThrowsExceptionWithoutCountries()
        {
            var data = new List<Country>();

            var mockSet = new Mock<DbSet<Country>>();
            //mockSet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Countries).Returns(mockSet.Object);

            var service = new CountryService(mockContext.Object);

            Assert.Throws<ArgumentException>(() => service.ShowAllCountries());
        }

        
    }
}
