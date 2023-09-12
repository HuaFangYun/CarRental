﻿using car_rental_common.Classes;
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

            var vehicle1 = new Vehicle("ABC123", "Volvo", 10000, 1m, VehicleTypes.Combi, 200, VehicleStatuses.Available);
            var vehicle2 = new Vehicle("DEF456", "Saab", 20000, 1m, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
            var vehicle3 = new Vehicle("GHI789", "Tesla", 1000, 3m, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
            var vehicle4 = new Vehicle("JKL123", "Jeep", 50000, 1.5m, VehicleTypes.Van, 300, VehicleStatuses.Available);
            var vehicle5 = new Vehicle("MNO456", "Yamaha", 30000, 0.5m, VehicleTypes.Motorcycle, 50, VehicleStatuses.Available);
            var vehicle6 = new Vehicle("PQR789", "Suzuki", 10000, 0.5m, VehicleTypes.Motorcycle, 50, VehicleStatuses.Available);
            _vehicles.Add(vehicle1);
            _vehicles.Add(vehicle2);
            _vehicles.Add(vehicle3);
            _vehicles.Add(vehicle4);
            _vehicles.Add(vehicle5);
            _vehicles.Add(vehicle6);



        }

        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<ICustomer> GetCustomers() => _customers;
        public IEnumerable<IVehicle> GetVehicles() => _vehicles;
    }
}