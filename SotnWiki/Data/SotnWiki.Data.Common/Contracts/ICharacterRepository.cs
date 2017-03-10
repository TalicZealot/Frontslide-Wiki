using SotnWiki.Models;

namespace SotnWiki.Data.Common.Contracts
{
    public interface ICharacterRepository
    {
        Character GetById(object id);
    }
}
