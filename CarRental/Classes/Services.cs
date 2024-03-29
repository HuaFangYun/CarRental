﻿using CarRental.Enums;
using CarRental.Extensions;
using CarRental.Interfaces;

namespace CarRental.Classes;

public class AppServices
{
    private readonly IData _db;

    public AppServices(IData db)
    {
        _db = db;
    }

    public IEnumerable<T> Get<T>() where T : class
    {
        return _db.Get<T>().ToList();
    }

    public T Single<T>(Func<T, bool> predicate) where T : class
    {
        return _db.Single(predicate);
    }

    public void Add<T>(T entity) where T : class
    {
        _db.Add(entity);
    }

    public float? TotalCost(IBooking b)
    {
        return b.KmDriven.HasValue
            ? (b.KmDriven.Value * b.Vehicle.CostKm) + (b.Vehicle.CostDay * b.RentDate.Duration(b.ReturnDate))
            : b.Vehicle.CostDay * b.RentDate.Duration(b.ReturnDate);
    }

    public VehicleStatus BookingStatus(string regNo)
    {
        return _db.Get<IBooking>().Where(b => b.Vehicle.RegNo == regNo).Any(b => b.Status == VehicleStatus.Booked)
            ? VehicleStatus.Booked
            : VehicleStatus.Available;
    }

    public IBooking RentVehicle(IVehicle v, string selectedCustomer, List<IPerson> customers)
    {
        IPerson? customerToBook = customers.FirstOrDefault(c => c.SSN == selectedCustomer) ?? throw new ArgumentException("Customer not found.");
        IBooking newBooking = new Booking(v, customerToBook)
        {
            RentDate = DateTime.Today.Date
        };
        _db.Add(newBooking);
        return newBooking;
    }

    public VehicleStatus ReturnVehicle(IBooking b)
    {
        UpdateOdometer(b);
        return b.Status = VehicleStatus.Available;
    }

    private void UpdateOdometer(IBooking b)
    {
        IVehicle vehicleToUpdate = _db.Single<IVehicle>(v => v.RegNo == b.Vehicle.RegNo);
        if (vehicleToUpdate != null)
        {
            vehicleToUpdate.Odometer += (int)(b.KmDriven ?? 0);
        }
    }
}
