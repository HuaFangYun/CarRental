using car_rental_common.Classes;
using car_rental_common.Enums;
using car_rental_common.Interfaces;
using car_rental_data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace car_rental_business_logic.Classes
{
    public class BookingProcessor
    {
        private readonly IData _dataBase;

        public BookingProcessor(IData dataBase)
        {
            _dataBase = dataBase;
        }

        // Generic Get method
        public IEnumerable<T> Get<T>(Func<T, bool> predicate) where T : class
        {
            switch (typeof(T))
            {
                case var type when type == typeof(IBooking):
                    return _dataBase.GetBookings().Where(predicate as Func<IBooking, bool>).Cast<T>().ToList();
                case var type when type == typeof(IVehicle):
                    return _dataBase.GetVehicles().Where(predicate as Func<IVehicle, bool>).Cast<T>().ToList();
                case var type when type == typeof(ICustomer):
                    return _dataBase.GetCustomers().Where(predicate as Func<ICustomer, bool>).Cast<T>().ToList();
                default:
                    return new List<T>();
            }
        }

        // Generic Single method
        public T Single<T>(Func<T, bool> predicate) where T : class
        {
            if (typeof(T) == typeof(IBooking))
            {
                return _dataBase.GetBookings().SingleOrDefault(predicate as Func<IBooking, bool>) as T;
            }
            else if (typeof(T) == typeof(IVehicle))
            {
                return _dataBase.GetVehicles().SingleOrDefault(predicate as Func<IVehicle, bool>) as T;
            }
            else if (typeof(T) == typeof(ICustomer))
            {
                return _dataBase.GetCustomers().SingleOrDefault(predicate as Func<ICustomer, bool>) as T;
            }
            return null;
        }

        // Add method
        public void Add<T>(T entity) where T : class
        {
            if (typeof(T) == typeof(IBooking))
            {
                _dataBase.AddBooking(entity as IBooking);
            }
            else if (typeof(T) == typeof(IVehicle))
            {
                _dataBase.AddVehicle(entity as IVehicle);
            }
            else if (typeof(T) == typeof(ICustomer))
            {
                _dataBase.AddCustomer(entity as ICustomer);
            }
        }

        //Update method
        public void Update<T>(T entity) where T : class
        {
            if (typeof(T) == typeof(IBooking))
            {
                _dataBase.UpdateBooking(entity as IBooking);
            }
            else if (typeof(T) == typeof(IVehicle))
            {
                _dataBase.UpdateVehicle(entity as IVehicle);
            }
            else if (typeof(T) == typeof(ICustomer))
            {
                _dataBase.UpdateCustomer(entity as ICustomer);
            }
        }

        public decimal CalculateCostForBooking(IBooking booking)
        {
            decimal cost = 0;

            if (booking.OdometerAfterDriving.HasValue)
                cost += ((booking.OdometerAfterDriving.Value - booking.OdometerBeforeDriving) * booking.Vehicle.CostKm) + (booking.Vehicle.CostDay * (booking.ReturnDate.DayNumber - booking.StartDate.DayNumber + 1));

            return (int)Math.Round(cost);
        }

        public string GetBookingStatus(IBooking booking)
        {
            if (booking.OdometerAfterDriving.HasValue)
                return "Closed";

            return "Open";
        }

        public VehicleStatuses IsVehicleBooked(string regNo)
        {
            var bookingsForVehicle = _dataBase.GetBookings().Where(b => b.Vehicle.RegNo == regNo);
            return bookingsForVehicle.Any(b => !b.OdometerAfterDriving.HasValue) ? VehicleStatuses.Booked : VehicleStatuses.Available;
        }
    }
}