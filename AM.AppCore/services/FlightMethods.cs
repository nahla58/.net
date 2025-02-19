using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AM.ApplicationCore.domain;
using System.Globalization;
using AM.ApplicationCore.Interfaces;
//using System.Numerics;


namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public Action<Plane> FlightDetailDel { get; set; }
        public Func<string, double> DurationAverageDel;
        private object t;

        public FlightMethods()
        {
            //  FlightDetailDel = ShowLightDetails;
            FlightDetailDel = pl =>
            {
                var req = from f in Flights
                          where f.Plane == pl
                          select new { f.FlightDate, f.Destination };//type anonyme 
                foreach (var f in req)
                    Console.WriteLine(f);
            };
            DurationAverageDel = destination =>
            {
                var req = from f in Flights
                          where f.Destination == destination
                          select f.EstimatedDuration;
                return req.Average();
            };

        }
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();

            //foreach(Flight f in Flights) 
            //     if(f.Destination == destination)
            //         dates.Add(f.FlightDate);

            dates = (from f in Flights
                     where f.Destination == destination
                     select f.FlightDate).ToList();
            dates = Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
            return dates;

        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                        if (f.Destination == filterValue)
                            Console.WriteLine(f);
                    break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure == filterValue)
                            Console.WriteLine(f);
                    break;
                case "EstimationDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration == Int32.Parse(filterValue))
                            Console.WriteLine(f);
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    break;

            }
        }

        public void ShowLightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.Plane == plane
                      select new { f.FlightDate, f.Destination };//type anonyme 
            var req2 = Flights.Where(p => p.Plane == plane).Select(f => new { f.FlightDate, f.Destination });
            foreach (var f in req)
                Console.WriteLine(f);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {

            var req = from f in Flights
                      where DateTime.Compare(f.FlightDate, startDate) >= 0 &&
                      (f.FlightDate - startDate).TotalDays < 8
                      select f;
            var req2 = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) >= 0 &&
             (f.FlightDate - startDate).TotalDays < 8);
            return req.Count();
        }
        /*  public double DurationAverage(string destination)
          {
              var req = from f in Flights

             var req2 = Flights.Where(f=>f.Destination == destination).Average(f=>f.EstimationDuration);
             return req.Average();
                  }*/
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;
            var req2 = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req;
        }
        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3).ToList();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            var req2 = Flights.GroupBy(f => f.Destination);
            foreach (var g in req)
            {
                Console.WriteLine(g.Key);
                foreach (Flight f in g)
                    Console.WriteLine(f.FlightDate);
            }
            return req;

        }

    }
}