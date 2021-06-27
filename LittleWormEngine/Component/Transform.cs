using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;

namespace LittleWormEngine
{
    class Transform : Component
    {
        public GameObject Attaching_GameObject { get; set; }
        public Core The_Core { get; set; }
        public string Tag { get; set; }

        public void Start()
        {
            
        }

        public void Update(string _Type)
        {
            switch (_Type)
            {
                case "Editing":

                    break;
            }
        }



        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public Transform()
        {
            Tag = "Normal";
            Position = new Vector3(Vector3.Zero);
            Rotation = new Vector3(Vector3.Zero);
            Scale = new Vector3(Vector3.One);
        }

        public Matrix4 GetTransform(Vector3 _OffSet)
        {
            return Matrix4.Translation(Position - _OffSet) * Matrix4.RotateX(Rotation.x) * Matrix4.RotateY(Rotation.y) * Matrix4.RotateZ(Rotation.z) * Matrix4.Scale(Scale.x, Scale.y, Scale.z);
        }

        public Matrix4 GetProjectdTransform(Vector3 _OffSet)
        {
            Transform CameraTransform = Core.The_Camera.Attaching_GameObject.transform;
            return Matrix4.Projection(Camera.zNear, Camera.zFar, Camera.Width, Camera.Height, Camera.fov) * Matrix4.RotateX(CameraTransform.Rotation.x) * Matrix4.RotateY(CameraTransform.Rotation.y) * Matrix4.RotateZ(CameraTransform.Rotation.z) * Matrix4.CameraTranslation(CameraTransform.Position) * GetTransform(_OffSet);
        }

    }
}
