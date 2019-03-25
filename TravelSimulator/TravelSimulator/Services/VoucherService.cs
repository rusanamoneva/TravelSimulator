using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public class VoucherService : IVoucher
    {
        public VoucherService()
        {

        }

        public decimal CalculateTripPrice()
        {
            throw new NotImplementedException();
        }

        public int CreateVoucher(Tourist tourist, Hotel hotel, int daysOfTrip, decimal tripPrice)
        {
            throw new NotImplementedException();
        }

        public string DeleteVoucher(Tourist tourist, Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public List<Tourist> GetArrtivalsByDate(DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public List<Tourist> GetDeparturesByDate(DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public decimal GetPriceWithDiscount(Tourist tourist, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
