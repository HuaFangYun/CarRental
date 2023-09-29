using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes;

public class Motorcycle : Vehicle, IMotorcycle
{
    public int? Seats { get; set; }

    public Motorcycle(string regNo = "", string make = "", int? odometer = null, float? costKm = null, VehicleTypes vehicleType = VehicleTypes.Standard, int? seats = null)
        : base(regNo, make, odometer, costKm, vehicleType)
    {
        Seats = seats;
    }
}
