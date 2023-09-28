using CarRentalCommon.Enums;

namespace CarRentalCommon.Interfaces;

public interface IBooking
{
    decimal Odometer { get; }
    decimal? KmDriven { get; set; }
    DateTime RentDate { get; set; }
    DateTime ReturnDate { get; set; }
    IVehicle Vehicle { get; }
    IPersons Customer { get; }
    VehicleStatuses Status { get; set; }
}
