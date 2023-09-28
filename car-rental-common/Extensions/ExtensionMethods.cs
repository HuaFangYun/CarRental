namespace car_rental_common.Extensions;

public static class ExtensionMethods
{
    public static int Duration(this DateTime rentDate, DateTime returnDate)
    {
        TimeSpan duration = returnDate - rentDate;
        return duration.Days + 1;
    }
}
