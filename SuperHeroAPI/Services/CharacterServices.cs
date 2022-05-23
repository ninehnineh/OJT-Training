using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Dtos.Character;
using SuperHeroAPI.Models;
using SuperHeroAPI.Repository;

namespace SuperHeroAPI.Services
{
    public class CharacterServices : ICharacterServices
    {

        private readonly DataContext Context;
        private readonly IMapper Mapper;
        public CharacterServices(DataContext context,
                                    IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        private static List<Character> Characters = new List<Character>
        {
            new Character(),
            new Character
            {
                Id = 1,
                Name = "Sam"
            }
        };
        public async Task<ServiceResponses<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponses<List<GetCharacterDto>>();
            // AddCharacterDto to Charater object
            Character character = Mapper.Map<Character>(newCharacter);
            Context.Characters.Add(character);
            await Context.SaveChangesAsync();
            serviceResponse.Data = await Context.Characters.Select(c => Mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponses<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponses<List<GetCharacterDto>>();
            var dbCharacters = await Context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => Mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Message = "All Character Information";
            return serviceResponse;

        }

        public async Task<ServiceResponses<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponses<GetCharacterDto>();
            var dbCharacter = await Context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            // map Characters to GetCharacterDto
            serviceResponse.Data = Mapper.Map<GetCharacterDto>(dbCharacter);
            serviceResponse.Message = $"The information of character with id {id}";
            return serviceResponse;
        }
        
        
        public async Task<ServiceResponses<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponses<GetCharacterDto>();
            try
            {
                // FirstOrDefault return null if no matching was found then throw exception
                var character = Characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponse.Data = Mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponses<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var serviceResponse = new ServiceResponses<List<GetCharacterDto>>();
            try
            {
                var character = Characters.First(c => c.Id == Id);

                Characters.Remove(character);

                serviceResponse.Data = Characters.Select(c => Mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
