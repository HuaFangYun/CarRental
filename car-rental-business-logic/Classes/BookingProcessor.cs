using car_rental_common.Classes;
using car_rental_common.Enums;
using car_rental_common.Extensions;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;


namespace car_rental_business_logic.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db)
    {
        _db = db;
    }

    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();
    public IEnumerable<ICustomer> GetCustomers() => _db.GetCustomers();
    public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();

    public decimal? TotalCost(IBooking booking)
    {
        if (booking.KmDriven != null)
        { 
            var kmDriven = (booking.KmDriven - booking.Odometer);
            return kmDriven * booking.Vehicle.CostKm + booking.Vehicle.CostDay * booking.RentDate.Duration(booking.ReturnDate);
        }
        return 0;
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