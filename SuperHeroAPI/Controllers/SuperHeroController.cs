using API.BusinessLogic.Services;
using API.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<SuperHeroDTO>> Get()
        {
            //throw new Exception("Error");
            return _superHero.GetAll();
        }
        
        //Get superhero with ID
        [HttpGet("{id}")]
        public ActionResult<SuperHeroDTO> Get(int id)
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
        public async Task<IActionResult> Post(SuperHeroDTO superHero)
        {
            await _superHero.Add(superHero);

            return CreatedAtAction(nameof(Get), new {id = superHero.Id}, superHero);
        }

        // Update SuperHero
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SuperHeroDTO superHero)
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
            

            await _superHero.Update(superHero);

            return Ok();
        }

        // Delete Superhero
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hero = _superHero.Get(id);
            if (hero == null)
            {
                return NotFound("Hero Not found");
            }
            await _superHero.Delete(id);
            return Ok();
        }
    }
}
