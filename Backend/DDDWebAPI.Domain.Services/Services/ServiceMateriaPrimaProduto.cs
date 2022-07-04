
using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Services.Services
{
    public class ServiceMateriaPrimaProduto : ServiceBase<MateriaPrima_Produto>, IServiceMateriaPrimaProduto
    {
        public readonly IRepositoryMateriaPrimaProduto _repositoryMateriaPrimaProduto;

        public ServiceMateriaPrimaProduto(IRepositoryMateriaPrimaProduto RepositoryMateriaPrimaProduto)
            : base(RepositoryMateriaPrimaProduto)
        {
            _repositoryMateriaPrimaProduto = RepositoryMateriaPrimaProduto;
        }

      
    }
}
