using car_rental_common.Interfaces;
using System;

namespace car_rental_common.Classes
{
    public class Booking : IBooking
    {
        public decimal OdometerBeforeDriving { get; set; }
        public decimal? OdometerAfterDriving { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public decimal Cost { get; set; }

        public Booking(decimal odometerBeforeDriving, decimal? odometerAfterDriving, string startDateStr, string endDateStr, Vehicle vehicle, Customer customer)
        {
            OdometerBeforeDriving = odometerBeforeDriving;
            OdometerAfterDriving = odometerAfterDriving;
            StartDate = ParseDate(startDateStr);
            ReturnDate = ParseDate(endDateStr);
            Vehicle = vehicle;
            Customer = customer;
            Cost = 0;
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