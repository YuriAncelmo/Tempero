using DDDWebAPI.Domain.Models;
namespace DDDWebAPI.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryMateriaPrima : IRepositoryBase<MateriaPrima>
    {
        IEnumerable<MateriaPrima> GetAllByNome(string nome);
    }
}
