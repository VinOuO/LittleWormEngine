using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Mathematics;

namespace LittleWormEngine.Utility
{
    class Matrix3
    {
        public float[,] Matrix { get; set; }
        static Matrix3 Zero = new Matrix3(Vector3.Zero,Vector3.Zero, Vector3.Zero);

        Matrix3(Vector3 _Row0, Vector3 _Row1, Vector3 _Row2)
        {
            Matrix = new float[3, 3];
            Matrix[0, 0] = _Row0.x; Matrix[0, 1] = _Row0.y; Matrix[0, 2] = _Row0.z;
            Matrix[1, 0] = _Row1.x; Matrix[1, 1] = _Row1.y; Matrix[1, 2] = _Row1.z;
            Matrix[2, 0] = _Row2.x; Matrix[2, 1] = _Row2.y; Matrix[2, 2] = _Row2.z;
        }

        public Vector3 Get_Vector3(string _Row_or_Col, int _No)
        {
            switch (_Row_or_Col)
            {
                case "Row":
                    return new Vector3(Matrix[_No, 0], Matrix[_No, 1], Matrix[_No, 2]);
                case "Col":
                    return new Vector3(Matrix[0, _No], Matrix[1, _No], Matrix[2, _No]);
            }
            return Vector3.Zero;
        }

        public static Matrix3 RotateX(float _Angle)
        {
            double _Radians = Math_of_Rotation.Radians_of(_Angle);
            return new Matrix3(new Vector3(1, 0, 0),
                               new Vector3(0, (float)Math.Cos(_Radians), -(float)Math.Sin(_Radians)), 
                               new Vector3(0, (float)Math.Sin(_Radians), (float)Math.Cos(_Radians)));
        }

        public static Matrix3 RotateY(float _Angle)
        {
            double _Radians = Math_of_Rotation.Radians_of(_Angle);
            return new Matrix3(new Vector3((float)Math.Cos(_Radians), 0, (float)Math.Sin(_Radians)), 
                               new Vector3(0, 1, 0), 
                               new Vector3(-(float)Math.Sin(_Radians), 0, (float)Math.Cos(_Radians)));
        }

        public static Matrix3 RotateZ(float _Angle)
        {
            double _Radians = Math_of_Rotation.Radians_of(_Angle);
            return new Matrix3(new Vector3((float)Math.Cos(_Radians), -(float)Math.Sin(_Radians), 0), 
                   new Vector3((float)Math.Sin(_Radians), (float)Math.Cos(Math_of_Rotation.Radians_of(_Angle)), 0), 
                   new Vector3(0, 0, 1));
        }

        public static Vector3 operator *(Vector3 _a, Matrix3 _b) => new Vector3(_a * _b.Get_Vector3("Col", 0), _a * _b.Get_Vector3("Col", 1), _a * _b.Get_Vector3("Col", 2));
        public static Vector3 operator *(Matrix3 _a, Vector3 _b) => new Vector3(_a.Get_Vector3("Row", 0) * _b, _a.Get_Vector3("Row", 1) * _b, _a.Get_Vector3("Row", 2) * _b);
    }
}
