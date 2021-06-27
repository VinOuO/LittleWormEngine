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
            OffSet = new Vector3(Vector3.Zero);

            Mesh _Mesh = new Mesh();
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
            RenderUtility.MeshData _Temp = RenderUtility.Get_LineMesh(Vector3.Zero, Vector3.Right * 3, 0.05f);
            _Mesh.AddVertices(_Temp.Vertices, _Temp.Indices);
            Set(_Mesh, new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
        }

        public void Set(Mesh _RenderMesh, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderShader = _RenderShader;
            RenderShader.AddUniform("transform");
        }
    }
}
