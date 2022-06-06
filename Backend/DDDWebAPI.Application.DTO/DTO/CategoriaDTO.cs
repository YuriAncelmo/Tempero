
using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class CategoriaDTO : BaseDTO
    {
        #region Propriedades 
        public string nome { get; set; }
        public List<ProdutoDTO> produtos;
        #endregion

    }
}
