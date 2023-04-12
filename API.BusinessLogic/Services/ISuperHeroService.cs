
using API.DataAccessLayer.Model;

namespace API.BusinessLogic.Services
{
    public interface ISuperHeroService
    {
        Task Add(SuperHero superHero);
        Task Delete(SuperHero hero);
        SuperHero? Get(int id);
        List<SuperHero> GetAll();
        Task Update(SuperHero superHero);
    }
}