using System;
using System.Collections.Generic;
using System.Text;

namespace TravelSimulator.View
{
    class Engine
    {
        public void Run()
        {
            RunHomePage();
        }

        //in progress
        private void RunHomePage()
        {
            ConsoleKeyInfo key;
            string keyValue = "";
            Display.PrintHomePage();
            while (keyValue != "Escape")
            {
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        RunAddPage();
                        break;
                    case "D2":
                        RunFindPage();
                        break;
                    case "D3":
                        RunListPage();
                        break;
                    case "D4":
                        //;
                        break;
                    case "D5":
                        //;
                        break;
                }
                Console.Clear();
                View.Display.PrintHomePage();
            }

            Console.Clear();
        }

        //in progress
        private void RunAddPage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            do
            {
                Console.Clear();
                Display.PrintAddPage();
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        RunAddCountryPage();
                        break;
                    case "D2":
                        RunAddTownPage();
                        break;
                    case "D3":
                        //View.Display.PrintAddPage();
                        break;
                    case "D4":
                        //View.Display.PrintAddPage();
                        break;
                    case "D5":
                        //View.Display.PrintAddPage();
                        break;
                }
            } while (keyValue != "D0");
        }

        //finished
        private void RunAddCountryPage()
        {
            Display.PrintAddCountryPage();
            Services.CountryService countryService = new Services.CountryService();
            try
            {
                string countryName = Console.ReadLine();
                countryService.AddCountry(countryName);
                Display.AddedCountryMessage(countryName);
            }
            catch (Exception ex)
            {
                Display.PrintErrorScreen();
                Console.WriteLine(ex.Message);
                Console.WriteLine(Display.GoBackMessage());
            }
            Console.ReadKey(true);
        }
        
        //finished
        private void RunAddTownPage()
        {
            Display.PrintAddTownPage();
            Services.CountryService countryService = new Services.CountryService();
            Services.TownService townService = new Services.TownService();

            try
            {
                string countryName = Console.ReadLine();
                countryService.GetCountryByName(countryName);
                Display.PrintAddTownBottom();
                string townName = Console.ReadLine();
                townService.AddTown(countryName, townName);
                Display.AddedTownMessage(countryName, townName);
            }
            catch (Exception ex)
            {
                Display.PrintErrorScreen();
                Console.WriteLine(ex.Message);
                Console.WriteLine(Display.GoBackMessage());
            }
            Console.ReadKey(true);
        }

        //in progress
        private void RunFindPage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            do
            {
                Console.Clear();
                Display.PrintFindPage();
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        //idk;
                        break;
                    case "D2":
                        //View.Display.PrintAddPage();
                        break;
                    case "D3":
                        //View.Display.PrintAddPage();
                        break;
                    case "D4":
                        //View.Display.PrintAddPage();
                        break;
                    case "D5":
                        //View.Display.PrintAddPage();
                        break;
                }

            } while (keyValue != "D0");
        }

        //in progress
        private void RunListPage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            do
            {
                Console.Clear();
                Display.PrintListPage();
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        RunListCountries();
                        break;
                    case "D2":
                        //View.Display.PrintAddPage();
                        break;
                    case "D3":
                        //View.Display.PrintAddPage();
                        break;
                    case "D4":
                        //View.Display.PrintAddPage();
                        break;
                    case "D5":
                        //View.Display.PrintAddPage();
                        break;
                }
            } while (keyValue != "D0");
        }

        //finished
        private void RunListCountries()
        {
            Display.PrintListCountries();
            Console.ReadKey(true);
        }
    }
}