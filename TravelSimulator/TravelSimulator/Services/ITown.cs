using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface ITown
    {
        int AddTown(string countryName, string townName);

        string DeleteTown(string countryName, string townName);

        List<Town> ShowAllTownsInCountry(string countryName);

        //List<Hotel> ShowAllHotelsInTown(string countryName, string townName);

        Town GetTownByName(string countryName, string townName);
    }
}
