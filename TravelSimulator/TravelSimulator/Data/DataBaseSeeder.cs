using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Services;

namespace TravelSimulator.Data
{
    public class DataBaseSeeder
    {
        private CountryService countryService;
        private TownService townService;
        private HotelService hotelService;

        public DataBaseSeeder()
        {
            this.countryService = new CountryService();
            this.townService = new TownService();
            this.hotelService = new HotelService();
        }

        public void SeedTableCountry()
        {
            countryService.AddCountry("Germany");
            countryService.AddCountry("Greece");
            countryService.AddCountry("Serbia");
            countryService.AddCountry("France");
            countryService.AddCountry("Russia");
            countryService.AddCountry("Turkey");
            countryService.AddCountry("Hungary");
            countryService.AddCountry("Austria");
            countryService.AddCountry("Norway");
        }

        public void SeedTableTowns()
        {
            townService.AddTown("Bulgaria", "Plovdiv");
            townService.AddTown("Bulgaria", "Burgas");
            townService.AddTown("Bulgaria", "Varna");
            townService.AddTown("Bulgaria", "Nessebar");
            townService.AddTown("Bulgaria", "Bansko");
            townService.AddTown("Bulgaria", "Borovets");
            townService.AddTown("Bulgaria", "Velingrad");
            townService.AddTown("Bulgaria", "Sunny Beach");

            townService.AddTown("Germany", "Berlin");
            townService.AddTown("Germany", "Munich");
            townService.AddTown("Germany", "Hanover");

            townService.AddTown("Greece", "Kavala");
            townService.AddTown("Greece", "Athens");
            townService.AddTown("Greece", "Halkidiki");
            townService.AddTown("Greece", "Thessaloniki");

            townService.AddTown("Serbia", "Belgrade");
            townService.AddTown("Serbia", "Dimitrovgrad");

            townService.AddTown("France", "Paris");
            townService.AddTown("France", "Lion");

            townService.AddTown("Russia", "Moscow");
            townService.AddTown("Russia", "St. Petersburg");

            townService.AddTown("Turkey", "Edirne");
            townService.AddTown("Turkey", "Istanbul");

            townService.AddTown("Austria", "Vienna");
            townService.AddTown("Austria", "Salzburg");

            townService.AddTown("Hungary", "Budapest");

            townService.AddTown("Norway", "Oslo");

        }

        public void SeedTableHotelsInBulgaria()
        {
            hotelService.AddHotel("Bulgaria", "Sofia", "Grand Hotel Sofia", 5, 150);
            hotelService.AddHotel("Bulgaria", "Sofia", "InterContinental", 5, 160);
            hotelService.AddHotel("Bulgaria", "Sofia", "Acord", 3, 60);
            hotelService.AddHotel("Bulgaria", "Sofia", "Hilton", 5, 150);
            hotelService.AddHotel("Bulgaria", "Sofia", "Lion", 3, 65);

            hotelService.AddHotel("Bulgaria", "Plovdiv", "Hotel Plovdiv", 3, 55);
            hotelService.AddHotel("Bulgaria", "Plovdiv", "Trimontium", 4, 70);
            hotelService.AddHotel("Bulgaria", "Plovdiv", "Hotel Zdravets", 3, 60);

            hotelService.AddHotel("Bulgaria", "Burgas", "Sunny", 3, 40);
            hotelService.AddHotel("Bulgaria", "Burgas", "Burgas Beach", 4, 70);
            hotelService.AddHotel("Bulgaria", "Burgas", "Atlantis Resort", 4, 75);
            hotelService.AddHotel("Bulgaria", "Burgas", "St Anastasia", 4, 95);

            hotelService.AddHotel("Bulgaria", "Varna", "South Bay", 4, 100);
            hotelService.AddHotel("Bulgaria", "Varna", "Galeria", 4, 105);
            hotelService.AddHotel("Bulgaria", "Varna", "Victoria", 3, 60);

            hotelService.AddHotel("Bulgaria", "Sunny Beach", "Grand Victoria", 4, 100);
            hotelService.AddHotel("Bulgaria", "Sunny Beach", "Jasmine", 3, 65);
            hotelService.AddHotel("Bulgaria", "Sunny Beach", "Majestic", 5, 150);
            hotelService.AddHotel("Bulgaria", "Sunny Beach", "Baikal", 4, 75);
            hotelService.AddHotel("Bulgaria", "Sunny Beach", "Trakia", 3, 55);

            hotelService.AddHotel("Bulgaria", "Nessebar", "Sol Nessebar Palace", 5, 145);
            hotelService.AddHotel("Bulgaria", "Nessebar", "Dolphin", 3, 45);
            hotelService.AddHotel("Bulgaria", "Nessebar", "Zlatna Ribka", 3, 40);
            hotelService.AddHotel("Bulgaria", "Nessebar", "Festa Panorama", 4, 110);

            hotelService.AddHotel("Bulgaria", "Bansko", "Maria Antoaneta", 3, 45);
            hotelService.AddHotel("Bulgaria", "Bansko", "Grand Hotel Bansko", 4, 55);
            hotelService.AddHotel("Bulgaria", "Bansko", "Campanella", 3, 60);

            hotelService.AddHotel("Bulgaria", "Borovets", "Lion", 4, 50);
            hotelService.AddHotel("Bulgaria", "Borovets", "Samokov", 3, 40);
            hotelService.AddHotel("Bulgaria", "Borovets", "Borovets Hills", 5, 100);
            hotelService.AddHotel("Bulgaria", "Borovets", "Flora", 4, 80);

            hotelService.AddHotel("Bulgaria", "Velingrad", "Select", 4, 65);
            hotelService.AddHotel("Bulgaria", "Velingrad", "Zdravets", 3, 55);
            hotelService.AddHotel("Bulgaria", "Velingrad", "Olymp", 4, 70);
        }
    }
}
