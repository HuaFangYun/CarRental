using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes;

public class Vehicle : IVehicle
{
    public int ID { get; init; }
    public string RegNo { get; set; }
    public string Make { get; set; }
    public int? Odometer { get; set; }
    public float? CostKm { get; set; }
    public int CostDay { get; set; }
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

    public Vehicle(string regNo = "", string make = "", int? odometer = null, float? costKm = null, VehicleTypes vehicleType = VehicleTypes.Other)
    {
        ID = IDGenerator.SetVehicleID();
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKm = costKm;
        VehicleType = vehicleType;
        CalculateCostDay();
        Status = VehicleStatuses.Available;
    }
    private void CalculateCostDay()
    {
        CostDay = VehicleType switch
        {
            VehicleTypes.Convertible => 150,
            VehicleTypes.Touring => 120,
            VehicleTypes.Luxury => 200,
            VehicleTypes.Hardtop => 100,
            VehicleTypes.Standard => 50,
            VehicleTypes.TrailBike => 60,
            _ => 100
        };
    }
}
