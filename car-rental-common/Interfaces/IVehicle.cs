using car_rental_common.Enums;

namespace car_rental_common.Interfaces
{
    public interface IVehicle
    {
        string RegNo { get; set; }
        string Make { get; set; }
        int Odometer { get; set; }
        decimal CostKm { get; set; }
        VehicleTypes VehicleType { get; set; }
        int CostDay { get; set; }
        VehicleStatuses Status { get; set; }
    }
}