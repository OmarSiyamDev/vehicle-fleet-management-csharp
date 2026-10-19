# Vehicle Fleet Management System

A C# console application for managing a vehicle fleet, built with Object-Oriented Programming principles. The application reads commands from a text file and performs operations such as adding, searching, editing, deleting, applying discounts, and generating fleet reports.

## Supported Vehicle Types
- Cars
- Trucks
- Motorcycles
- Electric Cars

## Features
- Add, search, edit, and delete vehicles
- Apply discounts to vehicles
- Generate fleet reports using LINQ
- Process commands from a text file (`commands.txt`)
- Input validation using Regular Expressions
- Error handling for invalid input

## Technologies & Concepts
- C#
- Inheritance, Abstraction, Polymorphism
- Generic Collections (`List<T>`)
- LINQ
- Regular Expressions (Regex)
- File Handling

## Project Structure
| File | Description |
|---|---|
| `Vehicle.cs` | Base class for all vehicles |
| `Car.cs`, `Truck.cs`, `Motorcycle.cs`, `ElectricCar.cs` | Derived vehicle classes |
| `FleetManager.cs` | Manages the fleet and executes operations |
| `Program.cs` | Entry point, reads and processes `commands.txt` |
| `commands.txt` | Input file containing the commands |

## How to Run
1. Clone the repository:
```bash
   git clone https://github.com/OmarSiyamDev/vehicle-fleet-management-csharp.git
```
2. Open `Vehicle Fleet Management System.slnx` in Visual Studio.
3. Make sure `commands.txt` is in the project folder.
4. Press **F5** to run.

## What I Learned
Designing class hierarchies, working with different object types through a common base class, processing structured input, handling errors, and using LINQ to generate useful reports.

## Author
**Omar Siyam** – Computer Engineering student, Islamic University of Gaza
[LinkedIn](https://www.linkedin.com/in/omar-siyam-62a312393)
