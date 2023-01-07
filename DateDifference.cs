using System;

public class DateDifferencemosso
{
    /// <summary>
    /// defining Number of days in month; index 0=> january and 11=> December
    /// february contain either 28 or 29 days, that's why here value is -1
    /// which wil be calculate later.
    /// </summary>
    private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    /// <summary>
    /// contain from date
    /// </summary>
    private DateTime fromDate;

    /// <summary>
    /// contain To Date
    /// </summary>
    private DateTime toDate;

    /// <summary>
    /// this three variable for output representation..
    /// </summary>
    private int year;
    private int month;
    private int day;

    public DateDifferencemosso(DateTime d1, DateTime d2)
    {
        int increment;
        if (d1 > d2)
        {
            fromDate = d2;
            toDate = d1;
        }
        else
        {
            fromDate = d1;
            toDate = d2;
        }

        /// Day Calculation
        increment = 0;
        if (fromDate.Day > toDate.Day)
        {
            increment = monthDay[fromDate.Month - 1];
        }
        /// if it is february month
        /// if it's to day is less then from day
        if (increment == -1)
        {
            if (DateTime.IsLeapYear(fromDate.Year))
            {
                // leap year february contain 29 days
                increment = 29;
            }
            else
            {
                increment = 28;
            }
        }

        if (increment != 0)
        {
            day = toDate.Day + increment - fromDate.Day;
            increment = 1;
        }
        else
        {
            day = toDate.Day - fromDate.Day;
        }

        if (fromDate.Month + increment > toDate.Month)
        {
            month = toDate.Month + 12 - (fromDate.Month + increment);
            increment = 1;
        }
        else
        {
            month = toDate.Month - (fromDate.Month + increment);
            increment = 0;
        }

        /// year calculation

        year = toDate.Year - (fromDate.Year + increment);
    }

    public override string ToString()
    {
        // return base.ToString();
        return year + " Year(s), " + month + " month(s), " + day + " day(s)";
    }

    public int Years
    {
        get
        {
            return year;
        }
    }

    public int Months
    {
        get
        {
            return month;
        }
    }

    public int Days
    {
        get
        {
            return day;
        }
    }
}