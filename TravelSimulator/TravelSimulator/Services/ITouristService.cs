using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface ITouristService
    {
        string RegisterTourist(string touristFirstName, string touristLastName, int age, string countryName);

        string DeleteTourist(int id);

        Tourist GetTouristById(int id);

        int ChangeTouristAge(int id);

        List<Tourist> ShowAllTouristsByCountryTheyComeFrom(string countryName);
    }
}
