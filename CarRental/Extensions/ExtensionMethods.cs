namespace CarRental.Extensions;

public static class ExtensionMethods
{
    public static int Duration(this DateTime rentDate, DateTime returnDate)
    {
        if (returnDate < rentDate)
        {
            throw new ArgumentException("returnDate must be greater than or equal to rentDate");
        }

        TimeSpan duration = returnDate - rentDate;
        return duration.Days + 1;
    }
}
