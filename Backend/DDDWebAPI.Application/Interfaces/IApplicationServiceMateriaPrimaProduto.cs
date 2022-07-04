using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces
{
    public interface IApplicationServiceMateriaPrimaProduto
    {
        void Add(MateriaPrima_ProdutoDTO obj);
        IEnumerable<MateriaPrima_ProdutoDTO> GetAll();
        MateriaPrima_ProdutoDTO GetById(int id);

        void Update(MateriaPrima_ProdutoDTO obj);

        void Remove(MateriaPrima_ProdutoDTO obj);

        void Dispose();
    }
}
