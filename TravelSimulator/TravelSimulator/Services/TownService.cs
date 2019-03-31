using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    class TownService : ITown
    {
        private TravelSimulatorContext context;

        public TownService()
        {
            this.context = new TravelSimulatorContext();
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

        public List<Hotel> ShowAllHotelsInTown(string countryName, string townName)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);

            List<Hotel> hotelsInTown = town.Hotels.ToList();

            if (hotelsInTown.Count == 0)
            {
                throw new InvalidOperationException($"No hotels to be shown in {townName}");
            }

            return hotelsInTown;
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
