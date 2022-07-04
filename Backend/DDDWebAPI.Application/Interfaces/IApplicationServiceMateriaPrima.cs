using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces
{
    public interface IApplicationServiceMateriaPrima
    {
        void Add(MateriaPrimaDTO obj);


        IEnumerable<MateriaPrimaDTO> GetAll();
        MateriaPrimaDTO GetById(int id);
        IEnumerable<MateriaPrimaDTO> GetAllByNome(string nome);

        void Update(MateriaPrimaDTO obj);

        void Remove(MateriaPrimaDTO obj);

        void Dispose();
    }
}
