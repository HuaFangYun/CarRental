using car_rental_common.Enums;

namespace car_rental_common.Interfaces;

public interface IVehicle
{
    string RegNo { get; set; }
    string Make { get; set; }
    int? Odometer { get; set; }
    float? CostKm { get; set; }
    int CostDay { get; set; }
    VehicleTypes VehicleType { get; set; }
    VehicleStatuses Status { get; set; }
}
