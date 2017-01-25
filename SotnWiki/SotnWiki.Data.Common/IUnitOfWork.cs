using System;

namespace SotnWiki.Data.Common
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
