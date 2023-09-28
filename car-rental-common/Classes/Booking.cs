using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_common.Classes;

public class Booking : IBooking
{
    public int? Odometer { get; set; }
    public float? KmDriven { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public IVehicle Vehicle { get; set; }
    public ICustomer Customer { get; set; }
    public VehicleStatuses Status { get; set; }

    public Booking(int? odometer, float? kmDriven, IVehicle vehicle, ICustomer customer, DateTime rentDate, DateTime returnDate)
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
