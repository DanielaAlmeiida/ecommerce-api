using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Data.Dtos
{
    public class CreateProdutoDto
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [MaxLength(80, ErrorMessage = "Erro tamanho")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço do produto é obrigatório")]
        public float Preco { get; set; }

        [Range(0, 999999999999, ErrorMessage = "Quantidade do produto é obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Categoria do produto é obrigatório")]
        [MaxLength(30, ErrorMessage = "Erro tamanho")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Cor do produto é obrigatório")]
        [MaxLength(30, ErrorMessage = "Erro tamanho")]
        public string? Cor { get; set; }

        [MaxLength(2000, ErrorMessage = "Erro tamanho")]
        public string? Descricao { get; set; }
    }
}
