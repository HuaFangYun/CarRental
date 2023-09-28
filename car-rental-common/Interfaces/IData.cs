using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_data.Interfaces;

public interface IData
{
    IEnumerable<IBooking> GetBookings();
    IEnumerable<ICustomer> GetCustomers();
    IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
}
