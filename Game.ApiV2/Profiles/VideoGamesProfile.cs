using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Profiles
{
    public class VideoGamesProfile : Profile
    {
        public VideoGamesProfile()
        {
            //GET
            CreateMap<ApiV2.Models.VideoGame, Dtos.VideoGameReadDto>()
                .ForMember(
                    dest => dest.Genres,
                    opt => opt.MapFrom(src => $"{src.Genre1}, {src.Genre2}"));

            //POST
            CreateMap<Dtos.VideoGameCreateDto, ApiV2.Models.VideoGame>();

            //PATCH
            CreateMap<ApiV2.Models.VideoGame, Dtos.VideoGameCreateDto>();

        }

    }
}
