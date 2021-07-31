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


        Vector3 position;
        public Vector3 Position { get { return position; } set { Set_ColliderPos(value); position = value; } }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public Transform()
        {
            Tag = "Normal";
            OnlySet_Position(Vector3.Zero);
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }

        public void OnlySet_Position(Vector3 _Pos)
        {
            position = _Pos;
        }

        public void Set_ColliderPos(Vector3 _Pos)
        {
            if (Attaching_GameObject != null)
            {
                if (Attaching_GameObject.ColliderComponent != null)
                {
                    Attaching_GameObject.ColliderComponent.Set_Position(_Pos);
                }
            }
        }

        public Matrix4 GetTransform(Vector3 _OffSet)
        {
            return Matrix4.Translation(Position - _OffSet) * Matrix4.RotateX(Rotation.x) * Matrix4.RotateY(Rotation.y) * Matrix4.RotateZ(Rotation.z) * Matrix4.Scale(Scale.x, Scale.y, Scale.z);
        }

        public Matrix4 GetProjectdTransform(Vector3 _OffSet)
        {
            Transform CameraTransform = Core.The_Camera.Attaching_GameObject.transform;
            //return Matrix4.Flip(Matrix4.OrthographicProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov)) * Matrix4.RotateX(CameraTransform.Rotation.x) * Matrix4.RotateY(CameraTransform.Rotation.y) * Matrix4.RotateZ(CameraTransform.Rotation.z) * Matrix4.CameraTranslation(CameraTransform.Position) * GetTransform(_OffSet);
            return Matrix4.PerspectiveProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov) * Matrix4.RotateX(CameraTransform.Rotation.x) * Matrix4.RotateY(CameraTransform.Rotation.y) * Matrix4.RotateZ(CameraTransform.Rotation.z) * Matrix4.CameraTranslation(CameraTransform.Position) * GetTransform(_OffSet);
        }

        public Matrix4 GetTransformwithoutScale(Vector3 _OffSet)
        {
            return Matrix4.Translation(Position - _OffSet) * Matrix4.RotateX(Rotation.x) * Matrix4.RotateY(Rotation.y) * Matrix4.RotateZ(Rotation.z);
        }

        public Matrix4 GetProjectdTransformwithoutScale(Vector3 _OffSet)
        {
            Transform CameraTransform = Core.The_Camera.Attaching_GameObject.transform;
            return Matrix4.PerspectiveProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov) * Matrix4.RotateX(CameraTransform.Rotation.x) * Matrix4.RotateY(CameraTransform.Rotation.y) * Matrix4.RotateZ(CameraTransform.Rotation.z) * Matrix4.CameraTranslation(CameraTransform.Position) * GetTransformwithoutScale(_OffSet);
        }
    }
}
