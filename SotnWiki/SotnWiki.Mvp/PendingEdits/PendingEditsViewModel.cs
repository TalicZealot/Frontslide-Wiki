using SotnWiki.Models;
using System.Linq;

namespace SotnWiki.Mvp.PendingEdits
{
    public class PendingEditsViewModel
    {
        public IQueryable<PageContentSubmission> Results { get; set; }
    }
}
