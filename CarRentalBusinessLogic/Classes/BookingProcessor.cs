using CarRentalCommon.Enums;
using CarRentalCommon.Extensions;
using CarRentalCommon.Interfaces;
using CarRentalData.Interfaces;

namespace CarRentalBusinessLogic.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db) => _db = db;

    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();
    public IEnumerable<IPersons> GetCustomers() => _db.GetCustomers();
    public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();

    public decimal TotalCost(IBooking b)
    {
        return (decimal)(b.KmDriven.HasValue
            ? ((b.KmDriven - b.Odometer) * b.Vehicle.CostKm + b.Vehicle.CostDay * b.RentDate.Duration(b.ReturnDate))
            : 0m);
    }

    public VehicleStatuses IsVehicleBooked(string regNo)
    {
        return (_db.GetBookings().Where(b => b.Vehicle.RegNo == regNo).Any(b => b.KmDriven.HasValue))
            ? VehicleStatuses.Available
            : VehicleStatuses.Booked;
    }
}
