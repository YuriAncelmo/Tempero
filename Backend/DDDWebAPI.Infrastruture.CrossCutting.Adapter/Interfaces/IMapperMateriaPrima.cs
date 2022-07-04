using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperMateriaPrima
    {
        #region Mappers

        MateriaPrima MapperToEntity(MateriaPrimaDTO materia_primaDTO);

        IEnumerable<MateriaPrimaDTO> MapperListMateriaPrimaDTO(IEnumerable<MateriaPrima> materia_primas);
        IEnumerable<MateriaPrima> MapperListMateriaPrimaEntity(IEnumerable<MateriaPrimaDTO> materia_primas);

        MateriaPrimaDTO MapperToDTO(MateriaPrima materia_prima);

        #endregion
    }
}
