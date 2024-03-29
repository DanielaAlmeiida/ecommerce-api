using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> RecuperaProdutos([FromQuery] int skip = 0, [FromQuery] int take = 10);
        Task<Produto?> RecuperaProdutoPorId(int id);
        Task<IEnumerable<Produto>> RecuperaProdutoPorNome(string nome);
        Task AdicionaProduto(Produto? produto);
        Task AtualizaProduto(Produto produto);
        Task DeletaProduto(Produto produto);
    }
}
