using CarRental.Enums;

namespace CarRental.Interfaces;

public interface IVehicle
{
    int ID { get; }
    string RegNo { get; set; }
    string Make { get; set; }
    int? Odometer { get; set; }
    float? CostKm { get; set; }
    int CostDay { get; set; }
    string Year { get; set; }
    string Info { get; set; }

    VehicleType VehicleType { get; set; }
    VehicleStatus Status { get; set; }
}