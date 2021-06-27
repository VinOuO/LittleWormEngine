using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine.Utility
{
    class Quaternion
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public static Quaternion Zero = new Quaternion(0, 0, 0, 0);
        public static Quaternion One = new Quaternion(1, 1, 1, 1);


        public Quaternion(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public Quaternion Normalize()
        {
            return new Quaternion(x, y, z, w) / Length();
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(-x, -y, -z, w);
        }

        public static Quaternion operator +(Quaternion _a, Quaternion _b) => new Quaternion(_a.x + _b.x, _a.y + _b.y, _a.z + _b.z, _a.w + _b.w);
        public static Quaternion operator -(Quaternion _a, Quaternion _b) => new Quaternion(_a.x - _b.x, _a.y - _b.y, _a.z - _b.z, _a.w - _b.w);
        public static Quaternion operator *(Quaternion _a, Quaternion _b) => new Quaternion(_a.x * _b.w + _a.w * _b.x + _a.y * _b.z - _a.z * _b.y, _a.y * _b.w + _a.w * _b.y + _a.z * _b.x - _a.x * _b.z, _a.z * _b.w + _a.w * _b.z + _a.x * _b.y - _a.y * _b.x, _a.w * _b.w - _a.x * _b.x - _a.y * _b.y - _a.z * _b.z);
        public static Quaternion operator *(Quaternion _a, Vector3 _b) => new Quaternion(_a.w * _b.x  + _a.y * _b.z - _a.z * _b.y, _a.w * _b.y + _a.z * _b.x - _a.x * _b.z, _a.w * _b.z + _a.x * _b.y - _a.y * _b.x, -_a.x * _b.x - _a.y * _b.y - _a.z * _b.z);
        public static Quaternion operator *(Quaternion _a, float _b) => new Quaternion(_a.x * _b, _a.y * _b, _a.z * _b, _a.w * _b);
        public static Quaternion operator *(float _a, Quaternion _b) => new Quaternion(_a * _b.x, _a * _b.y, _a * _b.z, _a * _b.w);
        public static Quaternion operator /(Quaternion _a, float _b) => new Quaternion(_a.x / _b, _a.y / _b, _a.z / _b, _a.w / _b);

    }
}
