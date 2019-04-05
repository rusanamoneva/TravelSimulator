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
<<<<<<< HEAD

=======
        
>>>>>>> 43aed3abc9d4149ca4b796e8f4e23a9ca67cbd83
        List<Hotel> ShowAllHotelsInTown(string countryName, string townName);

        decimal ChangeHotelPrice(string countryName, string townName, string hotelName, decimal newPrice);

        Hotel FindHotelByName(string hotelName, Town town);

        //int AddStarToHotel(string countryName, string townName, string hotelName);

<<<<<<< HEAD
        int RemoveStarFromHotel(string countryName, string townName, string hotelName);

        Hotel FindHotelByName(string hotelName, Town town);
=======
        //int RemoveStarFromHotel(string countryName, string townName, string hotelName);
>>>>>>> 43aed3abc9d4149ca4b796e8f4e23a9ca67cbd83
    }
}
