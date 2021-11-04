using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeroGameApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase {


           [HttpGet]//GET WIP
        public List<Game> Get(){
            return GameHandler.GetGames();
        }
        [HttpPost]//POST WORKS
        public string Post([FromBody]Game newGame) {
            return GameHandler.AddGame(newGame);
        }
    }
}