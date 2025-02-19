using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Staff : Passenger
    {
        public float Salary { get; set; }
        public string Function { get; set; }
        public DateTime EmploymentDate { get; set; }
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a staff");
        }
    }
}
