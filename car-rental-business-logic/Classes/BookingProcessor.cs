using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;

namespace car_rental_business_logic.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db) => _db = db;

        public IEnumerable<IBooking> GetBookings()
        {
            // Any additional business logic related to bookings can be applied here.
            return _db.GetBookings();
        }

        public IEnumerable<ICustomer> GetCustomers()
        {
            return _db.GetCustomers();
        }

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            return _db.GetVehicles(status);
        }
    }
}