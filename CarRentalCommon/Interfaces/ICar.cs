namespace CarRentalCommon.Interfaces;

public interface ICar : IVehicle
{
    public int? Doors { get; set; }
}
