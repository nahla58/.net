using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public String TelNumber { get; set; }
        public String PassportNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
        //public Boolean CheckProfile(string first , string last)
        //{
        //   return FirstName == first && LastName == last;
        //}
        public Boolean CheckProfile(string first, string last, string email)
        {
            if (email != null)
                return FirstName == first && LastName == last && EmailAddress == email;
            else
                return FirstName == first && LastName == last;
        }
    }
}
