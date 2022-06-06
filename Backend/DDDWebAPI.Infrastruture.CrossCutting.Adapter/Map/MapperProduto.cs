using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;


namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperProduto : IMapperProduto
    {

        #region properties

        List<ProdutoDTO> produtosDTOs = new List<ProdutoDTO>();

        #endregion


        #region methods

        public Produto MapperToEntity(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto
            {
                id = produtoDTO.id,
                nome = produtoDTO.nome,
                categoriaid = produtoDTO.categoriaid
            };
            return produto;
        }


        public IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                ProdutoDTO produtoDTO = new ProdutoDTO
                {
                    id = produto.id,
                    nome = produto.nome,
                    categoriaid = produto.categoriaid
                };
                produtosDTOs.Add(produtoDTO);
            }

            return produtosDTOs;
        }

        public ProdutoDTO MapperToDTO(Produto produto)
        {
            if (produto == null)
                return null;
            ProdutoDTO produtoDTO = new ProdutoDTO
            {
                id = produto.id,
                nome = produto.nome,
                categoriaid = produto.categoriaid
            };

            return produtoDTO;

        }
        #endregion
    }
}
