using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class HotelService : IHotel
    {
        public HotelService()
        {

        }

        public int AddHotel(string hotelName, int stars, decimal pricePerNight)
        {
            throw new NotImplementedException();
        }

        public string AddRoomInHotel(string townName, string hotelName, Room room)
        {
            throw new NotImplementedException();
        }

        public List<Tourist> GetAllTouristsInHotel()
        {
            throw new NotImplementedException();
        }

        public string RemoveHotel(string townName, string hotelName)
        {
            throw new NotImplementedException();
        }
    }
}
