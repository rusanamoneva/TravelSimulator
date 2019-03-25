using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;

namespace TravelSimulator.Services
{
    public interface ITown
    {
        int AddTown(string countryName, string townName);

        string DeleteTown(string countryName, string townName);

        List<Hotel> ShowAllHotelsInTown(string countryName, string townName);
    }
}
