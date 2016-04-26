using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Tennis
{
    public class TennisGame2 : ITennisGame
    {
        public int player1Points;
        public int player2Points;

        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string player)
        {
            if (player == this.player1Name)
            {
                P1Score();
            }
            else
            {
                P2Score();
            }
        }

        public void P1Score()
        {
            player1Points++;
        }

        public void P2Score()
        {
            player2Points++;
        }

        public string GetScore()
        {
            return GetScoreIfTie()
                ?? GetScoreIfWin()
                ?? GetScoreIfAdvantage()
                ?? GetScoreIfRegulation();
        }

        private string GetScoreIfTie()
        {
            if (player1Points != player2Points)
            {
                return null;
            }

            if (player1Points < 3)
            {
                var score = _scoreLookup[player1Points];
                return score + "-All";
            }

            return "Deuce";
        }

        private string GetScoreIfWin()
        {
            var pointDiff = Math.Abs(player1Points - player2Points);
            var pointMax = Math.Max(player1Points, player2Points);
            if (pointDiff < 2 || pointMax < 4)
            {
                return null;
            }

            return "Win for " + GetLeadingPlayer();
        }

        private string GetScoreIfAdvantage()
        {
            if (Math.Min(player1Points, player2Points) < 3)
            {
                return null;
            }

            return "Advantage " + GetLeadingPlayer();
        }

        private string GetScoreIfRegulation()
        {
            if (player1Points >= 4 || player2Points >= 4)
            {
                //shouldn't ever get here because the previous handlers cover this scenario, but just in case of refactoring...
                return null;
            }

            return _scoreLookup[player1Points] + "-" + _scoreLookup[player2Points];
        }

        private string GetLeadingPlayer()
        {
            return player1Points > player2Points
                ? player1Name
                : player2Name;
        }

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" }
        };
    }
}