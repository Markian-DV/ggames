using ggames.Data;
using ggames.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Services
{
    public class ArticleService
    {
        private readonly AppDataContext _appDataContext;

        public ArticleService(AppDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public async Task<List<Article>> CreateArticleAsync()
        {
            return await _appDataContext.Add<>;
        }
    }
}
