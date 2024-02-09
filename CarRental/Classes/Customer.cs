using CarRental.Interfaces;

namespace CarRental.Classes;

public class Customer : IPerson
{
    public int ID { get; init; }
    public string SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(string ssn = "", string firstName = "", string lastName = "")
    {
        ID = IDGenerator.SetCustomerID();
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
    }
}
