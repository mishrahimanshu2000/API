using SuperHeroAPI.Model;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        void Add(SuperHero superHero);
        void Delete(int id);
        SuperHero? Get(int id);
        List<SuperHero> GetAll();
        void Update(SuperHero superHero);
    }
}