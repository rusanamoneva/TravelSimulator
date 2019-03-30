using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface ITourist
    {
        string RegisterTourist(string touristFirstName, string touristLastName, int age, string countryName);

        string DeleteTourist(int id);

        Tourist GetTouristById(int id);
    }
}
