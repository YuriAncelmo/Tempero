
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Core.Interfaces.Services
{
    public interface IServiceCategoria:IServiceBase<Categoria>
    {
        IEnumerable<Categoria> GetAllByNome(string nome);
    }
}
