using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace SotnWiki.MvcClient.Models
{
    public class PageViewModel
    {
        public string PageHtml { get; set; }

        public string Title { get; set; }
    }
}