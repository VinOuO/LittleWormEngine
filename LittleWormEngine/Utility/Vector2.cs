using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Mathematics;

namespace LittleWormEngine.Utility
{
    class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public static Vector2 Zero { get { return new Vector2(0, 0); } } 
        public static Vector2 One { get { return new Vector2(1, 1); } }


        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public Vector2(Vector2 _Vector2)
        {
            x = _Vector2.x;
            y = _Vector2.y;
        }

        public Vector2 Normalize()
        {
            return new Vector2(x, y) / Length();
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static float Distance(Vector2 _a, Vector2 _b)
        {
            return (float)Math.Sqrt(_a.x * _b.x + _a.y * _b.y);
        }

        public Vector2 Rotate(float _Angle)
        {
            return new Vector2(x * (float)Math.Cos(Math_of_Rotation.Radians_of(_Angle)) - y * (float)Math.Sin(Math_of_Rotation.Radians_of(_Angle)), x * (float)Math.Sin(Math_of_Rotation.Radians_of(_Angle)) + y * (float)Math.Cos(Math_of_Rotation.Radians_of(_Angle)));
        }

        public static Vector2 operator +(Vector2 _a, Vector2 _b) => new Vector2(_a.x + _b.x, _a.y + _b.y);
        public static Vector2 operator -(Vector2 _a, Vector2 _b) => new Vector2(_a.x - _b.x, _a.y - _b.y);
        public static float operator *(Vector2 _a, Vector2 _b) => (_a.x * _b.x + _a.y * _b.y);
        public static Vector2 operator *(Vector2 _a, float _b) => new Vector2(_a.x * _b, _a.y * _b);
        public static Vector2 operator *(float _a, Vector2 _b) => new Vector2(_a * _b.x, _a * _b.y);
        public static Vector2 operator /(Vector2 _a, float _b) => new Vector2(_a.x / _b, _a.y / _b);
    }
}
