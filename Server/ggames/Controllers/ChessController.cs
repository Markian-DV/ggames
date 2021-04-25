using ggames.Data;
using ggames.Helpers;
using ggames.Models;
using ggames.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Controllers
{

    [ApiController]
    [Authorize]
    public class ChessController : ControllerBase
    {
        private readonly IChessService _chessService;
        private readonly UserManager<IdentityUser> _userManager;

        public ChessController(IChessService chessService, UserManager<IdentityUser> userManager)
        {
            _chessService = chessService;
            _userManager = userManager;
        }

        [Route(ApiRoutes.Chess.GetAll)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var TempList = await _chessService.GetRatingAsync();

            var ResultList = TempList.Select(x => new { 
                Rating = x.Rating, 
                UserId = x.UserId,
                Username = (_userManager.FindByIdAsync(x.UserId).Result.UserName)
            });

            return Ok(ResultList);
                //.Select(async x => new {Rating = x.Rating, UserId = x.UserId
            //, Username = (await  _userManager.FindByIdAsync(x.UserId)).UserName
            //}));
        }
        [Route(ApiRoutes.Chess.GetById)]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]Guid Id)
        {
            var rating = await _chessService.GetRatingByUserIdAsync(Id);
            if (rating == null) return NotFound();
            else
            {
                string username = (await _userManager.FindByIdAsync(rating.UserId)).UserName;
                return Ok(new { Rating = rating.Rating, UserId = rating.UserId, Username = username });
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
