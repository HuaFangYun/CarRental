using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes;

public class Booking : IBooking
{
    public int ID { get; init; }
    public float? KmDriven { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public IPerson Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public VehicleStatuses Status { get; set; }

    public Booking(IVehicle vehicle, IPerson customer)
    {
        ID = IDGenerator.SetBookingID();
        RentDate = DateTime.Now.Date;
        ReturnDate = DateTime.Now.Date;
        Customer = customer;
        Vehicle = vehicle;
        Status = VehicleStatuses.Booked;
    }
}
