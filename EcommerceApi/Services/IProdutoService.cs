using EcommerceApi.Models;

namespace EcommerceApi.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> RecuperaProdutos(int skip, int take);
        Task<Produto?> RecuperaProdutoPorId(int id);
        Task<IEnumerable<ProdutoDTO>> RecuperaProdutoPorNome(string nome);
        Task AdicionaProduto(ProdutoDTO produtoDto);
        Task AtualizaProduto(ProdutoDTO produtoDto);
        Task DeletaProduto(ProdutoDTO produtoDto);
    }
}
