using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotnWiki.Data.Common.Repositories
{
    public class CharacterRepository : EfGenericRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }
    }
}
