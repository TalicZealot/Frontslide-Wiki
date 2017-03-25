using SotnWiki.Data.Common.Contracts;
using SotnWiki.Models;
using System.Diagnostics.CodeAnalysis;

namespace SotnWiki.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public class CharacterEfRepository : EfRepository<Character>, ICharacterRepository
    {
        public CharacterEfRepository(ISotnWikiDbContext context)
            : base(context)
        {
        }
    }
}
