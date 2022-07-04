
using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Services.Services
{
    public class ServiceMateriaPrima : ServiceBase<MateriaPrima>, IServiceMateriaPrima
    {
        public readonly IRepositoryMateriaPrima _repositoryMateriaPrima;

        public ServiceMateriaPrima(IRepositoryMateriaPrima RepositoryMateriaPrima)
            : base(RepositoryMateriaPrima)
        {
            _repositoryMateriaPrima = RepositoryMateriaPrima;
        }

        public IEnumerable<MateriaPrima> GetAllByNome(string nome)
        {
           return _repositoryMateriaPrima.GetAllByNome(nome);
        }
    }
}
