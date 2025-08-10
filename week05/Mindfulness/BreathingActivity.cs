using System;
using System.Security.Cryptography.X509Certificates;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through deep breathing. Clear your mind and focus on your breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            Console.Write("\nBreathe out... ");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}