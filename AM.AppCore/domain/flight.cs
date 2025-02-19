using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }  // Assurez-vous que cette ligne existe
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }



        public override string ToString()
        {
            return "Flight date: " + FlightDate + "destination" + Destination
          + "estimated duration" + EstimatedDuration;
        }

    }
}
