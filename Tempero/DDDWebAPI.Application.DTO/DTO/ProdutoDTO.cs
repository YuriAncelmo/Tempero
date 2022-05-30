
using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class ProdutoDTO : BaseDTO
    {
        #region Propriedades 
        public string nome { get; set; }
        public double valor { get; set; }
        public int gramas { get; set; }

        public CategoriaDTO categoria { get; set; }
        #endregion

    }
}
