using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Services
{
    public interface IVoucher
    {
        int CreateVoucher(Tourist tourist, Hotel hotel, int daysOfTrip, decimal tripPrice);

        string DeleteVoucher(Tourist tourist, Hotel hotel);

        decimal CalculateTripPrice();

        List<Tourist> GetArrtivalsByDate(DateTime startDate);

        List<Tourist> GetDeparturesByDate(DateTime endDate);

        decimal GetPriceWithDiscount(Tourist tourist, Hotel hotel);
    }
}
