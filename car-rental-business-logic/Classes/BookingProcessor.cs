using car_rental_common.Classes;
using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;
using System;

namespace car_rental_business_logic.Classes
{
    public class BookingProcessor
    {
        private readonly IData _dataBase;

        public BookingProcessor(IData dataBase)
        {  
            _dataBase = dataBase;
        }

        public IEnumerable<IBooking> GetBookings()
        {
            return _dataBase.GetBookings();
        }

        public IEnumerable<ICustomer> GetCustomers()
        {
            return _dataBase.GetCustomers();
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            return _dataBase.GetVehicles();
        }

        public decimal CalculateCostForBooking(IBooking booking)
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
            var bookingsForVehicle = _dataBase.GetBookings().Where(b => b.Vehicle.RegNo == regNo);
            return bookingsForVehicle.Any(b => !b.OdometerAfterDriving.HasValue) ? VehicleStatuses.Booked : VehicleStatuses.Available;
        }

    }
}