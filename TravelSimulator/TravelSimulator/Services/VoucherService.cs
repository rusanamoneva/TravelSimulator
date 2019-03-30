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

        public decimal CalculateTripPrice(Tourist tourist, Hotel hotel, int daysOfTrip)
        {
            decimal tripPrice = 0M;

            if (tourist.Age <= 12)
            {
                tripPrice = (daysOfTrip * hotel.PricePerNight) * 0.7M;
            }

            tripPrice = daysOfTrip * hotel.PricePerNight;

            return tripPrice;
        }

        public List<Tourist> GetArrtivalsByDate(DateTime startDate)
        {
            List<Tourist> arrivals = new List<Tourist>();

            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.StartDate == startDate)
                {
                    arrivals.Add(voucher.Tourist);
                }
            }

            return arrivals;
        }

        public List<Tourist> GetDeparturesByDate(DateTime endDate)
        {
            List<Tourist> departures = new List<Tourist>();

            foreach (Voucher voucher in context.Vouchers)
            {
                if (voucher.EndDate == endDate)
                {
                    departures.Add(voucher.Tourist);
                }
            }

            return departures;
        }

        public decimal GetPriceWithDiscount(Voucher voucher, decimal discountPercent)
        {
            decimal tripPriceWithDiscount = voucher.TripPrice - (voucher.TripPrice * discountPercent);

            return tripPriceWithDiscount;
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
    }
}
