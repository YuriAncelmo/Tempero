
namespace DDDWebAPI.Domain.Models
{
    public class MateriaPrima_Produto : Base
    {
        public DateTime dataAlteracao { get; set; }
        public double quantidade { get; set; }
       
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int MateriaID { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
    }
}
