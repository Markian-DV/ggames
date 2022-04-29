using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public string[] Users { get; set; }
    }
}
