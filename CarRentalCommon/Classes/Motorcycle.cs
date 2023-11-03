using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes;

public class Motorcycle : Vehicle, IMotorcycle
{
    public int? Seats { get; set; }

    public Motorcycle(string regNo = "", string make = "", int? odometer = null, float? costKm = null, VehicleType vehicleType = VehicleType.Standard, int? seats = null, string year = "", string info = "")
        : base(regNo, make, odometer, costKm, vehicleType, year, info)
    {
        Seats = seats;
    }
}
