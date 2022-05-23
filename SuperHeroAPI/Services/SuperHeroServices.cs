using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Repository;

namespace SuperHeroAPI.Services
{
    public class SuperHeroServices : ISuperHeroServices
    {
        // After code-first Migration
        // We inject DataContext into Constructor
        private readonly DataContext Context;
        public SuperHeroServices(DataContext context)
        {
            Context = context;
        }

        // Delete
        public void DeleteHero(int id)
        {
            var hero = GetHeroById(id);

            if (hero == null) return;

            Context.SuperHeroes.Remove(hero);
            Context.SaveChanges();
        }

        // Find Hero by Id
        public bool FindHeroById(int id)
        {
            var Hero = Context.SuperHeroes.Find(id);

            if (Hero == null) return false;

            return true;
        }

        // Get Hero by Id
        public SuperHero? GetHeroById(int id)
        {
            var hero = Context.SuperHeroes.Find(id);

            if (hero == null) return null;

            return hero;
        }

        //Get all Hero
        public IEnumerable<SuperHero> GetHeroes()
        {
            return Context.SuperHeroes.ToList();
        }

        // Get all Hero
        public ActionResult<IEnumerable<SuperHero>> GetHeroes1()
        {
            return Context.SuperHeroes.ToList();
        }

        // Insert hero
        public void InsertHero(SuperHero newHero)
        {
            Context.SuperHeroes.Add(newHero);
            Context.SaveChanges();
        }

        // Update hero
        public void UpdateHero(SuperHero newHero)
        {
            var hero = GetHeroById(newHero.Id);

            if (hero == null) return;

            hero.Name = newHero.Name;
            hero.FirstName = newHero.FirstName;
            hero.LastName = newHero.LastName;
            hero.Place = newHero.Place;

            Context.SuperHeroes.Update(hero);
            Context.SaveChanges();
        }

    }
}
