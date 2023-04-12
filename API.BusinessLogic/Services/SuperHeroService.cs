using API.DataAccessLayer;
using API.Model;
using API.Model.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.BusinessLogic.Services
{

    public class SuperHeroService : ISuperHeroService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public SuperHeroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SuperHeroDTO> GetAll()
        {
            List<SuperHero> superHeroes = _context.SuperHeroes.ToList();
      
            return superHeroes.Select(hero => _mapper.Map<SuperHeroDTO>(hero)).ToList();
        }

        public SuperHeroDTO? Get(int id)
        {
            SuperHero? sh = _context.SuperHeroes.FirstOrDefault(s => s.Id == id);

            return _mapper.Map<SuperHeroDTO?>(sh);
        }

        public async Task Add(SuperHeroDTO superHero)
        {
            var hero = _mapper.Map<SuperHero>(superHero);
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            SuperHero? sh = await _context.SuperHeroes.FindAsync(id);
            if (sh == null) { return; }
            _context.SuperHeroes.Remove(sh);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SuperHeroDTO superHero)
        {
            var existing = _context.SuperHeroes.FirstOrDefault(s => s.Id == superHero.Id);
            if(existing is null)
            {
                return;
            }
            existing.Name = superHero.Name == null ? existing.Name : superHero.Name;
            existing.FirstName = superHero.FirstName == null ? existing.FirstName : superHero.FirstName;
            existing.LastName = superHero.LastName == null ? existing.LastName : superHero.LastName;
            existing.Place = superHero.Place == null ? existing.Place : superHero.Place;
            existing.DateTimeUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}