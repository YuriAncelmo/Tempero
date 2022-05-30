using DDDWebAPI.Domain.Models;
namespace DDDWebAPI.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryCategoria : IRepositoryBase<Categoria>
    {
        IEnumerable<Categoria> GetAllByNome(string nome_categoria);
    }
}
