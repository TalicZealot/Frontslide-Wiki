using SotnWiki.TextManipulation.Contracts;
using System;
using Textile;

namespace SotnWiki.TextManipulation
{
    public class TextileConverter : IMarkupConverter
    {
        public string ScriptToHtml(string script)
        {
            if (script == null)
            {
                throw new ArgumentNullException("script");
            }
            return TextileFormatter.FormatString(script);
        }
    }
}
