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

            if (context.Countries.FirstOrDefault(x => x.CountryName == countryName) != null)
            {
                throw new ArgumentException("Country already exists!");
            }

            context.Countries.Add(country);
            context.SaveChanges();

            int addedCountryId = context.Countries.FirstOrDefault(x => x.CountryName == countryName).Id;
            return addedCountryId;
        }

        public string RemoveCountry(string countryName)
        {
            if (context.Countries.FirstOrDefault(x => x.CountryName == countryName) == null)
            {
                throw new ArgumentException("Country does not exist!");
            }

            Country countryToRemove = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            context.Remove(countryToRemove);
            context.SaveChanges();

            return "Country successfully removed!";
        }

        public List<Town> ShowAllTownsInCountry(string countryName)
        {
            throw new NotImplementedException();
        }
    }
}
