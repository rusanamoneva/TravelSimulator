using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;

namespace TravelSimulator.Models
{
    public class Tourist 
    {
        private string touristFirstName;

        private string touristLastName;

        private int age;

        private string countryName;

        public Tourist()
        {
            this.Vouchers = new List<Voucher>();
        }

        public int Id { get; set; }

        public ICollection<Voucher> Vouchers { get; set; }

        public string TouristFirstName
        {
            get { return this.touristFirstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name! It should be longer that 1 character.");
                }

                this.touristFirstName = value;
            }
        }

        public string TouristLastName
        {
            get { return this.touristLastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name! It should be longer that 1 character.");
                }

                this.touristLastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid age! Age should be more than 0.");
                }

                this.Age = value;
            }
        }

        public string CountryName
        {
            get { return this.countryName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid country name! It should be more than 1 character.");
                }

                countryName = value;
            }
        }








    }
}
