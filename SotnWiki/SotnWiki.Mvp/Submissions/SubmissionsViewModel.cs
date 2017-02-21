using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.Mvp.Submissions
{
    public class SubmissionsViewModel
    {
        public IQueryable<SotnWiki.Models.Page> Results { get; set; }
    }
}
