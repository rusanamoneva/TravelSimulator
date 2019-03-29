using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class RoomService : IRoom
    {
        private TravelSimulatorContext context;

        public RoomService()
        {
            this.context = new TravelSimulatorContext();
        }

        public void AddRoom(string countryName, string townName, string hotelName, RoomType roomType)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = FindHotelByName(hotelName, town);

            Room room = new Room()
            {
                RoomType = roomType
            };

            context.Rooms.Add(room);
            hotel.Rooms.Add(room);
            context.SaveChanges();
        }

        public string DeleteRoom(string countryName, string townName, string hotelName, int roomId)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = FindHotelByName(hotelName, town);
            Room room = hotel.Rooms.FirstOrDefault(x => x.Id == roomId);

            hotel.Rooms.Remove(room);
            context.Rooms.Remove(room);

            string result = "Room successfully deleted.";

            return result;
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
