using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduto
    {
        #region Mappers

        Produto MapperToEntity(ProdutoDTO clienteDTO);

        IEnumerable<Produto> MapperListProdutosEntity(IEnumerable<ProdutoDTO> clientes);
        IEnumerable<ProdutoDTO> MapperListProdutosDTO(IEnumerable<Produto> clientes);

        ProdutoDTO MapperToDTO(Produto Cliente);

        #endregion
    }
}
