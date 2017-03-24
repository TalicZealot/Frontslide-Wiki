using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;

namespace SotnWiki.Data.Repositories
{
    public class CharacterEfRepository : EfRepository<Character>, ICharacterRepository
    {
        public CharacterEfRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }
    }
}
