using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data;
using System.Linq;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class VoucherService : IVouchersService
    {
        private TravelSimulatorContext context;

        public VoucherService()
        {
            this.context = new TravelSimulatorContext();
        }

        public VoucherService(TravelSimulatorContext cont)
        {
            this.context = cont;
        }

        //Created voucher and adds it to the database
        public string CreateVoucher(Tourist tourist, Hotel hotel, int daysOfTrip, decimal tripPrice, int cancellationPeriod, DateTime startDate, DateTime endDate)
        {
            ValidateData(tourist, hotel);

            decimal totalTripPrice = CalculateTripPriceForVoucher(daysOfTrip, hotel.PricePerNight);

            Voucher voucher = new Voucher()
            {
                Tourist = tourist,
                Hotel = hotel,
                DaysOfTrip = daysOfTrip,
                TripPrice = totalTripPrice,
                CancellationPeriod = cancellationPeriod,
                StartDate = startDate,
                EndDate = endDate
            };

            context.Vouchers.Add(voucher);
            context.SaveChanges();

            string result = "Voucher successfully created.";

            return result;
        }

        //Deletes the voucher of a tourist from the database
        public string DeleteVoucher(Tourist tourist, Hotel hotel)
        {
            Voucher voucherToDelete = new Voucher();

            foreach (Voucher voucher in context.Vouchers.Where(x => x.Hotel.HotelName == hotel.HotelName))
            {
                if (voucher.Tourist.TouristFirstName == tourist.TouristFirstName)
                {
                    voucherToDelete = voucher;
                }
            }

            context.Vouchers.Remove(voucherToDelete);
            context.SaveChanges();

            string result = "Voucher successfully removed.";

            return result;
        }

        //Tested
        //Calculates the price ot the trip by days of trip and hotel price per night
        public decimal CalculateTripPrice(int voucherId)
        {
            Voucher voucher = FindVoucherById(voucherId);

            Tourist tourist = voucher.Tourist;
            int daysOfTrip = voucher.DaysOfTrip;
            decimal hotelPrice = voucher.Hotel.PricePerNight;
            decimal tripPrice = 0M;

            if (tourist.Age <= 12)
            {
                tripPrice = (daysOfTrip * hotelPrice) * 0.7M;
            }

            tripPrice = daysOfTrip * hotelPrice;
            voucher.TripPrice = tripPrice;
            context.SaveChanges();

            return voucher.TripPrice;
        }

        //Tested
        //Lists the vouchers of all arrivals on a specific date
        public List<Voucher> GetArrtivalsByDate(DateTime startDate)
        {
            List<Voucher> vouchersOfArrivals = new List<Voucher>();

            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.StartDate == startDate)
                {
                    vouchersOfArrivals.Add(voucher);
                }
            }

            if (vouchersOfArrivals.Count == 0)
            {
                throw new InvalidOperationException($"No arrivals on {startDate}.");
            }

            return vouchersOfArrivals;
        }

        //Tested
        //Lists the vouchers of all departures on a specific date
        public List<Voucher> GetDeparturesByDate(DateTime endDate)
        {
            List<Voucher> vouchersOfDepartures = new List<Voucher>();

            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.EndDate == endDate)
                {
                    vouchersOfDepartures.Add(voucher);
                }
            }

            if (vouchersOfDepartures.Count == 0)
            {
                throw new InvalidOperationException($"No arrivals on {endDate}.");
            }

            return vouchersOfDepartures;
        }

        //Tested
        //Lists all tourists in a specific hotel
        public List<Tourist> GetAllTouristsByHotel(string countryName, string townName, string hotelName)
        {
            List<Tourist> tourists = new List<Tourist>();

            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.Hotel.HotelName == hotelName
                    && voucher.Hotel.Town.Country.CountryName == countryName
                    && voucher.Hotel.Town.TownName == townName)
                {
                    tourists.Add(voucher.Tourist);
                }
            }

            if (tourists.Count == 0)
            {
                throw new InvalidOperationException($"No tourists to be shown in hotel {hotelName}.");
            }

            return tourists;
        }

        //Tested
        //Changes hotel price with a discount percent and saves the new price in the database
        public decimal GetPriceWithDiscount(int voucherId, decimal discountPercent)
        {
            Voucher voucher = FindVoucherById(voucherId);
            decimal tripPriceWithDiscount = voucher.TripPrice - (voucher.TripPrice * discountPercent / 100);

            voucher.TripPrice = tripPriceWithDiscount;
            context.SaveChanges();


            return FindVoucherById(voucherId).TripPrice;
        }

        //Returns voucher by id
        public Voucher FindVoucherById(int voucherId)
        {
            Voucher voucher = context.Vouchers.FirstOrDefault(x => x.Id == voucherId);

            if (voucher == null)
            {
                throw new InvalidOperationException($"No voucher with id {voucherId}.");
            }

            return voucher;
        }

        //Lists all vouchers by the name of the tourist and the hotel for the trip
        public List<Voucher> GetAllVouchersByTouristNameAndHotel(string touristFirstName, string touristLastName, Hotel hotel)
        {
            List<Voucher> vouchers = new List<Voucher>();

            foreach (Voucher item in context.Vouchers)
            {
                if (item.Tourist.TouristFirstName == touristFirstName
                    && item.Tourist.TouristLastName == touristLastName
                    && item.Hotel.HotelName == hotel.HotelName)
                {
                    vouchers.Add(item);
                }
            }

            if (vouchers.Count == 0)
            {
                throw new InvalidOperationException("No vouchers found.");
            }

            return vouchers;
        }

        //Deletes all vouchers in a specific country
        //Used when deleting a country form the database
        public string DeleteVoucherByCountry(string countryName)
        {
            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.Hotel.Town.Country.CountryName == countryName)
                {
                    DeleteVoucher(voucher.Tourist, voucher.Hotel);
                }
            }

            string result = "Vouchers deleted.";

            return result;
        }

        //Deletes all vouchers in a specific town
        //Used when deleting a town form the database
        public string DeleteVoucherByTown(string townName)
        {
            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.Hotel.Town.TownName == townName)
                {
                    DeleteVoucher(voucher.Tourist, voucher.Hotel);
                }
            }

            string result = "Vouchers deleted.";

            return result;
        }

        private decimal CalculateTripPriceForVoucher(int daysOfTrip, decimal hotelPricePerNight)
        {
            decimal tripPrice = 0M;

            tripPrice = daysOfTrip * hotelPricePerNight;

            return tripPrice;
        }

        //Validates data used in methods
        private void ValidateData(Tourist tourist, Hotel hotel)
        {
            if (context.Tourists.FirstOrDefault(x => x.TouristFirstName == tourist.TouristFirstName) == null)
            {
                throw new ArgumentException("Tourist does not exist.");
            }
            else if (context.Hotels.FirstOrDefault(x => x.HotelName == hotel.HotelName) == null)
            {
                throw new ArgumentException("Hotel does not exist.");
            }
        }

        //Returns a valid town used in methods
        private Town FindTownByName(string countryName, string townName)
        {
            Town town = new Town();

            foreach (Town item in context.Towns)
            {
                if (item.TownName == townName && item.Country.CountryName == countryName)
                {
                    town = item;
                }
            }

            if (town.TownName == null)
            {
                throw new InvalidOperationException("Town not found.");
            }

            return town;
        }

        //Returns a valid country used in methods
        private Country FindCountryByName(string countryName)
        {
            Country country = new Country();

            foreach (Country item in context.Countries)
            {
                if (item.CountryName == countryName)
                {
                    country = item;
                }
            }

            if (country.CountryName == null)
            {
                throw new InvalidOperationException("Country not found.");
            }

            return country;
        }

        //Returns a valid hotel used in methods
        private Hotel FindHotelByName(string townName, string hotelName, Town town)
        {
            Hotel hotel = new Hotel();

            foreach (Hotel item in context.Hotels)
            {
                if (item.Town.Country.CountryName == town.Country.CountryName
                    && item.Town.TownName == townName
                    && item.HotelName == hotelName)
                {
                    hotel = item;
                }
            }

            if (hotel.HotelName == null)
            {
                throw new InvalidOperationException($"Hotel {hotelName} not found in {townName}.");
            }

            return hotel;
        }
    }
}
