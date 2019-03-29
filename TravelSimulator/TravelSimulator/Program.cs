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

            string cName = Console.ReadLine();
            string tName = Console.ReadLine();

            //Console.WriteLine(town.AddTown(cName, tName));


            //Console.WriteLine(town.DeleteTown(cName, tName));
            Console.WriteLine(string.Join(", ", c.ShowAllTownsInCountry(cName)));
            //Console.WriteLine(c.RemoveCountry(name));

        }
    }
}
