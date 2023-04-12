using API.DataAccessLayer;
using API.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.BusinessLogic.Services
{

    public class SuperHeroService : ISuperHeroService
    {
        private AppDbContext _context;

        public SuperHeroService(AppDbContext context)
        {
            _context = context;
        }

        public List<SuperHero> GetAll()
        {
            List<SuperHero> superHeroes = _context.SuperHeroes.ToList();
            return superHeroes;
        }

        public SuperHero? Get(int id)
        {
            return _context.SuperHeroes.FirstOrDefault(s => s.Id == id);
        }

        public async Task Add(SuperHero superHero)
        {
            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SuperHero hero)
        { 
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SuperHero superHero)
        {
            var existing = _context.SuperHeroes.FirstOrDefault(s => s.Id == superHero.Id);
            if(existing is null)
            {
                return;
            }
            existing.Name = superHero.Name;
            existing.FirstName = superHero.FirstName;
            existing.LastName = superHero.LastName;
            existing.Place = superHero.Place;

            await _context.SaveChangesAsync();
        }
    }
}