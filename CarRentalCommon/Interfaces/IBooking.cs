using CarRentalCommon.Enums;

namespace CarRentalCommon.Interfaces;

public interface IBooking
{
    int ID { get; }
    float? KmDriven { get; set; }
    DateTime RentDate { get; set; }
    DateTime ReturnDate { get; set; }
    IPerson Customer { get; set; }
    IVehicle Vehicle { get; set; }
    VehicleStatuses Status { get; set; }
}
