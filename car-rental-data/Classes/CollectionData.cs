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

            var vehicle1 = new Vehicle("ABC123", "Volvo", 1000, 1m, VehicleTypes.Combi, 200);
            var vehicle2 = new Vehicle("DEF456", "Saab", 2000, 1m, VehicleTypes.Sedan, 100);
            var vehicle3 = new Vehicle("GHI789", "Tesla", 1000, 3m, VehicleTypes.Sedan, 100);
            var vehicle4 = new Vehicle("JKL123", "Jeep", 5000, 1.5m, VehicleTypes.Van, 300);
            var vehicle5 = new Vehicle("MNO456", "Yamaha", 3000, 0.5m, VehicleTypes.Motorcycle, 50);
            var vehicle6 = new Vehicle("PQR789", "Suzuki", 1000, 0.5m, VehicleTypes.Motorcycle, 50);
            _vehicles.Add(vehicle1);
            _vehicles.Add(vehicle2);
            _vehicles.Add(vehicle3);
            _vehicles.Add(vehicle4);
            _vehicles.Add(vehicle5);
            _vehicles.Add(vehicle6);

            var booking1 = new Booking(1000, null, vehicle1, customer1);
            var booking2 = new Booking(5000, null, vehicle2, customer2);
            var booking3 = new Booking(2000, null, vehicle6, customer3);
            _bookings.Add(booking1);
            _bookings.Add(booking2);
            _bookings.Add(booking3);
        }

        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<ICustomer> GetCustomers() => _customers;
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles; //Måste göra ett urval med t.ex linq

        public void AddBooking(IBooking booking)
        {
            _bookings.Add(booking);
        }

        public void AddCustomer(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void UpdateBooking(IBooking updatedBooking)
        {
            var booking = _bookings.FirstOrDefault(b => b.Customer == updatedBooking.Customer);
            if (booking != null)
            {
                int index = _bookings.IndexOf(booking);
                _bookings[index] = updatedBooking;
            }
        }

        public void UpdateCustomer(ICustomer updatedCustomer)
        {
            var customer = _customers.FirstOrDefault(c => c.SSN == updatedCustomer.SSN);
            if (customer != null)
            {
                int index = _customers.IndexOf(customer);
                _customers[index] = updatedCustomer;
            }
        }


        public void UpdateVehicle(IVehicle updatedVehicle)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.RegNo == updatedVehicle.RegNo);
            if (vehicle != null)
            {
                int index = _vehicles.IndexOf(vehicle);
                _vehicles[index] = updatedVehicle;
            }
        }

    }
}