﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public enum PlaneType
    {
        Boeing,
        Airbus
    }
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Capacity :" + Capacity + "PlaneType :" + PlaneType;
        }
    }
}
