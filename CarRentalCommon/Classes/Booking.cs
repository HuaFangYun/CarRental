using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes;

public class Booking : IBooking
{
    public decimal Odometer { get; init; }
    public decimal? KmDriven { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public IVehicle Vehicle { get; init; }
    public IPersons Customer { get; init; }
    public VehicleStatuses Status { get; init; }

    public Booking(IVehicle vehicle, IPersons customer, DateTime rentDate, DateTime returnDate, decimal odometer, decimal? kmDriven = null)
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
