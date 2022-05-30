
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Core.Interfaces.Services
{
    public interface IServiceProduto : IServiceBase<Produto>
    {
        IEnumerable<Produto> GetAllByNome(string nome_produto);
    }
}
