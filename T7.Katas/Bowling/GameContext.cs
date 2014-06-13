using System.Collections.Generic;

namespace T7.Katas.Bowling
{
    public class GameContext
    {
        public IEnumerable<BallContext> Balls { get; set; }
    }
}