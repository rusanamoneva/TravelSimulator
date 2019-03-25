using System;
using System.Collections.Generic;
using System.Text;

namespace TravelSimulator.Services
{
    public interface ITourist
    {
        int RegisterTourist(string touristFirstName, string touristLastName, int age, string countryName);

        string DeleteTourist(string touristFirstName, string touristLastName);

        string GetTouristById(int id);
    }
}
