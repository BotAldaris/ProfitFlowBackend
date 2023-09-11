using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.Produto;

public class CreateProdutoDto
{
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
    public int CategoriaId { get; set; }
    [Required]
    public int Quantidade { get; set; }
    [Required]
    public string UserId { get; set; }
}
