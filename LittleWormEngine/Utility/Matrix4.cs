using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Mathematics;

namespace LittleWormEngine.Utility
{
    class Matrix4
    {
        public float[,] Matrix { get; set; }
        static Matrix4 Zero = new Matrix4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);

        Matrix4(Vector4 _Row0, Vector4 _Row1, Vector4 _Row2, Vector4 _Row3)
        {
            Matrix = new float[4, 4];
            Matrix[0, 0] = _Row0.x; Matrix[0, 1] = _Row0.y; Matrix[0, 2] = _Row0.z; Matrix[0, 3] = _Row0.w;
            Matrix[1, 0] = _Row1.x; Matrix[1, 1] = _Row1.y; Matrix[1, 2] = _Row1.z; Matrix[1, 3] = _Row1.w;
            Matrix[2, 0] = _Row2.x; Matrix[2, 1] = _Row2.y; Matrix[2, 2] = _Row2.z; Matrix[2, 3] = _Row2.w;
            Matrix[3, 0] = _Row3.x; Matrix[3, 1] = _Row3.y; Matrix[3, 2] = _Row3.z; Matrix[3, 3] = _Row3.w;
        }

        public Vector4 Get_Vector4(string _Row_or_Col, int _No)
        {
            switch (_Row_or_Col)
            {
                case "Row":
                    return new Vector4(Matrix[_No, 0], Matrix[_No, 1], Matrix[_No, 2], Matrix[_No, 3]);
                case "Col":
                    return new Vector4(Matrix[0, _No], Matrix[1, _No], Matrix[2, _No], Matrix[3, _No]);
            }
            return Vector4.Zero;
        }

        public static Matrix4 Identity()
        {
            return new Matrix4(new Vector4(1, 0, 0, 0), 
                               new Vector4(0, 1, 0, 0), 
                               new Vector4(0, 0, 1, 0), 
                               new Vector4(0, 0, 0, 1));
        }

        public static Matrix4 CameraTranslation(Vector3 _CameraPosition)
        {
            return new Matrix4(new Vector4(1, 0, 0, -_CameraPosition.x),
                               new Vector4(0, 1, 0, -_CameraPosition.y),
                               new Vector4(0, 0, 1, -_CameraPosition.z),
                               new Vector4(0, 0, 0, 1));
        }

        public static Matrix4 Translation(Vector3 _Position)
        {
            return new Matrix4(new Vector4(1, 0, 0, _Position.x), 
                               new Vector4(0, 1, 0, _Position.y), 
                               new Vector4(0, 0, 1, _Position.z), 
                               new Vector4(0, 0, 0, 1));
        }

        public static Matrix4 Scale(float _x, float _y, float _z)
        {
            return new Matrix4(new Vector4(_x, 0, 0, 0),
                               new Vector4(0, _y, 0, 0),
                               new Vector4(0, 0, _z, 0),
                               new Vector4(0, 0, 0, 1));
        }

        public static Matrix4 RotateX(float _Angle)
        {
            double _Radians = Math_of_Rotation.Radians_of(_Angle);
            return new Matrix4(new Vector4(1, 0, 0, 0), 
                               new Vector4(0, (float)Math.Cos(_Radians), (float)Math.Sin(_Radians), 0), 
                               new Vector4(0, -(float)Math.Sin(_Radians), (float)Math.Cos(_Radians), 0), 
                               new Vector4(0, 0, 0, 1));
        }

        public static Matrix4 RotateY(float _Angle)
        {
            double _Radians = Math_of_Rotation.Radians_of(_Angle);
            return new Matrix4(new Vector4((float)Math.Cos(_Radians), 0, -(float)Math.Sin(_Radians), 0), 
                               new Vector4(0, 1, 0, 0),
                               new Vector4((float)Math.Sin(_Radians), 0, (float)Math.Cos(_Radians), 0), 
                               new Vector4(0, 0, 0, 1));
        }

        public static Matrix4 RotateZ(float _Angle)
        {
            double _Radians = Math_of_Rotation.Radians_of(_Angle);
            return new Matrix4(new Vector4((float)Math.Cos(_Radians), -(float)Math.Sin(_Radians), 0, 0), 
                               new Vector4((float)Math.Sin(_Radians), (float)Math.Cos(_Radians), 0, 0), 
                               new Vector4(0, 0, 1, 0), 
                               new Vector4(0, 0, 0, 1));
        }
        
        public static Matrix4 OrthographicProjection(float _Right, float _Left, float _Top, float _Bottom, float _zFar, float _zNear)
        {
            return new Matrix4(new Vector4(2 / (_Right - _Left)                 , 0                                     , 0                                     , 0),
                               new Vector4(0                                    , 2  /(_Top - _Bottom)                  , 0                                     , 0),
                               new Vector4(0                                    , 0                                     , -2 / (_zFar-_zNear)                   , 0),
                               new Vector4(-(_Right + _Left) / (_Right - _Left) , -(_Top + _Bottom) / (_Top - _Bottom)  , -(_zFar + _zNear) / (_zFar - _zNear)  , 1));
        }

        public static Matrix4 GetCameraTransform()
        {
            Transform CameraTransform = Core.The_Camera.Attaching_GameObject.transform;
            return RotateX(CameraTransform.Rotation.x) * RotateY(CameraTransform.Rotation.y) * RotateZ(CameraTransform.Rotation.z) * CameraTranslation(CameraTransform.Position);
        }

        public static Matrix4 PerspectiveProjection(float _zNear, float _zFar, float _Width, float _Height, float _fov)
        {
            float _ar = _Width / _Height;
            float _tanHalffov = (float)Math.Tan(_fov / 2 * Math.PI/180);

            return new Matrix4(new Vector4(1 / (_tanHalffov * _ar), 0, 0, 0),
                               new Vector4(0, 1 / _tanHalffov, 0, 0),
                               new Vector4(0, 0, (_zFar + _zNear) / (_zFar - _zNear), -2 * _zNear * _zFar / (_zFar - _zNear)),
                               new Vector4(0, 0, 1, 0));
        }


        public static Matrix4 Flip(Matrix4 _Matrix)
        {
            return new Matrix4(_Matrix.Get_Vector4("Col", 0), _Matrix.Get_Vector4("Col", 1), _Matrix.Get_Vector4("Col", 2), _Matrix.Get_Vector4("Col", 3));
        }

        public static Vector4 operator *(Vector4 _a, Matrix4 _b) => new Vector4(_a * _b.Get_Vector4("Col", 0), _a * _b.Get_Vector4("Col", 1), _a * _b.Get_Vector4("Col", 2), _a * _b.Get_Vector4("Col", 3));
        public static Vector4 operator *(Matrix4 _a, Vector4 _b) => new Vector4(_a.Get_Vector4("Row", 0) * _b, _a.Get_Vector4("Row", 1) * _b, _a.Get_Vector4("Row", 2) * _b, _a.Get_Vector4("Row", 3) * _b);
        public static Matrix4 operator *(Matrix4 _a, Matrix4 _b) => new Matrix4(new Vector4(_a.Get_Vector4("Row", 0) * _b.Get_Vector4("Col", 0), _a.Get_Vector4("Row", 0) * _b.Get_Vector4("Col", 1), _a.Get_Vector4("Row", 0) * _b.Get_Vector4("Col", 2), _a.Get_Vector4("Row", 0) * _b.Get_Vector4("Col", 3)),
                                                                                new Vector4(_a.Get_Vector4("Row", 1) * _b.Get_Vector4("Col", 0), _a.Get_Vector4("Row", 1) * _b.Get_Vector4("Col", 1), _a.Get_Vector4("Row", 1) * _b.Get_Vector4("Col", 2), _a.Get_Vector4("Row", 1) * _b.Get_Vector4("Col", 3)), 
                                                                                new Vector4(_a.Get_Vector4("Row", 2) * _b.Get_Vector4("Col", 0), _a.Get_Vector4("Row", 2) * _b.Get_Vector4("Col", 1), _a.Get_Vector4("Row", 2) * _b.Get_Vector4("Col", 2), _a.Get_Vector4("Row", 2) * _b.Get_Vector4("Col", 3)), 
                                                                                new Vector4(_a.Get_Vector4("Row", 3) * _b.Get_Vector4("Col", 0), _a.Get_Vector4("Row", 3) * _b.Get_Vector4("Col", 1), _a.Get_Vector4("Row", 3) * _b.Get_Vector4("Col", 2), _a.Get_Vector4("Row", 3) * _b.Get_Vector4("Col", 3)));
    }
}
