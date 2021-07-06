using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;
namespace LittleWormEngine
{
    class Camera : Component
    {
        public static float zNear = 0.001f;
        public static float zFar = 1000;
        public static float Width = Core.Width;
        public static float Height = Core.Height;
        public static float fov = 70f;
        public static Vector3 yAxis = Vector3.Forward;

        public GameObject Attaching_GameObject { get; set; }
        public string Tag { get; set; }

        public void Start()
        {

        }
        public void Update(string _Type)
        {

        }

        public Camera()
        {

        }

        public static void SetProjection(float _zNear, float _zFar, float _Width, float _Height, float _fov)
        {
            zNear = _zNear;
            zFar = _zFar;
            Width = _Width;
            Height = _Height;
            fov = _fov;
        }
    }
}
