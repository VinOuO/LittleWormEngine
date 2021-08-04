using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using System.Drawing;

namespace LittleWormEngine
{
    class ResourceLoader
    {
        
        public static List<string> Get_AllFiles(string _Path)
        {
            List<string> _FileNames = new List<string>();
            _FileNames.AddRange(Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Resources\" + _Path));
            return _FileNames;
        }

        public static List<string> Load_File(string _FileName)
        {
            string _Temp_Path = Directory.GetCurrentDirectory() + @"\" + _FileName;
            if (File.Exists(_Temp_Path))
            {
                return new List<string>(File.ReadAllLines(_Temp_Path));
            }
            return new List<string>();
        }

        public static void Save_Scene()
        {
            List<string> _FileInfo = new List<string>();
            foreach (GameObject _GameObject in Core.GameObjects)
            {
                _FileInfo.Add("GameObject_" + _GameObject.Name);
            }

            using (StreamWriter File = new StreamWriter(Directory.GetCurrentDirectory() + @"\Save\Scene\" + Core.SceneName, false))
            {
                for (int i = 0; i < _FileInfo.Count; i++)
                {
                    File.WriteLine(_FileInfo[i]);
                }
            }
        }

        public static void Save_PrefabFile(GameObject _GameObject)
        {
            List<string> _FileInfo = new List<string>();

            foreach (Component _Component in _GameObject.Components)
            {
                switch (_Component.GetType().Name)
                {
                    case "Camera":
                        _FileInfo.Add("Camera");
                        break;
                    case "Transform":
                        _FileInfo.Add("Transform" + " " + _GameObject.GetComponent<Transform>().Position.x + " " + _GameObject.GetComponent<Transform>().Position.y + " " + _GameObject.GetComponent<Transform>().Position.z + " " + _GameObject.GetComponent<Transform>().Rotation.x + " " + _GameObject.GetComponent<Transform>().Rotation.y + " " + _GameObject.GetComponent<Transform>().Rotation.z + " " + _GameObject.GetComponent<Transform>().Scale.x + " " + _GameObject.GetComponent<Transform>().Scale.y + " " + _GameObject.GetComponent<Transform>().Scale.z);
                        break;
                    case "MeshRenderer":
                        _FileInfo.Add("MeshRenderer" + " " + _GameObject.GetComponent<MeshRenderer>().MeshFileName + " " + _GameObject.GetComponent<MeshRenderer>().TextureFileName + " " + _GameObject.GetComponent<MeshRenderer>().OffSet.x + " " + _GameObject.GetComponent<MeshRenderer>().OffSet.y + " " + _GameObject.GetComponent<MeshRenderer>().OffSet.z);
                        break;
                    case "BoxCollider":
                        _FileInfo.Add("BoxCollider" + " " + _GameObject.GetComponent<BoxCollider>().Is_Trigger.ToString() + " " + _GameObject.GetComponent<BoxCollider>().Is_Static.ToString() + " " + _GameObject.GetComponent<BoxCollider>().OffSet.x + " " + _GameObject.GetComponent<BoxCollider>().OffSet.y + " " + _GameObject.GetComponent<BoxCollider>().OffSet.z + " " + _GameObject.GetComponent<BoxCollider>().HalfSize.x + " " + _GameObject.GetComponent<BoxCollider>().HalfSize.y + " " + _GameObject.GetComponent<BoxCollider>().HalfSize.z);
                        break;
                    case "CapsuleCollider":
                        _FileInfo.Add("CapsuleCollider" + " " + _GameObject.GetComponent<CapsuleCollider>().Is_Trigger.ToString() + " " + _GameObject.GetComponent<CapsuleCollider>().Is_Static.ToString() + " " + _GameObject.GetComponent<CapsuleCollider>().OffSet.x + " " + _GameObject.GetComponent<CapsuleCollider>().OffSet.y + " " + _GameObject.GetComponent<CapsuleCollider>().OffSet.z + " " + _GameObject.GetComponent<CapsuleCollider>().RadiusHeight.x + " " + _GameObject.GetComponent<CapsuleCollider>().RadiusHeight.y);
                        break;
                }
            }

            foreach (CustomComponent _Component in _GameObject.CustomComponents)
            {
                _FileInfo.Add("Custom " + _Component.GetType().Name);
            }

            using (StreamWriter File = new StreamWriter(Directory.GetCurrentDirectory() + @"\Save\Prefab\Prefab_" + _GameObject.Name + ".lwobj", false))
            {
                for (int i = 0; i < _FileInfo.Count; i++)
                {
                    File.WriteLine(_FileInfo[i]);
                }
            }
        }

        public static void Save_GameObjectFile(GameObject _GameObject)
        {
            List<string> _FileInfo = new List<string>();

            foreach(Component _Component in _GameObject.Components)
            {
                switch (_Component.GetType().Name)
                {
                    case "Camera":
                        _FileInfo.Add("Camera");
                        break;
                    case "Transform":
                        _FileInfo.Add("Transform" + " " + _GameObject.GetComponent<Transform>().Position.x + " " + _GameObject.GetComponent<Transform>().Position.y + " " + _GameObject.GetComponent<Transform>().Position.z + " " + _GameObject.GetComponent<Transform>().Rotation.x + " " + _GameObject.GetComponent<Transform>().Rotation.y + " " + _GameObject.GetComponent<Transform>().Rotation.z + " " + _GameObject.GetComponent<Transform>().Scale.x + " " + _GameObject.GetComponent<Transform>().Scale.y + " " + _GameObject.GetComponent<Transform>().Scale.z);
                        break;
                    case "MeshRenderer":
                        _FileInfo.Add("MeshRenderer" + " " + _GameObject.GetComponent<MeshRenderer>().MeshFileName + " " + _GameObject.GetComponent<MeshRenderer>().TextureFileName + " " + _GameObject.GetComponent<MeshRenderer>().OffSet.x + " " + _GameObject.GetComponent<MeshRenderer>().OffSet.y + " " + _GameObject.GetComponent<MeshRenderer>().OffSet.z);
                        break;
                    case "BoxCollider":
                        _FileInfo.Add("BoxCollider" + " " + _GameObject.GetComponent<BoxCollider>().Is_Trigger.ToString() + " " + _GameObject.GetComponent<BoxCollider>().Is_Static.ToString() + " " + _GameObject.GetComponent<BoxCollider>().OffSet.x + " " + _GameObject.GetComponent<BoxCollider>().OffSet.y + " " + _GameObject.GetComponent<BoxCollider>().OffSet.z + " " + _GameObject.GetComponent<BoxCollider>().HalfSize.x + " " + _GameObject.GetComponent<BoxCollider>().HalfSize.y + " " + _GameObject.GetComponent<BoxCollider>().HalfSize.z);
                        break;
                    case "CapsuleCollider":
                        _FileInfo.Add("CapsuleCollider" + " " + _GameObject.GetComponent<CapsuleCollider>().Is_Trigger.ToString() + " " + _GameObject.GetComponent<CapsuleCollider>().Is_Static.ToString() + " " + _GameObject.GetComponent<CapsuleCollider>().OffSet.x + " " + _GameObject.GetComponent<CapsuleCollider>().OffSet.y + " " + _GameObject.GetComponent<CapsuleCollider>().OffSet.z + " " + _GameObject.GetComponent<CapsuleCollider>().RadiusHeight.x + " " + _GameObject.GetComponent<CapsuleCollider>().RadiusHeight.y);
                        break;
                }
            }

            foreach (CustomComponent _Component in _GameObject.CustomComponents)
            {
                _FileInfo.Add("Custom " + _Component.GetType().Name);
            }

            using (StreamWriter File = new StreamWriter(Directory.GetCurrentDirectory() + @"\Save\GameObject\GameObject_" + _GameObject.Name + ".lwobj", false))
            {
                for (int i = 0; i < _FileInfo.Count; i++)
                {
                    File.WriteLine(_FileInfo[i]);
                }
            }
        }

        public static Texture Load_Texture(string _FileName)
        {
            return new Texture(_FileName);
        }

        public static string Load_Shader(string _FileName)
        {
            List<string> _Lines = new List<string>(System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Resources" + @"\Shaders\" + _FileName));
            string _ShaderCode = "";
            foreach (string _Line in _Lines)
            {
                _ShaderCode += (_Line + "\n");
            }
            return _ShaderCode;
        }

        public static Mesh Load_Mesh(string _FileName)
        {
            Mesh _Mesh = new Mesh();
            List<Vertex> _Vertices = new List<Vertex>();

            List<Vector2> _TexCoord = new List<Vector2>();
            List<Vector3> _Pos = new List<Vector3>();
            List<Vector3> _Normal = new List<Vector3>();

            List<uint> _Indices = new List<uint>();

            List<string> File_Lines = new List<string>(System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Resources" + @"\Models\" + _FileName));
            string _Status = "Starting";
            for (int i = 0; i < File_Lines.Count; i++)
            {
                if(File_Lines[i].Length == 0)
                {
                    continue;
                }
                switch (_Status)
                {
                    case "Starting":
                        switch (Split(File_Lines[i], ' ')[0])
                        {
                            case "v":
                                i--;
                                _Status = "Importing_Vertices";
                                break;
                            case "vn":
                                i--;
                                _Status = "Importing_Normal";
                                break;
                            case "vt":
                                i--;
                                _Status = "Importing_TexCoord";
                                break;
                        }
                        break;
                    case "Importing_Vertices":
                        switch (Split(File_Lines[i], ' ')[0])
                        {
                            case "v":
                                List<string> _Temp = Split(File_Lines[i], ' ');
                                _Pos.Add(new Vector3(float.Parse(_Temp[1]), float.Parse(_Temp[2]), float.Parse(_Temp[3])));
                                break;
                            case "vn":
                                i--;
                                _Status = "Importing_Normal";
                                break;
                            case "vt":
                                i--;
                                _Status = "Importing_TexCoord";
                                break;
                        }
                        break;
                    case "Importing_Normal":
                        switch (Split(File_Lines[i], ' ')[0])
                        {
                            case "v":
                                i--;
                                _Status = "Importing_Vertices";
                                break;
                            case "vn":
                                List<string> _Temp = Split(File_Lines[i], ' ');
                                _Normal.Add(new Vector3(float.Parse(_Temp[1]), float.Parse(_Temp[2]), float.Parse(_Temp[3])));
                                break;
                            case "vt":
                                i--;
                                _Status = "Importing_TexCoord";
                                break;
                        }
                        break;
                    case "Importing_TexCoord":
                        switch (Split(File_Lines[i], ' ')[0])
                        {
                            case "v":
                                i--;
                                _Status = "Importing_Vertices";
                                break;
                            case "vn":
                                i--;
                                _Status = "Importing_Normal";
                                break;
                            case "vt":
                                List<string> _Temp = Split(File_Lines[i], ' ');
                                _TexCoord.Add(new Vector2(float.Parse(_Temp[1]), 1 - float.Parse(_Temp[2])));
                                break;
                        }
                        break;
                }
            }
            //Console.WriteLine(_Pos.Count);//4482
            //Console.WriteLine(_TexCoord.Count);//5991
            for (int i = 0; i < File_Lines.Count; i++)
            {
                if (File_Lines[i].Length == 0)
                {
                    continue;
                }

                if(Split(File_Lines[i], ' ')[0] == "f")
                {
                    List<string> _Temp_Indices = Split(File_Lines[i], ' ');
                    for(int j = 1; j < 4; j++)
                    {
                        int _VertexID = Vertex.Find_Vertex(_Vertices, _Temp_Indices[j]);
                        if (_VertexID != -1)
                        {
                            _Indices.Add((uint)_VertexID);
                        }
                        else
                        {
                            _Indices.Add((uint)_Vertices.Count);
                            List<string> _Pos_Coord = Split(_Temp_Indices[j], '/');
                            _Vertices.Add(new Vertex(_Pos[int.Parse(_Pos_Coord[0])-1], _TexCoord[int.Parse(_Pos_Coord[1]) - 1], _Normal[int.Parse(_Pos_Coord[2]) - 1], _Temp_Indices[j]));
                        }
                    }
                    if (Split(File_Lines[i], ' ').Count > 4)
                    {
                        for (int j = 1; j < 5; j++)
                        {
                            if (j == 2)
                            {
                                continue;
                            }
                            int _VertexID = Vertex.Find_Vertex(_Vertices, _Temp_Indices[j]);
                            if (_VertexID != -1)
                            {
                                _Indices.Add((uint)_VertexID);
                            }
                            else
                            {
                                _Indices.Add((uint)_Vertices.Count);
                                List<string> _Pos_Coord = Split(_Temp_Indices[j], '/');
                                _Vertices.Add(new Vertex(_Pos[int.Parse(_Pos_Coord[0])-1], _TexCoord[int.Parse(_Pos_Coord[1]) - 1], _Normal[int.Parse(_Pos_Coord[2]) - 1], _Temp_Indices[j]));
                            }
                        }
                    }
                }
            }
            /*
            foreach(Vertex _V in _Vertices)
            {
                //_V.Position.x *= -1;
                //_V.Position.y *= -1;
                //_V.Position.z *= -1;
            }
            */
            _Mesh.AddVertices(_Vertices, _Indices);
            return _Mesh;
        }

        public static List<string> Split(string _String, char _Spliter)
        {
            List<string> _Temp_Strings = new List<string>();
            string _Temp = "";
            for(int i = 0; i < _String.Length; i++)
            {
                if(_Temp != "" && _String[i] == _Spliter)
                {
                    _Temp_Strings.Add(_Temp);
                    _Temp = "";
                }
                else
                {
                    _Temp += _String[i];
                }
            }
            if (_Temp != "")
            {
                _Temp_Strings.Add(_Temp);
            }
            return _Temp_Strings;
        }
    }
}
