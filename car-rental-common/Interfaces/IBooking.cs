namespace car_rental_common.Interfaces
{
    public interface IBooking
    {
        double KmRented { get; set; }
        DateOnly RentedDate { get; set; }
        DateOnly Returned { get; set; }
    }
}