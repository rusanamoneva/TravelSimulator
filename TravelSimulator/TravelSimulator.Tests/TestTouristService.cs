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
    public class TestTouristService
    {
        [Test]
        public void GetTouristByIdShouldReturnTourist()
        {
            Mock<DbSet<Tourist>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Tourists).Returns(mockSet.Object);

            var service = new TouristService(mockContext.Object);
            var tourist = service.GetTouristById(3);

            string expectedTouristName = "John Smith";

            string resultedTouristName =
                String.Concat($"{tourist.TouristFirstName}" + " " + $"{tourist.TouristLastName}");

            Assert.AreEqual(expectedTouristName, resultedTouristName);
        }

        [Test]
        public void GetTouristByIdShouldThrowExceptionWithInvalidId()
        {
            Mock<DbSet<Tourist>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Tourists).Returns(mockSet.Object);

            var service = new TouristService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.GetTouristById(21));
        }

        [Test]
        public void ShowTouristsByCountryShouldReturnAllTouristsInCountry()
        {
            Mock<DbSet<Tourist>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Tourists).Returns(mockSet.Object);

            var service = new TouristService(mockContext.Object);
            var tourists = service.ShowAllTouristsByCountryTheyComeFrom("England");

            int expectedTouristCount = 7;

            Assert.AreEqual(expectedTouristCount, tourists.Count);
        }

        [Test]
        public void ShowTouristsByCountryShouldThrowExceptionWithInvalidCountry()
        {
            Mock<DbSet<Tourist>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Tourists).Returns(mockSet.Object);

            var service = new TouristService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ShowAllTouristsByCountryTheyComeFrom("Romania"));
        }

        [Test]
        public void ChangeTouristAgeShouldUpdateAge()
        {
            Mock<DbSet<Tourist>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Tourists).Returns(mockSet.Object);

            var service = new TouristService(mockContext.Object);
            int updatedTouristAge = service.ChangeTouristAge(10);

            int expectedTouristAge = 21;

            Assert.AreEqual(expectedTouristAge, updatedTouristAge);
        }

        [Test]
        public void ChangeTouristAgeShouldThrowExceptionWithInvalidId()
        {
            Mock<DbSet<Tourist>> mockSet = SeedDataBase();

            var mockContext = new Mock<TravelSimulatorContext>();
            mockContext.Setup(c => c.Tourists).Returns(mockSet.Object);

            var service = new TouristService(mockContext.Object);

            Assert.Throws<InvalidOperationException>(() => service.ChangeTouristAge(27));
        }

        private static Mock<DbSet<Tourist>> SeedDataBase()
        {
            var data = new List<Tourist>
            {
                new Tourist { Id = 1, TouristFirstName = "Ivan", TouristLastName = "Ivanov", CountryName = "Bulgaria", Age = 25 },
                new Tourist { Id = 2, TouristFirstName = "Maria", TouristLastName = "Georgieva", CountryName = "Bulgaria", Age = 60 },
                new Tourist { Id = 3, TouristFirstName = "John", TouristLastName = "Smith", CountryName = "England", Age = 35 },
                new Tourist { Id = 4, TouristFirstName = "Alina", TouristLastName = "Zagitova", CountryName = "Russia", Age = 23 },
                new Tourist { Id = 5, TouristFirstName = "Maksim", TouristLastName = "Lavrov", CountryName = "Russia", Age = 32 },
                new Tourist { Id = 6, TouristFirstName = "Vika", TouristLastName = "Lavrova", CountryName = "Russia", Age = 30 },
                new Tourist { Id = 7, TouristFirstName = "Sam", TouristLastName = "Coleman", CountryName = "England", Age = 55 },
                new Tourist { Id = 8, TouristFirstName = "Annie", TouristLastName = "Wilson", CountryName = "England", Age = 21 },
                new Tourist { Id = 9, TouristFirstName = "Naomi", TouristLastName = "Clark", CountryName = "England", Age = 21 },
                new Tourist { Id = 10, TouristFirstName = "Erin", TouristLastName = "Silver", CountryName = "England", Age = 20 },
                new Tourist { Id = 11, TouristFirstName = "Teddy", TouristLastName = "Montgomery", CountryName = "England", Age = 25 },
                new Tourist { Id = 12, TouristFirstName = "Ekaterina", TouristLastName = "Nikolova", CountryName = "Bulgaria", Age = 37 },
                new Tourist { Id = 13, TouristFirstName = "Simeon", TouristLastName = "Kovachev", CountryName = "Bulgaria", Age = 42 },
                new Tourist { Id = 14, TouristFirstName = "Kalina", TouristLastName = "Dimitorova", CountryName = "Bulgaria", Age = 51 },
                new Tourist { Id = 15, TouristFirstName = "Dimitur", TouristLastName = "Hristov", CountryName = "England", Age = 53 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Tourist>>();
            mockSet.As<IQueryable<Tourist>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tourist>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tourist>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tourist>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet;
        }
    }
}
