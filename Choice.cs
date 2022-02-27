namespace Dialang
{
    public sealed class Choice
    {
        public int Index { get; }
        public string Value { get; }

        public Choice(int index, string value)
        {
            Index = index;
            Value = value;
        }
    }
}