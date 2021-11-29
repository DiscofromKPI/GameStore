using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService) => _gameService = gameService;

        [HttpGet]
        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gameService.GetAllAsync();
        }
    }
}