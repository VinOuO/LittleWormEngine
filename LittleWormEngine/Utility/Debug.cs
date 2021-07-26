using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine.Utility
{
    class Debug
    {
        public static void Log(Vector2 _Vec2)
        {
            Console.WriteLine("(" + _Vec2.x + ", " + _Vec2.y + ")");
        }

        public static void Log(Vector3 _Vec3)
        {
            Console.WriteLine("(" + Math.Round(_Vec3.x, 2) + ", " + Math.Round(_Vec3.y, 2) + ", " + Math.Round(_Vec3.z, 2) + ")");
        }
        public static void Log(Vector4 _Vec4)
        {
            Console.WriteLine("(" + Math.Round(_Vec4.x, 2) + ", " + Math.Round(_Vec4.y, 2) + ", " + Math.Round(_Vec4.z, 2) + ", " + Math.Round(_Vec4.w, 2) + ")");
        }

        public static void Log(Matrix4 _Mat4)
        {
            Log(_Mat4.Get_Vector4("Row", 0));
            Log(_Mat4.Get_Vector4("Row", 1));
            Log(_Mat4.Get_Vector4("Row", 2));
            Log(_Mat4.Get_Vector4("Row", 3));
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
