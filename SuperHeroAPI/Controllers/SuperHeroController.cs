using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Repository;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroServices SuperHeroServices;

        public SuperHeroController(ISuperHeroServices superHeroServices)
        {
            SuperHeroServices = superHeroServices;
        }

        // Get all
        // Success: 200 (OK)
        // Failure: 400 (Not Found)
        //[HttpGet]
        //public IEnumerable<SuperHero> Get()
        //{
        //    return SuperHeroServices.GetHeroes(); // return a status code 200 (mean success)
        //}

        [HttpGet]
        public ActionResult<IEnumerable<SuperHero>> Get1()
        {   
            if(SuperHeroServices.GetHeroes1() == null)
                return BadRequest("There are no heroes here.");
            //return Ok(SuperHeroServices.GetHeroes1());
            return Ok(SuperHeroServices.GetHeroes1());
        }

        //[HttpGet]
        //public async Task<ActionResult<List<SuperHero>>> Get()
        //{
        //    return Ok(heroes);
        //}

        // Get hero by id
        // Success: 200 (OK)
        // Failure: 400 (Not Found)
        //==================
        [HttpGet("{id}")]
        public ActionResult<SuperHero> Get(int id)
        {
            var hero = SuperHeroServices.GetHeroById(id);
            if (hero == null)
                return NotFound("Hero with id " + id + " does not exist");
            return Ok(hero);
        }
        //==================
        // ActionResult

        //[HttpGet("{id}")]
        //public ActionResult<SuperHero> Get(int id)
        //{
        //    var hero = heroes.Find(h => h.Id == id);
        //    if (hero == null)
        //        return BadRequest("Hero not found.");
        //    return Ok(hero);
        //}

        //==================
        // Add new Hero
        // Success: 201 (Created)
        // Failure: 400 (Bad Request)
        [HttpPost]
        public ActionResult<List<SuperHero>> AddHero(SuperHero hero)
        {
            if (SuperHeroServices.FindHeroById(hero.Id))
                return BadRequest("The hero with id " + hero.Id + " is exist.");

            SuperHeroServices.InsertHero(hero);
            return Ok(SuperHeroServices.GetHeroes1());
        }
        //==================
        // Update a hero
        // Success: 204 (No Content)
        // Failure: 404 (Not Found)
        [HttpPut]
        public ActionResult<SuperHero> UpdateHero(SuperHero superHero)
        {

            var hero = SuperHeroServices.GetHeroById(superHero.Id);
            if (hero == null)
                return NotFound("The hero with id " + superHero.Id + " does not exist.");

            SuperHeroServices.UpdateHero(superHero);

            return Ok(SuperHeroServices.GetHeroes1());
        }
        //==================
        // Success: 204 (No Content)
        // Failure: 400 (Bad Request)
        [HttpDelete("{id}")]
        public ActionResult<SuperHero> DeleteHero(int id)
        {
            if (!SuperHeroServices.FindHeroById(id))
                return BadRequest("The hero with id " + id + " does not exist.");
            
            SuperHeroServices.DeleteHero(id);
            return Ok(SuperHeroServices.GetHeroes1());
        }
        //==================
    }
}
