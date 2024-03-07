using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController  : ControllerBase
{

    private ProdutoContext _context;

    public ProdutoController(ProdutoContext context)
    {
        _context = context;
    }


    [HttpPost]
    public IActionResult AdicionaProduto(
        [FromBody] Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaProdutoPorId),
            new {id = produto.Id},
            produto);
    }

    [HttpGet]
    public IEnumerable<Produto> RecuperaProdutos(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return _context.Produtos.ToList().Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Produto? RecuperaProdutoPorId(int id)
    {
        return _context.Produtos.Find(id);
    }

    /*
 
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
    }
    */

}
