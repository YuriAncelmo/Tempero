
namespace DDDWebAPI.Domain.Models
{
    public class Produto : Base
    {
        public string nome { get; set; }
        public double valor { get; set; }
        public int gramas { get; set; }
        
        public Categoria categoria { get; set; }
    }
}
