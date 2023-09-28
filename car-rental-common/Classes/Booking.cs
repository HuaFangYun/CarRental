using car_rental_common.Interfaces;

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

        public Booking(decimal odometerBeforeDriving, decimal? odometerAfterDriving, Vehicle vehicle, Customer customer)
        {
            OdometerBeforeDriving = odometerBeforeDriving;
            OdometerAfterDriving = odometerAfterDriving;
            StartDate = DateOnly.FromDateTime(DateTime.Now);
            ReturnDate = DateOnly.FromDateTime(DateTime.Now);
            Vehicle = vehicle;
            Customer = customer;
            Cost = 0;
        }
    }
}