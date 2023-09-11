using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfitFlowBackend.Data;
using ProfitFlowBackend.Data.Dtos.Vendas;
using ProfitFlowBackend.Models;
using System.Globalization;

namespace ProfitFlowBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : Controller
{
    private ProfitFlowDbContext _context;
    private IMapper _mapper;
    public VendaController(ProfitFlowDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ObterVendasPorDiaSomadas()
    {
        var vendasPorDia = await _context.Venda
            .GroupBy(v => v.Data.Date)
            .Select(g => new
            {
                Data = g.Key,
                ValorTotal = g.Sum(v => v.Valor)
            })
            .ToListAsync();

        return Ok(vendasPorDia);
    }
    [HttpGet("Produto/{id}")]
    [Authorize]
    public ICollection<ReadVendaDto> ObterVendasPorDia(int id)
    {
        string formato = "yyyy/MM/dd";
        var userId = User.FindFirst("id")?.Value;
        var vendas = _context.Venda.Where(c => c.UserId == userId).Where(v => v.ProdutoId == id).ToList();
        return _mapper.Map<List<ReadVendaDto>>(vendas);
    }
    [HttpGet("Dia/{data}")]
    [Authorize]
    public ICollection<ReadVendaDto> ObterVendasPorDia(string datasad)
    {
        string formato = "yyyy/MM/dd";
        var userId = User.FindFirst("id")?.Value;
        DateTime.TryParseExact(datasad, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data);
        var vendas = _context.Venda.Where(c => c.UserId == userId).Where(v => v.Data == data).ToList();
        return _mapper.Map<List<ReadVendaDto>>(vendas);
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult ObterVendasPorId(int id)
    {
        var userId = User.FindFirst("id")?.Value;
        Venda venda = _context.Venda.Where(v => v.UserId == userId).First(c => c.Id == id);
        if (venda == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ReadVendaDto>(venda));
        }
    }
    [HttpPost]
    [Authorize]
    public IActionResult PostVendas([FromBody] CreateVendaDto dto)
    {
        var userId = User.FindFirst("id")?.Value;
        dto.UserId = userId;
        Venda venda = _mapper.Map<Venda>(dto);
        _context.Venda.Add(venda);
        _context.SaveChanges();
        return Ok();
    }
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult PutVendas(int id, [FromBody] UpdateVendaDto dto)
    {
        var userId = User.FindFirst("id")?.Value;
        Venda venda = _context.Venda.Where(v => v.UserId == userId).First(v => v.Id.Equals(id));
        dto.UserId = userId;
        if (venda == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map(dto, venda);
            _context.SaveChanges();
            return Ok();
        }
    }
    [HttpPatch("{id}")]
    [Authorize]
    public IActionResult PatchVenda(int id, JsonPatchDocument<UpdateVendaDto> patch)
    {
        var userId = User.FindFirst("id")?.Value;
        Venda venda = _context.Venda.Where(p => p.UserId.Equals(userId)).FirstOrDefault(venda => venda.Id.Equals(id));
        if (venda == null)
        {
            return NotFound();
        }
        var vendaParaAtualizar = _mapper.Map<UpdateVendaDto>(venda);
        patch.ApplyTo(vendaParaAtualizar, ModelState);
        if (!TryValidateModel(vendaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(vendaParaAtualizar, venda);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult RemoveVenda(int id)
    {
        var userId = User.FindFirst("id")?.Value;
        Venda venda = _context.Venda.Where(v => v.User.Id.Equals(userId)).FirstOrDefault(venda => venda.Id.Equals(id));
        if (venda == null)
        {
            return NotFound();
        }
        else
        {
            _context.Remove(venda);
            return NoContent();
        }
    }
}
