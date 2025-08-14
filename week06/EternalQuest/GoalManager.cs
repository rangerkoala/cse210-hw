using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goal Names");
                Console.WriteLine("  3. List Goal Details");
                Console.WriteLine("  4. Record Event");
                Console.WriteLine("  5. Save Goals");
                Console.WriteLine("  6. Load Goals");
                Console.WriteLine("  7. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalNames(); break;
                    case "3": ListGoalDetails(); break;
                    case "4": RecordEvent(); break;
                    case "5": SaveGoals(); break;
                    case "6": LoadGoals(); break;
                    case "7": running = false; break;
                    default: Console.WriteLine("Please choose 1–7."); break;
                }
            }
            Console.WriteLine("Goodbye!");
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points. (Level {GetLevel(_score)})");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");

            string type = Console.ReadLine()?.Trim() ?? "";
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine() ?? "";
            Console.Write("What is a short description of it? ");
            string desc = Console.ReadLine() ?? "";
            Console.Write("What is the amount of points associated with this goal? ");
            int points = ReadInt();

            switch (type)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, desc, points));
                    break;

                case "2":
                    _goals.Add(new EternalGoal(name, desc, points));
                    break;

                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = ReadInt();
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = ReadInt();
                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                    break;

                default:
                    Console.WriteLine("Invalid goal type. No goal created.");
                    break;
            }

            Console.WriteLine("Goal created.");
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record yet.");
                return;
            }

            Console.WriteLine("Which goal did you accomplish?");
            ListGoalNames();
            Console.Write("Enter the number: ");

            int idx = ReadInt() - 1;
            if (idx < 0 || idx >= _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            int awarded = _goals[idx].RecordEvent();
            _score += awarded;

            Console.WriteLine($"Nice! You earned {awarded} points.");
            AnnounceLevelUpIfAny();
        }

        public void SaveGoals()
        {
            Console.Write("What is the filename to save to? ");
            string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

            using (StreamWriter output = new StreamWriter(filename))
            {
                output.WriteLine(_score);
                foreach (Goal g in _goals)
                {
                    output.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Saved to {filename}");
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename to load from? ");
            string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("File was empty.");
                return;
            }

            _goals.Clear();

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                Goal g = ParseGoal(lines[i]);
                if (g != null) _goals.Add(g);
            }

            Console.WriteLine($"Loaded {_goals.Count} goals and score = {_score}.");
            AnnounceLevelUpIfAny();
        }

        private static int ReadInt()
        {
            while (true)
            {
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int val)) return val;
                Console.Write("Please enter a whole number: ");
            }
        }

        private static Goal ParseGoal(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 0) return null;

            switch (parts[0])
            {
                case "SimpleGoal":    return SimpleGoal.FromParts(parts);
                case "EternalGoal":   return EternalGoal.FromParts(parts);
                case "ChecklistGoal": return ChecklistGoal.FromParts(parts);
                default:
                    Console.WriteLine($"Unknown goal type in file: {parts[0]}");
                    return null;
            }
        }

        private static int GetLevel(int score) => (score / 1000) + 1;

        private void AnnounceLevelUpIfAny()
        {
            if (_score > 0 && _score % 1000 == 0)
            {
                Console.WriteLine($"*** LEVEL UP! You reached Level {GetLevel(_score)} ***");
            }
        }
    }
}