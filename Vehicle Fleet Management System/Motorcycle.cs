using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Management_System
{
    public class Motorcycle : Vehicle
    {
        public int EngineSize { get; set; }

        public Motorcycle(string make, string model, string vin, int engineSize, decimal rate)
          : base(make, model, vin, rate)
        {
            EngineSize = engineSize;
        }

        public override decimal CalculateRentalCost()
        {
            return DailyRate;
        }
    }
}
