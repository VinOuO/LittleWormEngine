using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine.Utility
{
    class Debug
    {
        public static void Log(Vector3 _Vec3)
        {
            Console.WriteLine("(" + _Vec3.x + ", " + _Vec3.y + ", " + _Vec3.z + ")");
        }

        public static void Log(string _String, Vector3 _Vec3, int _a)
        {
            Console.WriteLine(_String + "(" + (int)_Vec3.x + ", " + (int)_Vec3.y + ", " + (int)_Vec3.z + ")");
        }

        public static void Log(string _String, Vector3 _Vec3, float _a)
        {
            Console.WriteLine(_String + "(" + _Vec3.x + ", " + _Vec3.y + ", " + _Vec3.z + ")");
        }

        public static void Log(string _String)
        {
            Console.WriteLine(_String);
        }
    }
}
