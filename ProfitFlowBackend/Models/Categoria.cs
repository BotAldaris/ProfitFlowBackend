using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Models;

public class Categoria
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required] public string Nome { get; set; }
    [Required] public string UserId { get; set; }
    public virtual Usuario User { get; set; }
    public virtual ICollection<Produto> Produto { get; set; }
}
