using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_common.Classes;

public class Booking : IBooking
{
    public decimal Odometer { get; set; }
    public decimal? KmDriven { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public IVehicle Vehicle { get; set; }
    public ICustomer Customer { get; set; }
    public VehicleStatuses Status { get; set; }

    public Booking(IVehicle vehicle, ICustomer customer, DateTime rentDate, DateTime returnDate, decimal odometer = 0, decimal? kmDriven = null)
    {
        Odometer = odometer;
        KmDriven = kmDriven;
        RentDate = rentDate;
        ReturnDate = returnDate;
        Vehicle = vehicle;
        Customer = customer;
        Status = VehicleStatuses.Booked;
    }
}
