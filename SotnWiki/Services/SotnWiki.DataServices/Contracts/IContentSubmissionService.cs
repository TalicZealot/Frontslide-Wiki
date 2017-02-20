using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.DataServices.Contracts
{
    public interface IContentSubmissionService
    {
        void SubmitEdit(string content, string title);
    }
}
