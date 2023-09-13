using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProfitFlowBackend.Data;
using ProfitFlowBackend.Data.Dtos.Produto;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProdutoController : Controller
{
    private ProfitFlowDbContext _context;
    private IMapper _mapper;
    public ProdutoController(ProfitFlowDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    [Authorize]
    public ICollection<ReadProdutoSemVendaDto> ReadProdutos()
    {
        var userId = User.FindFirst("id")?.Value;
        var produtos = _context.Produtos.Where(produto => produto.UserId.Equals(userId)).ToList();
        return _mapper.Map<List<ReadProdutoSemVendaDto>>(produtos);
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult ReadProdutosById(int id)
    {
        Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        else
        {
            ReadProdutoDto produtoDto = _mapper.Map<ReadProdutoDto>(produto);
            return Ok(produtoDto);
        }
    }
    [HttpGet("Quantidade")]
    [Authorize]
    public ICollection<ReadQuantidadeProdutoDto> ReadQuantidadeProdutos()
    {
        var userId = User.FindFirst("id")?.Value;
        var produtos = _context.Produtos.Where(produto => produto.UserId.Equals(userId));
        return _mapper.Map<List<ReadQuantidadeProdutoDto>>(produtos);
    }
    [HttpGet("Quantidade/{id}")]
    [Authorize]
    public IActionResult ReadQuantidadeProdutoById(int id)
    {
        var userId = User.FindFirst("id")?.Value;
        Produto produto = _context.Produtos.Where(p => p.UserId.Equals(userId)).FirstOrDefault(produto => produto.Id.Equals(id));
        if (produto == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ReadQuantidadeProdutoDto>(produto));
        }
    }
    [HttpPost]
    [Authorize]
    public IActionResult CreateProduto([FromBody] CreateProdutoDto produtoDto)
    {
        var userId = User.FindFirst("id")?.Value;
        produtoDto.UserId = userId;
        _context.Add(_mapper.Map<Produto>(produtoDto));
        _context.SaveChanges();
        return Ok();
    }
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        var userId = User.FindFirst("id")?.Value;
        Produto produto = _context.Produtos.Where(p => p.UserId.Equals(userId)).FirstOrDefault(produto => produto.Id.Equals(id));
        produtoDto.UserId = userId;
        if (produto == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map(produtoDto, produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
    [HttpPatch("{id}")]
    [Authorize]
    public IActionResult PatchProduto(int id, [FromBody] JsonPatchDocument<UpdateProdutoDto> patch)
    {
        var userId = User.FindFirst("id")?.Value;
        Produto produto = _context.Produtos.Where(p => p.UserId.Equals(userId)).FirstOrDefault(produto => produto.Id.Equals(id));
        if (produto == null)
        {
            return NotFound();
        }

        UpdateProdutoDto filmeParaAtualizar = _mapper.Map<UpdateProdutoDto>(produto);
        patch.ApplyTo(filmeParaAtualizar, ModelState);
        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, produto);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteProduto(int id)
    {
        var userId = User.FindFirst("id")?.Value;
        Produto produto = _context.Produtos.Where(p => p.UserId.Equals(userId)).FirstOrDefault(produto => produto.Id.Equals(id));
        if (produto == null)
        {
            return NotFound();
        }
        else
        {
            _context.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
