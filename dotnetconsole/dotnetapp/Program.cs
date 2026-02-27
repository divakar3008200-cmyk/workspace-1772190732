using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp
{
    public class Program
    {
        private static List<Transportation> transports = new List<Transportation>();
        private static int nextId = 1;

        public static void Main(string[] args)
        {
            SeedData();
            while (true)
            {
                Console.WriteLine("--- Transportation Management ---");
                Console.WriteLine("1. Add Transportation");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Display Limited");
                Console.WriteLine("4. Update Transportation");
                Console.WriteLine("5. Delete Transportation");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddTransportation();
                        break;
                    case 2:
                        DisplayAllTransportations();
                        break;
                    case 3:
                        Console.Write("Enter limit: ");
                        if (int.TryParse(Console.ReadLine(), out int limit))
                            DisplayLimitedTransportations(limit);
                        else
                            Console.WriteLine("Invalid number.");
                        break;
                    case 4:
                        Console.Write("Enter Vehicle Number to update: ");
                        var veh = Console.ReadLine();
                        UpdateTransportation(veh);
                        break;
                    case 5:
                        Console.Write("Enter Vehicle Number to delete: ");
                        var dv = Console.ReadLine();
                        DeleteTransportation(dv);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void SeedData()
        {
            transports.Clear();
            transports.Add(new Transportation { TransportID = nextId++, VehicleNumber = "AB123", Type = "Bus", Capacity = 40, DriverName = "John Doe", IsOperational = true });
            transports.Add(new Transportation { TransportID = nextId++, VehicleNumber = "CD456", Type = "Van", Capacity = 12, DriverName = "Jane Roe", IsOperational = true });
        }

        public static void AddTransportation()
        {
            try
            {
                Transportation t = new Transportation();
                t.TransportID = nextId++;
                Console.Write("Enter Vehicle Number: ");
                t.VehicleNumber = Console.ReadLine();
                Console.Write("Enter Type: ");
                t.Type = Console.ReadLine();
                Console.Write("Enter Capacity: ");
                if (!int.TryParse(Console.ReadLine(), out int cap)) cap = 0;
                t.Capacity = cap;
                Console.Write("Enter Driver Name: ");
                t.DriverName = Console.ReadLine();
                Console.Write("Is Operational (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out bool op)) op = false;
                t.IsOperational = op;

                transports.Add(t);
                Console.WriteLine("Transportation record added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding transportation: " + ex.Message);
            }
        }

        public static void DisplayAllTransportations()
        {
            if (!transports.Any())
            {
                Console.WriteLine("No transportation records found");
                return;
            }

            foreach (var t in transports)
            {
                Console.WriteLine($"ID:{t.TransportID} | Vehicle:{t.VehicleNumber} | Type:{t.Type} | Capacity:{t.Capacity} | Driver:{t.DriverName} | Operational:{t.IsOperational}");
            }
        }

        public static void DisplayLimitedTransportations(int limit)
        {
            var list = transports.Take(limit).ToList();
            if (!list.Any())
            {
                Console.WriteLine("No transportation records found");
                return;
            }

            foreach (var t in list)
            {
                Console.WriteLine($"{t.VehicleNumber} - {t.Type} - {t.DriverName}");
            }
        }

        public static void UpdateTransportation(string vehicleNumber)
        {
            var transport = transports.FirstOrDefault(x => x.VehicleNumber == vehicleNumber);
            if (transport == null)
            {
                Console.WriteLine("No matching transportation record found");
                return;
            }

            Console.Write("Enter new Type: ");
            var type = Console.ReadLine();
            Console.Write("Enter new Capacity: ");
            if (!int.TryParse(Console.ReadLine(), out int cap)) cap = transport.Capacity;
            Console.Write("Enter new Driver Name: ");
            var driver = Console.ReadLine();
            Console.Write("Is Operational (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out bool op)) op = transport.IsOperational;

            transport.Type = string.IsNullOrEmpty(type) ? transport.Type : type;
            transport.Capacity = cap;
            transport.DriverName = string.IsNullOrEmpty(driver) ? transport.DriverName : driver;
            transport.IsOperational = op;

            Console.WriteLine("Transportation record updated successfully");
        }

        public static void DeleteTransportation(string vehicleNumber)
        {
            var transport = transports.FirstOrDefault(x => x.VehicleNumber == vehicleNumber);
            if (transport == null)
            {
                Console.WriteLine("No matching transportation record found");
                return;
            }

            transports.Remove(transport);
            Console.WriteLine("Transportation record deleted successfully");
        }
    }
}