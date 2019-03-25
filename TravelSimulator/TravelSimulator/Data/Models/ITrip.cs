using System;
using System.Collections.Generic;
using System.Text;

namespace TravelSimulator.Models
{
    interface ITrip
    {
        decimal TripPrice { get; set; }
        int DaysOfTrip { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

    }
}
