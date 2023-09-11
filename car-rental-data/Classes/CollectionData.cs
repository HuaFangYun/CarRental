/*//using

// Declaring a namespace groups related types together.
// This is used to organize your code and avoid naming collisions with other libraries or packages.
using car_rental_data.Interfaces;

namespace car_rental_data.Classes
{
    // This class, "CollectionData," is designed to handle data for your car rental system.
    // It implements an interface called "IData" (which is not shown in the provided code 
    // but likely defines some methods/properties that this class should have).
    public class CollectionData : IData
    {
        // Below are three lists that will store data:

        // A list to hold data related to persons. Each item in this list is of type IPerson.
        // IPerson is an interface, suggesting that this list can contain any object that 
        // implements the IPerson interface.
        readonly List<IPerson> _persons = new List<IPerson>();

        // A list to hold data related to bookings. Each item is of type IBooking.
        readonly List<IBooking> _bookings = new List<IBooking>();

        // A list to hold data related to vehicles. Each item is of type IVehicle.
        readonly List<IVehicle> _vehicles = new List<IVehicle>();

        // This is the constructor of the CollectionData class.
        // A constructor is a special method that gets called when you create an instance of the class.
        // In this case, the constructor is calling another method, "SeedData", when a 
        // new instance of CollectionData is created.
        public CollectionData() => SeedData();

        // This is the SeedData method, which is currently empty.
        // From our previous discussion on "seed data," this method is likely meant to populate 
        // your data collections (_persons, _bookings, _vehicles) with initial data.
        void SeedData() { }

        // This method returns the list of persons when called.
        // IEnumerable is an interface that represents a sequence of items that can be enumerated (iterated over).
        // In this context, it means you can loop through the returned data.
        public IEnumerable<IPerson> GetPersons() => _persons;

        // Similarly, this method returns the list of bookings.
        public IEnumerable<IBooking> GetBookings() => _bookings;

        // This method returns the list of vehicles.
        // It has an optional parameter 'status' which defaults to some type "VehicleStatuses".
        // This might be used in the future to filter vehicles by their status.
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
    }
}
*/