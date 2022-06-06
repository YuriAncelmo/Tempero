using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastruture.CrossCutting.Adapter.Interfaces;


namespace DDDWebAPI.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperCategoria : IMapperCategoria
    {

        #region properties

        List<CategoriaDTO> categoriasDTOs = new List<CategoriaDTO>();

        #endregion


        #region methods

        public Categoria MapperToEntity(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = new Categoria
            {

                id = categoriaDTO.id,
                nome = categoriaDTO.nome
            };
            return categoria;
        }


        public IEnumerable<CategoriaDTO> MapperListCategorias(IEnumerable<Categoria> categorias)
        {
            foreach (var item in categorias)
            {
                CategoriaDTO categoriaDTO = new CategoriaDTO
                {
                    id = item.id,
                    nome = item.nome
                };
                categoriasDTOs.Add(categoriaDTO);
            }

            return categoriasDTOs;
        }

        public CategoriaDTO MapperToDTO(Categoria categoria)
        {
            if (categoria == null)
                return null;
            CategoriaDTO categoriaDTO = new CategoriaDTO
            {
                id = categoria.id,
                nome = categoria.nome
            };

            return categoriaDTO;

        }
        #endregion
    }
}
