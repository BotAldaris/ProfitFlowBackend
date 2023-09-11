using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.Vendas;

public class UpdateVendaDto
{
    [Required]
    public int ProdutoId { get; set; }

    [Required]
    public string Data { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    public double Valor { get; set; }

    [Required]
    public string UserId { get; set; }
}
