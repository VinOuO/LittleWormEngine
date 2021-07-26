using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;
namespace LittleWormEngine
{
    class Camera : Component
    {
        public static Camera Main { get { return Core.MainCamera; } }

        public float zNear = 0.1f;
        public float zFar = 100;
        public float Width = Core.Width;
        public float Height = Core.Height;
        public float Top = Core.Height / 2;
        public float Bottom = -Core.Height / 2;
        public float Right = Core.Width / 2;
        public float Left = -Core.Width / 2;
        public float fov = 45;
        public Vector3 yAxis = Vector3.Forward;

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
            Core.MainCamera = this;
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
            _AngleX = ((Input.MousePosition.x - Width / 2) / (Width / 2)) * (fov/2) * (Width / Height);
            _AngleY = (((Input.MousePosition.y - Height / 2) / (Height / 2)) * -1) * (fov / 2);

            _X = 1 / Math.Cos(Mathematics.Math_of_Rotation.Radians_of(_AngleX));
            _Y = 1 / Math.Cos(Mathematics.Math_of_Rotation.Radians_of(_AngleY));
            return new Vector3(Math.Sqrt(_X * _X - 1) * (_AngleX >= 0 ? 1 : -1), Math.Sqrt(_Y * _Y - 1) * (_AngleY >= 0 ? 1 : -1), 1);
        }
    }
}
