using AM.ApplicationCore.domain;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System; // Ajout nécessaire pour Console et DateTime

Plane plane3 = new Plane
{
    ManufactureDate = DateTime.Now,
    Capacity = 300,
    PlaneId = 3,
    PlaneType = PlaneType.Boeing
};
Console.WriteLine(plane3.ToString());

Plane plane4 = new Plane();
Console.WriteLine(plane4.ToString());

Passenger passenger = new Passenger
{
    FirstName = "nahla",
    LastName = "messaoudi",
    EmailAddress = "nahla.messaoudi@esprit.tn" // Correction : fermeture de la chaîne
};

Console.WriteLine(passenger.ToString());
//Console.WriteLine(passenger.CheckProfile("nahla", "messaoudi"));
Console.WriteLine(passenger.CheckProfile("nahla", "messaoudi", "nahla.mess@esprit.tn"));

Staff staff1 = new Staff { FirstName = "StaffFirstName", LastName = "StaffLastName" };
Traveller traveller1 = new Traveller { Nationality = "Tunisian", FirstName = "TravellerFirstName" };

passenger.PassengerType();
staff1.PassengerType();
traveller1.PassengerType();

FlightMethods flightMethods = new FlightMethods
{
    Flights = TestData
    .listFlights
};


foreach (var item in flightMethods.GetFlightDates("paris"))
{
    Console.WriteLine(item);
}

Console.WriteLine("");
flightMethods.GetFlights("Destination", "Paris");

FlightMethods fm = new FlightMethods { Flights = TestData.listFlights };
string destination = "Madrid";
Console.WriteLine(" List Dates de la destination " + destination + "  : \n ");
List<DateTime> list = new List<DateTime> { };
list = (List<DateTime>)fm.GetFlightDates(destination);
// using foreach loop
foreach (DateTime d in list)
{
    Console.WriteLine(" Flight Date : " + d);
}
fm.ShowLightDetails(TestData.BoingPlane);
Console.WriteLine(" nb vol : " + fm.ProgrammedFlightNumber(new DateTime(2021, 12, 2)));
Console.WriteLine(" average duration : " + fm.DurationAverageDel(destination));
foreach (Flight f in fm.OrderedDurationFlights())
{
    Console.WriteLine(" Flight : " + f.ToString());
}
foreach (Passenger p in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(" Senior Traveller : " + p.ToString());
}
fm.DestinationGroupedFlights();
// methode 2 
Console.WriteLine();
foreach (var g in fm.DestinationGroupedFlights())
{
    Console.WriteLine(" Destination : " + g.Key);
    foreach (Flight f in g)
    {
        Console.WriteLine("Décollage : " + f.FlightDate.ToString());
    }
}
// calling the delegate
Console.WriteLine();
fm.FlightDetailDel(TestData.BoingPlane);
Console.WriteLine(" average duration : " + fm.DurationAverageDel(destination));

AMContext context=new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();


