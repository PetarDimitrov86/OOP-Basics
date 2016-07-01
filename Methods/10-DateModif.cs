using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DateModifier
{
    public TimeSpan ts;
    public DateTime date1;
    public DateTime date2;

    public DateModifier(int year1, int month1, int day1, int year2, int month2, int day2)
    {
        this.date1 = new DateTime(year1, month1, day1);
        this.date2 = new DateTime(year2, month2, day2);
    }

    public static TimeSpan CalculateTimeSpan(DateTime date1, DateTime date2)
    {
        TimeSpan ts = new TimeSpan();
        ts = date2.Subtract(date1);
        return ts;
    }
}

class DateModif
{
    static void Main(string[] args)
    {
        string[] date1Split = Console.ReadLine().Split();
        string[] date2Split = Console.ReadLine().Split();

        int year1 = int.Parse(date1Split[0]);
        int month1 = int.Parse(date1Split[1].TrimStart('0'));
        int day1 = int.Parse(date1Split[2].TrimStart('0'));

        int year2 = int.Parse(date2Split[0]);
        int month2 = int.Parse(date2Split[1].TrimStart('0'));
        int day2 = int.Parse(date2Split[2].TrimStart('0'));

        DateModifier ourDate = new DateModifier(year1, month1, day1, year2, month2, day2);
        TimeSpan result = DateModifier.CalculateTimeSpan(ourDate.date1, ourDate.date2);
        Console.WriteLine(Math.Abs(result.Days));
    }
}
