namespace CarRental.Interfaces;

public interface ICar : IVehicle
{
    public int? Doors { get; set; }
}
