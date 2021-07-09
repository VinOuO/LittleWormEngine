using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;
using GLFW;
using static OpenGL.GL;

namespace LittleWormEngine
{
    class BoxCollider : Component
    {
        public GameObject Attaching_GameObject { get; set; }
        public string Tag { get; set; }
        public bool Started = false;
        public Vector3 OffSet { get; set; }
        public Vector3 HalfSize { get; private set; }
        public RigiBody Attaching_Rigibody {get;set;}

        public void Start()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Set_Mesh(BoxColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
                    break;
                case "Game":
                    Attaching_Rigibody = new RigiBody(PhysicWorld.Get_Rigibody(Attaching_GameObject));
                    if (Attaching_Rigibody.Is_Static)
                    {
                        Attaching_Rigibody.Set_Static();
                    }
                    break;
            }
            HalfSize.x *= Attaching_GameObject.transform.Scale.x;
            HalfSize.y *= Attaching_GameObject.transform.Scale.y;
            HalfSize.z *= Attaching_GameObject.transform.Scale.z;
            Started = true;
        }

        public void Update(string _Type)
        {
            if (!Started)
            {
                Start();
            }

            if (HalfSize_Changed)
            {
                HalfSize_Changed = false;
                Modify_Collider();
            }

            switch (_Type)
            {
                case "Rendering":
                    glUseProgram(RenderShader.Program);
                    glBindVertexArray(RenderMesh.Vao);
                    RenderShader.SetUniform("transform", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransformwithoutScale(OffSet));
                    Draw();
                    break;
            }
        } 

        public unsafe void Draw()
        {
            glEnableVertexAttribArray(0);

            glDrawElements(GL_TRIANGLES, RenderMesh.Indices.Length, GL_UNSIGNED_INT, NULL);

            glDisableVertexAttribArray(0);
        }

        bool HalfSize_Changed = false;
        public void Set_ColliderSize(Vector3 _HalfSize)
        {
            HalfSize = _HalfSize;
            _HalfSize.x *= Attaching_GameObject.transform.Scale.x;
            _HalfSize.y *= Attaching_GameObject.transform.Scale.y;
            _HalfSize.z *= Attaching_GameObject.transform.Scale.z;
            HalfSize_Changed = true;
        }

        void Modify_Collider()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Set_Mesh(BoxColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
                    break;
                case "Game":
                    PhysicWorld.Get_Rigibody(Attaching_GameObject).CollisionShape = PhysicWorld.Create_Box_Shape(HalfSize);
                    break;
            }
        }

        public string MeshFileName;
        public string TextureFileName;
        public Mesh RenderMesh { get; set; }
        public Texture RenderTexture { get; set; }
        public Shader RenderShader { get; set; }
        bool Mesh_Changed = false;
        public BoxCollider()
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
            HalfSize = Vector3.One;
        }

        public void Set_Mesh(Mesh _RenderMesh, Shader _RenderShader)
        { 
            RenderMesh = _RenderMesh;
            RenderShader = _RenderShader;
            RenderShader.AddUniform("transform");
        }

        Mesh BoxColliderMesh()
        {
            Mesh _Mesh = new Mesh();
            RenderUtility.MeshData _Temp = new RenderUtility.MeshData();
            float _Sacler = 0.05f;
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        Vector3 _Temp_Vec3 = new Vector3((i == 0 ? -1 : 1) * HalfSize.x, (j == 0 ? -1 : 1) * HalfSize.y, (k == 0 ? -1 : 1) * HalfSize.z);

                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(-_Temp_Vec3.x * 0.5f, 0, 0) + _Temp_Vec3, 1f * _Sacler));
                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(0, -_Temp_Vec3.y * 0.5f, 0) + _Temp_Vec3, 1f * _Sacler));
                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(0, 0, -_Temp_Vec3.z * 0.5f) + _Temp_Vec3, 1f * _Sacler));
                    }
                }
            }
            _Mesh.AddVertices(_Temp.Vertices, _Temp.Indices);

            return _Mesh;
        }
    }
}
