using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelSimulator.View
{
    class Engine
    {
        public void Run()
        {
            RunHomePage();
        }

        //finished
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
                        RunListPage();
                        break;
                    case "D3":
                        RunChangePage();
                        break;
                    case "D4":
                        RunRemovePage();
                        break;
                }
                Console.Clear();
                View.Display.PrintHomePage();
            }

            Console.Clear();
        }

        //finished
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
                        RunAddHotelPage();
                        break;
                    case "D4":
                        RunAddTourist();
                        break;
                    case "D5":
                        RunAddVoucher();
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

        //finished
        private void RunAddHotelPage()
        {
            Display.PrintAddHotelPage();
            Services.CountryService countryService = new Services.CountryService();
            Services.TownService townService = new Services.TownService();
            Services.HotelService hotelService = new Services.HotelService();

            try
            {
                string countryName = Console.ReadLine();
                countryService.GetCountryByName(countryName);
                Display.PrintAddHotelMiddle();
                string townName = Console.ReadLine();
                townService.GetTownByName(countryName, townName);
                Display.PrintAddHotelBottom();
                string hotelName = Console.ReadLine();
                Console.WriteLine("Enter number of stars for hotel:");
                int stars = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter initial price per night:");
                decimal price = decimal.Parse(Console.ReadLine());
                hotelService.AddHotel(countryName, townName, hotelName, stars, price);
                Display.AddedHotelMessage(townName, hotelName);
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
        private void RunAddTourist()
        {
            Display.PrintAddTouristPage();
            Services.TouristService touristService = new Services.TouristService();
            try
            {
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter last name:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter age:");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter home country:");
                string homeCountry = Console.ReadLine();
                touristService.RegisterTourist(firstName, lastName, age, homeCountry);
                Display.AddedTouristMessage(firstName, lastName);
            }
            catch (Exception ex)
            {
                Display.PrintErrorScreen();
                Console.WriteLine(ex.Message);
                Console.WriteLine(Display.GoBackMessage());
            }
            Console.ReadKey(true);
        }
        
        //cursed - do not touch
        private void RunAddVoucher()
        {
            Display.PrintAddVoucherPage();
            Services.TouristService touristService = new Services.TouristService();
            Services.HotelService hotelService = new Services.HotelService();
            Services.VoucherService voucherService = new Services.VoucherService();
            try
            {
                Console.WriteLine("Enter tourist's ID:");
                int touristID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name of country for hotel:");
                string countryName = Console.ReadLine();
                Console.WriteLine("Enter name of town for hotel:");
                string townName = Console.ReadLine();
                Console.WriteLine("Enter name of hotel:");
                string hotelName = Console.ReadLine();
                Console.WriteLine("Enter days of trip:");
                int daysOfTrip = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter cancellation period (in days):");
                int cancellationPeriod = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter start date (yyyy mm dd):");
                string[] date1 = Console.ReadLine().Split().ToArray();
                DateTime startDate = new DateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]));
                Console.WriteLine("Enter end date (yyyy mm dd):");
                string[] date2 = Console.ReadLine().Split().ToArray();
                DateTime endDate = new DateTime(int.Parse(date2[0]), int.Parse(date2[1]), int.Parse(date2[2]));

                voucherService.CreateVoucher(touristService.GetTouristById(touristID),
                    voucherService.FindHotelByName(townName, hotelName, voucherService.FindTownByName(countryName, townName)),
                    daysOfTrip,
                    voucherService.CalculateTripPriceForVoucher(daysOfTrip, voucherService.FindHotelByName(townName, hotelName, voucherService.FindTownByName(countryName, townName)).PricePerNight),
                    cancellationPeriod, startDate, endDate);
                Display.AddedVoucherMessage();
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
        private void RunListPage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            do
            {
                Display.PrintListPage();
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        RunListCountries();
                        break;
                    case "D2":
                        RunListTowns();
                        break;
                    case "D3":
                        RunListHotels();
                        break;
                    case "D4":
                        RunListTouristsPage();
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

        //finished
        private void RunListTowns()
        {
            Display.PrintListTowns();
            Services.CountryService countryService = new Services.CountryService();
            Services.TownService townService = new Services.TownService();

            try
            {
                string countryName = Console.ReadLine();
                countryService.GetCountryByName(countryName);
                Display.PrintListTownsBottom(countryName);
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
        private void RunListHotels()
        {
            Display.PrintListHotels();
            Services.CountryService countryService = new Services.CountryService();
            Services.TownService townService = new Services.TownService();
            Services.HotelService hotelService = new Services.HotelService();

            try
            {
                string countryName = Console.ReadLine();
                countryService.GetCountryByName(countryName);
                Display.PrintListHotelsMiddle();
                string townName = Console.ReadLine();
                townService.GetTownByName(countryName, townName);
                Display.PrintListHotelsBottom(countryName, townName);
                hotelService.ShowAllHotelsInTown(countryName, townName);
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
        private void RunListTouristsPage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            do
            {
                Display.PrintListTouristsPage();
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        RunListTouristsByCountry();
                        break;
                    case "D2":
                        RunListTouristsByHotel();
                        break;
                }
            } while (keyValue != "D0");
        }

        //finished
        private void RunListTouristsByCountry()
        {
            Display.PrintListTouristsByCountry();
            string country = Console.ReadLine();
            Services.TouristService touristService = new Services.TouristService();
            try
            {
                touristService.ShowAllTouristsByCountryTheyComeFrom(country);
                Display.ListTouristsByCountry(country);
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
        private void RunListTouristsByHotel()
        {
            Display.PrintListTouristsByHotel();
            string country = Console.ReadLine();
            Services.CountryService countryService = new Services.CountryService();
            Services.TownService townService = new Services.TownService();
            Services.HotelService hotelService = new Services.HotelService();
            Services.VoucherService voucherService = new Services.VoucherService();
            try
            {
                countryService.GetCountryByName(country);
                Console.WriteLine("Enter name of town:");
                string town = Console.ReadLine();
                townService.GetTownByName(country, town);
                Console.WriteLine("Enter name of Hotel:");
                string hotel = Console.ReadLine();
                Display.ListTouristsByHotel(country, town, hotel);
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
        private void RunRemovePage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            do
            {
                Display.PrintRemovePage();
                key = Console.ReadKey(true);
                keyValue = key.Key.ToString();

                switch (keyValue)
                {
                    case "D1":
                        RunRemoveCountryPage();
                        break;
                    case "D2":
                        RunRemoveTownPage();
                        break;
                    case "D3":
                        RunRemoveHotelPage();
                        break;
                    case "D4":
                        RunRemoveTourist();
                        break;
                    case "D5":
                        RunRemoveVoucher();
                        break;
                }
            } while (keyValue != "D0");
        }

        


        //in progress
        private void RunChangePage()
        {
            //ConsoleKeyInfo key;
            //string keyValue;
            //do
            //{
            //    Display.PrintRemovePage();
            //    key = Console.ReadKey(true);
            //    keyValue = key.Key.ToString();
            //
            //    switch (keyValue)
            //    {
            //        case "D1":
            //            RunRemoveCountryPage();
            //            break;
            //        case "D2":
            //            RunRemoveTownPage();
            //            break;
            //        case "D3":
            //            RunRemoveHotelPage();
            //            break;
            //        case "D4":
            //            RunRemoveTourist();
            //            break;
            //        case "D5":
            //            RunRemoveVoucher();
            //            break;
            //    }
            //} while (keyValue != "D0");
        }
        



        //finished
        private void RunRemoveCountryPage()
        {
            Display.PrintRemoveCountryPage();
            Services.CountryService countryService = new Services.CountryService();
            try
            {
                string countryName = Console.ReadLine();
                countryService.GetCountryByName(countryName);
                Services.VoucherService voucherService = new Services.VoucherService();
                voucherService.DeleteVoucherByCountry(countryName);
                Services.HotelService hotelService = new Services.HotelService();
                hotelService.DeleteHotelByCountry(countryName);
                Services.TownService townService = new Services.TownService();
                countryService.DeleteCountry(countryName);
                Display.RemovedCountryMessage(countryName);
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
        private void RunRemoveTownPage()
        {
            Display.PrintRemoveTownPage();
            Services.CountryService countryService = new Services.CountryService();
            try
            {
                string countryName = Console.ReadLine();
                countryService.GetCountryByName(countryName);
                Console.WriteLine("Now enter name of town:");
                string townName = Console.ReadLine();
                Services.VoucherService voucherService = new Services.VoucherService();
                Services.HotelService hotelService = new Services.HotelService();
                Services.TownService townService = new Services.TownService();
                townService.GetTownByName(countryName, townName);
                voucherService.DeleteVoucherByTown(townName);
                hotelService.DeleteHotelByTown(townName);
                townService.DeleteTown(countryName, townName);
                Display.RemovedTownMessage(countryName, townName);
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
        private void RunRemoveHotelPage()
        {
            //Display.PrintRemoveHotelPage();
            //Services.CountryService countryService = new Services.CountryService();
            //try
            //{
            //    string countryName = Console.ReadLine();
            //    countryService.GetCountryByName(countryName);
            //    Console.WriteLine("Now enter name of town:");
            //    string townName = Console.ReadLine();
            //    Services.VoucherService voucherService = new Services.VoucherService();
            //    Services.HotelService hotelService = new Services.HotelService();
            //    Services.TownService townService = new Services.TownService();
            //    townService.GetTownByName(countryName, townName);
            //    voucherService.DeleteVoucherByTown(townName);
            //    hotelService.DeleteHotelByTown(townName);
            //    townService.DeleteTown(countryName, townName);
            //    Display.RemovedTownMessage(countryName, townName);
            //}
            //catch (Exception ex)
            //{
            //    Display.PrintErrorScreen();
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(Display.GoBackMessage());
            //}
            //Console.ReadKey(true);
        }

        //in progress
        private void RunRemoveTourist()
        {

        }

        //in progress
        private void RunRemoveVoucher()
        {

        }
    }
}