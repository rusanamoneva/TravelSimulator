using System;
using TravelSimulator.Services;

namespace TravelSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryService c = new CountryService();
            TownService town = new TownService();
            HotelService hotelService = new HotelService();

            string cName = Console.ReadLine();
            string tName = Console.ReadLine();

            //Console.WriteLine(town.AddTown(cName, tName));
            Console.WriteLine("Hotel name");
            string hotelName = Console.ReadLine();

            //Console.WriteLine(town.DeleteTown(cName, tName));
            Console.WriteLine(string.Join(", ", c.ShowAllTownsInCountry(cName)));
            //Console.WriteLine(c.RemoveCountry(name));
            Console.WriteLine(hotelService.AddHotel(cName, tName, hotelName, 5, 100));
            Console.WriteLine(string.Join($"\n", town.ShowAllHotelsInTown(cName, tName)));

        }
    }
}
