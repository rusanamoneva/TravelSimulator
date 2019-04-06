using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class HotelService : IHotel
    {
        private TravelSimulatorContext context;

        public HotelService()
        {
            this.context = new TravelSimulatorContext();
        }

        public HotelService(TravelSimulatorContext cont)
        {
            this.context = cont;
        }

        public int AddHotel(string countryName, string townName, string hotelName, int stars, decimal pricePerNight)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);

            Hotel hotel = new Hotel()
            {
                HotelName = hotelName,
                Stars = stars,
                PricePerNight = pricePerNight
            };

            if (town.Hotels.FirstOrDefault(x => x.HotelName == hotelName) != null)
            {
                throw new InvalidOperationException("Hotel already exists.");
            }

            context.Hotels.Add(hotel);
            town.Hotels.Add(hotel);
            context.SaveChanges();

            int result = FindTownByName(countryName, townName).Hotels.FirstOrDefault(x => x.HotelName == hotelName).Id;

            return result;
        }

        public string RemoveHotel(string countryName, string townName, string hotelName)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = FindHotelByName(hotelName, town);

            town.Hotels.Remove(hotel);
            context.Hotels.Remove(hotel);
            context.SaveChanges();

            string result = $"Hotel {hotelName} successfully removed.";

            return result;
        }

        //Tested
        public decimal ChangeHotelPrice(string countryName, string townName, string hotelName, decimal newPrice)
        {
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = FindHotelByName(hotelName, town);

            hotel.PricePerNight = newPrice;
            context.SaveChanges();

            return hotel.PricePerNight;
        }

        //Tested
        public int AddStarToHotel(string countryName, string townName, string hotelName)
        {
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = FindHotelByName(hotelName, town);


            hotel.Stars++;
            hotel.PricePerNight += 10;
            context.SaveChanges();

            int newStars = hotel.Stars;
            return newStars;
        }

        //Tested
        public int RemoveStarFromHotel(string countryName, string townName, string hotelName)
        {
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = FindHotelByName(hotelName, town);


            hotel.Stars--;
            hotel.PricePerNight -= 10;
            context.SaveChanges();

            int newStars = hotel.Stars;
            return newStars;
        }

        public List<Hotel> ShowAllHotelsInTown(string countryName, string townName)
        {
            Town town = FindTownByName(countryName, townName);

            List<Hotel> hotelsInTown = new List<Hotel>();

            foreach (Hotel hotel in context.Hotels)
            {
                if (hotel.Town.Country.CountryName == countryName
                    && hotel.Town.TownName == townName)
                {
                    hotelsInTown.Add(hotel);
                }
            }

            if (hotelsInTown.Count == 0)
            {
                throw new InvalidOperationException($"No hotels to be shown in {townName}.");
            }

            return hotelsInTown;
        }

        public Hotel FindHotelByName(string hotelName, Town town)
        {
            Hotel hotel = new Hotel();

            string townName = town.TownName;

            foreach (Hotel item in context.Hotels)
            {
                if (item.Town.Country.CountryName == town.Country.CountryName
                    && item.Town.TownName == townName
                    && item.HotelName == hotelName)
                {
                    hotel = item;
                }
            }

            if (hotel.HotelName == null)
            {
                throw new InvalidOperationException($"Hotel {hotelName} does not exist in {townName}");
            }

            return hotel;
        }

        public string DeleteHotelByCountry(string countryName)
        {
            foreach (Hotel hotel in context.Hotels)
            {
                if (hotel.Town.Country.CountryName == countryName)
                {
                    string townName = hotel.Town.TownName;
                    RemoveHotel(countryName, townName, hotel.HotelName);
                }
            }

            string result = "Hotels deleted.";

            return result;
        }

        private Town FindTownByName(string countryName, string townName)
        {
            //if (FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName) == null)
            //{
            //    throw new ArgumentException("Town does not exists!");
            //}

            //Town town = FindCountryByName(countryName).Towns.FirstOrDefault(x => x.TownName == townName);

            Town town = new Town();

            foreach (Town item in context.Towns)
            {
                if (item.TownName == townName && item.Country.CountryName == countryName)
                {
                    town = item;
                }
            }

            if (town.TownName == null)
            {
                throw new InvalidOperationException("Town not found.");
            }

            return town;
        }

        private Country FindCountryByName(string countryName)
        {
            //if (context.Countries.FirstOrDefault(x => x.CountryName == countryName) == null)
            //{
            //    throw new InvalidOperationException("Town should be in a valid country! This country does not exist!");
            //}

            Country country = new Country();

            foreach (Country item in context.Countries)
            {
                if (item.CountryName == countryName)
                {
                    country = item;
                }
            }

            //Country country = context.Countries.FirstOrDefault(x => x.CountryName == countryName);

            if (country.CountryName == null)
            {
                throw new InvalidOperationException("Country not found.");
            }

            return country;
        }
<<<<<<< HEAD
=======

        public Hotel FindHotelByName(string hotelName, Town town)
        {
            Hotel hotel = new Hotel();

            string townName = town.TownName;

            foreach (Hotel item in context.Hotels)
            {
                if (item.Town.Country.CountryName == town.Country.CountryName
                    && item.Town.TownName == townName
                    && item.HotelName == hotelName)
                {
                    hotel = item;
                }
            }

            if (hotel.HotelName == null)
            {
                throw new InvalidOperationException($"Hotel {hotelName} not found in {townName}.");
            }

            return hotel;
        }
>>>>>>> fdcd898c706786c67f42bb8a10c300333962d910
    }
}


