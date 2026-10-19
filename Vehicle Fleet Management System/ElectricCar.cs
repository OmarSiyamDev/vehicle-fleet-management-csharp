using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Management_System
{
    public class ElectricCar : Vehicle
    {
        public int BatteryCapacity { get; set; }
        public int Range { get; set; }

        public ElectricCar(string make, string model, string vin, int batteryCapacity, int range, decimal rate)
         : base(make, model, vin, rate)
        {
            BatteryCapacity = batteryCapacity;
            Range = range;
        }

        public override decimal CalculateRentalCost()
        {
            return DailyRate;
        }
    }
}
