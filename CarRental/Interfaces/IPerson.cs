namespace CarRental.Interfaces;

public interface IPerson
{
    int ID { get; }
    string SSN { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
}
