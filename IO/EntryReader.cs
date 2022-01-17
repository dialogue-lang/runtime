using System;
using System.IO;
using System.Text;

namespace Dialang.IO
{
    public sealed class EntryReader : IDisposable
    {
        private readonly Stream s;

        #region Byte[] Buffers

        public int Read(byte[] buffer, int offset, int count) => s.Read(buffer, offset, count);
        public byte[] Read(int len)
        {
            byte[] buffer = new byte[len];
            s.Read(buffer, 0, len);
            return buffer;
        }
        public byte Read()
        {
            return (byte)s.ReadByte();
        }

        #endregion

        #region .NET Types

        public sbyte ReadInt8() => (sbyte)Read();
        public short ReadInt16() => BitConverter.ToInt16(Read(2), 0);
        public int ReadInt32() => BitConverter.ToInt32(Read(4), 0);
        public long ReadInt64() => BitConverter.ToInt64(Read(8), 0);
        public byte ReadUInt8() => Read();
        public ushort ReadUInt16() => BitConverter.ToUInt16(Read(2), 0);
        public uint ReadUInt32() => BitConverter.ToUInt32(Read(4), 0);
        public ulong ReadUInt64() => BitConverter.ToUInt64(Read(8), 0);
        public float ReadSingle() => BitConverter.ToSingle(Read(4), 0);
        public double ReadDouble() => BitConverter.ToDouble(Read(8), 0);
        public bool ReadBool() => BitConverter.ToBoolean(Read(1), 0);
        public char ReadChar() => BitConverter.ToChar(Read(2), 0);
        public string ReadString() => Encoding.UTF8.GetString(Read(ReadInt32()));
        public string ReadString(Encoding enc) => enc.GetString(Read(ReadInt32()));

        #endregion

        #region DiaLang Types

        public Entry ReadEntry()
        {
            Entry e = new Entry(ReadString(), ReadInt32());
            
            for (int i = 0; i < e.Scripts.Length; i++)
            {
                e.Scripts[i] = ReadScript();
            }

            return e;
        }

        public Script ReadScript()
        {
            // Events, Emotes, Formats, Pauses
            Script s = new Script(ReadString(), ReadInt32(), ReadInt32(), ReadInt32(), ReadInt32());
           
            for (int i = 0; i < s.Events.Length; i++)
                s.Events[i] = ReadEvent();

            for (int i = 0; i < s.Emotes.Length; i++)
                s.Emotes[i] = ReadEmote();

            for (int i = 0; i < s.Formats.Length; i++)
                s.Formats[i] = ReadFormat();

            for (int i = 0; i < s.Pauses.Length; i++)
                s.Pauses[i] = ReadPause();
            
            return s;
        }

        public Event ReadEvent()
        {
            return new Event(ReadString(), ReadInt32());
        }

        public Emote ReadEmote()
        {
            return new Emote(ReadString(), ReadInt32());
        }

        public Format ReadFormat()
        {
            return new Format(ReadString(), ReadInt32(), ReadInt32());
        }

        public Pause ReadPause()
        {
            return new Pause(ReadInt32(), ReadInt32());
        }

        #endregion

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
