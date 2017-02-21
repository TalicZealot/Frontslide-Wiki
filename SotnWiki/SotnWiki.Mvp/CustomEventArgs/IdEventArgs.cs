using System;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class IdEventArgs : EventArgs
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public IdEventArgs(Guid id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
