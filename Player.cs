using System;

namespace Dialang
{
    public sealed class Player : IDisposable
    {
        private bool disposed;
        private bool play;

        public Project Project { get; }
        public bool Playing => play;

        public void Dispose()
        {
            if (disposed)
                return;
            disposed = true;
        }

        public Player(byte[] proj)
        {
            Project = Project.Parse(proj);
        }
    }
}