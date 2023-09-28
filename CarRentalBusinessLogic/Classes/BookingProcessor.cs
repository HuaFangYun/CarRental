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

    public decimal TotalCost(IBooking booking)
    {
        return (decimal)(booking.KmDriven.HasValue ? ((booking.KmDriven - booking.Odometer) * booking.Vehicle.CostKm + booking.Vehicle.CostDay * booking.RentDate.Duration(booking.ReturnDate)) : 0m);
    }

    public VehicleStatuses IsVehicleBooked(string regNo)
    {
        var bookingsForVehicle = _db.GetBookings().Where(b => b.Vehicle.RegNo == regNo);

        if (bookingsForVehicle.Any(b => b.KmDriven.HasValue))
            return VehicleStatuses.Available;

        return bookingsForVehicle.Any(b => b.Status == VehicleStatuses.Booked)
            ? VehicleStatuses.Booked
            : VehicleStatuses.Available;
    }
}
