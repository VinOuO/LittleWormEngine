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

        public static float Radians_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            _VectorA = _VectorA.Normalize();
            _VectorB = _VectorB.Normalize();

            return (float)(Math.Acos(_VectorA * _VectorB));
        }


        public static Vector3 Cross(Vector3 _VectorA, Vector3 _VectorB)
        {
            float _x, _y, _z;
            _x = _VectorA.y * _VectorB.z - _VectorB.y * _VectorA.z;
            _y = _VectorB.x * _VectorA.z - _VectorA.x * _VectorB.z;
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
            if (Math.Round(_VectorA.y, 3) == 0 && Math.Round(_VectorA.z, 3) == 0 || Math.Round(_VectorB.y, 3) == 0 && Math.Round(_VectorB.z, 3) == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.y, -_VectorA.z) - Math.Atan2(_VectorB.y, -_VectorB.z)) * (180 / Math.PI));
        }
       
        public static double YAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            if (Math.Round(_VectorA.z, 3) == 0 && Math.Round(_VectorA.x, 3) == 0 || Math.Round(_VectorB.z, 3) == 0 && Math.Round(_VectorB.x, 3) == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.z, -_VectorA.x) - Math.Atan2(_VectorB.z, -_VectorB.x)) * (180 / Math.PI));
        }

        public static double ZAngle_between(Vector3 _VectorA, Vector3 _VectorB)
        {
            if(Math.Round(_VectorA.y, 3) == 0 && Math.Round(_VectorA.x, 3) == 0 || Math.Round(_VectorB.y, 3) == 0 && Math.Round(_VectorB.x, 3) == 0)
            {
                return 0;
            }
            return ((Math.Atan2(_VectorA.y, _VectorA.x) - Math.Atan2(_VectorB.y, _VectorB.x)) * (180 / Math.PI));
        }

        public static Vector3 EulerRotateZYZ(Vector3 _Vector, Vector3 _AxisFrom, Vector3 _AxisTo)
        {
            float _Temp_AngleZ, _Temp_AngleY, _Temp_AngleZ2;

            _Temp_AngleZ = (float)ZAngle_between(_AxisTo, _AxisFrom);
            _Temp_AngleY = (float)YAngle_between(_AxisTo, Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);
            _Temp_AngleZ2 = (float)ZAngle_between(_AxisTo, Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);
            _Vector = Matrix3.RotateZ(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _Vector;
            _AxisFrom = Matrix3.RotateZ(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom;

            return _Vector;
        }

        public static Vector3 EulerRotateR(Vector3 _Vector, Vector3 _AxisFrom, Vector3 _AxisTo)
        {
            float _Temp_AngleZ, _Temp_AngleY, _Temp_AngleX,_Temp_AngleZ2;

            _Temp_AngleZ = (float)ZAngle_between(_AxisTo, _AxisFrom);
            _Temp_AngleY = (float)YAngle_between(_AxisTo, Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);
            _Temp_AngleZ2 = (float)ZAngle_between(_AxisTo, Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);
            _Temp_AngleX = (float)XAngle_between(_AxisTo, Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);

            Vector3 _VecZYX, _VecZYZ;
            _VecZYX = Matrix3.RotateX(_Temp_AngleX) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom;
            _VecZYZ = Matrix3.RotateZ(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom;

            float _AngleZYX = Radians_between(_VecZYX, _AxisTo), _AngleZYZ = Radians_between(_VecZYZ, _AxisTo);
            if (_AngleZYX > 0.1f)
            {
                if(_AngleZYZ > 0.1f)
                {
                    //Debug.Log("Rotate Failed => AngleZYX: " + _AngleZYX + " AngleZYZ: " + _AngleZYZ);
                    return (_AngleZYX > _AngleZYZ? Matrix3.RotateZ(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _Vector : Matrix3.RotateX(_Temp_AngleX) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _Vector);
                }
                return Matrix3.RotateZ(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _Vector;
            }
            return Matrix3.RotateX(_Temp_AngleX) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _Vector;
        }

        public static Vector3 EulerRotate(Vector3 _Vector, Vector3 _AxisFrom, Vector3 _AxisTo)
        {
            float _RotateAngle = Radians_between(_AxisTo, _AxisFrom);
            _AxisTo = _AxisTo.Normalize();
            _AxisFrom = _AxisFrom.Normalize();

            if (Math.Round(Angle_of(_RotateAngle)) == 0 || Math.Round(Angle_of(_RotateAngle)) == 180)
            {
                if(_AxisTo.x * _AxisFrom.x >= 0 && _AxisTo.y * _AxisFrom.y >= 0 && _AxisTo.z * _AxisFrom.z >= 0)
                {
                    return _Vector;
                }
                else
                {
                    return -_Vector;
                }
            }
            return Matrix3.Rotate(Cross(_AxisFrom, _AxisTo).Normalize(), _RotateAngle) * _Vector;
        }

        public static  Vector3 EulerAngle(Vector3 _AxisTo)
        {
            Vector3 _Rot = Vector3.Zero;
            _Rot.x = (float)Math.Atan2(_AxisTo.y, _AxisTo.z);
            if (_AxisTo.z >= 0)
            {
                _Rot.y = -(float)Math.Atan2(_AxisTo.x * (float)Math.Cos(_Rot.x), _AxisTo.z);
            }
            else
            {
                _Rot.y = (float)Math.Atan2(_AxisTo.x * (float)Math.Cos(_Rot.x), -_AxisTo.z);
            }
            _Rot.z = (float)Math.Atan2(Math.Cos(_Rot.x), Math.Sin(_Rot.x) * Math.Sin(_Rot.y));
            return _Rot;
        }

        public static Vector3 EulerRotateZYZ0(Vector3 _Vector, Vector3 _AxisFrom, Vector3 _AxisTo)
        {
            Vector3 _Rot = EulerAngle(_AxisTo);
            _Vector = Matrix3.RotateZ(_Rot.z) * Matrix3.RotateY(_Rot.y) * Matrix3.RotateX(_Rot.x) * _Vector;

            return _Vector;
        }

        public static Vector3 EulerRotateZYZ4(Vector3 _Vector, Vector3 _AxisFrom, Vector3 _AxisTo)
        {
            int Try = 100;
            float _Temp_AngleX, _Temp_AngleY, _Temp_AngleZ;

            while(Try > 0)
            {
                _Temp_AngleZ = (float)ZAngle_between(_AxisTo, _AxisFrom);
                _Vector *= Matrix3.RotateZ(_Temp_AngleZ);
                _AxisFrom *= Matrix3.RotateZ(_Temp_AngleZ);
                _Temp_AngleZ = (float)YAngle_between(_AxisTo, _AxisFrom);
                _Vector *= Matrix3.RotateY(_Temp_AngleZ);
                _AxisFrom *= Matrix3.RotateY(_Temp_AngleZ);
                _Temp_AngleZ = (float)XAngle_between(_AxisTo, _AxisFrom);
                _Vector *= Matrix3.RotateX(_Temp_AngleZ);
                _AxisFrom *= Matrix3.RotateX(_Temp_AngleZ);

                if (Math.Abs((float)ZAngle_between(_AxisTo, _AxisFrom)) < 3 && Math.Abs((float)YAngle_between(_AxisTo, _AxisFrom)) < 3 && Math.Abs((float)XAngle_between(_AxisTo, _AxisFrom)) < 3)
                    break;
            }
            return _Vector;
        }


        public static Vector3 EulerRotateZYZ1(Vector3 _Vector, Vector3 _AxisFrom, Vector3 _AxisTo)
        {
            float _Temp_AngleZ, _Temp_AngleY, _Temp_AngleZ2;

            _Temp_AngleZ = (float)ZAngle_between(_AxisTo, _AxisFrom);
            _Temp_AngleY = (float)YAngle_between(_AxisTo, Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);
            _Temp_AngleZ2 = (float)ZAngle_between(_AxisTo, Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom);
            _Vector = Matrix3.RotateX(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * Matrix3.RotateZ(_Temp_AngleZ) * Matrix3.RotateZ(_Temp_AngleZ) * _Vector;
            _AxisFrom = Matrix3.RotateX(_Temp_AngleZ2) * Matrix3.RotateY(_Temp_AngleY) * Matrix3.RotateZ(_Temp_AngleZ) * _AxisFrom;

            return _Vector;
        }

        public static Vector3 EulerZXZRotate(Vector3 _VectorFrom, Vector3 _VectorTo)
        {
            float _Temp_AngleZ, _Temp_AngleX, _Temp_AngleZ2;

            _Temp_AngleZ = (float)ZAngle_between(_VectorTo, Vector3.Backward);
            _VectorFrom *= Matrix3.RotateZ(_Temp_AngleZ);
            _Temp_AngleX = (float)XAngle_between(_VectorTo, Matrix3.RotateZ(_Temp_AngleZ) * Vector3.Backward);
            _VectorFrom *= Matrix3.RotateX(_Temp_AngleX);
            _Temp_AngleZ2 = (float)ZAngle_between(_VectorTo, Matrix3.RotateX(_Temp_AngleX) * Matrix3.RotateZ(_Temp_AngleZ) * Vector3.Backward);
            _VectorFrom *= Matrix3.RotateZ(_Temp_AngleZ2);
            return _VectorFrom;
        }
    }
}
