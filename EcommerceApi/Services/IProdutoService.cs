using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> RecuperaProdutos([FromQuery] int skip = 0, [FromQuery] int take = 10);
        Task<Produto?> RecuperaProdutoPorId(int id);
        Task<IEnumerable<ProdutoDTO>> RecuperaProdutoPorNome(string nome);
        Task AdicionaProduto(Produto? produto);
        Task AtualizaProduto(Produto produto);
        Task DeletaProduto(Produto produto);
    }
}
