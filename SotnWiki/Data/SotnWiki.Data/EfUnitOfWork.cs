using Bytes2you.Validation;
using SotnWiki.Data.Common.Contracts;

namespace SotnWiki.Data
{
    public class EfUnitOfWork : IEfUnitOfWork
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
