using System.IO;
using System.Collections.Generic;

namespace Dialang
{
    public sealed class Emote
    {
        public string Name { get; set; }
        public int Position { get; set; }

        public Emote(string name, int position)
        {
            Name = name;
            Position = position;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
}
