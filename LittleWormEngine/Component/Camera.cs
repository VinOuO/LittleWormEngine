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
        public float zFar = 50;
        public float fov = 45;

        public float Width = Core.Width;
        public float Height = Core.Height;
        public float Top = Core.Height;
        public float Bottom = -Core.Height;
        public float Right = Core.Width;
        public float Left = -Core.Width;

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
            _AngleX = ((Input.MousePosition.x - Core.Width / 2) / (Core.Width / 2)) * (fov/2) * (double)Core.Width / (double)Core.Height;
            _AngleY = (((Input.MousePosition.y - Core.Height / 2) / (Core.Height / 2)) * -1) * (fov / 2);

            _X = 1 / Math.Cos(Mathematics.Math_of_Rotation.Radians_of(_AngleX));
            _Y = 1 / Math.Cos(Mathematics.Math_of_Rotation.Radians_of(_AngleY));
            //_TempVec3 = new Vector3(Math.Sqrt(_X * _X - 1) * (_AngleX >= 0 ? 1 : -1), Math.Sqrt(_Y * _Y - 1) * (_AngleY >= 0 ? 1 : -1), 1);
            if (Input.GetKeyDown(MouseCode.Left))
            {
                //Debug.Log("After X:" + _AngleX);
                //Debug.Log("After Y:" + _AngleY);
            }
            return new Vector3(Math.Sqrt(_X * _X - 1) * (_AngleX >= 0 ? 1 : -1), Math.Sqrt(_Y * _Y - 1) * (_AngleY >= 0 ? 1 : -1), 1);
        }
    }
}
