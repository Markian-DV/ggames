using ggames.Data;
using ggames.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Services
{
    public class ChessService : IChessService
    {
        private readonly AppDataContext _appDataContext;

        public ChessService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }


        public async Task<List<ChessRating>> GetRatingAsync()
        {
            return await _appDataContext.ChessRatings.ToListAsync();
        }

        public async Task<ChessRating> GetRatingByUserIdAsync(Guid UserId)
        {
            return await _appDataContext.ChessRatings.FirstOrDefaultAsync(r => r.UserId == UserId.ToString());
        }

        public async Task<bool> UpdateRatingAsync(Guid UserId, int rating)
        {
            


            var ratingToUpdate = await  GetRatingByUserIdAsync(UserId);
            if (ratingToUpdate == null) return false;
            if (ratingToUpdate.Rating <= 0 && rating<=0) rating = 0;
            ratingToUpdate.Rating += rating;
            _appDataContext.ChessRatings.Update(ratingToUpdate);
            var updated = await _appDataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
