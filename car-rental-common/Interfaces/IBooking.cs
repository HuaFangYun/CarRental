namespace car_rental_common.Interfaces
{
    internal interface IBooking
    {
        public double KmRented { get; set; }
        public DateOnly RentedDate { get; set; }
        public DateOnly Returned { get; set; }
    }
}