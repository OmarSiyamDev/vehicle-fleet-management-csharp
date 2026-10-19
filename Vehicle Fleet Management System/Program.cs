using System;
using System.IO;
using System.Text.RegularExpressions;
using Vehicle_Fleet_Management_System;

namespace VehicleFleetManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            FleetManager fleet = new FleetManager();

            string fileName = "commands.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Error: commands.txt was not found.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)){ continue; }

                try
                {
                    ProcessCommand(line, fleet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing command:");
                    Console.WriteLine(line);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void ProcessCommand(string line, FleetManager fleet)
        {
            string[] parts = Regex.Split(line.Trim(), @"\s+");

            if (parts.Length == 0) { return; }
            

            string command = parts[0];

            if (command == "add/+")
            {
                AddVehicle(parts, fleet);
            }
            else if (command == "delete/-")
            {
                DeleteVehicle(parts, fleet);
            }
            else if (command == "edit")
            {
                EditVehicle(parts, fleet);
            }
            else if (command == "followup")
            {
                FollowUp(parts, fleet);
            }
            else if (command == "discount")
            {
                Discount(parts, fleet);
            }
            else if (command == "search")
            {
                Search(parts, fleet);
            }
            else if (command == "report")
            {
                fleet.Report();
            }
            else
            {
                Console.WriteLine("Unknown command: " + command);
            }
        }

        static void AddVehicle(string[] parts, FleetManager fleet)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Error: Missing vehicle type.");
                return;
            }

            string type = parts[1];

            if (type == "Car")
            {
                if (parts.Length != 7)
                {
                    Console.WriteLine("Error: Invalid Car command.");
                    return;
                }
                string make = parts[2];
                string model = parts[3];
                string vin = parts[4];
                int seats = int.Parse(parts[5]);
                decimal rate = decimal.Parse(parts[6]);

                Car car = new Car(make, model, vin, seats, rate);

                fleet.AddVehicle(car);

                Console.WriteLine("Car added successfully.");
            }
            else if (type == "Truck")
            {
                if (parts.Length != 8)
                {
                    Console.WriteLine("Error: Invalid Truck command.");
                    return;
                }

                string make = parts[2];
                string model = parts[3];
                string vin = parts[4];
                int cargo = int.Parse(parts[5]);
                int towing = int.Parse(parts[6]);
                decimal rate = decimal.Parse(parts[7]);

                Truck truck = new Truck(make, model, vin, cargo, towing, rate);

                fleet.AddVehicle(truck);

                 Console.WriteLine("Truck added successfully.");
            }
            else if (type == "Motorcycle")
            {
                if (parts.Length != 7)
                {
                    Console.WriteLine("Error: Invalid Motorcycle command.");
                    return;
                }

                string make = parts[2];
                string model = parts[3];
                string vin = parts[4];
                int engineSize = int.Parse(parts[5]);
                decimal rate = decimal.Parse(parts[6]);

                Motorcycle motorcycle = new Motorcycle(make, model, vin, engineSize, rate);

                     fleet.AddVehicle(motorcycle);

                Console.WriteLine("Motorcycle added successfully.");
            }
            else if (type == "ElectricCar")
            {
                if (parts.Length != 8)
                {
                    Console.WriteLine("Error: Invalid ElectricCar command.");
                    return;
                }

                string make = parts[2];
                string model = parts[3];
                string vin = parts[4];
                int batteryCapacity = int.Parse(parts[5]);
                int range = int.Parse(parts[6]);
                decimal rate = decimal.Parse(parts[7]);

                ElectricCar electricCar = new ElectricCar(make, model, vin, batteryCapacity, range, rate);

                fleet.AddVehicle(electricCar);

                          Console.WriteLine("ElectricCar added successfully.");
            }
            else
            {
                Console.WriteLine("Error: Unknown vehicle type.");
            }
        }

        static void DeleteVehicle(string[] parts, FleetManager fleet)
        {
            if (parts.Length != 2)
            {
                Console.WriteLine("Error: Invalid delete command.");
                return;
            }

            string vin = parts[1];

            if (fleet.DeleteVehicle(vin))
            {
                Console.WriteLine("Vehicle deleted successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found: " + vin);
            }
        }

        static void EditVehicle(string[] parts, FleetManager fleet)
        {
            if (parts.Length != 4)
            {
                     Console.WriteLine("Error: Invalid edit command.");
                return;
            }

            string vin = parts[1];
            string newMake = parts[2];
            string newModel = parts[3];

            if (fleet.EditVehicle(vin, newMake, newModel))
            {
                Console.WriteLine("Vehicle edited successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found: " + vin);
            }
        }

        static void FollowUp(string[] parts, FleetManager fleet)
        {
            if (parts.Length != 3)
            {
                Console.WriteLine("Error: Invalid followup command.");
                return;
            }

            string vin = parts[1];
            decimal amount = decimal.Parse(parts[2]);

            if (fleet.AddFollowUp(vin, amount))
            {
                Console.WriteLine("Followup added successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found: " + vin);
            }
        }

        static void Discount(string[] parts, FleetManager fleet)
        {
            if (parts.Length != 3)
            {
                Console.WriteLine("Error: Invalid discount command.");
                return;
            }

            string vin = parts[1];
            decimal amount = decimal.Parse(parts[2]);

            if (fleet.AddDiscount(vin, amount))
            {
                Console.WriteLine("Discount applied successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found: " + vin);
            }
        }

        static void Search(string[] parts, FleetManager fleet)
        {
            if (parts.Length != 2)
            {
                Console.WriteLine("Error: Invalid search command.");
                return;
            }

            string vin = parts[1];

            fleet.SearchVehicle(vin);
        }
    }
}