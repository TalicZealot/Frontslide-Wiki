using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.Mvp.CustomEventArgs
{
    public class EditPageEventArgs : EventArgs
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public bool Publish { get; private set; }

        public EditPageEventArgs(string title, string content, bool publish)
        {
            this.Title = title;
            this.Content = content;
            this.Publish = publish;
        }
    }
}
