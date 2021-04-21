using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Models
{
    public class UpdateChessRatingModel
    {
        public Guid UserId { get; set; }
        public int rating { get; set; }
    }
}
