using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models
{
    public record ProdutoDTO(
         string Nome,
         float Preco,
         int Quantidade,
         string Categoria,
         string Cor,
         string Descricao
    );

}
