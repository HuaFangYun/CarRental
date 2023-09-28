using CarRentalCommon.Enums;

namespace CarRentalCommon.Interfaces;

public interface IVehicle
{
    string RegNo { get; }
    string Make { get; }
    decimal CostKm { get; }
    decimal CostDay { get; }
    VehicleTypes VehicleType { get; }
    decimal Odometer { get; set; }

    VehicleStatuses Status { get; set; }
}
