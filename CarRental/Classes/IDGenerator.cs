namespace CarRental.Classes;

public static class IDGenerator
{
    private static int BookingID = 0;
    private static int CustomerID = 0;
    private static int VehicleID = 0;

    public static int SetBookingID() => ++BookingID;
    public static int SetCustomerID() => ++CustomerID;
    public static int SetVehicleID() => ++VehicleID;
}
