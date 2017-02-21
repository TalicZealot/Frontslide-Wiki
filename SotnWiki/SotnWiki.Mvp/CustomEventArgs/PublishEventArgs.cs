using System;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class PublishEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string EditedContent { get; set; }

        public PublishEventArgs(string title, string editedContent)
        {
            this.Title = title;
            this.EditedContent = editedContent;
        }
    }
}
