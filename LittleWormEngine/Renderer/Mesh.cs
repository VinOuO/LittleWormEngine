using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;

namespace LittleWormEngine.Renderer
{
    class Mesh
    {
        public uint ID;
        public uint Vao;
        public uint Vbo;
        public uint Ibo;
        int Size;
        public List<Vertex> Vertices;
        public uint[] Indices;

        public Mesh()
        {
            ID = Core.Get_MeshID();
            Size = 0;
        }
 
        public void AddVertices(List<Vertex> _Vertices, List<uint> _Indices)
        {
            Vertices = _Vertices;

            Indices = new uint[_Indices.Count];
            for (int _Count = 0; _Count < _Indices.Count; _Count++)
            {
                Indices[_Count] = _Indices[_Count];
            }

            if(_Vertices[0].TexCoord == null || _Vertices[0].Normal == null)
            {
                SetVertices_OnlyPos();
            }
            else
            {
                SetVertices();
            }
        }

        public unsafe void SetVertices_OnlyPos()
        {
            float[] _Vertices = new float[Vertices.Count * 3];
            for (int i = 0, _Count = 0; _Count < Vertices.Count; i += 3, _Count++)
            {
                _Vertices[i] = Vertices[_Count].Position.x;
                _Vertices[i + 1] = Vertices[_Count].Position.y;
                _Vertices[i + 2] = Vertices[_Count].Position.z;
            }

            Vao = glGenVertexArray();
            glBindVertexArray(Vao);

            Vbo = glGenBuffer();
            glBindBuffer(GL_ARRAY_BUFFER, Vbo);
            fixed (void* p = &_Vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * _Vertices.Length, p, GL_STATIC_DRAW);
            }

            Ibo = glGenBuffer();
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);
            fixed (void* p = &Indices[0])
            {
                glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(uint) * Indices.Length, p, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 3, GL_FLOAT, false, 3 * sizeof(float), (IntPtr)0);
        }

        public unsafe void SetVertices()
        {
            float[] _Vertices = new float[Vertices.Count * Vertex.Size];
            for (int i = 0, _Count = 0; _Count < Vertices.Count; i += Vertex.Size, _Count++)
            {
                _Vertices[i] = Vertices[_Count].Position.x;
                _Vertices[i + 1] = Vertices[_Count].Position.y;
                _Vertices[i + 2] = Vertices[_Count].Position.z;
                _Vertices[i + 3] = Vertices[_Count].TexCoord.x;
                _Vertices[i + 4] = Vertices[_Count].TexCoord.y;
                _Vertices[i + 5] = Vertices[_Count].Normal.x;
                _Vertices[i + 6] = Vertices[_Count].Normal.y;
                _Vertices[i + 7] = Vertices[_Count].Normal.z;
            }
            
            Vao = glGenVertexArray();
            glBindVertexArray(Vao);

            Vbo = glGenBuffer();
            glBindBuffer(GL_ARRAY_BUFFER, Vbo);
            fixed (void* p = &_Vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * _Vertices.Length, p, GL_STATIC_DRAW);
            }

            Ibo = glGenBuffer();
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, Ibo);
            fixed (void* p = &Indices[0])
            {
                glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(uint) * Indices.Length, p, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 3, GL_FLOAT, false, Vertex.Size * sizeof(float), (IntPtr)0);
            glVertexAttribPointer(1, 2, GL_FLOAT, false, Vertex.Size * sizeof(float), (IntPtr)(sizeof(float) * 3));
            glVertexAttribPointer(2, 3, GL_FLOAT, false, Vertex.Size * sizeof(float), (IntPtr)(sizeof(float) * 5));
        }
    }
}
