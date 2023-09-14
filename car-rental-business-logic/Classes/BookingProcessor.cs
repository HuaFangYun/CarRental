using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;
using System;

namespace car_rental_business_logic.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db) => _db = db;

        public IEnumerable<IBooking> GetBookings()
        {
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

        public decimal CalculateCostForBooking(IBooking booking)
        {
            decimal cost = 0;

            if (booking.OdometerAfterDriving.HasValue)
                cost += ((booking.OdometerAfterDriving.Value - booking.OdometerBeforeDriving) * booking.Vehicle.CostKm) + (booking.Vehicle.CostDay * (booking.ReturnDate.DayNumber - booking.StartDate.DayNumber + 1));

            return (int)Math.Round(cost);
        }

        public string Returned(IBooking booking)
        {
            if (booking.OdometerAfterDriving.HasValue)
                return "Closed";

            return "Open";
        }
    }
}