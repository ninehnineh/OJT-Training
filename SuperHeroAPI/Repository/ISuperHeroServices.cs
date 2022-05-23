using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Repository
{
    public interface ISuperHeroServices
    {
        //IEnumerable<SuperHero> GetHeroes();
        ActionResult<IEnumerable<SuperHero>> GetHeroes1();
        SuperHero? GetHeroById(int id);
        void InsertHero(SuperHero newHero);
        void UpdateHero(SuperHero newHero);
        void DeleteHero(int id);
        bool FindHeroById(int id);

    }
}
