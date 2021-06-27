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
    }
}
