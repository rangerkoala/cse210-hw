using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        Scripture randomScripture = ScriptureLibrary.GetRandomScripture();
        while (!randomScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(randomScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            randomScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("All words are hidden! Final Scripture:\n");
        Console.WriteLine(randomScripture.GetDisplayText());
        Console.WriteLine("\nPress Enter to exit.");
        Console.ReadLine();
    }
}