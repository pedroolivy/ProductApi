using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Application.Dtos
{
    public  class ProductDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O tipo está incorreto")]
        [Range(0, 1)]
        [DisplayName("Type")]
        public int Type { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
