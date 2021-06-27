using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine.Utility;

namespace LittleWormEngine.Renderer
{
    class RenderUtility
    {
        public static void ClearScreen()
        {
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        }

        public static void SetTexture(bool _Enable)
        {
            if (_Enable)
            {
                glEnable(GL_TEXTURE_2D);
            }
            else
            {
                glDisable(GL_TEXTURE_2D);
            }
        }

        public static void InitGraphics()
        {
            glClearColor(0, 0, 0, 1);
            glEnable(GL_CULL_FACE);
            glEnable(GL_DEPTH_TEST);
            glFrontFace(GL_CW);
            glCullFace(GL_BACK);
            //TODO :Depth clamp for later
            SetTexture(true);
            glEnable(GL_FRAMEBUFFER_SRGB);
        }

        public static void SetBackGroundColor(Vector4 _RGBA)
        {
            glClearColor(_RGBA.x, _RGBA.y, _RGBA.z, _RGBA.w);
        }

        public static string GetOpenGLVersion()
        {
            return (glGetString(GL_VERSION));
        }

        public static void PrepareContext()
        {
            Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.Decorated, true);
        }

        public class MeshData
        {
            public List<Vertex> Vertices = new List<Vertex>();
            public List<uint> Indices = new List<uint>();

            public MeshData(List<Vertex> _Vertices, List<uint> _Indices)
            {
                Vertices = _Vertices;
                Indices = _Indices;
            }
        }

        public static MeshData Get_LineMesh(Vector3 _StartPos, Vector3 _EndPos, float _Radius)
        {
            int _SectorCount = 100;
            float _SectorStep = 2 * (float)Math.PI / _SectorCount;
            float _SectorAngle;

            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();

            _Vertices.Add(new Vertex(new Vector3(_StartPos)));
            for (int i = 1; i <= _SectorCount + 1; i++)
            {
                _SectorAngle = i * _SectorStep;
                Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);
                float _Temp_Angle = 0;

                Console.WriteLine((float)Mathematics.Math_of_Rotation.ZAngle_between(_StartPos, _EndPos));
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.ZAngle_between(_StartPos, _EndPos);
                _Temp_Vec3 *= Matrix3.RotateZ(_Temp_Angle);

                Console.WriteLine((float)Mathematics.Math_of_Rotation.YAngle_between(Matrix3.RotateZ(_Temp_Angle) * _StartPos, Matrix3.RotateZ(_Temp_Angle) * _EndPos));
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.YAngle_between(Matrix3.RotateZ(_Temp_Angle) * _StartPos, Matrix3.RotateZ(_Temp_Angle) * _EndPos);
                _Temp_Vec3 *= Matrix3.RotateY(_Temp_Angle);

                Console.WriteLine((float)Mathematics.Math_of_Rotation.XAngle_between(Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _StartPos), Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _EndPos)));
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.XAngle_between(Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _StartPos), Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _EndPos));
                _Temp_Vec3 *= Matrix3.RotateX(_Temp_Angle);
                _Vertices.Add(new Vertex(_Temp_Vec3 + _StartPos));
                if(i >= 2)
                {
                    _Indices.Add(0); _Indices.Add((uint)i); _Indices.Add((uint)i - 1);
                }
            }
            
            _Vertices.Add(new Vertex(new Vector3(_EndPos)));
            int _Temp_Vertices_Num = _Vertices.Count;
            for (int i = _Temp_Vertices_Num, _Origin_Index = _Temp_Vertices_Num - 1; i <= _SectorCount + _Temp_Vertices_Num; i++)
            {
                _SectorAngle = i * _SectorStep;
                Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);
                float _Temp_Angle = 0;

                Console.WriteLine((float)Mathematics.Math_of_Rotation.ZAngle_between(_StartPos, _EndPos));
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.ZAngle_between(_StartPos, _EndPos);
                _Temp_Vec3 *= Matrix3.RotateZ(_Temp_Angle);

                Console.WriteLine((float)Mathematics.Math_of_Rotation.YAngle_between(Matrix3.RotateZ(_Temp_Angle) * _StartPos, Matrix3.RotateZ(_Temp_Angle) * _EndPos));
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.YAngle_between(Matrix3.RotateZ(_Temp_Angle) * _StartPos, Matrix3.RotateZ(_Temp_Angle) * _EndPos);
                _Temp_Vec3 *= Matrix3.RotateY(_Temp_Angle);

                Console.WriteLine((float)Mathematics.Math_of_Rotation.XAngle_between(Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _StartPos), Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _EndPos)));
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.XAngle_between(Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _StartPos), Matrix3.RotateZ(_Temp_Angle) * (Matrix3.RotateY(_Temp_Angle) * _EndPos));
                _Temp_Vec3 *= Matrix3.RotateX(_Temp_Angle);
                _Vertices.Add(new Vertex(_Temp_Vec3 + _EndPos));
                if (i >= 2)
                {
                    _Indices.Add((uint)_Origin_Index); _Indices.Add((uint)i - 1); _Indices.Add((uint)i);
                }
            }

            for (int i = 2, j = _Temp_Vertices_Num + 1; i <= _SectorCount + 1; i++, j++)
            {
                _Indices.Add((uint)i); _Indices.Add((uint)j); _Indices.Add((uint)j - 1);
                _Indices.Add((uint)j - 1); _Indices.Add((uint)i - 1); _Indices.Add((uint)i);
            }


            return new MeshData(_Vertices, _Indices);
        }
    }
}
