using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;

namespace TravelSimulator.Models
{
    public class Country
    {
        private string countryName;

        public Country()
        {
            this.Towns = new List<Town>();
        }

        public int Id { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

        public string CountryName
        {
            get { return this.countryName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name! It should be longer that 1 character.");
                }

                this.countryName = value;
            }
        }

        public override string ToString()
        {
            string result = this.CountryName;

            return result;
        }

    }
}
