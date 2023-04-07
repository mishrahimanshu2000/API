using SuperHeroAPI.Model;

namespace SuperHeroAPI.Services
{
    public static class SuperHeroService
    {
        static List<SuperHero> SuperHeroes { get; }
        static int nextId = 3;
        static SuperHeroService()
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

        public static List<SuperHero> GetAll() => SuperHeroes;

        public static SuperHero? Get(int id) => SuperHeroes.FirstOrDefault(s => s.Id == id);

        public static void Add(SuperHero superHero)
        {
            superHero.Id = nextId++;
            SuperHeroes.Add(superHero);
        }

        public static void Delete(int id)
        {
            var superhero = Get(id);
            if (superhero is null)
            {
                return;
            }
            SuperHeroes.Remove(superhero);
        }

        public static void Update(SuperHero superHero)
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