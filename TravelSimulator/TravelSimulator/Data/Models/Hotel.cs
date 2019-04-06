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

        private decimal InitialPricePerNight;

        public int Id { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public Hotel()
        {
            this.Vouchers = new List<Voucher>();
            this.Rooms = new List<Room>();
        }

        public string HotelName
        {
            get { return this.hotelName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should be more that 1 character.");
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
            get { return this.InitialPricePerNight + this.Stars*10; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Initial price should be more than 0.");
                }

                this.InitialPricePerNight = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Hotel: {this.HotelName} ")
                .Append('*', this.Stars).AppendLine()
                .Append($"Town: {this.Town.TownName}").AppendLine()
                .Append($"Price per night: {this.PricePerNight :2f}lv.");

            return sb.ToString();
        }
    }
}