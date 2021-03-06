﻿using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface IHotelService
    {
        int AddHotel(string countryName, string townName, string hotelName, int stars, decimal pricePerNight);

        string RemoveHotel(string countryName, string townName, string hotelName);

        List<Hotel> ShowAllHotelsInTown(string countryName, string townName);

        decimal ChangeHotelPrice(string countryName, string townName, string hotelName, decimal newPrice);

        Hotel FindHotelByName(string hotelName, Town town);

        int AddStarToHotel(string countryName, string townName, string hotelName);

        int RemoveStarFromHotel(string countryName, string townName, string hotelName);

        string DeleteHotelByCountry(string countryName);

        string DeleteHotelByTown(string townName);
    }
}
