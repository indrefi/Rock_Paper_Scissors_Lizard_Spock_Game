using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Scoreboard> ScoreboardFirstPlayers { get; set; }
        public ICollection<Scoreboard> ScoreboardSecondPlayers { get; set; }

    }
}
