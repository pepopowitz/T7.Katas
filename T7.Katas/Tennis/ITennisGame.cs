using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7.Katas.Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();

    }
}