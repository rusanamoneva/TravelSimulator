using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TravelSimulator.Data;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class CountryService : ICountry
    {
        private TravelSimulatorContext context;

        public CountryService()
        {
            this.context = new TravelSimulatorContext();
        }

        public int AddCountry(string countryName)
        {
            Country country = new Country
            {
                CountryName = countryName
            };

            if (FindCountryByName(countryName) != null)
            {
                throw new ArgumentException("Country already exists!");
            }

            context.Countries.Add(country);
            context.SaveChanges();

            int addedCountryId = FindCountryByName(countryName).Id;
            return addedCountryId;
        }

        public string DeleteCountry(string countryName)
        {
            if (FindCountryByName(countryName) == null)
            {
                throw new ArgumentException("Country does not exist!");
            }

            Country countryToRemove = FindCountryByName(countryName);

            context.Remove(countryToRemove);
            context.SaveChanges();

            return "Country successfully removed!";
        }

        public List<Town> ShowAllTownsInCountry(string countryName)
        {
            if (FindCountryByName(countryName) == null)
            {
                throw new InvalidOperationException("Country does not exist!");
            }
            else if(FindCountryByName(countryName).Towns.Count == 0)
            {
                throw new InvalidOperationException("There are no towns to be shown in this country.");
            }

            List<Town> towns = FindCountryByName(countryName).Towns.ToList();

            return towns;
        }

        private Country FindCountryByName(string countryName)
        {
            Country searchedCountry = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            return searchedCountry;
        }
    }
}
