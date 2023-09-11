using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_common.Classes
{
    public class Vehicle
    {
        private string _regNo;
        private int _odometer;

        public string RegNo
        {
            get { return _regNo; }
            set
            {
                if (IsValidRegNo(value))
                {
                    _regNo = value;
                }
                else
                {
                    throw new ArgumentException("Registration number must be in the format ABC123.");
                }
            }
        }

        public string Make { get; set; }

        public int Odometer
        {
            get { return _odometer; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Odometer value cannot be negative.");
                }
                _odometer = value;
            }
        }

        public decimal CostKm { get; set; }
        public string VehicleType { get; set; }
        public int CostDay { get; set; }

        public Vehicle(string regNo, string make, int odometer, decimal costKm, string vehicleType, int costDay)
        {
            if (string.IsNullOrWhiteSpace(regNo))
            {
                throw new ArgumentException("Registration number must be provided.", nameof(regNo));
            }

            RegNo = regNo;
            Make = make;
            Odometer = odometer;
            CostKm = costKm;
            VehicleType = vehicleType;
            CostDay = costDay;
        }

        private bool IsValidRegNo(string regNo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(regNo, @"^[A-Z]{3}\d{3}$");
        }
    }
}