using SuperHeroAPI.Dtos.Character;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Repository
{
    public interface ICharacterServices
    {
        Task<ServiceResponses<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponses<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponses<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponses<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character);
        Task<ServiceResponses<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
