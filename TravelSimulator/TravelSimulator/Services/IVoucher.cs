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

        decimal CalculateTripPrice(int voucherId);

        List<Voucher> GetAllVouchersByTouristNameAndHotel(string touristFirstName, string touristLastName, Hotel hotel);

        List<Voucher> GetArrtivalsByDate(DateTime startDate);

        List<Voucher> GetDeparturesByDate(DateTime endDate);

        List<Tourist> GetAllTouristsByHotel(string countryName, string townName, string hotelName);

        decimal GetPriceWithDiscount(int voucherId, decimal discountPercent);

        string DeleteVoucherByCountry(string countryName);

        string DeleteVoucherByTown(string townName);
    }
}
