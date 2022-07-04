
namespace DDDWebAPI.Domain.Models
{
    public class Produto : Base
    {
        public string nome { get; set; }
        public int categoriaid { get; set; }
        public IEnumerable<MateriaPrima> materiasprima { get; set; }
        public List<MateriaPrima_Produto> MateriaPrima_Produtos { get; set; }
    }
}
