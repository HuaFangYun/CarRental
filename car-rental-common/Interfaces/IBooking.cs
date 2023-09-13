using car_rental_common.Classes;

namespace car_rental_common.Interfaces
{
    public interface IBooking
    {
        double? OdometerAtStart { get; set; }
        double? KilometersTraveled { get; set; }
        DateOnly StartDate { get; set; }
        DateOnly EndDate { get; set; }
        Vehicle Vehicle { get; set; }
        Customer Customer { get; set; }
        bool? IsBooked { get; }
    }
}