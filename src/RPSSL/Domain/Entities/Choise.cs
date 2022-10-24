using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Choise : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Scoreboard> ScoreboardFirstPlayerChoises { get; set; }
        public ICollection<Scoreboard> ScoreboardSecondPlayerChoises { get; set; }
    }
}