using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;


namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperMateriaPrima : IMapperMateriaPrima
    {

        #region properties

        List<MateriaPrimaDTO> materia_primasDTOs;
        List<MateriaPrima> materia_primas;
        MapperProduto mapperProduto;

        #endregion

        #region Constructor 
        public MapperMateriaPrima()
        {
            materia_primasDTOs = new List<MateriaPrimaDTO>();
            materia_primas = new List<MateriaPrima>();
            mapperProduto = new MapperProduto();
        }
        #endregion

        #region methods

        public MateriaPrima MapperToEntity(MateriaPrimaDTO materia_primaDTO)
        {
            MateriaPrima materia_prima = new MateriaPrima
            {
                id = materia_primaDTO.id,
                nome = materia_primaDTO.nome,
                valor = materia_primaDTO.valor,
                Produtos = mapperProduto.MapperListProdutosEntity(materia_primaDTO.produtos),
                medida = materia_primaDTO.medida,
                quantidade = materia_primaDTO.quantidade
            };
            return materia_prima;

        }


        public IEnumerable<MateriaPrimaDTO> MapperListMateriaPrimaDTO(IEnumerable<MateriaPrima> materia_primas)
        {
            foreach (var materia_prima in materia_primas)
            {
                MateriaPrimaDTO materia_prima_dto = MapperToDTO(materia_prima);

                materia_primasDTOs.Add(materia_prima_dto);
            }

            return materia_primasDTOs;
        }
        public IEnumerable<MateriaPrima> MapperListMateriaPrimaEntity(IEnumerable<MateriaPrimaDTO> materia_primas_dto)
        {
            foreach (var materia_prima_dto in materia_primas_dto)
            {
                MateriaPrima materia_prima = MapperToEntity(materia_prima_dto);

                materia_primas.Add(materia_prima);
            }

            return materia_primas;
        }

        public MateriaPrimaDTO MapperToDTO(MateriaPrima materia_prima)
        {
            if (materia_prima == null)
                return null;
            MateriaPrimaDTO materia_prima_dto = new MateriaPrimaDTO
            {
                id = materia_prima.id,
                nome = materia_prima.nome,
                valor = materia_prima.valor,
                produtos = mapperProduto.MapperListProdutosDTO(materia_prima.Produtos),
                medida = materia_prima.medida,
                quantidade = materia_prima.quantidade
            };
            return materia_prima_dto;

        }
        #endregion
    }
}
