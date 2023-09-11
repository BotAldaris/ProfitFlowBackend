using AutoMapper;
using ProfitFlowBackend.Data.Dtos.Categoria;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<UpdateCategoriaDto, Categoria>();
        CreateMap<Categoria, ReadCategoriaDto>();
        CreateMap<Categoria, ReadCategoriaComProdutosDto>().ForMember(dto => dto.Produtos, opt => opt.MapFrom(categoria => categoria.Produto));

    }
}
