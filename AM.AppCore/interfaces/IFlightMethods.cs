using System;
using System.Collections.Generic;
using AM.ApplicationCore.domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
        public void ShowLightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        //double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        public IList<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights();
       

        
    }
}