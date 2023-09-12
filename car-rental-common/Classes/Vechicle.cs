using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_common.Classes
{
    public class Vehicle : IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Odometer { get; set; }
        public decimal CostKm { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public int CostDay { get; set; }
        public VehicleStatuses Status { get; set; }

        public Vehicle(string regNo, string make, int odometer, decimal costKm, VehicleTypes vehicleType, int costDay, VehicleStatuses status)
        {
            RegNo = regNo;
            Make = make;
            Odometer = odometer;
            CostKm = costKm;
            VehicleType = vehicleType;
            CostDay = costDay;
            Status = status;
        }
    }
}