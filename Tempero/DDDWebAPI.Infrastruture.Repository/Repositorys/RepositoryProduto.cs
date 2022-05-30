using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;

namespace DDDWebAPI.Infrastruture.Repository.Repositorys
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly MySqlContext _context;
        public RepositoryProduto(MySqlContext Context)//injeção da dependência
            : base(Context)
        {
            _context = Context;
            
        }
        public IEnumerable<Produto> GetAllByNome(string nome_produto)
        {
            return _context.Produtos.Where(produto => produto.nome == nome_produto).ToList();
        }
        

        public override void Update(Produto produto)
        {
            Produto entity = GetById(produto.id);
            entity.id = produto.id;
            entity.nome = produto.nome;
            entity.gramas = produto.gramas;
            entity.categoria = produto.categoria;
            entity.valor = produto.valor;
            base.Update(entity);
        }
    }
}
