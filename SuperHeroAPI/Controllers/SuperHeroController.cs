using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SuperHeroAPI.Model;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/superHero")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly ISuperHeroService _superHero;

        // Adding Constructor Dependency
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this._superHero = superHeroService;
        }

        //Get Superhero 
        [HttpGet]
        public ActionResult<List<SuperHero>> Get()
        {
            //throw new Exception("Error");
            return _superHero.GetAll();
        }
        
        //Get superhero with ID
        [HttpGet("{id}")]
        public ActionResult<SuperHero> Get(int id)
        {
            var hero = _superHero.Get(id);

            if (hero == null)
            {
                // TO Check Global Exception Hanndling Uncomment the below line ;
                //throw new Exception("Not Found");
                return NotFound("Hero Not Available");
            }
            return hero;
        }

        // Create new SuperHero
        [HttpPost]
        public IActionResult Post(SuperHero superHero)
        {
            _superHero.Add(superHero);

            return CreatedAtAction(nameof(Get), new {id = superHero.Id}, superHero);
        }

        // Update SuperHero
        [HttpPut("{id}")]
        public IActionResult Put(int id, SuperHero superHero)
        {
            if(id != superHero.Id)
            {
                return BadRequest();
            }

            var existingHero = _superHero.Get(id);

            if (existingHero == null)
            {
                return NotFound("Hero Not found");
            }

            _superHero.Update(superHero);

            return Ok();
        }

        // Delete Superhero
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hero = _superHero.Get(id);
            if (hero == null)
            {
                return NotFound("Hero Not found");
            }
            _superHero.Delete(id);
            return Ok();
        }
    }
}
