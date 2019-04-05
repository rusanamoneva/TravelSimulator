using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;
using TravelSimulator.Services;

namespace TravelSimulator.Data
{
    public class DataBaseSeeder
    {
        private CountryService countryService;
        private TownService townService;
        private HotelService hotelService;
        private TouristService touristService;
        private VoucherService voucherService;

        public DataBaseSeeder()
        {
            this.countryService = new CountryService();
            this.townService = new TownService();
            this.hotelService = new HotelService();
            this.touristService = new TouristService();
            this.voucherService = new VoucherService();
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

        public void SeedTableTourists()
        {
            touristService.RegisterTourist("Ivan", "Ivanov", 25, "Bulgaria");
            touristService.RegisterTourist("Maria", "Georgieva", 60, "Bulgaria");
            touristService.RegisterTourist("John", "Smith", 35, "England");
            touristService.RegisterTourist("Alina", "Zagitova", 23, "Russia");
            touristService.RegisterTourist("Maksim", "Lavrov", 32, "Russia");
            touristService.RegisterTourist("Vika", "Lavrova", 30, "Russia");
            touristService.RegisterTourist("Sam", "Coleman", 55, "England");
            touristService.RegisterTourist("Annie", "Wilson", 21, "England");
            touristService.RegisterTourist("Naomi", "Clark", 21, "England");
            touristService.RegisterTourist("Erin", "Silver", 20, "England");
            touristService.RegisterTourist("Teddy", "Montgomery", 25, "England");
            touristService.RegisterTourist("Ekaterina", "Nikolova", 37, "Bulgaria");
            touristService.RegisterTourist("Simeon", "Kovachev", 42, "Bulgaria");
            touristService.RegisterTourist("Kalina", "Dimitorova", 51, "Bulgaria");
            touristService.RegisterTourist("Dimitur", "Hristov", 53, "England");
        }

        public void SeedTableVouchers()
        {
            Town town = townService.GetTownByName("Bulgaria", "Sunny Beach");
            Hotel hotel = hotelService.FindHotelByName("Jasmine", town);
            Tourist tourist = touristService.GetTouristById(1);
            DateTime startDate = new DateTime(2019, 07, 10);
            DateTime endDate = new DateTime(2019, 07, 17);
            voucherService.CreateVoucher(tourist, hotel, 7, 0, 10, startDate, endDate);

            Tourist tourist2 = touristService.GetTouristById(2);
            DateTime startDate2 = new DateTime(2019, 08, 01);
            DateTime endDate2 = new DateTime(2019, 08, 15);
            voucherService.CreateVoucher(tourist2, hotel, 15, 0, 20, startDate2, endDate2);

            Tourist tourist3 = touristService.GetTouristById(3);
            DateTime startDate3 = new DateTime(2019, 06, 21);
            DateTime endDate3 = new DateTime(2019, 06, 26);
            voucherService.CreateVoucher(tourist3, hotel, 5, 0, 7, startDate3, endDate3);

            Town town2 = townService.GetTownByName("Bulgaria", "Bansko");
            Hotel hotel2 = hotelService.FindHotelByName("Campanella", town2);
            Tourist tourist4 = touristService.GetTouristById(4);
            DateTime startDate4 = new DateTime(2019, 10, 17);
            DateTime endDate4 = new DateTime(2019, 10, 29);
            voucherService.CreateVoucher(tourist4, hotel2, 12, 0, 15, startDate4, endDate4);

            Tourist tourist5 = touristService.GetTouristById(5);
            DateTime startDate5 = new DateTime(2019, 12, 01);
            DateTime endDate5 = new DateTime(2019, 12, 10);
            voucherService.CreateVoucher(tourist5, hotel2, 10, 0, 10, startDate5, endDate5);

            Hotel hotel3 = hotelService.FindHotelByName("Majestic", town);
            Tourist tourist6 = touristService.GetTouristById(6);
            DateTime startDate6 = new DateTime(2019, 06, 19);
            DateTime endDate6 = new DateTime(2019, 06, 29);
            voucherService.CreateVoucher(tourist6, hotel3, 10, 0, 15, startDate6, endDate6);

            Tourist tourist7 = touristService.GetTouristById(7);
            DateTime startDate7 = new DateTime(2019, 08, 03);
            DateTime endDate7 = new DateTime(2019, 08, 13);
            voucherService.CreateVoucher(tourist7, hotel3, 10, 0, 10, startDate7, endDate7);
            
            Town town3 = townService.GetTownByName("Bulgaria", "Borovets");
            Hotel hotel4 = hotelService.FindHotelByName("Samokov", town3);
            Tourist tourist9 = touristService.GetTouristById(9);
            DateTime startDate9 = new DateTime(2019, 10, 17);
            DateTime endDate9 = new DateTime(2019, 10, 29);
            voucherService.CreateVoucher(tourist9, hotel4, 12, 0, 15, startDate9, endDate9);

            Tourist tourist8 = touristService.GetTouristById(8);
            voucherService.CreateVoucher(tourist8, hotel, 10, 0, 15, startDate6, endDate6);
            
            Tourist tourist10 = touristService.GetTouristById(10);
            DateTime startDate10 = new DateTime(2019, 11, 17);
            DateTime endDate10 = new DateTime(2019, 11, 29);
            voucherService.CreateVoucher(tourist10, hotel4, 12, 0, 15, startDate10, endDate10);

            Tourist tourist11 = touristService.GetTouristById(11);
            voucherService.CreateVoucher(tourist11, hotel, 7, 0, 10, startDate, endDate);

            Tourist tourist12 = touristService.GetTouristById(12);
            voucherService.CreateVoucher(tourist12, hotel3, 7, 0, 10, startDate, endDate);

            Tourist tourist13 = touristService.GetTouristById(13);
            voucherService.CreateVoucher(tourist13, hotel3, 7, 0, 10, startDate, endDate);

            Tourist tourist14 = touristService.GetTouristById(14);
            voucherService.CreateVoucher(tourist14, hotel, 10, 0, 15, startDate6, endDate6);

            Tourist tourist15 = touristService.GetTouristById(15);
            voucherService.CreateVoucher(tourist15, hotel, 10, 0, 15, startDate6, endDate6);
        }
    }
}
