namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public static ChecklistGoal FromParts(string[] parts)
        {
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            int done = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);

            var g = new ChecklistGoal(name, desc, points, target, bonus);
            g._amountCompleted = done;
            return g;
        }

        public override int RecordEvent()
        {
            _amountCompleted++;

            if (_amountCompleted == _target)
            {
                return _points + _bonus;
            }

            return _points;
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
        }
    }
}