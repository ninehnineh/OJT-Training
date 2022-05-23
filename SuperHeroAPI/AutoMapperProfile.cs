using AutoMapper;
using SuperHeroAPI.Dtos.Character;
using SuperHeroAPI.Models;

namespace SuperHeroAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
