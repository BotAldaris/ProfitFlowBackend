using AutoMapper;
using ProfitFlowBackend.Data.Dtos.Vendas;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Profiles;

public class VendasProfile : Profile
{
    public VendasProfile()
    {
        CreateMap<CreateVendaDto, Venda>().ForMember(dto => dto.Data, opt => opt.MapFrom(src => DateTime.Parse(src.Data)));
        CreateMap<UpdateVendaDto, Venda>().ForMember(dto => dto.Data, opt => opt.MapFrom(src => DateTime.Parse(src.Data)));
        CreateMap<Venda, ReadVendaDto>().ForMember(dto => dto.Produto, opt => opt.MapFrom(venda => venda.Produto));
        CreateMap<Venda, ReadVendaQuantidadeDto>();
    }
}
