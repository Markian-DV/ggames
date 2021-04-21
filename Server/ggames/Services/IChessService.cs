using ggames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Services
{
    public interface IChessService
    {
        //get all ratings
        Task<List<ChessRating>> GetRatingAsync();
        //get rating by id
        Task<ChessRating> GetRatingByUserIdAsync(Guid UserId);

        //add rating
        Task<bool> UpdateRatingAsync(Guid UserId, int rating);
    }
}
