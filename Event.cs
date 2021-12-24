namespace Dialang
{
    public abstract class Event
    {
        public int Char { get; }
        public abstract void Run();
    }
}