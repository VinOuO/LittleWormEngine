using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;
using GLFW;
using static OpenGL.GL;

namespace LittleWormEngine
{
    class CapsuleCollider : Collider
    {

        public Vector2 RadiusHeight { get; private set; }

        public unsafe void Draw()
        {
            glEnableVertexAttribArray(0);

            glDrawElements(GL_TRIANGLES, RenderMesh.Indices.Length, GL_UNSIGNED_INT, NULL);

            glDisableVertexAttribArray(0);
        }

        public void Set_BoxColiiderSize(Vector3 _HalfSize)
        {
            List<object> _Parameters = new List<object>();
            _Parameters.Add(_HalfSize);
            Set_ColliderSize(_Parameters);
        }

        /// <summary>
        /// _Size_Parameters[0] = RadiusHeight
        /// </summary>
        /// <param name="_Size_Parameters"></param>
        public override void Set_ColliderSize(List<object> _Size_Parameters)
        {
            RadiusHeight = (Vector2)_Size_Parameters[0];
            ColliderSize_Changed = true;
        }

        public string MeshFileName;
        public string TextureFileName;
        public Mesh RenderMesh { get; set; }
        public Texture RenderTexture { get; set; }
        public Shader RenderShader { get; set; }

        public CapsuleCollider()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Tag = "Renderer";
                    break;
                case "Game":
                    Tag = "Collider";
                    break;
            }
            OffSet = Vector3.Zero;
            RadiusHeight = Vector2.One;
            Is_Trigger = false;
        }

        public void Set_Mesh(Mesh _RenderMesh, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderShader = _RenderShader;
            RenderShader.AddUniform("transform");
        }

        protected override BulletSharp.CollisionShape Create_Shape()
        {
            return PhysicsWorld.Create_CapsuleShape(RadiusHeight);
        }

        protected override Mesh ColliderMesh()
        {
            Mesh _Mesh = new Mesh();
            RenderUtility.MeshData _Temp = new RenderUtility.MeshData();
            float _Scaler = 0.05f;

            _Temp.Add_MeshData(RenderUtility.Get_HalfRingMesh(Vector3.Up * RadiusHeight.y / 2, Vector3.Backward, Vector3.Up, RadiusHeight.x, 20, _Scaler, false));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(Vector3.Up * RadiusHeight.y / 2 + Vector3.Left * RadiusHeight.x, Vector3.Down * RadiusHeight.y / 2 + Vector3.Left * RadiusHeight.x, 1f * _Scaler));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(Vector3.Up * RadiusHeight.y / 2 + Vector3.Right * RadiusHeight.x, Vector3.Down * RadiusHeight.y / 2 + Vector3.Right * RadiusHeight.x, 1f * _Scaler));
            _Temp.Add_MeshData(RenderUtility.Get_HalfRingMesh(Vector3.Down * RadiusHeight.y / 2, Vector3.Forward, Vector3.Up, RadiusHeight.x, 20, _Scaler, false));

            _Temp.Add_MeshData(RenderUtility.Get_HalfRingMesh(Vector3.Up * RadiusHeight.y / 2, Vector3.Left, Vector3.Right, RadiusHeight.x, 20, _Scaler, false));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(Vector3.Up * RadiusHeight.y / 2 + Vector3.Backward * RadiusHeight.x, Vector3.Down * RadiusHeight.y / 2 + Vector3.Backward * RadiusHeight.x, 1f * _Scaler));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(Vector3.Up * RadiusHeight.y / 2 + Vector3.Forward * RadiusHeight.x, Vector3.Down * RadiusHeight.y / 2 + Vector3.Forward * RadiusHeight.x, 1f * _Scaler));
            _Temp.Add_MeshData(RenderUtility.Get_HalfRingMesh(Vector3.Down * RadiusHeight.y / 2, Vector3.Right, Vector3.Right, RadiusHeight.x, 20, _Scaler, true));

            _Temp.Add_MeshData(RenderUtility.Get_RingMesh(Vector3.Down * RadiusHeight.y / 2, Vector3.Up, Vector3.Up, RadiusHeight.x, 20, _Scaler, 1f));
            _Temp.Add_MeshData(RenderUtility.Get_RingMesh(Vector3.Up * RadiusHeight.y / 2, Vector3.Up, Vector3.Up, RadiusHeight.x, 20, _Scaler, 1f));

            _Mesh.AddVertices(_Temp.Vertices, _Temp.Indices);

            return _Mesh;
        }

    }
}
