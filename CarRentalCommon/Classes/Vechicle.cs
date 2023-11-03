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
    public string Year { get; set; }
    public string Info { get; set; }

    public VehicleStatus Status { get; set; }
    private VehicleType _vehicleType;
    public VehicleType VehicleType
    {
        get => _vehicleType;
        set
        {
            _vehicleType = value;
            CalculateCostDay();
        }
    }

    public Vehicle(string regNo = "", string make = "", int? odometer = null, float? costKm = null, VehicleType vehicleType = VehicleType.Other, string year = "", string info = "")
    {
        ID = IDGenerator.SetVehicleID();
        RegNo = regNo;
        Make = make;
        Odometer = odometer;
        CostKm = costKm;
        VehicleType = vehicleType;
        CalculateCostDay();
        Year = year;
        Info = info;
        Status = VehicleStatus.Available;
    }
    private void CalculateCostDay()
    {
        CostDay = VehicleType switch
        {
            VehicleType.Convertible => 150,
            VehicleType.Touring => 120,
            VehicleType.Luxury => 200,
            VehicleType.Hardtop => 100,
            VehicleType.Standard => 50,
            VehicleType.TrailBike => 60,
            _ => 100
        };
    }
}
