using SuperHeroAPI.Model;

namespace SuperHeroAPI.Services
{

    public interface ISuperHeroService
    {
        List<SuperHero> GetAll();
        SuperHero? Get(int id);
        void Update(SuperHero superHero);
        void Delete(int id);
        void Add(SuperHero superHero);
    }


    public class SuperHeroService : ISuperHeroService
    {
        List<SuperHero> SuperHeroes { get; }
        static int nextId = 3;

        //private static SuperHeroService _instance;
        public SuperHeroService()
        {
            SuperHeroes = new List<SuperHero>
                {
                    new SuperHero
                    {
                        Id = 1,
                        Name = "Spider Man",
                        FirstName = "Peter",
                        LastName = "Parker",
                        Place = "New York City"
                    },
                    new SuperHero
                    {
                        Id = 2,
                        Name = "Iron Man",
                        FirstName = "Tony",
                        LastName = "Stark",
                        Place = "Long Island"
                    }
            };

        }

        //public static SuperHeroService Instance
        //{
        //    get
        //    {
        //        if(_instance == null)
        //            _instance = new SuperHeroService();

        //        return _instance;
        //    }
        //}
              
        public List<SuperHero> GetAll() => SuperHeroes;

        public SuperHero? Get(int id) => SuperHeroes.FirstOrDefault(s => s.Id == id);

        public void Add(SuperHero superHero)
        {
            superHero.Id = nextId++;
            SuperHeroes.Add(superHero);
        }

        public void Delete(int id)
        {
            var superhero = Get(id);
            if (superhero is null)
            {
                return;
            }
            SuperHeroes.Remove(superhero);
        }

        public void Update(SuperHero superHero)
        {
            var index = SuperHeroes.FindIndex(s => s.Id == superHero.Id);
            if(index == -1)
            {
                return;
            }
            SuperHeroes[index] = superHero;
        }
    }
}

// Global exception hndl - Done
// # 3 tier arch; - 
// # n layer 