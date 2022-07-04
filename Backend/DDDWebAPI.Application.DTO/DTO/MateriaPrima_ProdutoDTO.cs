using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class MateriaPrima_ProdutoDTO : BaseDTO
    {
        #region Propriedades 
        
        public DateTime dataAlteracao { get; set; }
        [Required(ErrorMessage = "É necessário uma quantidade especificada para associação de materia prima a um produto.")]
        public double quantidade { get; set; }

        public int ProdutoID { get; set; }
        public ProdutoDTO Produto { get; set; }

        public int MateriaID { get; set; }
        public MateriaPrimaDTO MateriaPrima { get; set; }
        #endregion

    }
}
