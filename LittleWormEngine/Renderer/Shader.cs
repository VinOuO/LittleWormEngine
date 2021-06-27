using System;
using System.Collections.Generic;
using System.Text;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine.Utility;

namespace LittleWormEngine.Renderer
{
    class Shader
    {
        public uint Program;
        List<Uniform> Uniforms;

        public Shader(string _VertexShader, string _GeometryShader, string _FragmentShader)
        {
            Uniforms = new List<Uniform>();
            Program = CreateProgram(_VertexShader, _GeometryShader, _FragmentShader);
        }

        public uint CreateProgram(string _VertexShader, string _GeometryShader, string _FragmentShader)
        {
            uint _Program = glCreateProgram();
            uint _Vertex = 0, _Geometry = 0, _Fragment = 0;

            if (_VertexShader != "")
            {
                _Vertex = AddVertexShader(ResourceLoader.Load_Shader(_VertexShader));
                glAttachShader(_Program, _Vertex);
            }

            if (_GeometryShader != "")
            {
                _Geometry = AddGeometryShader(ResourceLoader.Load_Shader(_GeometryShader));
                glAttachShader(_Program, _Geometry);
            }

            if (_FragmentShader != "")
            {
                _Fragment = AddFragmentShader(ResourceLoader.Load_Shader(_FragmentShader));
                glAttachShader(_Program, _Fragment);
            }
            glLinkProgram(_Program);
            if (_VertexShader != "")
            {
                glDeleteShader(_Vertex);
            }

            if (_GeometryShader != "")
            {
                glDeleteShader(_Geometry);
            }

            if (_FragmentShader != "")
            {
                glDeleteShader(_Fragment);
            }

            return _Program;
        }

        public uint AddVertexShader(string _Code)
        {
            return CreateShader(GL_VERTEX_SHADER, _Code);
        }

        public uint AddGeometryShader(string _Code)
        {
            return CreateShader(GL_GEOMETRY_SHADER, _Code);
        }

        public uint AddFragmentShader(string _Code)
        {
            return CreateShader(GL_FRAGMENT_SHADER, _Code);
        }

        public uint CreateShader(int _Type, string _Code)
        {
            uint _Shader = glCreateShader(_Type);
            glShaderSource(_Shader, _Code);
            glCompileShader(_Shader);
            glAttachShader(Program, _Shader);

            return _Shader;
        }

        public void DeleteShader(uint _Shader)
        {
            glDeleteShader(_Shader);
        }

        public void AddUniform(string _UniformName)
        {
            int _UniformLocation = glGetUniformLocation(Program, _UniformName);

            Uniforms.Add(new Uniform(_UniformName, _UniformLocation));
        }

        public unsafe void SetUniform(string _UniformName, object _Value)
        {
            switch (_Value)
            {
                case int _i:
                    glUniform1i(Uniforms.Find(_x => _x.Name == _UniformName).Location, _i);
                    break;
                case float _f:
                    glUniform1f(Uniforms.Find(_x => _x.Name == _UniformName).Location, _f);
                    break;
                case Vector3 _v:
                    glUniform3f(Uniforms.Find(_x => _x.Name == _UniformName).Location, _v.x, _v.y, _v.z);
                    break;
                case Matrix4 _m:
                    fixed (float* p = &_m.Matrix[0,0])
                    {
                        glUniformMatrix4fv(Uniforms.Find(_x => _x.Name == _UniformName).Location, 1, true, p);
                    }
                    break;
            }
        }
    }
}
