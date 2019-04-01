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

        public int AddTown(string countryName, string townName)
        {
            Country country = FindCountryByName(countryName);

            if (FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName) != null)
            {
                throw new ArgumentException("Town already exists!");
            }


            Town town = new Town()
            {
                TownName = townName,
                Country = FindCountryByName(countryName)
            };

            context.Towns.Add(town);
            country.Towns.Add(town);
            context.SaveChanges();

            return FindTownByName(countryName, townName).Id;
        }

        public string DeleteTown(string countryName, string townName)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);

            country.Towns.Remove(town);
            context.Towns.Remove(town);
            context.SaveChanges();

            return "Town successfully deleted.";
        }

        //Tested without exception
        public List<Town> ShowAllTownsInCountry(string countryName)
        {
            //Country country = context.Countries.FirstOrDefault(x => x.CountryName == countryName); 

            //if (country == null)
            //{
            //    throw new ArgumentException($"The country {countryName} isn't registered.");
            //}

            List<Town> towns = new List<Town>();

            foreach (Town item in context.Towns)
            {
                if (item.Country.CountryName == countryName)
                {
                    towns.Add(item);
                }
            }

            //Country searchedCountry = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            //if (searchedCountry == null)
            //{
            //    throw new InvalidOperationException("Country does not exist!");
            //}
            //else if (searchedCountry.Towns.Count == 0)
            //{
            //    throw new InvalidOperationException($"There are no towns to be shown in {countryName}.");
            //}

            //List<Town> towns = searchedCountry.Towns.ToList();

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
            //Country country = context.Countries.FirstOrDefault(x => x.CountryName == countryName);
            //Town town = country.Towns.FirstOrDefault(x => x.TownName == townName);

            //if (town == null)
            //{
            //    throw new ArgumentException($"No town with name {townName}");
            //}

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
                throw new ArgumentException($"No town with name {townName}");
            }

            return town;

        }

        private Town FindTownByName(string countryName, string townName)
        {
            if (FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName) == null)
            {
                throw new ArgumentException("Town does not exist!");
            }

            Town town = FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName);

            return town;
        }

        private Country FindCountryByName(string countryName)
        {
            if (context.Countries.FirstOrDefault(x => x.CountryName == countryName) == null)
            {
                throw new InvalidOperationException("Town should be in a valid country! This country does not exist!");
            }

            Country country = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            return country;
        }
    }
}
