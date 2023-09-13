using ProfitFlowBackend.Data.Dtos.Produto;
using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.Categoria;

public class ReadCategoriaComProdutosDto
{
    [Required] public string Nome { get; set; }
    [Required] public string UserId { get; set; }

    public ICollection<ReadQuantidadeProdutoDto> Produtos { get; set; }
}
