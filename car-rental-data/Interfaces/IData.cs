using car_rental_common.Enums;
using car_rental_common.Interfaces;

namespace car_rental_data.Interfaces
{
    public interface IData
    {
        IEnumerable<IBooking> GetBookings();
        IEnumerable<ICustomer> GetCustomers();
        IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);

        void AddBooking(IBooking booking);
        void AddCustomer(ICustomer customer);
        void AddVehicle(IVehicle vehicle);
        void UpdateBooking(IBooking booking);
        void UpdateVehicle(IVehicle vehicle);
        void UpdateCustomer(ICustomer customer);
    }
}