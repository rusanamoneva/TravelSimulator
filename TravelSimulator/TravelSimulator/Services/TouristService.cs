using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class TouristService : ITourist
    {
        private TravelSimulatorContext context;

        public TouristService()
        {
            this.context = new TravelSimulatorContext();
        }

        public string RegisterTourist(string touristFirstName, string touristLastName, int age, string countryName)
        {
            Tourist tourist = new Tourist()
            {
                TouristFirstName = touristFirstName,
                TouristLastName = touristLastName,
                Age = age,
                CountryName = countryName
            };

            context.Tourists.Add(tourist);
            context.SaveChanges();

            string result = "Tourist successfully registered.";

            return result;
        }

        public string DeleteTourist(int id)
        {
            Tourist tourist = context.Tourists.FirstOrDefault(x => x.Id == id);

            context.Tourists.Remove(tourist);
            context.SaveChanges();

            string result = "Tourist successfully removed.";

            return result;
        }

        public Tourist GetTouristById(int id)
        {
            Tourist tourist = context.Tourists.FirstOrDefault(x => x.Id == id);

            return tourist;
        }

        private Town FindTownByName(string countryName, string townName)
        {
            if (FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName) == null)
            {
                throw new ArgumentException("Town does not exists!");
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

        private static Hotel FindHotelByName(string hotelName, Town town)
        {
            if (town.Hotels.FirstOrDefault(x => x.HotelName == hotelName) == null)
            {
                throw new InvalidOperationException("There isn't a hotel with that name in town.");
            }

            Hotel hotel = town.Hotels.FirstOrDefault(x => x.HotelName == hotelName);

            return hotel;
        }
    }
}
