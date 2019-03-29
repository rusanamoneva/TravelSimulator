using System;
using System.Collections.Generic;
using TravelSimulator.Data.Models;

namespace TravelSimulator.Models
{
    public class Town
    {
        private string townName;

        public Town()
        { }

        public int Id { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public string TownName
        {
            get { return this.townName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name! It should be longer that 1 character.");
                }

                this.townName = value;
            }
        }

        public override string ToString()
        {
            string result = this.TownName;

            return result;
        }
    }
}