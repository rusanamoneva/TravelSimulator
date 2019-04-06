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
            View.Engine engine = new View.Engine();
            engine.Run();
        }
    }
}
