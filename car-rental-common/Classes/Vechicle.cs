using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_common.Classes;

public class Vehicle : IVehicle
{
    public string RegNo { get; set; }
    public string Make { get; set; }
    public decimal Odometer { get; set; }
    public decimal CostKm { get; set; }
    public decimal CostDay { get; set; }
    public VehicleStatuses Status { get; set; }
    private VehicleTypes _vehicleType;
    public VehicleTypes VehicleType
    {
        get => _vehicleType;
        set
        {
            _vehicleType = value;
            CalculateCostDay();
        }
    }

    public Vehicle(string regNo = "", string make = "", decimal odometer = 0, decimal costKm = 1, VehicleTypes vehicleType = VehicleTypes.Other, VehicleStatuses status = VehicleStatuses.Available)
    {
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKm = costKm;
        VehicleType = vehicleType;
        CalculateCostDay();
        Status = status;
    }
    private void CalculateCostDay()
    {
        CostDay = VehicleType switch
        {
            VehicleTypes.Convertible => 150,
            VehicleTypes.Touring => 120,
            VehicleTypes.Luxury => 200,
            VehicleTypes.Hardtop => 100,
            VehicleTypes.Motorcycle => 50,
            _ => 100
        };
    }
}
