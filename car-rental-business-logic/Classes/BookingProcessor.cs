using car_rental_common.Interfaces;
using car_rental_data.Interfaces;

namespace car_rental_business_logic.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db) => _db = db;

        //Dessa ska innehålla själva logiken för att utföra beräkningarna i tabellerna.
        //public IEnumerable<IBooking> GetBookings()...
        //public IEnumerable<ICustomer> GetCustomers()...
        //public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)...
    }
}