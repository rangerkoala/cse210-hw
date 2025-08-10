using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private int _count;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by listing items in a specific area.") { }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }
        return items;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine($"\nList response to the following prompt:\n--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        var items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
    }
}