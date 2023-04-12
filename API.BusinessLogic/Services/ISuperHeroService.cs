
using API.Model.DTOs;

namespace API.BusinessLogic.Services
{
    public interface ISuperHeroService
    {
        Task Add(SuperHeroDTO superHero);
        Task Delete(int id);
        SuperHeroDTO? Get(int id);
        List<SuperHeroDTO> GetAll();
        Task Update(SuperHeroDTO superHero);
    }
}