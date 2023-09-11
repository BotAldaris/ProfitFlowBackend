using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.Categoria
{
    public class CreateCategoriaDto
    {
        [Required] public string Nome { get; set; }
        [Required] public string UserId { get; set; }
    }
}
