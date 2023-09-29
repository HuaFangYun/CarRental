using CarRentalCommon.Classes;
using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalData.Classes
{
    public class CollectionData : IData
    {
        private readonly Dictionary<Type, object> _data = new Dictionary<Type, object>
        {
            { typeof(IPerson), new List<IPerson>() },
            { typeof(IVehicle), new List<IVehicle>() },
            { typeof(IBooking), new List<IBooking>() }
        };

        public CollectionData() => SeedData();

        void SeedData()
        {
            var customers = (List<IPerson>)_data[typeof(IPerson)];
            var vehicles = (List<IVehicle>)_data[typeof(IVehicle)];
            var bookings = (List<IBooking>)_data[typeof(IBooking)];

            customers.Add(new Customer("891010-0168", "Charlie ", "Sharp"));
            customers.Add(new Customer("690830-8572", "Visilia ", "Studiya"));
            customers.Add(new Customer("821003-6612", "Blaine ", "Bootstrap"));

            vehicles.Add(new Car("AND243", "Porche", 5500, 1f, VehicleTypes.Touring, 2));
            vehicles.Add(new Car("AWL853", "Ford", 6000, 1f, VehicleTypes.Touring, 0));
            vehicles.Add(new Car("PQZ552", "Duesenberg", 1000, 1.5f, VehicleTypes.Luxury, 2));
            vehicles.Add(new Car("VUQ516", "Buick", 5600, 1f, VehicleTypes.Convertible, 2));
            vehicles.Add(new Car("IEN716", "Chevrolet", 2950, 1f, VehicleTypes.Hardtop, 2));
            vehicles.Add(new Car("ENN712", "Chevrolet", 9700, 1f, VehicleTypes.Convertible, 2));
            vehicles.Add(new Motorcycle("MBU852", "Yamaha", 8780, 0.5f, VehicleTypes.Standard, 1));
            vehicles.Add(new Motorcycle("WCK661", "Benelli", 7370, 0.5f, VehicleTypes.Standard, 2));

            bookings.Add(new Booking(vehicles[5], customers[0]));
            bookings.Add(new Booking(vehicles[6], customers[1]));
            bookings.Add(new Booking(vehicles[7], customers[2]));
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            return _data.TryGetValue(typeof(T), out var list)
                ? (IEnumerable<T>)list
                : Enumerable.Empty<T>();
        }

        public T Single<T>(Func<T, bool> predicate) where T : class
        {
            return _data.TryGetValue(typeof(T), out var list)
                ? ((IEnumerable<T>)list).SingleOrDefault(predicate)
                : null;
        }

        public void Add<T>(T entity) where T : class
        {
            if (_data.TryGetValue(typeof(T), out var list))
                ((List<T>)list).Add(entity);
        }
    }
}
