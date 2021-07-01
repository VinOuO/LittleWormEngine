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
        public Vector3 OffSet { get; set; }
        public Vector3 HalfSize { get; set; }

        public void Start()
        {

        }

        public void Update(string _Type)
        {
            switch (_Type)
            {
                case "Rendering":
                    glUseProgram(RenderShader.Program);
                    glBindVertexArray(RenderMesh.Vao);
                    RenderShader.SetUniform("transform", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(OffSet));
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

        public string MeshFileName;
        public string TextureFileName;
        public Mesh RenderMesh { get; set; }
        public Texture RenderTexture { get; set; }
        public Shader RenderShader { get; set; }
        public BoxCollider()
        {
            Tag = "Renderer";
            OffSet = Vector3.Zero;
            HalfSize = Vector3.One;
            /*
            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();
            
            _Vertices.Add(new Vertex(new Vector3(-1, -1, 1)));
            _Vertices.Add(new Vertex(new Vector3(1,-1, 1)));
            _Vertices.Add(new Vertex(new Vector3(-1, 1, 1)));
            _Vertices.Add(new Vertex(new Vector3(1, 1, 1)));
            _Vertices.Add(new Vertex(new Vector3(-1, 1, -1)));
            _Vertices.Add(new Vertex(new Vector3(1, 1, -1)));
            _Vertices.Add(new Vertex(new Vector3(-1, -1, -1)));
            _Vertices.Add(new Vertex(new Vector3(1, -1, -1)));
            
            _Indices.Add(1 - 1); _Indices.Add(3 - 1); _Indices.Add(2 - 1);
            _Indices.Add(3 - 1); _Indices.Add(2 - 1); _Indices.Add(4 - 1);
            _Indices.Add(3 - 1); _Indices.Add(4 - 1); _Indices.Add(5 - 1);
            _Indices.Add(5 - 1); _Indices.Add(4 - 1); _Indices.Add(6 - 1);
            _Indices.Add(5 - 1); _Indices.Add(6 - 1); _Indices.Add(7 - 1);
            _Indices.Add(7 - 1); _Indices.Add(6 - 1); _Indices.Add(8 - 1);
            _Indices.Add(7 - 1); _Indices.Add(8 - 1); _Indices.Add(1 - 1);
            _Indices.Add(1 - 1); _Indices.Add(8 - 1); _Indices.Add(2 - 1);
            _Indices.Add(2 - 1); _Indices.Add(8 - 1); _Indices.Add(4 - 1);
            _Indices.Add(4 - 1); _Indices.Add(8 - 1); _Indices.Add(6 - 1);
            _Indices.Add(7 - 1); _Indices.Add(1 - 1); _Indices.Add(5 - 1);
            _Indices.Add(5 - 1); _Indices.Add(1 - 1); _Indices.Add(3 - 1);
            //_Mesh.AddVertices(_Vertices, _Indices);
            */
            
            Set(BoxColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
        }

        public void Set(Mesh _RenderMesh, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderShader = _RenderShader;
            RenderShader.AddUniform("transform");
        }

        Mesh BoxColliderMesh()
        {
            Mesh _Mesh = new Mesh();
            /*
            RenderUtility.MeshData _Temp = RenderUtility.Get_LineMesh(-HalfSize, new Vector3(HalfSize.x, -HalfSize.y, -HalfSize.z) * 0.3f, 0.05f);
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(-HalfSize, new Vector3(-HalfSize.x, HalfSize.y, -HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(-HalfSize, new Vector3(-HalfSize.x, -HalfSize.y, HalfSize.z) * 0.3f, 0.05f));


            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(-HalfSize.x, HalfSize.y, HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(HalfSize.x, -HalfSize.y, HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(HalfSize.x, HalfSize.y, -HalfSize.z) * 0.3f, 0.05f));

            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(-HalfSize.x, HalfSize.y, HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(HalfSize.x, -HalfSize.y, HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(HalfSize.x, HalfSize.y, -HalfSize.z) * 0.3f, 0.05f));

            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(-HalfSize.x, HalfSize.y, HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(HalfSize.x, -HalfSize.y, HalfSize.z) * 0.3f, 0.05f));
            _Temp.Add_MeshData(RenderUtility.Get_LineMesh(HalfSize, new Vector3(HalfSize.x, HalfSize.y, -HalfSize.z) * 0.3f, 0.05f));
            */
            RenderUtility.MeshData _Temp = new RenderUtility.MeshData();
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        Vector3 _Temp_Vec3 = new Vector3((i == 0 ? -1 : 1) * HalfSize.x, (j == 0 ? -1 : 1) * HalfSize.y, (k == 0 ? -1 : 1) * HalfSize.z);

                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(-_Temp_Vec3.x * 0.5f, 0, 0) + _Temp_Vec3, 0.05f));
                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(0, -_Temp_Vec3.y * 0.5f, 0) + _Temp_Vec3, 0.05f));
                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(0, 0, -_Temp_Vec3.z * 0.5f) + _Temp_Vec3, 0.05f));
                    }
                }
            }
            _Mesh.AddVertices(_Temp.Vertices, _Temp.Indices);

            return _Mesh;
        }
    }
}
