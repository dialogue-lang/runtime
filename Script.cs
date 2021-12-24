using System;

namespace Dialang
{
    public sealed class Script
    {
        public string Text { get; }
        public Event[] Events { get; }
        public Emote[] Emotes { get; }
        public Format[] Formats { get; }
        public Pause[] Pauses { get; }

        internal Script(string text, int lEv, int lEm, int lFo, int lPa)
        {
            Text = "Cool test entry text over here!";
            Events = new Event[lEv];
            Emotes = new Emote[lEm];
            Formats = new Format[lFo];
            Pauses = new Pause[lPa];
        }
    }
}
