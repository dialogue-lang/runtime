using System.Collections;
using System.IO;

using Dialang.IO;

namespace Dialang
{
    public delegate void LoggingHandle(string msg);
    public sealed class Project
    {
        public string Name { get; }
        public int Length { get; }
        public Hashtable Entries { get; }

        public static Project Parse(byte[] buffer)
        {
            using (MemoryStream mem = new MemoryStream(buffer))
            {
                using (EntryReader r = new EntryReader(mem))
                {
                    Project p = new Project(r.ReadString(), r.ReadInt32());
                    Entry e;

                    for (int i = 0; i < p.Length; i++)
                    {
                        e = r.ReadEntry();
                        if (e.Name.Length > 0 && e.Scripts.Length > 0)
                            p.Entries.Add(e.Name, e);
                    }

                    return p;
                }
            }
        }

        public static Project Parse(Stream stream, bool dispose = true)
        {
            using (EntryReader r = new EntryReader(stream))
            {
                Project p = new Project(r.ReadString(), r.ReadInt32());
                Entry e;
                
                for (int i = 0; i < p.Length; i++)
                {
                    e = r.ReadEntry();
                    if (e.Name.Length > 0 && e.Scripts.Length > 0)
                        p.Entries.Add(e.Name, e);
                }

                if (dispose)
                    stream.Dispose();

                return p;
            }
        }

        public Entry Get(string id)
        {
            if (!Entries.ContainsKey(id))
                throw new System.ArgumentOutOfRangeException($"The provided id '{id}' does not exist in the entry table.");
            return (Entry)Entries[id];
        }

        public bool TryGet(string id, out Entry entry)
        {
            if (!Entries.ContainsKey(id))
            {
                entry = null;
                return false;
            }

            entry = (Entry)Entries[id];
            return true;
        }

        internal Project(string name, int amount)
        {
            Name = name;
            Length = amount;
            Entries = new Hashtable(amount);
        }
    }
}