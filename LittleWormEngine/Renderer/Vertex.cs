using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;

namespace LittleWormEngine.Renderer
{
    class Vertex
    {
        public static int Size = 8;
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }
        public Vector2 TexCoord { get; set; }
        string Combination;

        public Vertex(Vector3 _Position)
        {
            Position = _Position;
            TexCoord = new Vector2(Vector2.Zero);
        }

        public Vertex(Vector3 _Position, Vector2 _TexCoord)
        {
            Position = _Position;
            TexCoord = _TexCoord;
        }

        public Vertex(Vector3 _Position, Vector2 _TexCoord, Vector3 _Normal, string _Combination)
        {
            Position = _Position;
            Normal = _Normal;
            TexCoord = _TexCoord;
            Combination = _Combination;
        }

        public static int Find_Vertex(List<Vertex> _Vertices, string _Combination)
        {
            for(int i = 0; i < _Vertices.Count; i++)
            {
                if (_Vertices[i].Combination == _Combination)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
