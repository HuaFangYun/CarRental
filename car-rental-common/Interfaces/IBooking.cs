using car_rental_common.Classes;

namespace car_rental_common.Interfaces
{
    public interface IBooking
    {
        double KmRented { get; set; }
        double? KmTotal { get; set; }
        DateOnly RentedDate { get; set; }
        DateOnly Returned { get; set; }
        Vehicle Vehicle { get; set; }
        Customer Customer { get; set; }
        bool IsBooked { get; }
    }
}
