using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_common.Classes
{
    public class Motorcycle : Vehicle
    {
        public string MotorcycleType { get; set; }

        public Motorcycle(string regNo, string make, int odometer, decimal costKm, string vehicleType, int costDay, string motorcycleType) : base(regNo, make, odometer, costKm, vehicleType, costDay)
        {
            this.MotorcycleType = motorcycleType;
        }
    }
}