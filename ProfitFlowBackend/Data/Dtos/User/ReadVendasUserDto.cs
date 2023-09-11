using ProfitFlowBackend.Data.Dtos.Vendas;

namespace ProfitFlowBackend.Data.Dtos.User
{
    public class ReadVendasUserDto
    {
        public ICollection<ReadVendaDto> Vendas { get; set; }

    }
}
