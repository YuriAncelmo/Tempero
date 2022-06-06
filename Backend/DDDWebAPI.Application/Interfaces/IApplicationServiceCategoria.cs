using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces
{
    public interface IApplicationServiceCategoria
    {
        void Add(CategoriaDTO obj);
        IEnumerable<CategoriaDTO> GetAll();
        CategoriaDTO GetById(int id);
        IEnumerable<CategoriaDTO> GetAllByNome(string nome);

        void Update(CategoriaDTO obj);

        void Remove(CategoriaDTO obj);

        void Dispose();
    }
}
