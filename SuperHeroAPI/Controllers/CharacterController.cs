using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Dtos.Character;
using SuperHeroAPI.Models;
using SuperHeroAPI.Repository;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private static List<Character> Characters = new List<Character>
        {
            new Character(),
            new Character
            {
                Id = 1,
                Name = "Sam"
            }
        };

        private readonly ICharacterServices CharactorService;

        public CharacterController(ICharacterServices charactorService)
        {
            CharactorService = charactorService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponses<List<GetCharacterDto>>>> Get()
        {
            return Ok(await CharactorService.GetAllCharacters());
        }
         
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponses<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await CharactorService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponses<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character)
        {
            return Ok(await CharactorService.AddCharacter(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponses<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await CharactorService.GetCharacterById(updatedCharacter.Id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponses<List<GetCharacterDto>>>> Delete(int Id)
        {
            var response = await CharactorService.DeleteCharacter(Id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
    }
}
