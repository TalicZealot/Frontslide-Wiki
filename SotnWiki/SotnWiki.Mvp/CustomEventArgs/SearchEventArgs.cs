using System;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class SearchEventArgs : EventArgs
    {
        public string SearchPhrase { get; private set; }

        public SearchEventArgs(string searchPhrase)
        {
            this.SearchPhrase = searchPhrase;
        }
    }
}
