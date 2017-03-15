using Bytes2you.Validation;
using SotnWiki.TextManipulation.Contracts;
using System;
using Textile;

namespace SotnWiki.TextManipulation
{
    public class TextileConverter : IMarkupConverter
    {
        public string ScriptToHtml(string script)
        {
            Guard.WhenArgument(script, "script").IsNullOrEmpty().Throw();

            return TextileFormatter.FormatString(script);
        }
    }
}
