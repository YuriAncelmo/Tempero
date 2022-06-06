using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO obj);


        IEnumerable<ProdutoDTO> GetAll();
        ProdutoDTO GetById(int id);
        IEnumerable<ProdutoDTO> GetAllByNome(string nome);

        void Update(ProdutoDTO obj);

        void Remove(ProdutoDTO obj);

        void Dispose();
    }
}
