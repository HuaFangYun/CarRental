//Input control for every value?

using car_rental_common.Interfaces;

namespace car_rental_common.Classes
{
    public class Booking : IBooking
    {
        double IBooking.KmRented { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateOnly IBooking.RentedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateOnly IBooking.Returned { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}