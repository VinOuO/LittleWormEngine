using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine.Utility
{
    class Vector4
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public static Vector4 Zero { get { return new Vector4(0, 0, 0, 0); } }
        public static Vector4 One { get { return new Vector4(1, 1, 1, 1); } }

        public Vector4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public Vector4(Vector4 _Vector4)
        {
            x = _Vector4.x;
            y = _Vector4.y;
            z = _Vector4.z;
            w = _Vector4.w;
        }

        public Vector4 Normalize()
        {
            return new Vector4(x, y, z, w) / Length();
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);                                                      
        }

        public Vector3 Rotate(Vector3 _Rotate_xyz)
        {
            return new Vector3(x, y, z) * Matrix3.RotateX(_Rotate_xyz.x) * Matrix3.RotateY(_Rotate_xyz.y) * Matrix3.RotateZ(_Rotate_xyz.z);
        }

        public static Vector4 operator +(Vector4 _a, Vector4 _b) => new Vector4(_a.x + _b.x, _a.y + _b.y, _a.z + _b.z, _a.w + _b.w);
        public static Vector4 operator -(Vector4 _a, Vector4 _b) => new Vector4(_a.x - _b.x, _a.y - _b.y, _a.z - _b.z, _a.w - _b.w);
        public static float operator *(Vector4 _a, Vector4 _b) => (_a.x * _b.x + _a.y * _b.y + _a.z * _b.z + _a.w * _b.w);
        public static Vector4 operator *(Vector4 _a, float _b) => new Vector4(_a.x * _b, _a.y * _b, _a.z * _b, _a.w * _b);
        public static Vector4 operator *(float _a, Vector4 _b) => new Vector4(_a * _b.x, _a * _b.y, _a * _b.z, _a * _b.w);
        public static Vector4 operator /(Vector4 _a, float _b) => new Vector4(_a.x / _b, _a.y / _b, _a.z / _b, _a.w / _b);
    }
}
