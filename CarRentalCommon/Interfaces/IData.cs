using CarRentalCommon.Enums;
using CarRentalCommon.Interfaces;

namespace CarRentalData.Interfaces;

public interface IData
{
    IEnumerable<IBooking> GetBookings();
    IEnumerable<IPerson> GetCustomers();
    IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
}
