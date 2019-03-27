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

        private decimal pricePerNight;

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
                    throw new ArgumentException("Invalid name! It should be longer that 1 character.");
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
            get { return this.pricePerNight; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price should be more than 0.");
                }

                this.pricePerNight = value;
            }
        }

    }
}
