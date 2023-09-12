using car_rental_common.Interfaces;
using System;

namespace car_rental_common.Classes
{
    public class Booking : IBooking
    {
        public double KmRented { get; set; }
        public double? KmTotal { get; set; }
        public DateOnly RentedDate { get; set; }
        public DateOnly Returned { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }

        public bool IsBooked
        {
            get
            {
                return Returned > DateOnly.FromDateTime(DateTime.Today);
            }
        }

        public Booking(double kmRented, double? kmTotal, string rentedDateStr, string returnedDateStr, Vehicle vehicle, Customer customer)
        {
            KmRented = kmRented;
            KmTotal = kmTotal;
            RentedDate = ParseDate(rentedDateStr);
            Returned = ParseDate(returnedDateStr);
            Vehicle = vehicle;
            Customer = customer;
        }

        private DateOnly ParseDate(string dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
            {
                return DateOnly.MaxValue;
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