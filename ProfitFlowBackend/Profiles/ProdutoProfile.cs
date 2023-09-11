using AutoMapper;
using ProfitFlowBackend.Data.Dtos.Produto;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>().ForMember(dto => dto.Categoria, opt => opt.MapFrom(produto => produto.Categoria)).ForMember(dto => dto.Venda, opt => opt.MapFrom(produto => produto.Venda));
        CreateMap<Produto, ReadProdutoSemVendaDto>().ForMember(dto => dto.Categoria, opt => opt.MapFrom(produto => produto.Categoria));
        CreateMap<Produto, ReadQuantidadeProdutoDto>();
    }
}
