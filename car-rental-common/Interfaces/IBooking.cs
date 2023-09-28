using CarRentalCommon.Enums;

namespace CarRentalCommon.Interfaces;

public interface IBooking
{
    decimal Odometer { get; set; }
    decimal? KmDriven { get; set; }
    DateTime RentDate { get; set; }
    DateTime ReturnDate { get; set; }
    IVehicle Vehicle { get; set; }
    ICustomer Customer { get; set; }
    VehicleStatuses Status { get; set; }
}
