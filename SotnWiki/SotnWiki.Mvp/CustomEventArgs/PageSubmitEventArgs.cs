using System;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class PageSubmitEventArgs : EventArgs
    {
        public string Character { get; private set; }

        public string Type { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public bool Publish { get; private set; }

        public PageSubmitEventArgs(string character, string type, string title, string content, bool publish)
        {
            this.Character = character;
            this.Type = type;
            this.Title = title;
            this.Content = content;
            this.Publish = publish;
        }
    }
}
