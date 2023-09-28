using car_rental_common.Classes;
using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;

namespace car_rental_data.CollectionData;

public class CollectionData : IData
{
    readonly List<IBooking> _bookings = new();
    readonly List<ICustomer> _customers = new();
    readonly List<IVehicle> _vehicles = new();

    public CollectionData() => SeedData();

    void SeedData()
    {
        _customers.Add(new Customer("123456", "Charlie", "Sharp"));
        _customers.Add(new Customer("456789", "Visilia", "Studiya"));
        _customers.Add(new Customer("789123", "Blaine", "Bootstrap"));

        _vehicles.Add(new Vehicle("AND243", "Porche", 5900, 1.5m, VehicleTypes.Touring));
        _vehicles.Add(new Vehicle("VUQ516", "Buick", 3000, 1.5m, VehicleTypes.Convertible));
        _vehicles.Add(new Vehicle("PQZ552", "Dusenberg", 7500, 2m, VehicleTypes.Luxury));
        _vehicles.Add(new Vehicle("IEN716", "Chevrolet", 5050, 1m, VehicleTypes.Hardtop));
        _vehicles.Add(new Vehicle("MBU852", "Yamaha", 3570, 1m, VehicleTypes.Motorcycle));
        _vehicles.Add(new Vehicle("WCK661", "Benelli", 1200, 0.5m, VehicleTypes.Motorcycle));

        _bookings.Add(new Booking(_vehicles[3], _customers[0], DateTime.Parse("2023-09-20"), DateTime.Parse("2023-09-25"), _vehicles[3].Odometer, 5500));
        _bookings.Add(new Booking(_vehicles[4], _customers[1], DateTime.Now, DateTime.Now, _vehicles[4].Odometer, null));
        _bookings.Add(new Booking(_vehicles[5], _customers[2], DateTime.Now, DateTime.Now, _vehicles[5].Odometer, null));
    }

    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<ICustomer> GetCustomers() => _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
}
