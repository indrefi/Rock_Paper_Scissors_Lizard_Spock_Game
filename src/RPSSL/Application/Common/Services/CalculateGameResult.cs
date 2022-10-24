using Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common.Services
{
    public class CalculateGameResult : ICalculateGameResult
    {
        /// <summary>
        /// Results in matrix mapped.
        /// -1 - INVALID
        /// 1 - WIN
        /// 2 - LOSE
        /// 3 - TIE
        /// 
        /// Selection based on index
        /// 0 - None (not available)
        /// 1 - Rock
        /// 2 - Paper
        /// 3 - Scissors
        /// 4 - Lizard
        /// 5 - Spock
        /// 
        /// On Y axis is player one
        /// On X axis is player two
        /// </summary>
        private readonly List<List<int>> _combatResultRules = new List<List<int>> 
        {
            new List<int>{ -1,-1,-1,-1,-1,-1 },
            new List<int>{ -1, 3, 2, 1, 1, 2 },
            new List<int>{ -1, 1, 3, 2, 2, 1 },
            new List<int>{ -1, 2, 1 ,3, 1, 2 },
            new List<int>{ -1, 2, 1, 2, 3, 1 },
            new List<int>{ -1, 1, 2, 1, 2, 3  }
        };

        /// <summary>
        /// This method calculates the results of combat between player one and player two.
        /// </summary>
        /// <param name="firstPlayerChoiseId">The choise of first player</param>
        /// <param name="secondPlayerChoiseId">The choise of second player.</param>
        /// <returns>The methods returns the result of the combat of player one versus player two. 
        /// E.g: Player one wins over player two returns win.</returns>
        public int CalculateResult(int firstPlayerChoiseId, int secondPlayerChoiseId) =>
            _combatResultRules
            .ElementAt(firstPlayerChoiseId)
            .ElementAt(secondPlayerChoiseId);
    }
}
