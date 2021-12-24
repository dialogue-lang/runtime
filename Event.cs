namespace Dialang
{
    public sealed class Event
    {
        public string Name { get; }
        public int Position { get; }

        public Event(string name, int position)
        {
            Name = name;
            Position = position;
        }
    }
}