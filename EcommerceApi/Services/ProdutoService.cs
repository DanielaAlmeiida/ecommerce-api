using EcommerceApi.Context;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly ProdutoContext _context;

        public ProdutoService(ProdutoContext context)
        {
            _context = context;
        }


        public IEnumerable<ProdutoDTO> converteProdutoParaDTO(IEnumerable<Produto> produtos)
        {
            var produtosDto = produtos.Select(p => new ProdutoDTO(
                p.Nome,
                p.Preco,
                p.Quantidade,
                p.Categoria,
                p.Cor ?? string.Empty,
                p.Descricao ?? string.Empty
           ));

            return produtosDto;
        }

        public async Task<IEnumerable<ProdutoDTO>> RecuperaProdutos(int skip, int take)
        {
            var produtos = await _context.Produtos.Skip(skip).Take(take).ToListAsync();
            var produtosDto = converteProdutoParaDTO(produtos);
            return produtosDto;
        }
    
        public async Task<Produto?> RecuperaProdutoPorId(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            return produto;
        }

        public async Task<IEnumerable<ProdutoDTO>> RecuperaProdutoPorNome(string nome)
        {
            IEnumerable<ProdutoDTO> produtosDto;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                var produtos = await _context.Produtos.Where(p => p.Nome.Contains(nome)).ToListAsync();
                produtosDto = converteProdutoParaDTO(produtos);
            }
            else
            {
                produtosDto = await RecuperaProdutos(0, 10);
            }

            return produtosDto;
        }

        public async Task AdicionaProduto(Produto produto)
        {
          _context.Produtos.Add(produto);
          await _context.SaveChangesAsync();
        }

        public async Task AtualizaProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletaProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }
}
