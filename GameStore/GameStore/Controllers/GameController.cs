using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService) => _gameService = gameService;

        [HttpGet]
        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gameService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(Game game)
        {
            var model = await _gameService.GetByIdAsync(game.Id);
            if (model is not null) return BadRequest();
            
            await _gameService.CreateAsync(game);
            return Ok();

        }

        [HttpGet("/game")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var model = await _gameService.GetByIdAsync(id);
            if (model is null) return BadRequest();
            return Ok(model);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(Game game)
        {
            var model = await _gameService.GetByIdAsync(game.Id);
            if (model is null) return BadRequest();
            
            await _gameService.UpdateAsync( game);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGame(int id)
        {
            try
            {
                await _gameService.DeleteByIdAsync(id);
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}