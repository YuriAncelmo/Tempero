using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperCategoria
    {
        #region Mappers

        Categoria MapperToEntity(CategoriaDTO clienteDTO);

        IEnumerable<CategoriaDTO> MapperListCategorias(IEnumerable<Categoria> clientes);

        CategoriaDTO MapperToDTO(Categoria Cliente);

        #endregion
    }
}
