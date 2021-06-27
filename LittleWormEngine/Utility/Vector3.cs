using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Mathematics;

namespace LittleWormEngine.Utility
{
    class Vector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        public static readonly Vector3 Up = new Vector3(0, 1, 0);
        public static readonly Vector3 Right = new Vector3(1, 0, 0);
        public static readonly Vector3 Forward = new Vector3(0, 0, 1);
        public static readonly Vector3 Backward = new Vector3(0, 0, -1);

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3(Vector3 _Vector3)
        {
            x = _Vector3.x;
            y = _Vector3.y;
            z = _Vector3.z;
        }

        public Vector3 Normalize()
        {
            return new Vector3(x, y, z) / Length();
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public static float Distance(Vector3 _a, Vector3 _b)
        {
            return (float)Math.Sqrt(_a.x * _b.x + _a.y * _b.y + _a.z * _b.z);
        }
        
        public Vector3 Rotate(Vector3 _Rotate_xyz)
        {
            return new Vector3(x, y, z) * Matrix3.RotateX(_Rotate_xyz.x) * Matrix3.RotateY(_Rotate_xyz.y) * Matrix3.RotateZ(_Rotate_xyz.z);
        }

        public static Vector3 operator -(Vector3 _a) => new Vector3(-_a.x, -_a.y, -_a.z);
        public static Vector3 operator +(Vector3 _a, Vector3 _b) => new Vector3(_a.x + _b.x, _a.y + _b.y, _a.z + _b.z);
        public static Vector3 operator -(Vector3 _a, Vector3 _b) => new Vector3(_a.x - _b.x, _a.y - _b.y, _a.z - _b.z);
        public static Vector3 operator +(Vector3 _a, float _b) => new Vector3(_a.x + _b, _a.y + _b, _a.z + _b);
        public static Vector3 operator +(float _a, Vector3 _b) => new Vector3(_a + _b.x, _a + _b.y, _a + _b.z);
        public static Vector3 operator -(Vector3 _a, float _b) => new Vector3(_a.x - _b, _a.y - _b, _a.z - _b);
        public static Vector3 operator -(float _a, Vector3 _b) => new Vector3(_a - _b.x, _a - _b.y, _a - _b.z);
        public static float operator *(Vector3 _a, Vector3 _b) => (_a.x * _b.x + _a.y * _b.y + _a.z * _b.z);
        public static Vector3 operator *(Vector3 _a, float _b) => new Vector3(_a.x * _b, _a.y * _b, _a.z * _b);
        public static Vector3 operator *(float _a, Vector3 _b) => new Vector3(_a * _b.x, _a * _b.y, _a * _b.z);
        public static Vector3 operator /(Vector3 _a, float _b) => new Vector3(_a.x / _b, _a.y / _b, _a.z / _b);
        public static Vector3 operator %(Vector3 _a, float _b) => new Vector3(_a.x % _b, _a.y % _b, _a.z % _b);
    }
}
