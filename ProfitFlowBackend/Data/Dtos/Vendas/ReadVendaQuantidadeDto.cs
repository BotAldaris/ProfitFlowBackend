namespace ProfitFlowBackend.Data.Dtos.Vendas;

public class ReadVendaQuantidadeDto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
}
