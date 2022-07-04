using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperMateriaPrimaProduto
    {
        #region Mappers

        MateriaPrima_Produto MapperToEntity(MateriaPrima_ProdutoDTO materia_primaDTO);

        IEnumerable<MateriaPrima_ProdutoDTO> MapperListMateriaPrima_ProdutoDTO(IEnumerable<MateriaPrima_Produto> materia_primas);
        IEnumerable<MateriaPrima_Produto> MapperListMateriaPrima_ProdutoEntity(IEnumerable<MateriaPrima_ProdutoDTO> materia_primas);

        MateriaPrima_ProdutoDTO MapperToDTO(MateriaPrima_Produto materia_prima);

        #endregion
    }
}
