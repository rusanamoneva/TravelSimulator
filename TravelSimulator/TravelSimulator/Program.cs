using System;
using System.Collections.Generic;
using TravelSimulator.Data;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;
using TravelSimulator.Services;

namespace TravelSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //dataBaseSeeder.SeedTableTowns();
            //dataBaseSeeder.SeedTableHotelsInBulgaria();
            //DataBaseSeeder dataBaseSeeder = new DataBaseSeeder();

            View.Engine engine = new View.Engine();
            engine.Run();
        }
    }
}
