using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfitFlowBackend.Data;
using ProfitFlowBackend.Data.Dtos.Categoria;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : Controller
{
    private ProfitFlowDbContext _context;
    private IMapper _mapper;

    public CategoriaController(ProfitFlowDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPut("{id}")]
    [Authorize]
    public IActionResult AtualizaCategoria(int id, [FromBody] UpdateCategoriaDto updateCategoriaDto)
    {
        var userId = User.FindFirst("id")?.Value;
        Categoria categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        updateCategoriaDto.UserId = userId;
        if (categoria == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map(updateCategoriaDto, categoria);
            _context.SaveChanges();
            return NoContent();
        }
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetCategoriaPorId(int id)
    {
        Categoria categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if (categoria == null)
        {
            return NotFound();
        }
        else
        {
            ReadCategoriaComProdutosDto categoriaDto = _mapper.Map<ReadCategoriaComProdutosDto>(categoria);
            return Ok(categoriaDto);
        }
    }

    [HttpPost]
    [Authorize]
    public IActionResult AdiconaCategoria([FromBody] CreateCategoriaDto createCategoriaDto)
    {
        var userId = User.FindFirst("id")?.Value;
        createCategoriaDto.UserId = userId;
        Categoria categoria = _mapper.Map<Categoria>(createCategoriaDto);
        _context.Add(categoria);
        _context.SaveChanges();
        return Ok();
    }
    [HttpGet]
    [Authorize]
    public ICollection<ReadCategoriaDto> GetCategorias()
    {
        var userId = User.FindFirst("id")?.Value;
        var categorias = _context.Categorias.Where(c => c.UserId == userId).ToList();
        return _mapper.Map<List<ReadCategoriaDto>>(categorias);
    }
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteCategoria(int id)
    {
        Categoria categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
        if (categoria == null)
        {
            return NotFound();
        }
        _context.Remove(categoria);
        _context.SaveChanges();
        return NoContent();
    }
}