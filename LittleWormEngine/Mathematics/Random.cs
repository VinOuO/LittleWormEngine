using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine.Mathematics
{
    static class LWRandom
    {
        public static float Range()
        {
            var _Rand = new Random();
            return (float)_Rand.NextDouble() * 10;
        }
    }
}
