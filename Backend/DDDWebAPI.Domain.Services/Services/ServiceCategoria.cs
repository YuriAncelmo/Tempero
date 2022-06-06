
using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Services.Services
{
    public class ServiceCategoria : ServiceBase<Categoria>, IServiceCategoria
    {
        public readonly IRepositoryCategoria _repositoryCategoria;

        public ServiceCategoria(IRepositoryCategoria RepositoryCategoria)
            : base(RepositoryCategoria)
        {
            _repositoryCategoria = RepositoryCategoria;
        }

        public IEnumerable<Categoria> GetAllByNome(string nome)
        {
           return _repositoryCategoria.GetAllByNome(nome);
        }

        
    }
}
