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

            if (town.Hotels.Contains(hotel))
            {
                throw new InvalidOperationException("Hotel already exists!");
            }

            context.Hotels.Add(hotel);
            town.Hotels.Add(hotel);
            context.SaveChanges();

            int result = FindTownByName(countryName, townName).Hotels.FirstOrDefault(x => x.HotelName == hotelName).Id;

            return result;
        }

        public string AddRoomInHotel(string countryName, string townName, string hotelName, Room room)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = town.Hotels.FirstOrDefault(x => x.HotelName == hotelName);

            hotel.Rooms.Add(room);
            context.SaveChanges();

            string result = $"Room {room.RoomType} successfully added."

            return result;
        }

        public string RemoveHotel(string countryName, string townName, string hotelName)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = town.Hotels.FirstOrDefault(x => x.HotelName == hotelName);

            town.Hotels.Remove(hotel);
            context.Hotels.Remove(hotel);
            context.SaveChanges();

            string result = $"Hotel {hotelName} successfully removed.";

            return result;
        }

        public List<Tourist> GetAllTouristsInHotel(string countryName, string townName, string hotelName)
        {
            Country country = FindCountryByName(countryName);
            Town town = FindTownByName(countryName, townName);
            Hotel hotel = town.Hotels.FirstOrDefault(x => x.HotelName == hotelName);

            List<Tourist> tourists = new List<Tourist>();

            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.Hotel.HotelName == hotelName)
                {
                    tourists.Add(voucher.Tourist);
                }
            }

            return tourists;
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
    }
}
