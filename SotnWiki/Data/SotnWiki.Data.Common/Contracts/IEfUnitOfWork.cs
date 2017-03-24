using System;

namespace SotnWiki.Data.Common.Contracts
{
    public interface IEfUnitOfWork: IDisposable
    {
        void Commit();
    }
}