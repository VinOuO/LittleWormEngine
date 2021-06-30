using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;

namespace LittleWormEngine.Mathematics
{
    class Math_of_Rotation
    {
        public static double Radians_of(double _Angle)
        {
            return (Math.PI / 180) * _Angle;
        }

        public static double Angle_of(double _Radians)
        {
            return (180 / Math.PI) * _Radians;
        }
        /*
        public static double Radians_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            return (Math.Atan2(_VectorA.y, _VectorA.z) - Math.Atan2(_VectorB.y, _VectorB.z));
        }
        */
        /*
        public static double XAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            Vector3 _Temp = _VectorB - _VectorA;
            return ((Math.Atan2(_Temp.y, _Temp.x) - Math.Atan2(Vector3.Backward.y, Vector3.Backward.x)) * (180 / Math.PI));
        }
        public static double YAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            Vector3 _Temp = _VectorB - _VectorA;
            return ((Math.Atan2(_Temp.y, _Temp.z) - Math.Atan2(Vector3.Backward.y, Vector3.Backward.z)) * (180 / Math.PI));
        }
        public static double ZAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            Vector3 _Temp = _VectorB - _VectorA;
            return ((Math.Atan2(_Temp.z, _Temp.x) - Math.Atan2(Vector3.Backward.z, Vector3.Backward.x)) * (180 / Math.PI));
        }
        */

        public static float Angle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            return (float)Math.Acos(_VectorA * _VectorB / (_VectorA.Length() * _VectorB.Length()));
        }


        public static Vector3 Cross(Vector3 _VectorA, Vector3 _VectorB)
        {
            float _x, _y, _z;
            _x = _VectorA.y * _VectorB.z - _VectorB.y * _VectorA.z;
            _y = (_VectorA.x * _VectorB.z - _VectorB.x * _VectorA.z) * -1;
            _z = _VectorA.x * _VectorB.y - _VectorB.x * _VectorA.y;
            return new Vector3(_x, _y, _z);
        }

        public static float RoundAngle(float _Angle)
        {
            if(_Angle >= 0)
            {
                while (_Angle >= 360)
                {
                    _Angle -= 360;
                }
            }
            else
            {
                while (_Angle < 0)
                {
                    _Angle += 360;
                }
            }
            return _Angle;
        }

        public static double XAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            if (_VectorA.y == 0 && _VectorA.z == 0 || _VectorB.y == 0 && _VectorB.z == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.y, _VectorA.z) - Math.Atan2(_VectorB.y, _VectorB.z)) * (180 / Math.PI));
        }
        public static double XAngle_between(Vector3 _VectorA, Vector3 _VectorB, int a)
        {
            Console.WriteLine("VecA: " + (int)_VectorA.x + ", " + (int)_VectorA.y + ", " + (int)_VectorA.z);
            Console.WriteLine("VecB: " + (int)_VectorB.x + ", " + (int)_VectorB.y + ", " + (int)_VectorB.z);
            if (_VectorA.y == 0 && _VectorA.z == 0 || _VectorB.y == 0 && _VectorB.z == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.y, _VectorA.z) - Math.Atan2(_VectorB.y, _VectorB.z)) * (180 / Math.PI));
        }
        public static double YAngle_between(Vector3 _VectorA, Vector3 _VectorB, int a)
        {
            Console.WriteLine("VecA: " + (int)_VectorA.x + ", " + (int)_VectorA.y + ", " + (int)_VectorA.z);
            Console.WriteLine("VecB: " + (int)_VectorB.x + ", " + (int)_VectorB.y + ", " + (int)_VectorB.z);
            if (_VectorA.z == 0 && _VectorA.x == 0 || _VectorB.z == 0 && _VectorB.x == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.z, _VectorA.x) - Math.Atan2(_VectorB.z, _VectorB.x)) * (180 / Math.PI));
        }
        public static double YAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            if (_VectorA.z == 0 && _VectorA.x == 0 || _VectorB.z == 0 && _VectorB.x == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.z, _VectorA.x) - Math.Atan2(_VectorB.z, _VectorB.x)) * (180 / Math.PI));
        }

        public static double ZAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            if(_VectorA.y == 0 && _VectorA.x == 0 || _VectorB.y == 0 && _VectorB.x == 0)
            {
                return 0;
            }
            return -((Math.Atan2(_VectorA.y, _VectorA.x) - Math.Atan2(_VectorB.y, _VectorB.x)) * (180 / Math.PI));
        }
    }
}
