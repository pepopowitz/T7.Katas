using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Bowling
{
    public class Bowler
    {
        public int Score(string throws)
        {
            var total = 0;

            var context = GetGameContext(throws);
            int previousBall = 0;
            bool nextBallCountsTwice = false;

            int current = 0;
            var totalBalls = throws.Length;
            foreach (var ball in context.Balls)
            {
                total += ball.Value;
                for (int future = current+1; 
                    future <= current+ball.IncludeNextThrows; 
                    future++)
                {
                    if (future < totalBalls)
                    {
                        total += context.Balls.ElementAt(future).Value;
                    }
                }
                current++;
            }
            return total;
        }

        private GameContext GetGameContext(string throws)
        {
            var context = new GameContext();

            var balls = new List<BallContext>();
            BallContext previousBall = null;

            for (int i = 0; i < throws.Length; i++)
            {
                var ball = GetBallContext(throws[i], previousBall);
                balls.Add(ball);
                previousBall = ball;
            }
            context.Balls = balls;

            return context;
        }

        private BallContext GetBallContext(char ball, BallContext previousBall)
        {
            var result = new BallContext();

            result.Raw = ball;

            switch (ball)
            {
                case '-':
                    result.Value = 0;
                    break;
                case '/':
                    result.Value = 10 - previousBall.Value;
                    result.IncludeNextThrows = 1;
                    break;
                case 'X':
                    result.Value = 10;
                    result.IncludeNextThrows = 2;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    result.Value = int.Parse(ball.ToString());
                    break;
            }

            return result;
        }
    }
}
