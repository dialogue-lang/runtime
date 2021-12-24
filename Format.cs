namespace Dialang
{
    public sealed class Format
    {
        public string Type { get; }
        public int Start { get; }
        public int End { get; }

        public Format(string type, int start, int end)
        {
            Type = type;
            Start = start;
            End = end;
        }

        public override int GetHashCode()
        {
            return Start ^ End;
        }
    }
}
