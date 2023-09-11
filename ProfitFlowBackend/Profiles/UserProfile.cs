using AutoMapper;
using ProfitFlowBackend.Data.Dtos.User;
using ProfitFlowBackend.Models;

namespace ProfitFlowBackend.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDtos, Usuario>();
    }

}
