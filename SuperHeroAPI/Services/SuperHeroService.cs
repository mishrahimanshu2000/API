using API.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Model;
using SuperHeroAPI.Services;
using System.Net;

namespace SuperHeroAPI.Services
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

        public async Task Delete(int id)
        {
            var superhero = Get(id);
            if (superhero is null)
            {
                return;
            }
            _context.SuperHeroes.Remove(superhero);
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