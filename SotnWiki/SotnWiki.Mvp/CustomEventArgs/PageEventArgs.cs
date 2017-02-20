using System;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class PageEventArgs : EventArgs
    {
        public string Title { get; private set; }

        public PageEventArgs(string title)
        {
            this.Title = title;
        }
    }
}
