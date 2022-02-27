using System;
using System.IO;

using Dialang.IO;

namespace Dialang
{
    public sealed class Script
    {
        public string Text { get; }
        public Event[] Events { get; }
        public Emote[] Emotes { get; }
        public Format[] Formats { get; }
        public Pause[] Pauses { get; }
        public Choice[] Choices { get; }

        internal Script(string text, int lEv, int lEm, int lFo, int lPa, int lCh)
        {
            Text = text;
            Events = new Event[lEv];
            Emotes = new Emote[lEm];
            Formats = new Format[lFo];
            Pauses = new Pause[lPa];
            Choices = new Choice[lCh];
        }
    }
}
