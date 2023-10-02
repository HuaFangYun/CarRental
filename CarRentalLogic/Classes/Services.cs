using CarRentalCommon.Classes;
using CarRentalCommon.Enums;
using CarRentalCommon.Extensions;
using CarRentalCommon.Interfaces;

namespace CarRentalLogic.Classes;

public class Services
{
    private readonly IData _db;

    public Services(IData db) => _db = db;

    public IEnumerable<T> Get<T>(Func<T, bool> predicate) where T : class => _db.Get<T>().Where(predicate).ToList();

    public T Single<T>(Func<T, bool> predicate) where T : class => _db.Single(predicate);

    public void Add<T>(T entity) where T : class => _db.Add(entity);

    public float? TotalCost(IBooking b)
    { 
        return b.KmDriven.HasValue
            ? b.KmDriven.Value * b.Vehicle.CostKm + b.Vehicle.CostDay * b.RentDate.Duration(b.ReturnDate)
            : 0;
    }

    public VehicleStatus BookingStatus(string regNo)
    {
        return _db.Get<IBooking>().Where(b => b.Vehicle.RegNo == regNo).Any(b => b.Status == VehicleStatus.Booked)
            ? VehicleStatus.Booked
            : VehicleStatus.Available;
    }

    public IBooking RentVehicle(IVehicle v, string selectedCustomer, List<IPerson> c, List<IBooking> b)
    {
        IPerson? customerToBook = c.FirstOrDefault(c => c.SSN == selectedCustomer);

        if (customerToBook == null)
            throw new ArgumentException("Customer not found.");

        IBooking newBooking = new Booking(v, customerToBook)
        {
            RentDate = DateTime.Today.Date
        };
        _db.Add(newBooking);
        b.Add(newBooking);
        return newBooking;
    }

    public VehicleStatus ReturnVehicle(IBooking b)
    {
        UpdateOdometer(b);
        return b.Status = VehicleStatus.Available;
    }

    public void UpdateOdometer(IBooking b)
    {
        var vehicleToUpdate = _db.Get<IVehicle>().FirstOrDefault(v => v.RegNo == b.Vehicle.RegNo);
        if (vehicleToUpdate != null)
        {
            vehicleToUpdate.Odometer += (int)(b.KmDriven ?? 0);
        }
    }
}
