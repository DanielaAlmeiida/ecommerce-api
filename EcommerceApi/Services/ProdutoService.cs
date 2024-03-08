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



        public async Task AdicionaProduto(ProdutoDTO produtoDto)
        {
            /*
            _context.Produtos.Add(produtoDto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produtoDto);
            */
        }

        public async Task AtualizaProduto(ProdutoDTO produtoDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeletaProduto(ProdutoDTO produtoDto)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<ProdutoDTO>> RecuperaProdutos(int skip, int take)
        {
            return (IEnumerable<ProdutoDTO>)await _context.Produtos.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Produto?> RecuperaProdutoPorId(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            return produto;
        }

        public async Task<IEnumerable<ProdutoDTO>> RecuperaProdutoPorNome(string nome)
        {
            IEnumerable<ProdutoDTO> produtosDto;
            if(!string.IsNullOrWhiteSpace(nome))
            {
                produtosDto = (IEnumerable<ProdutoDTO>)await _context.Produtos.Where(p => p.Nome.Contains(nome)).ToListAsync();
            } else
            {
                produtosDto = await RecuperaProdutos(0, 10);
            }

            return produtosDto;
        }

    }
}
