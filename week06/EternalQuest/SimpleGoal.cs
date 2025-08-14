using System.Collections.Concurrent;

namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public static SimpleGoal FromParts(string[] parts)
        {
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            bool IsComplete = bool.Parse(parts[4]);
            var g = new SimpleGoal(name, desc, points);
            g._isComplete = IsComplete;
            return g;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{_shortName}|{_description}|{_points}|{IsComplete}";
        }
    }
}