//Input control for every value?

using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_common.Classes
{
    public class Vehicle : IVehicle
    {
        public string RegNo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Odometer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal CostKm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public VehicleTypes VehicleType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CostDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public VehicleStatuses Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}