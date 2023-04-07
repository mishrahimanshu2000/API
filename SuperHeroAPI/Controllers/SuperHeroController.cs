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
        //Get Superhero 
        [HttpGet]
        public ActionResult<List<SuperHero>> Get()
        {
             //throw new Exception("Error");
            return SuperHeroService.GetAll();
        }
        
        //Get superhero with ID
        [HttpGet("{id}")]
        public ActionResult<SuperHero> Get(int id)
        {
            var hero = SuperHeroService.Get(id);

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
            SuperHeroService.Add(superHero);

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

            var existingHero = SuperHeroService.Get(id);
            if (existingHero == null)
            {
                return NotFound("Hero Not found");
            }

            SuperHeroService.Update(superHero);

            return NoContent();
        }

        // Delete Superhero
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hero = SuperHeroService.Get(id);
            if (hero == null)
            {
                return NotFound("Hero Not found");
            }
            SuperHeroService.Delete(id);
            return NoContent();
        }
    }
}
