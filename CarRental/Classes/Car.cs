using CarRental.Enums;
using CarRental.Interfaces;

namespace CarRental.Classes;

public class Car : Vehicle, ICar
{
    public int? Doors { get; set; }

    public Car(string regNo = "", string make = "", int? odometer = null, float? costKm = null, VehicleType vehicleType = VehicleType.Other, int? doors = null, string year = "", string info = "")
        : base(regNo, make, odometer, costKm, vehicleType, year, info)
    {
        Doors = doors;
    }
}
