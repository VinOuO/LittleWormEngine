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
            //glDepthFunc(GL_ALWAYS);
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

            public MeshData()
            {

            }

            public MeshData(List<Vertex> _Vertices, List<uint> _Indices)
            {
                Vertices = _Vertices;
                Indices = _Indices;
            }

            public void Add_MeshData(MeshData _MeshData)
            {
                uint _Temp_VerticesNum = (uint)Vertices.Count;
                Vertices.AddRange(_MeshData.Vertices);
                for(int i = 0; i < _MeshData.Indices.Count; i++)
                {
                    _MeshData.Indices[i] += _Temp_VerticesNum;
                }
                Indices.AddRange(_MeshData.Indices);
            }
        }

        #region Old LineMesh
        /*
        public static MeshData Get_LineMesh(Vector3 _StartPos, Vector3 _EndPos, float _Radius)
        {
            int _SectorCount = 100;
            float _SectorStep = 2 * (float)Math.PI / _SectorCount;
            float _SectorAngle;

            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();
            Vector3 _Temp = _EndPos - _StartPos;
            _Vertices.Add(new Vertex(new Vector3(_StartPos)));
            for (int i = 1; i <= _SectorCount + 1; i++)
            {
                _SectorAngle = i * _SectorStep;
                Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);
                float _Temp_Angle;
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.ZAngle_between(_Temp, Vector3.Backward);
                _Temp_Vec3 *= Matrix3.RotateZ(_Temp_Angle);
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.YAngle_between(Matrix3.RotateZ(_Temp_Angle) * (_Temp), Vector3.Backward);
                _Temp_Vec3 *= Matrix3.RotateY(_Temp_Angle);
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.XAngle_between(Matrix3.RotateY(_Temp_Angle) * (Matrix3.RotateZ(_Temp_Angle) * (_Temp)), Vector3.Backward);
                _Temp_Vec3 *= Matrix3.RotateX(_Temp_Angle);
                _Vertices.Add(new Vertex(_Temp_Vec3 + _StartPos));
                if(i >= 2)
                {
                    if(Mathematics.Math_of_Rotation.RoundAngle(Mathematics.Math_of_Rotation.Angle_between(Mathematics.Math_of_Rotation.Cross(_Vertices[i].Position,_Vertices[i-1].Position), _Temp)) < 180)
                    {
                        _Indices.Add(0); _Indices.Add((uint)i - 1); _Indices.Add((uint)i);
                    }
                    else
                    {
                        _Indices.Add(0); _Indices.Add((uint)i); _Indices.Add((uint)i - 1);
                    }
                }
            }
            
            _Vertices.Add(new Vertex(new Vector3(_EndPos)));
            int _Temp_Vertices_Num = _Vertices.Count;
            for (int i = _Temp_Vertices_Num, _Origin_Index = _Temp_Vertices_Num - 1; i <= _SectorCount + _Temp_Vertices_Num; i++)
            {
                _SectorAngle = i * _SectorStep;
                Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);
                float _Temp_Angle;

                _Temp_Angle = (float)Mathematics.Math_of_Rotation.ZAngle_between(_Temp, Vector3.Backward);
                _Temp_Vec3 *= Matrix3.RotateZ(_Temp_Angle);
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.YAngle_between(Matrix3.RotateZ(_Temp_Angle) * _Temp, Vector3.Backward);
                _Temp_Vec3 *= Matrix3.RotateY(_Temp_Angle);
                _Temp_Angle = (float)Mathematics.Math_of_Rotation.XAngle_between(Matrix3.RotateY(_Temp_Angle) * (Matrix3.RotateZ(_Temp_Angle) * _Temp), Vector3.Backward);
                _Temp_Vec3 *= Matrix3.RotateX(_Temp_Angle);
                _Vertices.Add(new Vertex(_Temp_Vec3 + _EndPos));
                if (i >= 2)
                {
                    if (Mathematics.Math_of_Rotation.RoundAngle(Mathematics.Math_of_Rotation.Angle_between(Mathematics.Math_of_Rotation.Cross(_Vertices[i].Position, _Vertices[i - 1].Position), _Temp)) < 180)
                    {
                        _Indices.Add((uint)_Origin_Index); _Indices.Add((uint)i); _Indices.Add((uint)i - 1);
                    }
                    else
                    {
                        _Indices.Add((uint)_Origin_Index); _Indices.Add((uint)i - 1); _Indices.Add((uint)i);
                    }
                }
            }
            
            for (int i = 2, j = _Temp_Vertices_Num + 1; i <= _SectorCount + 1; i++, j++)
            {
                _Indices.Add((uint)i); _Indices.Add((uint)j - 1); _Indices.Add((uint)j);    
                _Indices.Add((uint)j - 1); _Indices.Add((uint)i); _Indices.Add((uint)i - 1);
            }
            
            return new MeshData(_Vertices, _Indices);
        }
        */
        #endregion

        public static MeshData Get_DebugQuad()
        {
            float _Scaler = 1f;
            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();

            _Vertices.Add(new Vertex(new Vector3(-1, 1, 0) * _Scaler, new Vector2(0, 1)));
            _Vertices.Add(new Vertex(new Vector3(1, 1, 0) * _Scaler, new Vector2(1, 1)));
            _Vertices.Add(new Vertex(new Vector3(-1, -1, 0) * _Scaler, new Vector2(0, 0)));
            _Vertices.Add(new Vertex(new Vector3(1, -1, 0) * _Scaler, new Vector2(1, 0)));

            _Indices.Add(0);  _Indices.Add(1); _Indices.Add(3);
            _Indices.Add(0);  _Indices.Add(3); _Indices.Add(2);

            return new MeshData(_Vertices, _Indices);
        }

        public static MeshData Get_LineMesh(Vector3 _StartPos, Vector3 _EndPos, float _Radius)
        {
            int _SectorCount = 100;
            float _SectorStep = 2 * (float)Math.PI / _SectorCount;
            float _SectorAngle;

            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();
            Vector3 _Temp = _EndPos - _StartPos;
            _Vertices.Add(new Vertex(new Vector3(_StartPos)));
            for (int i = 1; i <= _SectorCount + 1; i++)
            {
                _SectorAngle = i * _SectorStep;
                Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);

                _Vertices.Add(new Vertex(Mathematics.Math_of_Rotation.BackwardBasedRotate(_Temp_Vec3, _Temp) + _StartPos));
                if (i >= 2)
                {
                    _Indices.Add(0); _Indices.Add((uint)i - 1); _Indices.Add((uint)i);
                }
            }

            _Vertices.Add(new Vertex(new Vector3(_EndPos)));
            int _Temp_Vertices_Num = _Vertices.Count;
            for (int i = _Temp_Vertices_Num, _Origin_Index = _Temp_Vertices_Num - 1; i <= _SectorCount + _Temp_Vertices_Num; i++)
            {
                _SectorAngle = i * _SectorStep;
                Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);

                _Vertices.Add(new Vertex(Mathematics.Math_of_Rotation.BackwardBasedRotate(_Temp_Vec3, _Temp) + _EndPos));
                if (i >= 2)
                {
                    _Indices.Add((uint)_Origin_Index); _Indices.Add((uint)i); _Indices.Add((uint)i - 1);

                }
            }

            for (int i = 2, j = _Temp_Vertices_Num + 1; i <= _SectorCount + 1; i++, j++)
            {
                _Indices.Add((uint)i); _Indices.Add((uint)j - 1); _Indices.Add((uint)j);
                _Indices.Add((uint)j - 1); _Indices.Add((uint)i); _Indices.Add((uint)i - 1);
            }

            return new MeshData(_Vertices, _Indices);
        }

        public static MeshData Get_ClosedCirclePipeMesh(List<Vector3> _Points, float _Radius, Vector3 _SuppoutAxis)
        {
            int _SectorCount = 100;
            float _SectorStep = 2 * (float)Math.PI / _SectorCount;
            float _SectorAngle;

            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();

            int _Temp_Vertices_Num1 = 0;
            int _Temp_Vertices_Num2 = 0;
 
            for (int p = 0; p <= _Points.Count; p++)
            {
                if(p < _Points.Count)
                {
                    Vector3 _Temp;
                    if (p == 0)
                    {
                        _Temp = _Points[1] - _Points[_Points.Count - 1];
                    }
                    else if(p == _Points.Count - 1)
                    {
                        _Temp = _Points[0] - _Points[_Points.Count - 2];
                    }
                    else
                    {
                        _Temp = _Points[p + 1] - _Points[p - 1];
                    }
                    _Vertices.Add(new Vertex(new Vector3(_Points[p])));
                    int _Temp_Vertices_Num = _Vertices.Count;

                    if (p % 2 == 0)
                    {
                        _Temp_Vertices_Num1 = _Vertices.Count;
                    }
                    else
                    {
                        _Temp_Vertices_Num2 = _Vertices.Count;
                    }

                    for (int i = _Temp_Vertices_Num; i <= _SectorCount + _Temp_Vertices_Num; i++)
                    {
                        _SectorAngle = i * _SectorStep;
                        Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);
                        _Vertices.Add(new Vertex(Mathematics.Math_of_Rotation.BackwardBasedRotate(_Temp_Vec3, _Temp, _SuppoutAxis) + _Points[p]));
                    }

                    if (p > 0)
                    {
                        if (p % 2 == 0)
                        {
                            for (int i = _Temp_Vertices_Num1, j = _Temp_Vertices_Num2; i < _Temp_Vertices_Num1 + _SectorCount; i++, j++)
                            {
                                _Indices.Add((uint)j); _Indices.Add((uint)i); _Indices.Add((uint)i + 1);
                                _Indices.Add((uint)i + 1); _Indices.Add((uint)j + 1); _Indices.Add((uint)j);
                            }
                        }
                        else
                        {
                            for (int i = _Temp_Vertices_Num1, j = _Temp_Vertices_Num2; i < _Temp_Vertices_Num1 + _SectorCount; i++, j++)
                            {
                                _Indices.Add((uint)i); _Indices.Add((uint)j); _Indices.Add((uint)j + 1);
                                _Indices.Add((uint)j + 1); _Indices.Add((uint)i + 1); _Indices.Add((uint)i);
                            }
                        }
                    } 
                }
                else if (p == _Points.Count)
                {
                    if (p % 2 == 0)
                    {
                        int i, j = _Temp_Vertices_Num2;

                        int _MinIndex = 1;
                        float _MinRadians = float.MaxValue;
                        for (int _i = 1; _i <= _SectorCount; _i++)
                        {
                            float _Temp = Mathematics.Math_of_Rotation.Radians_between(_Vertices[_i].Position - _Vertices[j].Position, _Points[0] - _Points[_Points.Count - 1]);
                            if (_Temp < _MinRadians)
                            {
                                _MinRadians = _Temp;
                                _MinIndex = _i;
                            }
                        }

                        i = _MinIndex;

                        bool _Finished = false;
                        while (!_Finished)
                        {
                            if (j + 1 >= _Vertices.Count)
                            {
                                j = _Temp_Vertices_Num2;
                            }
                            if (i >= _SectorCount + 1)
                            {
                                i = 1;
                            }
                            _Indices.Add((uint)i); _Indices.Add((uint)j + 1); _Indices.Add((uint)j);
                            _Indices.Add((uint)j + 1); _Indices.Add((uint)i); _Indices.Add((uint)i + 1);

                            i++;
                            j++;

                            if (i == _MinIndex)
                            {
                                _Finished = true;
                            }
                        }
                    }
                    else
                    {
                        int i = _Temp_Vertices_Num1, j;

                        int _MinIndex = 1;
                        float _MinRadians = float.MaxValue;
                        for (int _j = 1; _j <= _SectorCount; _j++)
                        {
                            float _Temp = Mathematics.Math_of_Rotation.Radians_between(_Vertices[_j].Position - _Vertices[i].Position, _Points[0] - _Points[_Points.Count - 1]);
                            if (_Temp < _MinRadians)
                            {
                                _MinRadians = _Temp;
                                _MinIndex = _j;
                            }
                        }
                        j = _MinIndex;

                        bool _Finished = false;
                        while (!_Finished)
                        {
                            if (i + 1 >= _Vertices.Count)
                            {
                                i = _Temp_Vertices_Num1;
                            }
                            if (j >= _SectorCount + 1)
                            {
                                j = 1;
                            }
                            _Indices.Add((uint)j); _Indices.Add((uint)i + 1); _Indices.Add((uint)i);
                            _Indices.Add((uint)i + 1); _Indices.Add((uint)j); _Indices.Add((uint)j + 1);

                            j++;
                            i++;

                            if (j == _MinIndex)
                            {
                                _Finished = true;
                            }
                        }
                    }

                }
            }

            return new MeshData(_Vertices, _Indices);
        }

        public static MeshData Get_OpenedPipeMesh(List<Vector3> _Points, float _Radius, Vector3 _SuppoutAxis, bool _HaveCap)
        {
            int _SectorCount = 100;
            float _SectorStep = 2 * (float)Math.PI / _SectorCount;
            float _SectorAngle;

            List<Vertex> _Vertices = new List<Vertex>();
            List<uint> _Indices = new List<uint>();

            int _Temp_Vertices_Num1 = 0;
            int _Temp_Vertices_Num2 = 0;

            for (int p = 0; p < _Points.Count - 1; p++)
            {
                if (p < _Points.Count)
                {
                    Vector3 _Temp;
                    if (p == 0)
                    {
                        _Temp = _Points[1] - _Points[0];
                    }
                    else if (p == _Points.Count - 2)
                    {
                        _Temp = _Points[_Points.Count - 1] - _Points[_Points.Count - 2];
                    }
                    else
                    {
                        _Temp = _Points[p + 1] - _Points[p - 1];
                    }
                                    
                    if (p > 1)
                    {
                        _Vertices.Add(new Vertex(new Vector3(_Points[p])));
                        int _Temp_Vertices_Num = _Vertices.Count;

                        if (p % 2 == 0)
                        {
                            _Temp_Vertices_Num1 = _Vertices.Count;
                        }
                        else
                        {
                            _Temp_Vertices_Num2 = _Vertices.Count;
                        }
                        for (int i = _Temp_Vertices_Num; i <= _SectorCount + _Temp_Vertices_Num; i++)
                        {
                            _SectorAngle = i * _SectorStep;
                            Vector3 _Temp_Vec3 = new Vector3((float)Math.Cos(_SectorAngle) * _Radius, (float)Math.Sin(_SectorAngle) * _Radius, 0);
                            _Vertices.Add(new Vertex(Mathematics.Math_of_Rotation.BackwardBasedRotate(_Temp_Vec3, _Temp, _SuppoutAxis) + _Points[p]));
                        }
                        if (p % 2 == 0)
                        {
                            for (int i = _Temp_Vertices_Num1, j = _Temp_Vertices_Num2; i < _Temp_Vertices_Num1 + _SectorCount; i++, j++)
                            {
                                _Indices.Add((uint)j); _Indices.Add((uint)i); _Indices.Add((uint)i + 1);
                                _Indices.Add((uint)i + 1); _Indices.Add((uint)j + 1); _Indices.Add((uint)j);
                            }
                        }
                        else
                        {
                            for (int i = _Temp_Vertices_Num1, j = _Temp_Vertices_Num2; i < _Temp_Vertices_Num1 + _SectorCount; i++, j++)
                            {
                                _Indices.Add((uint)i); _Indices.Add((uint)j); _Indices.Add((uint)j + 1);
                                _Indices.Add((uint)j + 1); _Indices.Add((uint)i + 1); _Indices.Add((uint)i);
                            }
                        }
                    }
                }
            }

            return new MeshData(_Vertices, _Indices);
        }
        #region Old Method, Use Lines to form a Ring.
        public static MeshData __Old__Get_RingMesh(Vector3 _Center, Vector3 _Direction, float _Radius, int _Slices, float _Scaler, float _RoundNum)
        {
            MeshData _Temp = new MeshData();
            Vector3 _StartPoint, _EndPoint, _InisPoint;
            Vector3 _OffSet =  Vector3.Up * _Radius;
            _InisPoint = _OffSet;

            _InisPoint = Mathematics.Math_of_Rotation.BackwardBasedRotate(_InisPoint, _Direction);
            _StartPoint = _InisPoint;

            for (int i = 0; i < _Slices * _RoundNum; i++)
            {
                if(i == _Slices - 1)
                {
                    _EndPoint = _InisPoint;
                }
                else
                {
                    _EndPoint = Matrix3.RotateZ(360 / _Slices * (i + 1)) * _OffSet;

                    _EndPoint = Mathematics.Math_of_Rotation.BackwardBasedRotate(_EndPoint, _Direction);
                }
                _Temp.Add_MeshData(Get_LineMesh(_StartPoint + _Center, _EndPoint + _Center, _Scaler));
                _StartPoint = _EndPoint;
            }
            return _Temp;
        }
        #endregion

        public static MeshData Get_RingMesh(Vector3 _Center, Vector3 _Direction, Vector3 _SuppoutAxis, float _Radius, int _Slices, float _Scaler, float _RoundNum)
        {
            List<Vector3> _Points = new List<Vector3>();
            MeshData _Temp = new MeshData();
            Vector3 _Point;
            Vector3 _OffSet = Vector3.Right * _Radius;

            for (int i = 0; i < _Slices * _RoundNum; i++)
            {
                _Point = Matrix3.RotateZ(360 / _Slices * i) * _OffSet;
                _Point = Mathematics.Math_of_Rotation.BackwardBasedRotate(_Point, _Direction);
                _Points.Add(_Point + _Center);
            }
            _Temp.Add_MeshData(Get_ClosedCirclePipeMesh(_Points, _Scaler, _SuppoutAxis)); 
            return _Temp;
        }

        public static MeshData Get_HalfRingMesh(Vector3 _Center, Vector3 _Direction, Vector3 _SuppoutAxis, float _Radius, int _Slices, float _Scaler, bool _Flip)
        {
            List<Vector3> _Points = new List<Vector3>();
            MeshData _Temp = new MeshData();
            Vector3 _Point;
            Vector3 _OffSet = (_Flip ? Vector3.Left : Vector3.Right) * _Radius;

            for (int i = -2; i <= _Slices * 0.5f + 1; i++)
            {
                _Point = Matrix3.RotateZ(360 / _Slices * i) * _OffSet;
                _Point = Mathematics.Math_of_Rotation.BackwardBasedRotate(_Point, _Direction);
                _Points.Add(_Point + _Center);
            }

            _Temp.Add_MeshData(Get_OpenedPipeMesh(_Points, _Scaler, _SuppoutAxis, false));
            return _Temp;
        }

    }
}
