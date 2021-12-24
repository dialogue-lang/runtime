using System;

namespace Dialang
{
    public sealed class Entry
    {
        public string Name { get; }
        public Script[] Scripts { get; }

        internal Entry(string name, int len)
        {
            Name = name;
            Scripts = new Script[len];
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}