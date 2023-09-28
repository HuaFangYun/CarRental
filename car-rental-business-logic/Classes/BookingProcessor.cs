using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;


namespace car_rental_business_logic.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db)
        {
            _db = db;
        }

        public IEnumerable<IBooking> GetBookings() => _db.GetBookings();
        public IEnumerable<ICustomer> GetCustomers() => _db.GetCustomers();
        public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();

        public decimal TotalCost(IBooking booking)
        {
            decimal cost = 0;

            if (booking.OdometerAfterDriving.HasValue)
                cost += ((booking.OdometerAfterDriving.Value - booking.OdometerBeforeDriving) * booking.Vehicle.CostKm) + (booking.Vehicle.CostDay * (booking.ReturnDate.DayNumber - booking.StartDate.DayNumber + 1));

            return (int)Math.Round(cost);
        }

        public string GetBookingStatus(IBooking booking)
        {
            if (booking.OdometerAfterDriving.HasValue)
                return "Closed";

            return "Open";
        }

        public VehicleStatuses IsVehicleBooked(string regNo)
        {
            var bookingsForVehicle = _db.GetBookings().Where(b => b.Vehicle.RegNo == regNo);
            return bookingsForVehicle.Any(b => !b.OdometerAfterDriving.HasValue) ? VehicleStatuses.Booked : VehicleStatuses.Available;
        }
    }
}