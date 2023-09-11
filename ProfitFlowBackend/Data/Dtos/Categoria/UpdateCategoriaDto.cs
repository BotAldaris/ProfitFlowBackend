using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.Categoria;

public class UpdateCategoriaDto
{
    [Required(ErrorMessage = "O campo do nome é obrigatório.")]
    public string Nome { get; set; }
    [Required] public string UserId { get; set; }

}
