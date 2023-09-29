using CarRentalCommon.Enums;

namespace CarRentalCommon.Interfaces;

public interface IVehicle
{
    int ID { get; }
    string RegNo { get; set; }
    string Make { get; set; }
    int? Odometer { get; set; }
    float? CostKm { get; set; }
    int CostDay { get; set; }
    VehicleTypes VehicleType { get; set; }
    VehicleStatuses Status { get; set; }
}