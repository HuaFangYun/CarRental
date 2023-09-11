using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_common.Classes
{
    public class Car : Vehicle
    {
        public string CarType { get; set; }

        public Car(string regNo, string make, int odometer, decimal costKm, string vehicleType, int costDay, string carType) : base(regNo, make, odometer, costKm, vehicleType, costDay)
        {
            this.CarType = carType;
        }
    }
}