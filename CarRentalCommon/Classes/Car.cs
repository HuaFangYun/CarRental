using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes
{
    public class Car : IVehicle
    {
        public string RegNo { get; init; }
        public string Make { get; init; }
        public decimal CostKm { get; init; }
        public decimal CostDay { get; init; }
        public decimal Odometer { get; init; }
        public VehicleStatuses Status { get; set; }
        private VehicleTypes _vehicleType;
        public VehicleTypes VehicleType
        {
            get => _vehicleType;
            init
            {
                _vehicleType = value;
            }
        }

        public Car(string regNo, string make, decimal odometer, decimal costKm, VehicleTypes vehicleType)
        {
            RegNo = regNo;
            Make = make;
            Odometer = odometer;
            CostKm = costKm;
            VehicleType = vehicleType;
            CostDay = CalculateCostDay();
            Status = VehicleStatuses.Available;
        }

        private decimal CalculateCostDay()
        {
            return _vehicleType switch
            {
                VehicleTypes.Convertible => 150,
                VehicleTypes.Touring => 120,
                VehicleTypes.Luxury => 200,
                VehicleTypes.Hardtop => 100,
                _ => 100
            };
        }
    }
}
