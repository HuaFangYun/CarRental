using car_rental_common.Classes;
using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;

namespace car_rental_data.CollectionData
{
    public class CollectionData : IData
    {
        readonly List<IBooking> _bookings = new List<IBooking>();
        readonly List<ICustomer> _customers = new List<ICustomer>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();

        public CollectionData() => SeedData();

        void SeedData()
        {
            var customer1 = new Customer("123456", "Charlie", "Sharp");
            var customer2 = new Customer("456789", "Rosie", "Uby");
            var customer3 = new Customer("789123", "Karen", "Otlin");
            _customers.Add(customer1);
            _customers.Add(customer2);
            _customers.Add(customer3);

            var vehicle1 = new Vehicle("ABC123", "Volvo", 10000, 1m, VehicleTypes.Combi, 200);
            var vehicle2 = new Vehicle("DEF456", "Saab", 20000, 1m, VehicleTypes.Sedan, 100);
            var vehicle3 = new Vehicle("GHI789", "Tesla", 1000, 3m, VehicleTypes.Sedan, 100);
            var vehicle4 = new Vehicle("JKL123", "Jeep", 50000, 1.5m, VehicleTypes.Van, 300);
            var vehicle5 = new Vehicle("MNO456", "Yamaha", 30000, 0.5m, VehicleTypes.Motorcycle, 50);
            var vehicle6 = new Vehicle("PQR789", "Suzuki", 10000, 0.5m, VehicleTypes.Motorcycle, 50);
            _vehicles.Add(vehicle1);
            _vehicles.Add(vehicle2);
            _vehicles.Add(vehicle3);
            _vehicles.Add(vehicle4);
            _vehicles.Add(vehicle5);
            _vehicles.Add(vehicle6);

            var booking1 = new Booking(1000, null, "", "", vehicle1, customer1);
            var booking2 = new Booking(5000, null, "2023-09-09", "2023-09-09", vehicle2, customer2);
            var booking3 = new Booking(2000, 4000, "2023-09-09", "2023-09-11", vehicle6, customer3);
            _bookings.Add(booking1);
            _bookings.Add(booking2);
            _bookings.Add(booking3);
        }

        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<ICustomer> GetCustomers() => _customers;
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles; //Måste göra ett urval med t.ex linq
    }
}