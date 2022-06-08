using AutoMapper;
using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.WebAPI.Models;

namespace NubimetricsChallenge.WebAPI.Mappings;

public class AutoMapperConfigurationModel : Profile
{
    public override string ProfileName
    {
        get { return "AutoMapperConfigurationModel"; }
    }

    public AutoMapperConfigurationModel()
    {
        CreateMap<UserModel, UserDTO>().ReverseMap();
    }
}