//Input control for every value?

using car_rental_common.Interfaces;

namespace car_rental_common.Classes
{
    public class Customer : ICustomer
    {
        string ICustomer.SSN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ICustomer.LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}