using car_rental_common.Interfaces;
using System;

namespace car_rental_common.Classes
{
    public class Booking : IBooking
    {
        public double? OdometerAtStart { get; set; }
        public double? KilometersTraveled { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }

        public bool? IsBooked
        {
            get
            {
                return EndDate > DateOnly.FromDateTime(DateTime.Today);
            }
        }

        public Booking(double? odometerAtStart, double? kilometersTraveled, string startDateStr, string endDateStr, Vehicle vehicle, Customer customer)
        {
            OdometerAtStart = odometerAtStart;
            KilometersTraveled = kilometersTraveled;
            StartDate = ParseDate(startDateStr);
            EndDate = ParseDate(endDateStr);
            Vehicle = vehicle;
            Customer = customer;
        }

        private DateOnly ParseDate(string dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
            {
                return DateOnly.MinValue;
            }

            if (DateOnly.TryParse(dateStr, out var date))
            {
                return date;
            }
            else
            {
                throw new ArgumentException($"Invalid date string: {dateStr}. Expected format: yyyy-MM-dd");
            }
        }
    }
}