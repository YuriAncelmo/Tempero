
namespace DDDWebAPI.Domain.Models
{
    public class Categoria : Base
    {
        public string nome { get; set; }
        public List<Produto> produtos;
    }
}
