namespace Dialang
{
    public sealed class Pause
    {
        public int Start { get; }
        public int Length { get; }

        public Pause()
        {
            Start = 0;
            Length = 0;
        }

        public Pause(int start, int length)
        {
            Start = start;
            Length = length;
        }

        public override int GetHashCode()
        {
            return Start ^ Length;
        }
    }
}
