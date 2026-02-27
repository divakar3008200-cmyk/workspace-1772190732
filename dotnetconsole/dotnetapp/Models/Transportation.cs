using System;

namespace dotnetapp.Models
{
    public class Transportation
    {
        public int TransportID { get; set; }
        public string VehicleNumber { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string DriverName { get; set; }
        public bool IsOperational { get; set; }
    }
}