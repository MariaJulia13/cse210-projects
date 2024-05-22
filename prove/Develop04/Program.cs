using System;
using System.Threading;

// Base class for activities
class Activity
{
    protected string name;
    protected string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start(int duration)
    {
        Console.WriteLine($"Starting {name}...");
        Console.WriteLine(description);
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public void End(int duration)
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {name} for {duration} seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected void ShowSpinner(string message, int duration)
    {
        Console.Write(message);
        for (int i = 0; i < duration; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}

// Derived class for Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public void StartBreathing(int duration)
    {
        Start(duration);
        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner("Breathing in", 3);
            Console.WriteLine("Breathe out...");
            ShowSpinner("Breathing out", 3);
        }
        End(duration);
    }
}

// Derived class for Reflection Activity
class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    public void StartReflection(int duration)
    {
        Start(duration);
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        foreach (string question in questions)
        {
            Console.WriteLine(question);
            ShowSpinner("Reflecting...", 5);
        }
        End(duration);
    }
}

// Derived class for Listing Activity
class ListingActivity : Activity
{
    private string[] listPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public void StartListing(int duration)
    {
        Start(duration);
        Random rand = new Random();
        string prompt = listPrompts[rand.Next(listPrompts.Length)];
        Console.WriteLine(prompt);
        ShowSpinner("Preparing to list", 3);
        DateTime startTime = DateTime.Now;
        int count = 0;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write("List an item: ");
            Console.ReadLine(); // Read user input (can be anything)
            count++;
        }
        Console.WriteLine($"You listed {count} items.");
        End(duration);
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.StartBreathing(duration);
            }
            else if (choice == "2")
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.StartReflection(duration);
            }
            else if (choice == "3")
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.StartListing(duration);
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
            }
        }
    }
}
