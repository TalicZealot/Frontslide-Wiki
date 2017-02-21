using Bytes2you.Validation;
using System;

namespace SotnWiki.Data.Common
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ISotnWikiDbContext context;

        public EfUnitOfWork(ISotnWikiDbContext context)
        {
            Guard.WhenArgument(context, nameof(ISotnWikiDbContext)).IsNull().Throw();
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
