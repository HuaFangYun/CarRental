# Simple Vehicle Rental Website

A simple vehicle rental app developed using Blazor WebAssembly, incorporating a three-layered architecture.

## Note
This is a foundational project aimed at understanding the basics of Blazor WebAssembly and the principles of a three-layered architecture. Future enhancements would include more advanced features, refinements, and a more comprehensive external data layer.

## Architecture
The application follows a basic three-layered architecture:

- **Presentation Layer**: Provides an interface for adding vehicles and customers, viewing current bookings, and renting or returning vehicles.
- **Business Logic Layer**: Responsible for tasks like adding a new vehicle, validating customer data, and processing rentals and returns.
- **Data Access Layer**: Seed data is used a placeholder for an actual database or other storage solution.

## Features
- **List Management**: View current bookings, available vehicles, and registered customers.
- **Add Vehicles and Customers**: Simple forms allow users to add cars, motorcycles, or new customers.
- **Rent & Return**: Basic functionality to simulate renting and returning vehicles.
- **Simple Validation**: Checks on customer details to ensure they match expected formats.
- **Toggle Instructions**: Helpful guide for users unfamiliar with the system.

## How to Use
1. **Start the App**: Initial load will show available vehicles, current bookings, and customers.
2. **Adding**: Use the provided forms to input a new car, motorcycle, or customer details.
3. **Renting**: Choose a vehicle and a customer to simulate a rental transaction.
4. **Returning**: Once a vehicle is rented, there's an option to mark it as returned.
