using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;


namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperMateriaPrima_Produto : IMapperMateriaPrimaProduto
    {

        #region properties

        List<MateriaPrima_ProdutoDTO> materia_primasDTOs;
        List<MateriaPrima_Produto> materia_primas;
        MapperProduto mapperProduto;

        #endregion

        #region Constructor 
        public MapperMateriaPrima_Produto()
        {
            materia_primasDTOs = new List<MateriaPrima_ProdutoDTO>();
            materia_primas = new List<MateriaPrima_Produto>();
            mapperProduto = new MapperProduto();
        }
        #endregion

        #region methods

        public MateriaPrima_Produto MapperToEntity(MateriaPrima_ProdutoDTO materia_primaDTO)
        {
            MateriaPrima_Produto materia_prima = new MateriaPrima_Produto
            {
                id = materia_primaDTO.id,
                ProdutoID = materia_primaDTO.ProdutoID,
                MateriaID = materia_primaDTO.MateriaID,
                quantidade = materia_primaDTO.quantidade
            };
            return materia_prima;

        }


        public IEnumerable<MateriaPrima_ProdutoDTO> MapperListMateriaPrima_ProdutoDTO(IEnumerable<MateriaPrima_Produto> materia_primas)
        {
            foreach (var materia_prima in materia_primas)
            {
                MateriaPrima_ProdutoDTO materia_prima_dto = MapperToDTO(materia_prima);

                materia_primasDTOs.Add(materia_prima_dto);
            }

            return materia_primasDTOs;
        }
        public IEnumerable<MateriaPrima_Produto> MapperListMateriaPrima_ProdutoEntity(IEnumerable<MateriaPrima_ProdutoDTO> materia_primas_dto)
        {
            foreach (var materia_prima_dto in materia_primas_dto)
            {
                MateriaPrima_Produto materia_prima = MapperToEntity(materia_prima_dto);

                materia_primas.Add(materia_prima);
            }

            return materia_primas;
        }

        public MateriaPrima_ProdutoDTO MapperToDTO(MateriaPrima_Produto materia_prima)
        {
            if (materia_prima == null)
                return null;
            MateriaPrima_ProdutoDTO materia_prima_dto = new MateriaPrima_ProdutoDTO
            {
                id = materia_prima.id,
                ProdutoID = materia_prima.ProdutoID,
                MateriaID = materia_prima.MateriaID,
                quantidade = materia_prima.quantidade
            };
            return materia_prima_dto;

        }
        #endregion
    }
}
