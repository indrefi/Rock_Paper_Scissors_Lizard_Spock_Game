using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class GameResult : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Scoreboard> Scoreboards { get; set; }
    }
}
