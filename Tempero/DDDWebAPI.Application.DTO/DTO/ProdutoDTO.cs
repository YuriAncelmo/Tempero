
using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class ProdutoDTO : BaseDTO
    {
        #region Propriedades 
        [Required(ErrorMessage ="É necessário um nome para o produto.")]
        public string? nome { get; set; }
        public int categoriaid { get; set; }
        #endregion

    }
}
