using System;
using System.Collections.Generic;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;
using TravelSimulator.Services;

namespace TravelSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseSeeder dataBaseSeeder = new DataBaseSeeder();

           

            CountryService c = new CountryService();
            TownService town = new TownService();
            HotelService hotelService = new HotelService();

            string cName = Console.ReadLine();
            string tName = Console.ReadLine();
            //string hName = Console.ReadLine();

            //Console.WriteLine(town.AddTown(cName, tName));
            //Console.WriteLine("Hotel name");
            //string hotelName = Console.ReadLine();

            //Console.WriteLine(hotelService.RemoveHotel(cName, tName, "Olymp"));
            //Console.WriteLine(string.Join(", ", c.ShowAllTownsInCountry(cName)));
            //Console.WriteLine(c.RemoveCountry(name));
            //Console.WriteLine(hotelService.AddHotel(cName, tName, hotelName, 5, 100));
            //Console.WriteLine(string.Join($"\n", town.ShowAllHotelsInTown(cName, tName)));

            //Console.WriteLine(hotelService.ChangeHotelPrice(cName, tName, "Olymp", 70));

            Console.WriteLine(hotelService.AddStarToHotel(cName, tName, "Olymp"));

        }
    }
}
