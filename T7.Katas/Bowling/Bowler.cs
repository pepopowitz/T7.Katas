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

            var frame = 0;
            var ballInFrame = 0;
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
            result.Frame = previousBall == null
                ? 1
                : (previousBall.LastBallInFrame ? previousBall.Frame + 1 : previousBall.Frame);
            var ballsAllowedThisFrame = result.Frame >= 10 ? 3 : 2;
            var ballsSoFarThisFrame = previousBall == null
                ? 0
                : (previousBall.LastBallInFrame ? 0 : 1);

            switch (ball)
            {
                case '-':
                    result.Value = 0;
                    result.LastBallInFrame = ballsSoFarThisFrame > 0;
                    break;
                case '/':
                    //can't get a spare on the first ball, so who cares if previousBall could be null.
                    result.Value = 10 - previousBall.Value;
                    result.IncludeNextThrows = (result.Frame < 10) ? 1 : 0;
                    result.LastBallInFrame = true;
                    break;
                case 'X':
                    result.Value = 10;
                    result.IncludeNextThrows = (result.Frame < 10) ? 2 : 0;
                    result.LastBallInFrame = (result.Frame < 10);
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
                    result.LastBallInFrame = ballsSoFarThisFrame > 0;
                    break;
            }

            return result;
        }
    }
}
