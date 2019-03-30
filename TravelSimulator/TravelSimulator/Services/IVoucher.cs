using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface IVoucher
    {
        string CreateVoucher(Tourist tourist, Hotel hotel, int daysOfTrip, decimal tripPrice, int cancellationPeriod, DateTime startDate, DateTime endDate);

        string DeleteVoucher(Tourist tourist, Hotel hotel);

        decimal CalculateTripPrice(Tourist tourist, Hotel hotel, int daysOfTrip);

        List<Tourist> GetArrtivalsByDate(DateTime startDate);

        List<Tourist> GetDeparturesByDate(DateTime endDate);

        decimal GetPriceWithDiscount(Voucher voucher, decimal discountPercent);
    }
}
