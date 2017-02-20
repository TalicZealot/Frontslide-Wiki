using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.TextManipulation.Contracts
{
    public interface IMarkupConverter
    {
        string ScriptToHtml(string script);
    }
}
