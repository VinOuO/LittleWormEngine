using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;
namespace LittleWormEngine
{
    class Camera : Component
    {
        public static Camera Main { get { return Core.MainCamera; } }
        public Transform transform { get { return Attaching_GameObject.transform; } }
        public float zNear = 0.1f;
        public float zFar = 200;
        public float fov = 45;

        public float Width = Core.Width;
        public float Height = Core.Height;
        public float Top = Core.Height;
        public float Bottom = -Core.Height;
        public float Right = Core.Width;
        public float Left = -Core.Width;

        public float Zoomer = 0.25f;

        public Vector3 ForwardDir { get {Vector4 _Temp = Matrix4.RotateX(transform.Rotation.x) * Matrix4.RotateY(transform.Rotation.y)  * Matrix4.RotateZ(transform.Rotation.z) * new Vector4(Vector3.Forward, 1);return new Vector3(-_Temp.x,(_Temp.z < 0? 1:-1) * _Temp.y, _Temp.z); } }
        public Vector3 RightDir { get { Vector4 _Temp = Matrix4.RotateX(transform.Rotation.x) * Matrix4.RotateY(transform.Rotation.y + 90) * Matrix4.RotateZ(transform.Rotation.z) * new Vector4(Vector3.Forward, 1); return new Vector3(-_Temp.x, (_Temp.z < 0 ? 1 : -1) * _Temp.y, _Temp.z); } }

        public GameObject Attaching_GameObject { get; set; }
        public string Tag { get; set; }

        public void Start()
        {

        }
        public void Update(string _Type)
        {
            /*
            if (Input.GetKeyDown(KeyCode.Up))
            {
                fov += 3;
            }
            if (Input.GetKeyDown(KeyCode.Down))
            {
                fov -= 3;
            }
            */
        }

        public Camera()
        {

        }

        public void SetProjection(float _zNear, float _zFar, float _Width, float _Height, float _fov)
        {
            zNear = _zNear;
            zFar = _zFar;
            Width = _Width;
            Height = _Height;
            fov = _fov;
        }

        public Vector3 Get_MouseDir()
        {
            Vector3 _TempVec3 = Vector3.Zero;
            double _AngleX, _AngleY, _X, _Y;
            _AngleX = ((Input.MousePosition.x - Core.Width / 2) / (Core.Width / 2)) * (fov/2) * (double)Core.Width / (double)Core.Height;
            _AngleY = (((Input.MousePosition.y - Core.Height / 2) / (Core.Height / 2)) * -1) * (fov / 2);

            _X = 1 / Math.Cos(Mathematics.Math_of_Rotation.Radians_of(_AngleX));
            _Y = 1 / Math.Cos(Mathematics.Math_of_Rotation.Radians_of(_AngleY));
            _TempVec3 = new Vector3(Math.Sqrt(_X * _X - 1) * (_AngleX >= 0 ? 1 : -1), Math.Sqrt(_Y * _Y - 1) * (_AngleY >= 0 ? 1 : -1), 1);
            //Transform _Trans = Main.transform;
            //return Matrix3.RotateX(-_Trans.Rotation.x) * Matrix3.RotateY(_Trans.Rotation.y) * Matrix3.RotateZ(_Trans.Rotation.z) * _TempVec3;
            if (Input.GetKeyDown(MouseCode.Left))
            {
                //Debug.Log(_TempVec3);
                //Debug.Log(ForwardDir);
                //Debug.Log(Mathematics.Math_of_Rotation.ForwardBasedRotate(_TempVec3, Vector3.Forward));
            }
            return Mathematics.Math_of_Rotation.ForwardBasedRotate(_TempVec3, ForwardDir, Vector3.Up);
            return Mathematics.Math_of_Rotation.ForwardBasedRotate(_TempVec3, Vector3.Up * -0.1f +Vector3.Left +Vector3.Forward, Vector3.Up);
        }

        public static Vector2 Get_MousePos()
        {
            return new Vector2((Input.MousePosition.x - Core.Width / 2) / (Core.Width / 2), -1 * (Input.MousePosition.y - Core.Height / 2) / (Core.Height / 2));
        }
    }
}
