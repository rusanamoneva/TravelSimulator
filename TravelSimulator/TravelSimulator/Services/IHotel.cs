using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface IHotel
    {
        int AddHotel(string countryName, string townName, string hotelName, int stars, decimal pricePerNight);

        string RemoveHotel(string countryName, string townName, string hotelName);

        string AddRoomInHotel(string countryName, string townName, string hotelName, Room room);

        List<Tourist> GetAllTouristsInHotel(string countryName, string townName, string hotelName);
    }
}
