using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TravelSimulator.Data;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class CountryService : ICountryService
    {
        private TravelSimulatorContext context;

        //Used in the View
        public CountryService()
        {
            this.context = new TravelSimulatorContext();
        }

        //Used for Unit tests
        public CountryService(TravelSimulatorContext cont)
        {
            this.context = cont;
        }

        //fixed
        //Checks if country is contained in the datebase. If yes, throus exception.
        //If country isn't contained, the method adds the country to the datebase
        public int AddCountry(string countryName)
        {
            Country country = new Country
            {
                CountryName = countryName
            };
            
            //checks if country is contained so as not to have two dublicate countries
            if (context.Countries.FirstOrDefault(x => x.CountryName == countryName) != null)
            {
                throw new ArgumentException("Country already exists.");
            }

            context.Countries.Add(country);
            context.SaveChanges();

            //returns id of the added country
            int addedCountryId = GetCountryByName(countryName).Id;
            return addedCountryId;
        }
        
        //not tested
        //Checks if the parameter countryName is name of a contained country.
        //If the database contains the country it is deleted. If it is not contained
        //the method throws exception
        public string DeleteCountry(string countryName)
        {
            //Is countryName is not valid it throws exception
            if (GetCountryByName(countryName) == null)
            {
                throw new ArgumentException("Country not found.");
            }

            Country countryToRemove = GetCountryByName(countryName);

            context.Remove(countryToRemove);
            context.SaveChanges();

            return "Country successfully removed.";
        }

        //Tested
        //Searches for a country in the database. If country exists in the databse
        //it returns the country.
        //If country doesn't exist the method throws exception
        public Country GetCountryByName(string countryName)
        {
            Country searchedCountry = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            //Checks if country exist in the database
            if (searchedCountry == null)
            {
                throw new ArgumentException("Country not found.");
            }

            //returns the country if the country exists
            return searchedCountry;
        }

        //Tested
        //Lists all countries in the database
        //If there aren't countries the method throws exception
        public List<Country> ShowAllCountries()
        {
            List<Country> countries = context.Countries.ToList();

            //Throws exception if there aren't countries in the database
            if (countries.Count == 0)
            {
                throw new ArgumentException("No added countries.");
            }
    
            return countries;
        }

    }
}
