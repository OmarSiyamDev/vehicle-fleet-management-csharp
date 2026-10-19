using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Management_System
{
    public class Car : Vehicle
    {
        public int SeatingCapacity { get; set; }

        public Car(string make, string model, string vin, int seats, decimal rate)
          : base(make, model, vin, rate)
        {
            SeatingCapacity = seats;
        }

        public override decimal CalculateRentalCost()
        {
            return DailyRate;
        }
    }
}
