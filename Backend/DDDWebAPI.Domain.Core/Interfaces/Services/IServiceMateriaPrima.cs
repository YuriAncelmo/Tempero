
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Core.Interfaces.Services
{
    public interface IServiceMateriaPrima : IServiceBase<MateriaPrima>
    {
        IEnumerable<MateriaPrima> GetAllByNome(string nome);
    }
}
