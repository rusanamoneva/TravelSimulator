﻿using System;
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

        public CountryService(TravelSimulatorContext cont)
        {
            this.context = cont;
        }

        public int AddCountry(string countryName)
        {
            Country country = new Country
            {
                CountryName = countryName
            };

            //if (GetCountryByName(countryName) != null)
            //{
            //    throw new ArgumentException("Country already exists!");
            //}

            context.Countries.Add(country);
            context.SaveChanges();

            int addedCountryId = GetCountryByName(countryName).Id;
            return addedCountryId;
        }

        public string DeleteCountry(string countryName)
        {
            if (GetCountryByName(countryName) == null)
            {
                throw new ArgumentException("Country does not exist!");
            }

            Country countryToRemove = GetCountryByName(countryName);

            context.Remove(countryToRemove);
            context.SaveChanges();

            return "Country successfully removed!";
        }

        //Tested
        public Country GetCountryByName(string countryName)
        {
            Country searchedCountry = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            if (searchedCountry == null)
            {
                throw new ArgumentException("Country does not exist.");
            }

            return searchedCountry;
        }

        //Tested
        public List<Country> ShowAllCountries()
        {
            List<Country> countries = context.Countries.ToList();

            if (countries.Count == 0)
            {
                throw new ArgumentException("No added countries.");
            }
    
            return countries;
        }

    }
}
