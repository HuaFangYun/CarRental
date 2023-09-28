using CarRentalCommon.Interfaces;

namespace CarRentalCommon.Classes
{
    public class Customer : IPersons
    {
        public string SSN { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Customer(string ssn = "", string firstName = "", string lastName = "")
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
