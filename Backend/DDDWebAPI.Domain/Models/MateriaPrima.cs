
namespace DDDWebAPI.Domain.Models
{
    public class MateriaPrima : Base
    {
        public string nome { get; set; }
        public double valor { get; set; }

        public Medida medida { get; set; }
        public double quantidade { get; set; }
        public IEnumerable<Produto> Produtos{ get; set; }
        public List<MateriaPrima_Produto> MateriaPrima_Produtos { get; set; }
    }
    public enum Medida
    {
        KG = 1,
        UNIDADE = 2,
        GRAMA = 3
    }
}
