using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Models;

namespace TravelSimulator.Data.Models
{
    public class Hotel
    {
        private string hotelName;

        private int stars;

        private decimal initialPricePerNight;

        public int Id { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }

        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public Hotel()
        {
            this.Vouchers = new List<Voucher>();
        }

        public string HotelName
        {
            get { return this.hotelName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should be more than 1 character.");
                }

                this.hotelName = value;
            }
        }

        public int Stars
        {
            get { return this.stars; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Stars should be more than 0.");
                }

                this.stars = value;
            }
        }

        public decimal PricePerNight
        {
            get { return this.initialPricePerNight; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price should be more than 0.");
                }

                this.initialPricePerNight = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Hotel: {this.HotelName} ")
                .Append('*', this.Stars).AppendLine()
                .Append($"Town: {this.Town.TownName}").AppendLine()
                .Append($"Price per night: {this.initialPricePerNight:f2}lv.");

            return sb.ToString();
        }
    }
}