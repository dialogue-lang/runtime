using System.Collections.Generic;

namespace Dialang
{
    public sealed class Entry
    {
        public string Text { get; }
        public int Length => Text.Length;
        public HashSet<string> Events { get; }
    }
}