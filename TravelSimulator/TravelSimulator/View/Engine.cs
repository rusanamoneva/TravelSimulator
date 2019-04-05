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
                        //;
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
            Display.PrintAddPage();
            do
            {
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
        private void RunFindPage()
        {
            ConsoleKeyInfo key;
            string keyValue;
            Display.PrintFindPage();
            do
            {
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
    }
}
