using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Scoreboard : BaseEntity
    {
        public Player FirstPlayer { get; set; }
        public int FirstPlayerID { get; set; }
        public Player SecondPlayer { get; set; }
        public int SecondPlayerID { get; set; }
        public Choise FirstPlayerChoise { get; set; }
        public int FirstPlayerChoiseID { get; set; }
        public Choise SecondPlayerChoise { get; set; }
        public int SecondPlayerChoiseID { get; set; }
        public GameResult GameResult { get; set; }
        public int GameResultID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}