using car_rental_common.Interfaces;

namespace car_rental_common.Classes
{
    public class Booking : IBooking
    {
        public double KmRented { get; set; }
        public DateOnly RentedDate { get; set; }
        public DateOnly Returned { get; set; }

        public Booking(double kmRented, DateOnly rentedDate, DateOnly returned)
        {
            KmRented = kmRented;
            RentedDate = rentedDate;
            Returned = returned;
        }
    }
}