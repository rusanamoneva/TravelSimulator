using System;
using System.Collections.Generic;
using System.Text;

namespace TravelSimulator.Data.Models
{
    public class Room
    {
        public int Id { get; set; }

        public RoomType RoomType { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public Room()
        { }
        
    }
}
