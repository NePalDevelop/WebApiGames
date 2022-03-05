using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Domain.Interfaces;
using WebApiGames.Models;

namespace WebApiGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameStore _gameStore;

        public GamesController(IGameStore gameStores)
        {
            _gameStore = gameStores;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get([FromQuery] Domain.Models.GameQuery gameQuery)
        {
            var games = await _gameStore.GetGames(gameQuery);

            return games.Select(Mapper.MapGameFromDomain).ToList();
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            return Mapper.MapGameFromDomain(await _gameStore.GetGame(id));
        }

        // POST api/<GamesController>
        [HttpPost]
        public async Task<ActionResult<Game>> Post([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            var createdGame = await _gameStore.AddGame(Mapper.MapGameToDomain(game));

            return Mapper.MapGameFromDomain(createdGame);
        }

        // PUT api/<GamesController>/5
        [HttpPut]
        public async Task<ActionResult<Game>> Put([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            var updatedGame = await _gameStore.UpdateGame(Mapper.MapGameToDomain(game));

            return Mapper.MapGameFromDomain(updatedGame);
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _gameStore.DeleteGame(id)) return Ok();

            return NotFound();
        }
    }
}
