using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.Data.Common
{
    public class PageRepository<T> : EfGenericRepository<T> where T : class
    {

        public PageRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }


    }
}
