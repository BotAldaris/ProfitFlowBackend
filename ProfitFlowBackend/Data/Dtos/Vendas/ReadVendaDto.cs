using ProfitFlowBackend.Data.Dtos.Produto;

namespace ProfitFlowBackend.Data.Dtos.Vendas;

public class ReadVendaDto
{
    public int Id { get; set; }
    public ReadProdutoSemVendaDto Produto { get; set; }
    public string Data { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
}
