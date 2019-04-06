using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class TownService : ITownService
    {
        private TravelSimulatorContext context;

        //Used in the View
        public TownService()
        {
            this.context = new TravelSimulatorContext();
        }

        //Used for Unit Tests
        public TownService(TravelSimulatorContext cont)
        {
            this.context = cont;
        }

        //working
        //Adds town in the database
        //If town is contained in the database, the method throws exception
        public int AddTown(string countryName, string townName)
        {
            Country country = FindCountryByName(countryName);

            if (FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName) != null)
            {
                throw new ArgumentException("Town already exists.");
            }
            
            Town town = new Town()
            {
                TownName = townName,
                Country = FindCountryByName(countryName)
            };

            context.Towns.Add(town);
            country.Towns.Add(town);
            context.SaveChanges();

            return GetTownByName(countryName, townName).Id;
        }

        //Deletes town from the database
        //If town is not contained in the database, the method throws exception
        public string DeleteTown(string countryName, string townName)
        {
            Country country = FindCountryByName(countryName);
            Town town = GetTownByName(countryName, townName);

            country.Towns.Remove(town);
            context.Towns.Remove(town);
            context.SaveChanges();

            return "Town successfully deleted.";
        }

        //Tested
        //Lists all towns in a specific country
        //If there are no towns in the country, the method throws exception
        public List<Town> ShowAllTownsInCountry(string countryName)
        {
            Country country = FindCountryByName(countryName);

            List<Town> towns = new List<Town>();

            foreach (Town item in context.Towns)
            {
                if (item.Country.CountryName == countryName)
                {
                    towns.Add(item);
                }
            }

            if (towns.Count == 0)
            {
                throw new InvalidOperationException($"No towns to be shown in {countryName}.");
            }

            return towns;
        }

        //Tested
        //Returns Town by name and countryName
        //It town doesn't exist in the database, the method throws exception
        public Town GetTownByName(string countryName, string townName)
        {
            Town town = new Town();

            foreach (Town item in context.Towns)
            {
                if (item.Country.CountryName == countryName && item.TownName == townName)
                {
                    town = item;
                }
            }

            if (town.TownName == null)
            {
                throw new ArgumentException($"No town with name {townName}.");
            }

            return town;

        }

        //Deletes all towns in a specific country
        //Used when deleting a country
        public string DeleteTownByCountry(string countryName)
        {
            foreach (Town town in context.Towns)
            {
                if (town.Country.CountryName == countryName)
                {
                    DeleteTown(countryName, town.TownName);
                }
            }

            string result = "Towns deleted.";

            return result;
        }

        //Used to validate country
        private Country FindCountryByName(string countryName)
        {
            Country country = new Country();

            foreach (Country item in context.Countries)
            {
                if (item.CountryName == countryName)
                {
                    country = item;
                }
            }

            if (country.CountryName == null)
            {
                throw new InvalidOperationException("Country not found.");
            }

            return country;
        }
    }
}
