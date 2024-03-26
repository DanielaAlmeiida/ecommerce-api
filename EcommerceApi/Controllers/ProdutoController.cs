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
            var produtos = await _produtoService.RecuperaProdutos(0, 100);
            return Ok(produtos);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter produtos");
        }
    }
    
    [HttpGet("{id:int}", Name="RecuperaProdutoPorId")]
    public async Task<ActionResult<Produto?>> RecuperaProdutoPorId(int id)
    {
        try
        {
            var produtos = await _produtoService.RecuperaProdutoPorId(id);
            return Ok(produtos);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter produto");
        }
    }

    [HttpGet("busca")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> RecuperaProdutoPorNome([FromQuery] string nome  = "")
    {
        try
        {
            var produtos = await _produtoService.RecuperaProdutoPorNome(nome);

            if (produtos == null) 
                return NotFound($"Não existem produtos com o critério {nome}");

            return Ok(produtos);
        } 
        catch
        { 
            return BadRequest("Request inválido");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AdicionaProduto(Produto produto)
    {
        try
        {
            await _produtoService.AdicionaProduto(produto);
            return CreatedAtRoute(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
        }
        catch
        {
            return BadRequest("Request inválido");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> AtualizaProduto(int id, [FromBody] Produto produto)
    {
        try
        {
            if(produto.Id == id)
            {
                await _produtoService.AtualizaProduto(produto);
                return NoContent();
            } 
            else
            {
                return BadRequest("Dados inconsistentes");
            }
        }
        catch
        {
            return BadRequest("Request inválido");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletaProduto(int id)
    {
        try
        {
            var produto = await _produtoService.RecuperaProdutoPorId(id);
            if (produto != null)
            {
                await _produtoService.DeletaProduto(produto);
                return Ok("Produto de excluído com sucesso");
            }
            else
            {
                return NotFound("Produto não encontrado");
            }
        }
        catch
        {
            return BadRequest("Request inválido");
        }
    }

}
