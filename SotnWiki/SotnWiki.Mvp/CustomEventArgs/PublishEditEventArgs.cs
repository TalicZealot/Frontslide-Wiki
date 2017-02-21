using System;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class PublishEditEventArgs : EventArgs
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public Guid Id { get; private set; }

        public PublishEditEventArgs(string title, string content, Guid id)
        {
            this.Title = title;
            this.Content = content;
            this.Id = id;
        }
    }
}
