using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            const int maxPointsInRegulation = 4;

            if (player1Score == player2Score)
            {
                return GetEvenScore();
            }
            if (player1Score >= maxPointsInRegulation 
                || player2Score >= maxPointsInRegulation)
            {
                return GetOvertimeScore();
            }
            return GetRegulationScore();
        }

        private string GetEvenScore()
        {
            switch (player1Score)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private string GetOvertimeScore()
        {
            int minusResult = player1Score - player2Score;
            if (minusResult == 1)
            {
                return "Advantage " + this.player1Name;
            }
            if (minusResult == -1)
            {
                return "Advantage " + this.player2Name;
            }
            if (minusResult >= 2)
            {
                return "Win for " + this.player1Name;
            }
            return "Win for " + this.player2Name;
        }

        private string GetRegulationScore()
        {
            var player1Text = _scoreLookup[player1Score];
            var player2Text = _scoreLookup[player2Score];

            return player1Text + "-" + player2Text;
        }

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {0,"Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" }
        };
    }

}
