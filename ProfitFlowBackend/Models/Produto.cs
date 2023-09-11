using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Models;

public class Produto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public double Preco { get; set; }
    [Required]
    public double Custo { get; set; }
    [Required]
    public string Imagem { get; set; }
    [Required]
    public string FormatoImagem { get; set; }
    [Required]
    public int Quantidade { get; set; }
    [Required]
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
    [Required]
    public string UserId { get; set; }
    public virtual Usuario User { get; set; }
    public virtual ICollection<Venda> Venda { get; set; }
}
