using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Models;

public class Venda
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public int Quantidade { get; set; }
    [Required]
    public double Valor { get; set; }
    [Required]
    public string UserId { get; set; }
    public virtual Usuario User { get; set; }
}
