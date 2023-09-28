using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes
{
    public class Customer : ICustomer
    {
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(string ssn = "", string firstName = "", string lastName = "")
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
