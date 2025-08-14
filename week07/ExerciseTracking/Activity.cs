using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date
    {
        get { return _date; }
    }

    public int Minutes
    {
        get { return _minutes; }
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return  $"{Date:dd MMM yyyy} {this.GetType().Name} ({Minutes} min) - " +
                $"Distance {GetDistance():0.0} km, " +
                $"Speed {GetSpeed():0.0} kph, " +
                $"Pace: {GetPace():0.00} min per km";
    }
}