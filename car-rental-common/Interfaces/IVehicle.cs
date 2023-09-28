using car_rental_common.Enums;

namespace car_rental_common.Interfaces;

public interface IVehicle
{
    string RegNo { get; set; }
    string Make { get; set; }
    decimal? Odometer { get; set; }
    decimal? CostKm { get; set; }
    decimal CostDay { get; set; }
    VehicleTypes VehicleType { get; set; }
    VehicleStatuses Status { get; set; }
}
