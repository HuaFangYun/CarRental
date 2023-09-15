using car_rental_common.Classes;

namespace car_rental_common.Interfaces
{
    public interface IBooking
    {
        decimal OdometerBeforeDriving { get; set; }
        decimal? OdometerAfterDriving { get; set; }
        DateOnly StartDate { get; set; }
        DateOnly ReturnDate { get; set; }
        Vehicle Vehicle { get; set; }
        Customer Customer { get; set; }
        decimal Cost { get; set; }
    }
}