public abstract class Goal
{
    protected string _name;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _isComplete = false;
    }

    public string Name => _name;
    public int Points => _points;
    public bool IsComplete => _isComplete;

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
}

