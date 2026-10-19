using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Vehicle_Fleet_Management_System
{
    public class FleetManager
    {
        private List<Vehicle> vehicles;

        public FleetManager()
        {
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
        public bool DeleteVehicle(string vin)
        {
            Vehicle vehicle = FindVehicle(vin);

            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }
        public Vehicle FindVehicle(string vin)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Vin == vin) { return vehicle; }
                
            }

           return null;
        }
        public bool EditVehicle(string vin, string newMake, string newModel)
        {
            Vehicle vehicle = FindVehicle(vin);

            if (vehicle != null)
            {
                vehicle.Make = newMake;
                vehicle.Model = newModel;
                return true;
            }

            return false;
        }
        public bool AddFollowUp(string vin, decimal amount)
        {
            Vehicle vehicle = FindVehicle(vin);

            if (vehicle != null)
            {
                vehicle.DailyRate += amount;
                return true;
            }

            return false;
        }
        public bool AddDiscount(string vin, decimal amount)
        {
            Vehicle vehicle = FindVehicle(vin);

            if (vehicle != null)
            {
                vehicle.DailyRate -= amount;
                return true;
            }

            return false;
        }
          public void SearchVehicle(string vin)
        {
            Vehicle vehicle = FindVehicle(vin);

            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found: " + vin);
                return;
            }

            Console.WriteLine("Vehicle Found");
            Console.WriteLine("Type: " + vehicle.GetType().Name);
            Console.WriteLine("VIN: " + vehicle.Vin);
            Console.WriteLine("Make: " + vehicle.Make);
            Console.WriteLine("Model: " + vehicle.Model);
            Console.WriteLine("Daily Rate: " + vehicle.DailyRate);
            Console.WriteLine("Rental Cost: " + vehicle.CalculateRentalCost());
        }

        public void Report()
        {
            Console.WriteLine();
            Console.WriteLine("----- Vehicle Report -----");

            var report = vehicles.Select(vehicle =>
                vehicle.Vin + "," +
                vehicle.Make + " " +
                vehicle.Model + "," +
                vehicle.CalculateRentalCost()
            );

            foreach (string line in report)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("--------------------------");
        }
    }
}
