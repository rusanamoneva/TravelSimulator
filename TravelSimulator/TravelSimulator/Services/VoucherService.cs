using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data;
using System.Linq;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class VoucherService : IVoucher
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

        public string CreateVoucher(Tourist tourist, Hotel hotel, int daysOfTrip, decimal tripPrice, int cancellationPeriod, DateTime startDate, DateTime endDate)
        {
            ValidateData(tourist, hotel);

            Voucher voucher = new Voucher()
            {
                Tourist = tourist,
                Hotel = hotel,
                DaysOfTrip = daysOfTrip,
                TripPrice = tripPrice,
                CancellationPeriod = cancellationPeriod,
                StartDate = startDate,
                EndDate = endDate
            };

            context.Vouchers.Add(voucher);
            context.SaveChanges();

            string result = "Voucher successfully created.";

            return result;
        }

        public string DeleteVoucher(Tourist tourist, Hotel hotel)
        {
            Voucher voucherToDelete = new Voucher();

            foreach (Voucher voucher in context.Vouchers.Where(x => x.Hotel == hotel))
            {
                if (voucher.Tourist == tourist)
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
                throw new InvalidOperationException($"No tourists to be shown in hotel {hotelName}");
            }

            return tourists;
        }

        //Tested
        public decimal GetPriceWithDiscount(int voucherId, decimal discountPercent)
        {
            Voucher voucher = FindVoucherById(voucherId);
            decimal tripPriceWithDiscount = voucher.TripPrice - (voucher.TripPrice * discountPercent / 100);

            voucher.TripPrice = tripPriceWithDiscount;
            context.SaveChanges();


            return FindVoucherById(voucherId).TripPrice;
        }

        public Voucher FindVoucherById(int voucherId)
        {
            Voucher voucher = context.Vouchers.FirstOrDefault(x => x.Id == voucherId);

            if (voucher == null)
            {
                throw new InvalidOperationException($"No voucher with id {voucherId}");
            }

            return voucher;
        }

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
                throw new InvalidOperationException("Town does not exists!");
            }

            return town;
        }

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
                throw new InvalidOperationException("Town should be in a valid country! This country does not exist!");
            }

            return country;
        }

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
                throw new InvalidOperationException($"Hotel {hotelName} does not exist in {townName}");
            }

            return hotel;
        }

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
    }
}
