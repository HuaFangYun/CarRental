using CarRentalCommon.Classes;
using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;
using CarRentalData.Interfaces;

namespace CarRentalData.Classes;

public class CollectionData : IData
{
    readonly List<IBooking> _bookings = new();
    readonly List<IPerson> _customers = new();
    readonly List<IVehicle> _vehicles = new();

    public CollectionData() => SeedData();

    void SeedData()
    {
        _customers.Add(new Customer("123456", "Charlie", "Sharp"));
        _customers.Add(new Customer("456789", "Visilia", "Studiya"));
        _customers.Add(new Customer("789123", "Blaine", "Bootstrap"));

        _vehicles.Add(new Car("AND243", "Porche", 5900, 1.5m, VehicleTypes.Touring));
        _vehicles.Add(new Car("VUQ516", "Buick", 3000, 1.5m, VehicleTypes.Convertible));
        _vehicles.Add(new Car("PQZ552", "Dusenberg", 7500, 2m, VehicleTypes.Luxury));
        _vehicles.Add(new Car("IEN716", "Chevrolet", 5050, 1m, VehicleTypes.Hardtop));
        _vehicles.Add(new Motorcycle("MBU852", "Yamaha", 3570, 1m));
        _vehicles.Add(new Motorcycle("WCK661", "Benelli", 1200, 0.5m));

        _bookings.Add(new Booking(_vehicles[3], _customers[0], DateTime.Parse("2023-09-20"), DateTime.Parse("2023-09-25"), _vehicles[3].Odometer, 5500));
        _bookings.Add(new Booking(_vehicles[4], _customers[1], DateTime.Now, DateTime.Now, _vehicles[4].Odometer, null));
        _bookings.Add(new Booking(_vehicles[5], _customers[2], DateTime.Now, DateTime.Now, _vehicles[5].Odometer, null));
    }

    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IPerson> GetCustomers() => _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
}
