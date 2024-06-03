using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string description;
    protected int points;
    protected bool isCompleted;

    public Goal(string description, int points)
    {
        this.description = description;
        this.points = points;
        this.isCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
    public abstract void Deserialize(string data);

    public int GetPoints()
    {
        return points;
    }

    public bool IsCompleted()
    {
        return isCompleted;
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points) { }

    public override void RecordEvent()
    {
        if (!isCompleted)
        {
            isCompleted = true;
        }
    }

    public override string GetStatus()
    {
        return $"[Simple] {description}: {(isCompleted ? "[X]" : "[ ]")}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal:{description},{points},{isCompleted}";
    }

    public override void Deserialize(string data)
    {
        string[] parts = data.Split(',');
        description = parts[0];
        points = int.Parse(parts[1]);
        isCompleted = bool.Parse(parts[2]);
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points) { }

    public override void RecordEvent() { }

    public override string GetStatus()
    {
        return $"[Eternal] {description}: [ ]";
    }

    public override string Serialize()
    {
        return $"EternalGoal:{description},{points}";
    }

    public override void Deserialize(string data)
    {
        string[] parts = data.Split(',');
        description = parts[0];
        points = int.Parse(parts[1]);
    }
}

class ChecklistGoal : Goal
{
    private int requiredCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string description, int points, int requiredCount, int bonusPoints) 
        : base(description, points)
    {
        this.requiredCount = requiredCount;
        this.currentCount = 0;
        this.bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        currentCount++;
        if (currentCount >= requiredCount)
        {
            isCompleted = true;
            points += bonusPoints;
        }
    }

    public override string GetStatus()
    {
        return $"[Checklist] {description}: Completed {currentCount}/{requiredCount} {(isCompleted ? "[X]" : "[ ]")}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal:{description},{points},{currentCount},{requiredCount},{bonusPoints},{isCompleted}";
    }

    public override void Deserialize(string data)
    {
        string[] parts = data.Split(',');
        description = parts[0];
        points = int.Parse(parts[1]);
        currentCount = int.Parse(parts[2]);
        requiredCount = int.Parse(parts[3]);
        bonusPoints = int.Parse(parts[4]);
        isCompleted = bool.Parse(parts[5]);
    }
}

class NegativeGoal : Goal
{
    public NegativeGoal(string description, int points) : base(description, points) { }

    public override void RecordEvent()
    {
        if (!isCompleted)
        {
            isCompleted = true;
        }
    }

    public override string GetStatus()
    {
        return $"[Negative] {description}: {(isCompleted ? "[X]" : "[ ]")}";
    }

    public override string Serialize()
    {
        return $"NegativeGoal:{description},{points},{isCompleted}";
    }

    public override void Deserialize(string data)
    {
        string[] parts = data.Split(',');
        description = parts[0];
        points = int.Parse(parts[1]);
        isCompleted = bool.Parse(parts[2]);
    }
}

class GoalManager
{
    private List<Goal> goals;
    private int userScore;
    private int userLevel;
    private List<string> badges;

    public GoalManager()
    {
        goals = new List<Goal>();
        userScore = 0;
        userLevel = 1;
        badges = new List<string>();
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            userScore += goals[goalIndex].GetPoints();
            UpdateLevel();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"User Score: {userScore}");
        Console.WriteLine($"User Level: {userLevel}");
        Console.WriteLine($"Badges: {string.Join(", ", badges)}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(userScore);
            outputFile.WriteLine(userLevel);
            outputFile.WriteLine(string.Join(";", badges));
            foreach (var goal in goals)
            {
                outputFile.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            userScore = int.Parse(lines[0]);
            userLevel = int.Parse(lines[1]);
            badges = new List<string>(lines[2].Split(';'));

            goals.Clear();
            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string goalType = parts[0];
                string goalData = parts[1];

                Goal goal = null;
                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal("", 0);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal("", 0);
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal("", 0, 0, 0);
                        break;
                    case "NegativeGoal":
                        goal = new NegativeGoal("", 0);
                        break;
                }

                if (goal != null)
                {
                    goal.Deserialize(goalData);
                    goals.Add(goal);
                }
            }
        }
    }

    private void UpdateLevel()
    {
        userLevel = userScore / 1000 + 1;
        if (userScore >= 5000 && !badges.Contains("High Achiever"))
        {
            badges.Add("High Achiever");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        
        // Add goals
        manager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read scriptures", 100));
        manager.AddGoal(new ChecklistGoal("Attend temple", 50, 10, 500));
        manager.AddGoal(new NegativeGoal("Avoid junk food", -100));

        // Record events
        manager.RecordEvent(1);  // Read scriptures
        manager.RecordEvent(2);  // Attend temple
        manager.RecordEvent(2);  // Attend temple
        manager.RecordEvent(3);  // Avoid junk food

        // Display goals and score
        manager.DisplayGoals();
        manager.DisplayScore();

        // Save and load goals
        manager.SaveGoals("goals.txt");
        manager.LoadGoals("goals.txt");

        // Display goals and score after loading
        manager.DisplayGoals();
        manager.DisplayScore();
    }
}
