namespace Dialang
{
    public sealed class Combine
    {
        public int Start { get; }
        public int End { get; }

        public Combine(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}