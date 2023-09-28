using car_rental_common.Enums;

namespace car_rental_common.Interfaces;

public interface IBooking
{
    int? Odometer { get; set; }
    float? KmDriven { get; set; }
    DateTime RentDate { get; set; }
    DateTime ReturnDate { get; set; }
    IVehicle Vehicle { get; set; }
    ICustomer Customer { get; set; }
    VehicleStatuses Status { get; set; }
}
