using CarRental.Enums;
using CarRental.Interfaces;
using Newtonsoft.Json;
using System.Reflection;

namespace CarRental.Classes
{
    public class CollectionData : IData
    {
        private readonly Dictionary<Type, object> _data = [];
        private readonly HashSet<string> _checkForDuplicates = [];

        public CollectionData()
        {
            SeedData();
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            return GetOrCreateList<T>();
        }

        public T Single<T>(Func<T, bool> predicate) where T : class
        {
            return GetOrCreateList<T>().Single(predicate);
        }

        public void Add<T>(T entity) where T : class
        {
            CheckForDuplicates(entity);
            GetOrCreateList<T>().Add(entity);
        }

        private void SeedData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "CarRental.SeedData.seedData.json";

            string jsonData = String.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            if (stream != null)
            {
                using (StreamReader reader = new(stream))
                {
                    jsonData = reader.ReadToEnd();
                }
            }

            SeedDataStructure? seed = JsonConvert.DeserializeObject<SeedDataStructure>(jsonData);

            foreach (CustomerSeed customer in seed.customers)
            {
                Add<IPerson>(new Customer(customer.ssn, customer.firstName, customer.lastName));
            }

            foreach (VehicleSeed vehicle in seed.vehicles)
            {
                if (Enum.TryParse(vehicle.vehicleType, out VehicleType vehicleType))
                {
                    if (vehicleType is VehicleType.Touring or VehicleType.Luxury or VehicleType.Convertible or VehicleType.Hardtop or VehicleType.Other)
                    {
                        Add<IVehicle>(new Car(vehicle.regNo, vehicle.make, vehicle.odometer, vehicle.costKm, vehicleType, vehicle.doors, vehicle.year, vehicle.info));
                    }
                    else if (vehicleType is VehicleType.Standard or VehicleType.TrailBike or VehicleType.Other)
                    {
                        Add<IVehicle>(new Motorcycle(vehicle.regNo, vehicle.make, vehicle.odometer, vehicle.costKm, vehicleType, vehicle.seats, vehicle.year, vehicle.info));
                    }
                }
            }

            foreach (BookingSeed booking in seed.bookings)
            {
                IVehicle bookedVehicle = Single<IVehicle>(v => v.RegNo == booking.vehicleRegNo);
                IPerson bookingCustomer = Single<IPerson>(c => c.SSN == booking.customerSSN);
                Add<IBooking>(new Booking(bookedVehicle, bookingCustomer));
            }
        }

        private class SeedDataStructure
        {
            public required List<CustomerSeed> customers { get; set; }
            public required List<VehicleSeed> vehicles { get; set; }
            public required List<BookingSeed> bookings { get; set; }
        }

        private class CustomerSeed
        {
            public required string ssn { get; set; }
            public required string firstName { get; set; }
            public required string lastName { get; set; }
        }

        private class VehicleSeed
        {
            public required string regNo { get; set; }
            public required string make { get; set; }
            public int odometer { get; set; }
            public float costKm { get; set; }
            public required string vehicleType { get; set; }
            public int? doors { get; set; }
            public int? seats { get; set; }
            public required string year { get; set; }
            public required string info { get; set; }

        }

        private class BookingSeed
        {
            public string? vehicleRegNo { get; set; }
            public string? customerSSN { get; set; }
        }


        private void CheckForDuplicates<T>(T entity) where T : class
        {
            if (entity is IVehicle v && !_checkForDuplicates.Add(v.RegNo))
            {
                throw new ArgumentException($"Vehicle with RegNo {v.RegNo} already exists.");
            }

            if (entity is IPerson c && !_checkForDuplicates.Add(c.SSN))
            {
                throw new ArgumentException($"Customer with SSN {c.SSN} already exists.");
            }
        }

        private List<T> GetOrCreateList<T>() where T : class
        {
            Type actualType = typeof(T);
            if (!_data.TryGetValue(actualType, out object? list))
            {
                list = new List<T>();
                _data[actualType] = list;
            }
            return (List<T>)list;
        }
    }
}

