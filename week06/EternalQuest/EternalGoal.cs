namespace EternalQuest
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public static EternalGoal FromParts(string[] parts)
        {
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            return new EternalGoal(name, desc, points);
        }

        public override int RecordEvent()
        {
            return _points;
        }

        public override bool IsComplete() => false;

        public override string GetStringRepresentation()
        {
            return $"EternalGoal|{_shortName}|{_description}|{_points}";
        }
    }
}