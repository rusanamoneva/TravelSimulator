using System;
using System.Collections.Generic;
using System.Text;

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
                    .Append("[2] - Find...")
                    .AppendLine()
                    .Append("[3] - List...")
                    .AppendLine()
                    .Append("[4] - Change...")
                    .AppendLine()
                    .Append("[5] - Remove...")
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

        //--------------------------//

        //Find page elements:
        //----FIND----
        private static string FindPageMenu()
        {
            StringBuilder home = new StringBuilder();
            return home.Append('-', 19).Append("FIND").Append('-', 19).AppendLine().ToString();
        }

        public static void PrintFindPage()
        {
            Console.Clear();
            Console.WriteLine(Header());
            Console.WriteLine(FindPageMenu());
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
                    .Append("[2] - Towns")
                    .AppendLine()
                    .Append("[3] - Hotels")
                    .AppendLine()
                    .Append("[4] - Leaving on...")
                    .AppendLine()
                    .Append("[5] - Arriving on...")
                    .AppendLine()
                    .Append("[6] - Tourists")
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

        public static string GoBackMessage()
        {
            return Environment.NewLine + "Press any key to go back.";
        }
    }
}