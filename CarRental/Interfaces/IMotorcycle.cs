namespace CarRental.Interfaces;

public interface IMotorcycle : IVehicle
{
    public int? Seats { get; set; }
}
