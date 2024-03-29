﻿namespace CarRental.Classes;

public static class IDGenerator
{
    private static int BookingID = 0;
    private static int CustomerID = 0;
    private static int VehicleID = 0;

    public static int SetBookingID()
    {
        return ++BookingID;
    }

    public static int SetCustomerID()
    {
        return ++CustomerID;
    }

    public static int SetVehicleID()
    {
        return ++VehicleID;
    }
}
