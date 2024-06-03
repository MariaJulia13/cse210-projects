using System;
using System.Collections.Generic;

// Activity Class
public abstract class Activity
{
    protected DateTime _date;
    protected int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date.ToShortDateString()} {_lengthInMinutes} min";
    }
}

// Running Class
public class Running : Activity
{
    private double _distanceInMiles;

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles)
        : base(date, lengthInMinutes)
    {
        _distanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return _distanceInMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceInMiles / _lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / _distanceInMiles;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Running - Distance: {_distanceInMiles} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min/mile";
    }
}

// Cycling Class
public class Cycling : Activity
{
    private double _speedInMph;

    public Cycling(DateTime date, int lengthInMinutes, double speedInMph)
        : base(date, lengthInMinutes)
    {
        _speedInMph = speedInMph;
    }

    public override double GetDistance()
    {
        return (_speedInMph * _lengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedInMph;
    }

    public override double GetPace()
    {
        return 60 / _speedInMph;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Cycling - Speed: {_speedInMph} mph, Distance: {GetDistance():F1} miles, Pace: {GetPace():F1} min/mile";
    }
}

// Swimming Class
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Swimming - Laps: {_laps}, Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min/mile";
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Create activities
        Running running = new Running(new DateTime(2023, 6, 1), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2023, 6, 2), 45, 15.0);
        Swimming swimming = new Swimming(new DateTime(2023, 6, 3), 60, 40);

        // Store activities in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display activity summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
