using ggames.Data;
using ggames.Helpers;
using ggames.Models;
using ggames.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Controllers
{

    [ApiController]
    [Authorize]
    public class ChessControllere : ControllerBase
    {
        private readonly IChessService _chessService;

        public ChessControllere(IChessService chessService)
        {
            _chessService = chessService;
        }

        [Route(ApiRoutes.Chess.GetAll)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _chessService.GetRatingAsync()).Select(x => new {Rating = x.Rating, UserId = x.UserId }));
        }
        [Route(ApiRoutes.Chess.GetById)]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]Guid Id)
        {
            var rating = await _chessService.GetRatingByUserIdAsync(Id);
            if (rating == null) return NotFound();
            else
            {
                return Ok(new { Rating = rating.Rating, UserId = rating.UserId });
            }
        }

        [Route(ApiRoutes.Chess.UpdateRating)]
        [HttpPost]
        public async Task<IActionResult> UpdateRating(UpdateChessRatingModel updateChessRating )
        {
            var UserId = HttpContext.User.Claims.Single(x => x.Type == "id").Value;
            if (updateChessRating.UserId.ToString() != UserId) return BadRequest();
            bool updated = await _chessService.UpdateRatingAsync(updateChessRating.UserId, updateChessRating.rating);
            if(updated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }



    }
}
