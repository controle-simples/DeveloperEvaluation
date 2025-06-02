using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class GetUserResponseProfile : Profile
{
    public GetUserResponseProfile()
    {
        CreateMap<GetUserResult, GetUserResponse>();
    }
}