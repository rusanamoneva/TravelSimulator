using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Models;

namespace TravelSimulator.Data.Models
{
    public class Voucher
    {
        //this class contains information about tourist's trip

        private int daysOfTrip;

        private decimal tripPrice;

        //represents how many days before startDate the trip can be cancelled
        private int cancellationPeriod;

        public Voucher()
        { }

        public int Id { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public int TouristId { get; set; }
        public virtual Tourist Tourist { get; set; }

        public int DaysOfTrip
        {
            get { return this.daysOfTrip; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Days of trip should be more than 1 day.");
                }

                this.daysOfTrip = value;
            }
        }

        public decimal TripPrice
        {
            get { return this.tripPrice; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Days of trip should be more than 1 day.");
                }

                this.tripPrice = value;
            }
        }

        public int CancellationPeriod
        {
            get { return this.cancellationPeriod; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cancellation period should be more than 1 day.");
                }

                this.cancellationPeriod = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Tourist first name: {this.Tourist.TouristFirstName}")
                .Append($"Tourist last name: {this.Tourist.TouristLastName}")
                .Append($"Country name: {this.Hotel.Town.Country.CountryName}")
                .Append($"Town name: {this.Hotel.Town.TownName}")
                .Append($"Hotel name: {this.Hotel.HotelName}")
                .Append($"Days of trip: {this.DaysOfTrip}")
                .Append($"Trip price: {this.TripPrice}lv")
                .Append($"Cancellation period: {this.CancellationPeriod}");

            return sb.ToString();
        }
    }
}
