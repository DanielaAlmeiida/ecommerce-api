using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController  : ControllerBase
{

    private IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }


    [HttpGet]
    public async Task<ActionResult<IAsyncEnumerable<ProdutoDTO>>> RecuperaProdutos()
    {
        try
        {
            var produtos = await _produtoService.RecuperaProdutos(0, 10);
            return Ok(produtos);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter produtos");
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Produto?>> RecuperaProdutoPorId(int id)
    {
        return await _produtoService.RecuperaProdutoPorId(id);
    }

    /*
    [HttpGet("{nome}")]
    public async Task<IAsyncEnumerable<ProdutoDTO>> RecuperaProdutoPorNome(string nome)
    {
        return (IAsyncEnumerable<ProdutoDTO>)await _produtoService.RecuperaProdutoPorNome(nome);
    }
    */

    /*
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
    }
    */

    /*
    [HttpPost]
    public IActionResult AdicionaProduto([FromBody] Produto produto)
    {

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaProdutoPorId), new {id = produto.Id}, produto);

    }
    */

}
