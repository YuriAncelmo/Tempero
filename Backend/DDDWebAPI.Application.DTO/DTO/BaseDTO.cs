
using System.ComponentModel.DataAnnotations;

namespace DDDWebAPI.Application.DTO.DTO
{
    public class BaseDTO
    {
        [Key]
        public int id { get; set; }
    }
}
