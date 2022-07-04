
using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class ProdutoDTO : BaseDTO
    {
        #region Propriedades 
        [Required(ErrorMessage ="É necessário um nome para o produto.")]
        public string? nome { get; set; }
        public int categoriaid { get; set; }
        public IEnumerable<MateriaPrimaDTO> MateriaPrimas { get; set; }
        public int quantidade { get; set; }
        public double peso { get; set; }
        public List<MateriaPrima_ProdutoDTO> MateriaPrima_Produtos { get; set; }
        #endregion

    }
}
