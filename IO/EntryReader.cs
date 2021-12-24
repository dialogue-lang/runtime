using System;
using System.IO;

namespace Dialang.IO
{
    public sealed class EntryReader : IDisposable
    {
        private readonly Stream s;

        public string ReadString()
        {
            return s.ToString()!;
        }

        public void Close()
        {
            s.Close();
        }

        public void Dispose()
        {
            s.Dispose();
        }

        public EntryReader(Stream input)
        {
            s = input;
        }
    }
}
