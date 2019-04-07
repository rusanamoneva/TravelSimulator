using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data;
using TravelSimulator.Models;

namespace TravelSimulator.View
{
    public class Display
    {
        //common elements:
        private static string Header()
        {
            StringBuilder header = new StringBuilder();
            header.Append('#', 42);
            header.AppendLine();
            header.Append('#', 12);
            header.Append(" TRAVEL SIMULATOR ");
            header.Append('#', 12);
            header.AppendLine();
            header.Append('#', 42);
            header.AppendLine();
            return header.ToString();
        }

        private static string Footer()
        {
            StringBuilder footer = new StringBuilder();
            return footer.AppendLine().Append('=', 42).AppendLine().Append("[0] - Back").ToString();
        }

        public static string GoBackMessage()
        {
            return Environment.NewLine + "Press any key to go back.";
        }

        //--------------------------//

        //Home page elements:
        //"----HOME----"
        private static string HomePageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 19).Append("HOME").Append('-', 19).AppendLine().ToString();
        }

        //Buttons
        private static string HomePageOptions()
        {
            StringBuilder options = new StringBuilder();
            options.AppendLine()
                    .AppendLine()
                    .Append("[1] - Add new...")
                    .AppendLine()
                    .Append("[2] - List...")
                    .AppendLine()
                    .Append("[3] - Remove...")
                    .AppendLine()
                    .AppendLine()
                    .AppendLine()
                    .AppendLine();

            return options.ToString();
        }

        //Special footer
        private static string HomePageFooter()
        {
            StringBuilder footer = new StringBuilder();
            return footer.AppendLine().Append('=', 42).AppendLine().Append("[Esc] - Exit").ToString();
        }

        public static void PrintHomePage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(HomePageMenu());
            Console.WriteLine(HomePageOptions());
            Console.WriteLine(HomePageFooter());
        }

        //--------------------------//

        //Add page elements:
        //----ADD NEW...----
        private static string AddPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 16).Append("ADD NEW...").Append('-', 16).AppendLine().ToString();
        }

        //Buttons
        private static string AddPageOptions()
        {
            StringBuilder options = new StringBuilder();
            options.AppendLine()
                    .AppendLine()
                    .Append("[1] - Country")
                    .AppendLine()
                    .Append("[2] - Town")
                    .AppendLine()
                    .Append("[3] - Hotel")
                    .AppendLine()
                    .Append("[4] - Tourist")
                    .AppendLine()
                    .Append("[5] - Voucher")
                    .AppendLine()
                    .AppendLine();

            return options.ToString();
        }

        public static void PrintAddPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddPageMenu());
            Console.WriteLine(AddPageOptions());
            Console.WriteLine(Footer());
        }

        //Add country page elements:
        //----Add a new country----
        private static string AddCountryPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 12).Append("ADD A NEW COUNTRY:").Append('-', 12).AppendLine().ToString();
        }

        public static void PrintAddCountryPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddCountryPageMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void AddedCountryMessage(string countryName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddCountryPageMenu());
            Console.WriteLine($"Successfully added {countryName}.");
            Console.WriteLine(GoBackMessage());
        }

        //Add town elements:
        //----Add a new town----
        private static string AddTownPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 14).Append("ADD A NEW TOWN").Append('-', 14).AppendLine().ToString();
        }

        public static void PrintAddTownPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddTownPageMenu());
            Console.WriteLine("First, enter name of country:");
        }

        public static void PrintAddTownBottom()
        {
            Console.WriteLine("Now enter name of town:");
        }

        public static void AddedTownMessage(string countryName, string townName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddTownPageMenu());
            Console.WriteLine($"Successfully added {townName} in {countryName}.");
            Console.WriteLine(GoBackMessage());
        }

        //Add hotel elements:
        //----Add a new hotel----
        private static string AddHotelPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 13).Append("ADD A NEW HOTEL:").Append('-', 13).AppendLine().ToString();
        }

        public static void PrintAddHotelPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddHotelPageMenu());
            Console.WriteLine("First, enter name of country:");
        }

        public static void PrintAddHotelMiddle()
        {
            Console.WriteLine("Now enter name of town:");
        }

        public static void PrintAddHotelBottom()
        {
            Console.WriteLine("Enter Hotel name:");
        }

        public static void AddedHotelMessage(string townName, string hotelName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddHotelPageMenu());
            Console.WriteLine($"Successfully added {hotelName} in {townName}.");
            Console.WriteLine(GoBackMessage());
        }

        //Add tourist elements:
        //----Add a new tourist:----
        private static string AddTouristPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 12).Append("ADD A NEW TOURIST:").Append('-', 12).AppendLine().ToString();
        }

        public static void PrintAddTouristPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddTouristPageMenu());
            Console.WriteLine("Enter first name:");
        }

        public static void AddedTouristMessage(string firstName, string lastName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddTouristPageMenu());
            Console.WriteLine($"Successfully registered {firstName} {lastName}.");
            Console.WriteLine(GoBackMessage());
        }
        
        //Add voucher elements
        //----Add a new voucher----
        private static string AddVoucherPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 12).Append("ADD A NEW VOUCHER:").Append('-', 12).AppendLine().ToString();
        }

        public static void PrintAddVoucherPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddVoucherPageMenu());
        }

        public static void AddedVoucherMessage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(AddVoucherPageMenu());
            Console.WriteLine("Successfully added voucher.");
            Console.WriteLine(GoBackMessage());
        }
        
        //--------------------------//

        //List page elements:
        //----List----
        private static string ListPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 19).Append("LIST").Append('-', 19).AppendLine().ToString();
        }

        //Buttons
        private static string ListPageOptions()
        {
            StringBuilder options = new StringBuilder();
            options.AppendLine()
                    .AppendLine()
                    .Append("[1] - Countries")
                    .AppendLine()
                    .Append("[2] - Towns in...")
                    .AppendLine()
                    .Append("[3] - Hotels in...")
                    .AppendLine()
                    .Append("[4] - Tourists...")
                    .AppendLine()
                    .AppendLine()
                    .AppendLine();

            return options.ToString();
        }

        public static void PrintListPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListPageMenu());
            Console.WriteLine(ListPageOptions());
            Console.WriteLine(Footer());
        }

        //----Countries:----
        private static string ListCountriesMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 16).Append("COUNTRIES:").Append('-', 16).AppendLine().ToString();
        }

        public static void PrintListCountries()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListCountriesMenu(), Environment.NewLine);
            TravelSimulatorContext context = new TravelSimulatorContext();
            foreach (Country country in context.Countries)
            {
                Console.WriteLine(country.CountryName);
            }
            Console.WriteLine(GoBackMessage());
        }

        //----Towns:----
        private static string ListTownsMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 18).Append("TOWNS:").Append('-', 18).AppendLine().ToString();
        }

        public static void PrintListTowns()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTownsMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void PrintListTownsBottom(string countryName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTownsMenu());
            Console.WriteLine($"Towns in {countryName}:" + Environment.NewLine);
            Services.TownService townService = new Services.TownService();
            foreach (Town town in townService.ShowAllTownsInCountry(countryName))
            {
                Console.WriteLine(town.TownName);
            }
            Console.WriteLine(GoBackMessage());
        }

        //----Hotels----
        private static string ListHotelsMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 18).Append("HOTELS").Append('-', 18).AppendLine().ToString();
        }

        public static void PrintListHotels()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListHotelsMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void PrintListHotelsMiddle()
        {
            Console.WriteLine("Now enter name of town:");
        }

        public static void PrintListHotelsBottom(string countryName, string townName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListHotelsMenu());
            Console.WriteLine($"Hotels in {townName}:" + Environment.NewLine);
            Services.HotelService hotelService = new Services.HotelService();
            foreach (Data.Models.Hotel hotel in hotelService.ShowAllHotelsInTown(countryName, townName))
            {
                Console.WriteLine(hotel.ToString());
            }
            Console.WriteLine(GoBackMessage());
        }

        //----List tourists...----
        private static string ListTouristsMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 13).Append("LIST TOURISTS...").Append('-', 13).AppendLine().ToString();
        }

        //Buttons
        private static string ListTouristsOptions()
        {
            StringBuilder options = new StringBuilder();
            options.AppendLine()
                    .AppendLine()
                    .Append("[1] - By home country...")
                    .AppendLine()
                    .Append("[2] - By hotel...")
                    .AppendLine()
                    .AppendLine()
                    .AppendLine()
                    .AppendLine()
                    .AppendLine();

            return options.ToString();
        }

        public static void PrintListTouristsPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTouristsMenu());
            Console.WriteLine(ListTouristsOptions());
            Console.WriteLine(Footer());
        }

        public static void PrintListTouristsByCountry()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTouristsMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void PrintListTouristsByHotel()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTouristsMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void ListTouristsByCountry(string countryName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTouristsMenu());
            Console.WriteLine($"Tourists from {countryName}:" + Environment.NewLine);

            Services.TouristService touristService = new Services.TouristService();
            foreach (Tourist tourist in touristService.ShowAllTouristsByCountryTheyComeFrom(countryName))
            {
                Console.WriteLine(tourist.ToString());
            }

            Console.WriteLine(GoBackMessage());
        }

        public static void ListTouristsByHotel(string countryName, string townName, string hotelName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ListTouristsMenu());
            Console.WriteLine($"Tourists in {hotelName}:" + Environment.NewLine);

            Services.VoucherService voucherService = new Services.VoucherService();
            foreach (Tourist tourist in voucherService.GetAllTouristsByHotel(countryName, townName, hotelName))
            {
                Console.WriteLine(tourist.ToString());
            }

            Console.WriteLine(GoBackMessage());
        }

        //--------------------------//

        //Remove page elements:
        //----Remove----
        private static string RemovePageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 18).Append("REMOVE").Append('-', 18).AppendLine().ToString();
        }

        //Buttons
        private static string RemovePageOptions()
        {
            StringBuilder options = new StringBuilder();
            options.AppendLine()
                    .AppendLine()
                    .Append("[1] - Country")
                    .AppendLine()
                    .Append("[2] - Town")
                    .AppendLine()
                    .Append("[3] - Hotel")
                    .AppendLine()
                    .Append("[4] - Tourist")
                    .AppendLine()
                    .Append("[5] - Voucher")
                    .AppendLine()
                    .AppendLine();

            return options.ToString();
        }

        public static void PrintRemovePage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(RemovePageMenu());
            Console.WriteLine(RemovePageOptions());
            Console.WriteLine(Footer());
        }

        //Remove country page elements:
        //----Remove country----
        private static string RemoveCountryPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 14).Append("REMOVE COUNTRY").Append('-', 14).AppendLine().ToString();
        }

        public static void PrintRemoveCountryPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(RemoveCountryPageMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void RemovedCountryMessage(string countryName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(RemoveCountryPageMenu());
            Console.WriteLine($"Successfully removed {countryName}.");
            Console.WriteLine(GoBackMessage());
        }

        //Remove town page elements:
        //----Remove town----
        private static string RemoveTownPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 15).Append("REMOVE TOWN:").Append('-', 15).AppendLine().ToString();
        }

        public static void PrintRemoveTownPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(RemoveTownPageMenu());
            Console.WriteLine("Enter name of country:");
        }

        public static void RemovedTownMessage(string countryName, string townName)
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(RemoveTownPageMenu());
            Console.WriteLine($"Successfully removed {townName} from {countryName}.");
            Console.WriteLine(GoBackMessage());
        }

        //--------------------------//

        //Error screen elements:
        //----Error!----
        private static string ErrorMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 18).Append("ERROR!").Append('-', 18).AppendLine().ToString();
        }

        public static void PrintErrorScreen()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(ErrorMenu());
        }
    }
}