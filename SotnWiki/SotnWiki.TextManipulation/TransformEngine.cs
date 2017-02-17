using DNA.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.TextManipulation
{
    public class TransformEngine
    {
        public TransformEngine()
        {
        }

        public string WikiToString(string wikiCode)
        {
            return TextEngine.Wiki(wikiCode).ToHtmlString();
        }
    }
}
