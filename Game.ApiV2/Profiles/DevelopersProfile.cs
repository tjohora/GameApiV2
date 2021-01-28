using AutoMapper;
using Game.ApiV2.Dtos;
using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Profiles
{
    public class DevelopersProfile : Profile
    {
        public DevelopersProfile()
        {
            //Source -> Target
            CreateMap<ApiV2.Models.Developer, Dtos.DeveloperReadDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.FoundedDate.GetCompanyAge()))
                .ForMember(
                    dest => dest.CompanyName,
                    opt => opt.MapFrom(src => src.Name));


            CreateMap<Dtos.DeveloperCreateDto, ApiV2.Models.Developer>();

            //PUT
            CreateMap<Dtos.DeveloperUpdateDto, ApiV2.Models.Developer>();

            //PATCH
            CreateMap<ApiV2.Models.Developer, Dtos.DeveloperUpdateDto>();
        }
    }
}
