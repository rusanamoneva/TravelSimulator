using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class TownService : ITown
    {
        private TravelSimulatorContext context;

        public TownService()
        {
            this.context = new TravelSimulatorContext();
        }

        public TownService(TravelSimulatorContext cont)
        {
            this.context = cont;
        }

        //working
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

        //public List<Hotel> ShowAllHotelsInTown(string countryName, string townName)
        //{
        //    Country country = FindCountryByName(countryName);
        //    Town town = FindTownByName(countryName, townName);

        //    List<Hotel> hotelsInTown = town.Hotels.ToList();

        //    if (hotelsInTown.Count == 0)
        //    {
        //        throw new InvalidOperationException($"No hotels to be shown in {townName}");
        //    }

        //    return hotelsInTown;
        //}

        //Tested
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
