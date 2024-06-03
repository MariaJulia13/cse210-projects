using System;
using System.Collections.Generic;

// Address Class
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}, {_city}, {_stateOrProvince}, {_country}";
    }
}

// Event Class
public abstract class Event
{
    protected string _title;
    protected string _description;
    protected DateTime _date;
    protected string _time;
    protected Address _address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}

// Lecture Class
public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {_title}, Date: {_date.ToShortDateString()}";
    }
}

// Reception Class
public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {_title}, Date: {_date.ToShortDateString()}";
    }
}

// Outdoor Gathering Class
public class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {_weather}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering: {_title}, Date: {_date.ToShortDateString()}";
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 Pine St", "Los Angeles", "CA", "USA");

        // Create events
        Lecture lecture = new Lecture("C# for Beginners", "An introductory lecture on C#", new DateTime(2023, 6, 10), "10:00 AM", address1, "John Doe", 100);
        Reception reception = new Reception("Tech Networking", "An event to network with tech enthusiasts", new DateTime(2023, 7, 5), "6:00 PM", address2, "rsvp@techconnect.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer BBQ", "A fun outdoor BBQ event", new DateTime(2023, 8, 15), "12:00 PM", address3, "Sunny and warm");

        // Store events in a list
        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        // Display event details
        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine(new string('-', 20));
        }
    }
}
