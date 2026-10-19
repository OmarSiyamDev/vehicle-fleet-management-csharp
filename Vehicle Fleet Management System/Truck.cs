using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Management_System
{
    public class Truck : Vehicle
    {
        public int CargoCapacity { get; set; }
        public int TowingCapacity { get; set; }

        public Truck(string make, string model, string vin, int cargo, int towing, decimal rate)
          : base(make, model, vin, rate)
        {
            CargoCapacity = cargo;
            TowingCapacity = towing;
        }

        public override decimal CalculateRentalCost()
        {
            return DailyRate + 20.00m;
        }
    }
}
