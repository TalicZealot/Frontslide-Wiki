using Bytes2you.Validation;
using SotnWiki.TextManipulation.Contracts;
using System;
using System.Text.RegularExpressions;

namespace SotnWiki.TextManipulation
{
    public class TextileConverterWithDivs : IMarkupConverter
    {
        private readonly IMarkupConverter baseConverter;

        public TextileConverterWithDivs(IMarkupConverter baseConverter)
        {
            Guard.WhenArgument(baseConverter, nameof(IMarkupConverter)).IsNull().Throw();

            this.baseConverter = baseConverter;
        }

        public string ScriptToHtml(string script)
        {
            string openDivPattern = @"^(div)(\(){0,1}(\w+){0,1}(\)){0,1}(\.)(\n|\r|\r\n)$";
            string closeDivPattern = @"^(enddiv)(\.)(\n|\r|\r\n)$";
            string openDivTag = "<div{0}>";
            string openDivClassAttribute = @" class=""{0}""";
            string closeDivTag = "</div>";
            string formatted = script;

            formatted = Regex.Replace(formatted, closeDivPattern, closeDivTag, RegexOptions.Multiline);
            formatted = Regex.Replace(formatted, openDivPattern,
                m => m.Groups[2].Length > 0 && m.Groups[3].Length > 0 && m.Groups[4].Length > 0 && m.Groups[5].Length > 0 ? 
                string.Format(openDivTag, string.Format(openDivClassAttribute, m.Groups[3].Value)) : string.Format(openDivTag, string.Empty)
                , RegexOptions.Multiline);
            return baseConverter.ScriptToHtml(formatted);
        }
    }
}
