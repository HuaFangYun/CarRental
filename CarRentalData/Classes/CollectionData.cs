using CarRentalCommon.Classes;
using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace CarRentalData.Classes
{
    public class CollectionData : IData
    {
        private readonly Dictionary<Type, object> _data = new();
        private readonly HashSet<string> _checkForDuplicates = new();

        public CollectionData() => SeedData();

        public IEnumerable<T> Get<T>() where T : class => GetOrCreateList<T>();

        public T Single<T>(Func<T, bool> predicate) where T : class => GetOrCreateList<T>().Single(predicate);

        public void Add<T>(T entity) where T : class
        {
            CheckForDuplicates(entity);
            GetOrCreateList<T>().Add(entity);
        }

        void SeedData()
        {
            // Load JSON from the embedded resource
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CarRentalData.SeedData.seedData.json";

            string jsonData;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonData = reader.ReadToEnd();
            }

            // Deserialize the data
            var seed = JsonConvert.DeserializeObject<SeedDataStructure>(jsonData);

            // Populate data from deserialized JSON
            foreach (var customer in seed.customers)
            {
                Add<IPerson>(new Customer(customer.ssn, customer.firstName, customer.lastName));
            }

            foreach (var vehicle in seed.vehicles)
            {
                if (Enum.TryParse(vehicle.vehicleType, out VehicleType vehicleType))
                {
                    if (vehicleType == VehicleType.Touring || vehicleType == VehicleType.Luxury || vehicleType == VehicleType.Convertible || vehicleType == VehicleType.Hardtop || vehicleType == VehicleType.Other)
                    {
                        Add<IVehicle>(new Car(vehicle.regNo, vehicle.make, vehicle.odometer, vehicle.costKm, vehicleType, vehicle.doors));
                    }
                    else if (vehicleType == VehicleType.Standard || vehicleType == VehicleType.TrailBike || vehicleType == VehicleType.Other)
                    {
                        Add<IVehicle>(new Motorcycle(vehicle.regNo, vehicle.make, vehicle.odometer, vehicle.costKm, vehicleType, vehicle.seats));
                    }
                }
            }

            foreach (var booking in seed.bookings)
            {
                var bookedVehicle = Single<IVehicle>(v => v.RegNo == booking.vehicleRegNo);
                var bookingCustomer = Single<IPerson>(c => c.SSN == booking.customerSSN);
                Add<IBooking>(new Booking(bookedVehicle, bookingCustomer));
            }
        }

        // This structure represents your seedData.json
        private class SeedDataStructure
        {
            public List<CustomerSeed> customers { get; set; }
            public List<VehicleSeed> vehicles { get; set; }
            public List<BookingSeed> bookings { get; set; }
        }

        private class CustomerSeed
        {
            public string ssn { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        private class VehicleSeed
        {
            public string regNo { get; set; }
            public string make { get; set; }
            public int odometer { get; set; }
            public float costKm { get; set; }
            public string vehicleType { get; set; }
            public int? doors { get; set; }
            public int? seats { get; set; }
        }

        private class BookingSeed
        {
            public string? vehicleRegNo { get; set; }
            public string? customerSSN { get; set; }
        }


        private void CheckForDuplicates<T>(T entity) where T : class
        {
            if (entity is IVehicle v && !_checkForDuplicates.Add(v.RegNo))
                throw new ArgumentException($"Vehicle with RegNo {v.RegNo} already exists.");

            if (entity is IPerson c && !_checkForDuplicates.Add(c.SSN))
                throw new ArgumentException($"Customer with SSN {c.SSN} already exists.");
        }

        private List<T> GetOrCreateList<T>() where T : class
        {
            Type actualType = typeof(T);
            if (!_data.TryGetValue(actualType, out var list))
            {
                list = new List<T>();
                _data[actualType] = list;
            }
            return (List<T>)list;
        }
    }
}

