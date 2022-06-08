using AutoMapper;
using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.Domain.Entities;

namespace NubimetricsChallenge.Application.Mappings;

public class AutoMapperConfigurationDto : Profile
{
    public override string ProfileName
    {
        get { return "AutoMapperConfigurationDto"; }
    }

    public AutoMapperConfigurationDto()
    {
        CreateMap<UserDTO, User>().ReverseMap();
    }
}
