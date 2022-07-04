using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;

namespace DDDWebAPI.Infrastruture.Repository.Repositorys
{
    public class RepositoryMateriaPrimaProduto : RepositoryBase<MateriaPrima_Produto>, IRepositoryMateriaPrimaProduto
    {
        private readonly MySqlContext _context;
        public RepositoryMateriaPrimaProduto(MySqlContext Context)//injeção da dependência
            : base(Context)
        {
            _context = Context;
            
        }
   
        public override void Update(MateriaPrima_Produto materiaPrimaproduto)
        {
            MateriaPrima_Produto entity = GetById(materiaPrimaproduto.id);
            entity.id = materiaPrimaproduto.id;
            entity.ProdutoID = materiaPrimaproduto.ProdutoID;
            entity.MateriaID = materiaPrimaproduto.MateriaID;
            entity.quantidade = materiaPrimaproduto.quantidade;
            base.Update(entity);
        }
    }
}
