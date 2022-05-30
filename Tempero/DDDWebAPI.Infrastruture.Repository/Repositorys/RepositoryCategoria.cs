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
        
        public override void Add(Categoria categoria)
        {
            //base.Add(obj);
            if(categoria != null)
              _context.Add(categoria);
            _context.SaveChanges();
        }



        public override void Update(Categoria categoria)
        {
            //TODO: base.Update(categoria);Não sei por que não funciona
            try
            {
                var entity = _context.Categorias.SingleOrDefault(o => o.id == categoria.id);
                //entity.registro = categoria.registro; Não deve ter alteração 
                if (entity == null)
                    return;
                entity.id = categoria.id;
                entity.nome = categoria.nome;
                
                _context.Entry(entity).Property(c => c.id).IsModified = false;//Duplo check para não alterar mesmo a chave, apesar de o entity já fazer este trabalho 
                                                                                //this.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;//Necessário pois foi feito uma operação de inserção e depois remoção na sequencia
                _context.Categorias.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }
        public override void Remove(Categoria categoria)
        {
            base.Remove(categoria);
            //_context.Categorias.Attach(categoria);
            //_context.Categorias.Remove(categoria);
            //_context.SaveChanges();
            //_context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Detached;//Necessário pois foi feito uma operação de inserção e depois remoção na sequencia
        }
    }
}
