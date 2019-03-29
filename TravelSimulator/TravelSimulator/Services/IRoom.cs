using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;

namespace TravelSimulator.Services
{
    public interface IRoom
    {
        void AddRoom(string countryName, string townName, string hotelName, RoomType roomType);

        string DeleteRoom(string countryName, string townName, string hotelName, int roomId);
    }
}
