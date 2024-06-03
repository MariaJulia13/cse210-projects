using System;
using System.Collections.Generic;

// Comment Class
public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string CommentText
    {
        get { return _commentText; }
    }
}

// Video Class
public class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string Title
    {
        get { return _title; }
    }

    public string Author
    {
        get { return _author; }
    }

    public int Length
    {
        get { return _length; }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Learn C#", "John Doe", 600);
        Video video2 = new Video("Understanding OOP", "Jane Smith", 1200);
        Video video3 = new Video("Advanced C# Techniques", "Alice Johnson", 1800);

        // Add comments to videos
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Very informative."));
        video1.AddComment(new Comment("User3", "Helped me a lot, thanks!"));

        video2.AddComment(new Comment("User4", "Awesome explanation."));
        video2.AddComment(new Comment("User5", "Loved the examples."));
        video2.AddComment(new Comment("User6", "Can you make more on this topic?"));

        video3.AddComment(new Comment("User7", "This is gold!"));
        video3.AddComment(new Comment("User8", "Fantastic content."));
        video3.AddComment(new Comment("User9", "Super helpful, thanks!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
