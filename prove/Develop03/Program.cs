using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private string _reference;
    private string _text;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _text = text;
        InitializeWords();
    }

    private void InitializeWords()
    {
        _words = _text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"Scripture: {_reference}");
        foreach (var word in _words)
        {
            Console.Write(word.IsVisible ? word.Text + " " : "_ ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, _words.Count / 2); // Adjust the range based on desired difficulty

        HashSet<int> indicesToHide = new HashSet<int>();
        while (indicesToHide.Count < wordsToHide)
        {
            indicesToHide.Add(random.Next(0, _words.Count));
        }

        foreach (int index in indicesToHide)
        {
            _words[index].Hide();
        }
    }
}

public class Reference
{
    private string _reference;

    public Reference(string reference)
    {
        _reference = reference;
    }
}

public class Word
{
    private string _text;
    private bool _isVisible;

    public Word(string text)
    {
        _text = text;
        _isVisible = true;
    }

    public string Text { get { return _text; } }
    public bool IsVisible { get { return _isVisible; } }

    public void Hide()
    {
        _isVisible = false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life.");
        
        Console.WriteLine("Press Enter to hide random words in the scripture or type 'quit' to exit.");
        while (Console.ReadLine().ToLower() != "quit")
        {
            Console.Clear();
            scripture.HideRandomWords();
            scripture.Display();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
        }
    }
}
