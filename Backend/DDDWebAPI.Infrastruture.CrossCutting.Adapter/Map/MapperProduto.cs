using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;


namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperProduto : IMapperProduto
    {

        #region properties

        List<ProdutoDTO> produtosDTOs;
        List<Produto> produtos;
        MapperMateriaPrima mapperMateriaPrima;



        #endregion
        public MapperProduto()
        {
            produtos = new List<Produto>();
            produtosDTOs = new List<ProdutoDTO>();
            mapperMateriaPrima = new MapperMateriaPrima();
        }

        #region methods

        public Produto MapperToEntity(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto
            {
                id = produtoDTO.id,
                nome = produtoDTO.nome,
                categoriaid = produtoDTO.categoriaid,
                materiasprima = mapperMateriaPrima.MapperListMateriaPrimaEntity(produtoDTO.MateriaPrimas)
            };
            return produto;
        }


        public IEnumerable<ProdutoDTO> MapperListProdutosDTO(IEnumerable<Produto> produtos)
        {
            foreach (Produto produto in produtos)
            {
                ProdutoDTO produtoDTO = MapperToDTO(produto);
                produtosDTOs.Add(produtoDTO);
            }

            return produtosDTOs;
        }
        public IEnumerable<Produto> MapperListProdutosEntity(IEnumerable<ProdutoDTO> produtos_dto)
        {
            foreach (ProdutoDTO produto_dto in produtos_dto)
            {
                Produto produto = MapperToEntity(produto_dto);
                produtos.Add(produto);
            }

            return produtos;
        }
        public ProdutoDTO MapperToDTO(Produto produto)
        {
            if (produto == null)
                return null;

            ProdutoDTO produtoDTO = new ProdutoDTO
            {
                id = produto.id,
                nome = produto.nome,
                categoriaid = produto.categoriaid,
                MateriaPrimas = mapperMateriaPrima.MapperListMateriaPrimaDTO(produto.materiasprima)
            };

            return produtoDTO;

        }
        #endregion
    }
}
