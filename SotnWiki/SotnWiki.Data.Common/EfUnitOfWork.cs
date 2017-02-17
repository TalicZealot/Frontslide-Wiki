﻿using System;

namespace SotnWiki.Data.Common
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ISotnWikiDbContext context;

        public EfUnitOfWork(ISotnWikiDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DbContext cannot be null!");
            }
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
