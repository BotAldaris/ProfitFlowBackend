using ProfitFlowBackend.Data.Dtos.Categoria;
using ProfitFlowBackend.Data.Dtos.Vendas;

namespace ProfitFlowBackend.Data.Dtos.Produto;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public double Custo { get; set; }
    public ICollection<ReadVendaQuantidadeDto> Venda { get; set; }
    public ReadCategoriaDto Categoria { get; set; }
    public int Quantidade { get; set; }
    public string Imagem { get; set; }
    public string FormatoImagem { get; set; }

}
