using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Fleet_Management_System
{
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public decimal DailyRate { get; set; }

        protected Vehicle(string make, string model, string vin, decimal dailyRate)
        {
            Make = make;
            Model = model;
            Vin = vin;
            DailyRate = dailyRate;
        }

        public abstract decimal CalculateRentalCost();

        public override string ToString()
        {
            return Vin + " - " + Make + " " + Model +
                   " - Daily Rate: " + DailyRate;
        }
    }
}
