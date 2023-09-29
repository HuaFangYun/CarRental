using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes;

public class Car : Vehicle, ICar
{
    public int? Doors { get; set; }

    public Car(string regNo = "", string make = "", int? odometer = null, float? costKm = null, VehicleTypes vehicleType = VehicleTypes.Other, int? doors = null)
        : base(regNo, make, odometer, costKm, vehicleType)
    {
        Doors = doors;
    }
}
