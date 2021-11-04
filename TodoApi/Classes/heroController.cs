using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeroGameApi;
using WebApi;


namespace HeroGameApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase {

        [HttpGet] //HERO GET WORKS
        public IEnumerable<Hero> Get(){
        return heroHandler.GetHeroes();
        }

        [HttpGet] //HERO GET WORKS
        [Route("{id}")]
        public Hero Get(int id){
        return heroHandler.GetHero(id);
        }

        [HttpPost] //HERO POST WORKS
        public string Post([FromBody]Hero newHero) {
        return heroHandler.AddHeros(newHero);
        }

        [HttpPut] //HERO UPDATE WORKS
        public string Put([FromBody]Hero hero) {
        return heroHandler.UpdateHero(hero);
        }

        [HttpDelete] //HERO DELETE WORKS
        public string Delete([FromBody]Hero hero) {
        return heroHandler.DeleteHero(hero);
        }
    }
}