using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;

namespace DDDWebAPI.Infrastruture.Repository.Repositorys
{
    public class RepositoryMateriaPrima : RepositoryBase<MateriaPrima>, IRepositoryMateriaPrima
    {
        private readonly MySqlContext _context;
        public RepositoryMateriaPrima(MySqlContext Context)//injeção da dependência
            : base(Context)
        {
            _context = Context;
            
        }

        public IEnumerable<MateriaPrima> GetAllByNome(string nome)
        {
            return _context.MateriaPrimas.Where(materiaprima => materiaprima.nome == nome).ToList();
        }

        public override void Update(MateriaPrima produto)
        {
            MateriaPrima entity = GetById(produto.id);
            entity.id = produto.id;
            entity.nome = produto.nome;
            entity.quantidade = produto.quantidade;
            entity.valor = produto.valor;
            entity.medida = produto.medida; 
            base.Update(entity);
        }
    }
}
