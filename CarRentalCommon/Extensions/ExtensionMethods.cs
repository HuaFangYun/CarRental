namespace CarRentalCommon.Extensions;

public static class ExtensionMethods
{
    public static decimal Duration(this DateTime rentDate, DateTime returnDate)
    {
        TimeSpan duration = returnDate - rentDate;
        return duration.Days + 1;
    }
}
