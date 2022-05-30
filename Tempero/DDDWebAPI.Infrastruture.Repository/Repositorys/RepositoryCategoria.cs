using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;
using System.Reflection;

namespace DDDWebAPI.Infrastruture.Repository.Repositorys
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        private readonly MySqlContext _context;
        public RepositoryCategoria(MySqlContext Context)//injeção da dependência
            : base(Context)
        {
            _context = Context;
            
        }
        public IEnumerable<Categoria> GetAllByNome(string nome)
        {
            return _context.Categorias.Where(categoria => categoria.nome == nome).ToList();
        }
        
        public override void Update(Categoria categoria)
        {
            Categoria model = GetById(categoria.id);
            model.nome = categoria.nome;
            base.Update(model);
           
        }
    }
}
