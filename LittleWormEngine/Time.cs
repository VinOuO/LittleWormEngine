using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LittleWormEngine
{
    class Time
    {
        public static float DeltaTime { get; set; }
        public static double PersiceDeltaTime { get; set; }
        public static long Get_Time()
        {
            return nanoTime();
        }

        public static float PresentTime()
        {
            return (float)nano_to_Scend(Get_Time());
        }

        public static double PersicePresentTime()
        {
            return nano_to_Scend(Get_Time());
        }

        private static long nanoTime()
        {
            long _nano = 10000L * Stopwatch.GetTimestamp();
            _nano /= TimeSpan.TicksPerMillisecond;
            _nano *= 100L;
            return _nano;
        }

        public static double nano_to_Scend(long _nanoTime)
        {
            return (double)_nanoTime / (double)1000000000;
        }
    }
}
