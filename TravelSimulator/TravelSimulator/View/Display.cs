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
    }
}