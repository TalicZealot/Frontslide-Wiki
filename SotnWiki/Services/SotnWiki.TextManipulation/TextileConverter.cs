using SotnWiki.TextManipulation.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
