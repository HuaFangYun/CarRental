using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes
{
    public class Motorcycle : IVehicle
    {
        public string RegNo { get; init; }
        public string Make { get; init; }
        public decimal CostKm { get; init; }
        public decimal CostDay { get; init; }
        public decimal Odometer { get; set; }
        public VehicleStatuses Status { get; set; }
        public VehicleTypes VehicleType => VehicleTypes.Motorcycle;
        public Motorcycle(string regNo, string make, decimal odometer, decimal costKm, VehicleStatuses status = VehicleStatuses.Available)
        {
            RegNo = regNo;
            Make = make;
            Odometer = odometer;
            CostKm = costKm;
            CostDay = 50;
            Status = status;
        }
    }
}
