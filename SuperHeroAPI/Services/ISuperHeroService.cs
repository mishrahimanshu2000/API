using SuperHeroAPI.Model;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        Task Add(SuperHero superHero);
        Task Delete(int id);
        SuperHero? Get(int id);
        List<SuperHero> GetAll();
        Task Update(SuperHero superHero);
    }
}