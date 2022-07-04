
using DDDWebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class MateriaPrimaDTO : BaseDTO
    {
        #region Propriedades 
        [Required(ErrorMessage ="É necessário um nome para a materia prima.")]
        public string? nome { get; set; }
        public double valor { get; set; }
        public IEnumerable<ProdutoDTO>? produtos { get; set; }
        public Medida medida { get; set; }
        public double quantidade { get; set; }
        #endregion

    }
}
