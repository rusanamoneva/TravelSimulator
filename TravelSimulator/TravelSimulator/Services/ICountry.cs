using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface ICountry
    {
        int AddCountry(string countryName);

        string DeleteCountry(string countryName);

        Country GetCountryByName(string countryName);

        List<Country> ShowAllCountries();
    }
}
