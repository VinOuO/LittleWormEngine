using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;
using GLFW;
using static OpenGL.GL;

namespace LittleWormEngine
{
    class MeshRenderer : Component
    {
        public GameObject Attaching_GameObject { get; set; }
        public string Tag { get; set; }
        public Vector3 OffSet { get; set; }

        public void Start()
        {
            Set_DebugMesh(Get_DebugMesh(), new Shader("DebugVertex.vs", "", "DebugFragment.fs"));
        }
        Vector3 _temp, Light_Dir = new Vector3(1, 0, 0);
        public void Update(string _Type)
        {
            switch (_Type)
            {
                case "Rendering":
                    //Render();
                    if (Attaching_GameObject.Name == "Ashe")
                    {
                        Render_ShadowMap();
                    }
                    break;
            }
        }
        void Render()
        {
            for (int i = 0; i < RenderTextures.Count; i++)
            {
                glActiveTexture(GL_TEXTURE0 + i); // Texture unit i
                glBindTexture(GL_TEXTURE_2D, RenderTextures[i].TexID);
            }
            glUseProgram(RenderShader.Program);
            glBindVertexArray(RenderMesh.Vao);

            RenderShader.SetUniform("transform", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(OffSet));
            RenderShader.SetUniform("nptransform", Attaching_GameObject.GetComponent<Transform>().GetTransform(OffSet));
            RenderShader.SetUniform("cam_pos", Camera.Main.Attaching_GameObject.transform.Position);
            Light_Dir = Matrix3.RotateY(30 * Time.DeltaTime) * Light_Dir;
            _temp = Matrix3.RotateX(-Attaching_GameObject.GetComponent<Transform>().Rotation.x) * (Matrix3.RotateY(-Attaching_GameObject.GetComponent<Transform>().Rotation.y) * (Matrix3.RotateZ(-Attaching_GameObject.GetComponent<Transform>().Rotation.z) * Light_Dir.Normalize()));
            RenderShader.SetUniform("light_angle", _temp);
            Draw();
        }

        void Render_with_Shadow()
        {
            for (int i = 0; i < RenderTextures.Count; i++)
            {
                glActiveTexture(GL_TEXTURE0 + i); // Texture unit i
                glBindTexture(GL_TEXTURE_2D, RenderTextures[i].TexID);
            }
            glUseProgram(RenderShader.Program);
            glBindVertexArray(RenderMesh.Vao);
            RenderShader.SetUniform("transform", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(OffSet));
            RenderShader.SetUniform("cam_pos", Camera.Main.Attaching_GameObject.transform.Position);
            Light_Dir = Matrix3.RotateY(30 * Time.DeltaTime) * Light_Dir;
            _temp = Matrix3.RotateX(-Attaching_GameObject.GetComponent<Transform>().Rotation.x) * (Matrix3.RotateY(-Attaching_GameObject.GetComponent<Transform>().Rotation.y) * (Matrix3.RotateZ(-Attaching_GameObject.GetComponent<Transform>().Rotation.z) * Light_Dir.Normalize()));
            RenderShader.SetUniform("light_angle", _temp);
            Draw();
        }
        
        void Render_ShadowMap()
        {
            Matrix4 _LightSpace = Matrix4.PerspectiveProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov) * Matrix4.GetCameraTransform() * Attaching_GameObject.transform.GetTransform(OffSet);
            ShadowShader.SetUniform("LightSpace", _LightSpace);
            Debug.Log_Once(glGetProgramInfoLog(ShadowShader.Program));

            glViewport(0, 0, ShadowMap.Width, ShadowMap.Height);
            glBindFramebuffer(GL_FRAMEBUFFER, ShadowMap.RenderBufferID);
            glBindFramebuffer(GL_FRAMEBUFFER, 0);

            glBindVertexArray(RenderMesh.Vao);
            Draw();
            _LightSpace = Matrix4.PerspectiveProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov) * Matrix4.GetCameraTransform() * GameObject.Find("Box2").transform.GetTransform(GameObject.Find("Box2").GetComponent<MeshRenderer>().OffSet);
            ShadowShader.SetUniform("LightSpace", _LightSpace);
            glBindVertexArray(GameObject.Find("Box2").GetComponent<MeshRenderer>().RenderMesh.Vao);
            Draw();
            /*
            _LightSpace = Matrix4.PerspectiveProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov) * Matrix4.GetCameraTransform() * Attaching_GameObject.transform.GetTransform(GameObject.Find("Box2").GetComponent<MeshRenderer>().OffSet);
            ShadowShader.SetUniform("LightSpace", _LightSpace);

            glBindVertexArray(GameObject.Find("Box2").GetComponent<MeshRenderer>().RenderMesh.Vao);
            Draw();
            */
            //Show_ShadowMap();
        }

        void Debug_Draw()
        {
            Matrix4 _LightSpace = Matrix4.PerspectiveProjection(Core.MainCamera.zNear, Core.MainCamera.zFar, Core.MainCamera.Width, Core.MainCamera.Height, Core.MainCamera.fov) * Matrix4.GetCameraTransform() * Attaching_GameObject.transform.GetTransform(OffSet);
            //Matrix4 _LightSpace = Matrix4.OrthographicProjection(Camera.Main.Right, Camera.Main.Left, Camera.Main.Top, Camera.Main.Bottom, Camera.Main.zFar, Camera.Main.zNear) * Matrix4.GetCameraTransform() * Attaching_GameObject.transform.GetTransform(OffSet);
            ShadowShader.SetUniform("LightSpace", _LightSpace);
            //ShadowShader.SetUniform("LightSpace", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(OffSet));
            //Debug.Log_Once(glGetProgramInfoLog(ShadowShader.Program));
            glActiveTexture(GL_TEXTURE0); // Texture unit i
            glBindTexture(GL_TEXTURE_2D, RenderTextures[0].TexID);
            glBindVertexArray(RenderMesh.Vao);
            Draw();
        }


        public Mesh DebugMesh { get; set; }
        public Shader DebugShader { get; set; }
        unsafe void Show_ShadowMap()
        {
            glBindFramebuffer(GL_FRAMEBUFFER, 0);
            glViewport(0, 0, Core.Width, Core.Height);
            glClearColor(0, 1, 1, 1);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            glActiveTexture(GL_TEXTURE0); // Texture unit i
            glBindTexture(GL_TEXTURE_2D, ShadowMap.TexID);
            glUseProgram(DebugShader.Program);
            glBindVertexArray(DebugMesh.Vao);
            Debug.Log_Once(glGetProgramInfoLog(DebugShader.Program));
            //DebugShader.SetUniform("DepthMap", 0);
            glEnableVertexAttribArray(0);
            glEnableVertexAttribArray(1);
            glDrawElements(GL_TRIANGLES, DebugMesh.Indices.Length, GL_UNSIGNED_INT, NULL);
            glDisableVertexAttribArray(0);
            glDisableVertexAttribArray(1);
        }

        public void Set_DebugMesh(Mesh _RenderMesh, Shader _RenderShader)
        {
            DebugMesh = _RenderMesh;
            DebugShader = _RenderShader;
            DebugShader.AddUniform("DepthMap");
        }

        Mesh Get_DebugMesh()
        {
            Mesh _Mesh = new Mesh();
            RenderUtility.MeshData _Temp = new RenderUtility.MeshData();
            _Temp.Add_MeshData(RenderUtility.Get_DebugQuad());
            _Mesh.AddVertices(_Temp.Vertices, _Temp.Indices);
            return _Mesh;
        }

        public unsafe void Draw()
        {
            glEnableVertexAttribArray(0);
            glEnableVertexAttribArray(1);
            glEnableVertexAttribArray(2);

            glDrawElements(GL_TRIANGLES, RenderMesh.Indices.Length, GL_UNSIGNED_INT, NULL);

            glDisableVertexAttribArray(0);
            glDisableVertexAttribArray(1);
            glDisableVertexAttribArray(2);
        }

        public string MeshFileName;
        public string TextureFileName;
        public Mesh RenderMesh { get; set; }
        public Texture RenderTexture { get; set; }
        public ShadowTexture ShadowMap { get; set; }
        public List<Texture> RenderTextures { get; set; }
        public Shader RenderShader { get; set; }
        public Shader ShadowShader { get; set; }
        
        public MeshRenderer()
        {
            Tag = "Renderer";
            OffSet = Vector3.Zero;
        }

        public void Set(Mesh _RenderMesh, Texture _RenderTexture, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderTextures = new List<Texture>();
            RenderTexture = _RenderTexture;
            RenderTextures.Add(RenderTexture);
            RenderShader = _RenderShader;
        }

        public void Set(string _MeshFileName, string _TextureFileName)
        {
            MeshFileName = _MeshFileName;
            TextureFileName = _TextureFileName;
            RenderMesh = ResourceLoader.Load_Mesh(_MeshFileName);
            RenderTextures = new List<Texture>();
            RenderTexture = ResourceLoader.Load_Texture(_TextureFileName);
            RenderTextures.Add(RenderTexture);
            RenderShader = new Shader("BasicVertex.vs", "", "BasicFragment.fs");
            RenderShader.AddUniform("transform");
            RenderShader.AddUniform("nptransform");
            RenderShader.AddUniform("cam_pos");
            RenderShader.AddUniform("light_angle");
            RenderShader.AddUniform("sampler");

            ShadowMap = new ShadowTexture();
            ShadowShader = new Shader("ShadowVertex.vs", "", "ShadowFragment.fs");
            ShadowShader.AddUniform("LightSpace");
            ShadowShader.AddUniform("Transform");
        }

        public void Set_Shader(string _VertexShader, string _GeometryShader, string _FragmentShader)
        {
            RenderShader = new Shader(_VertexShader, _GeometryShader, _FragmentShader);
        }

        public Texture Add_Texture(string _TextureFileName)
        {
            Texture _TempTexture = ResourceLoader.Load_Texture(_TextureFileName);
            RenderTextures.Add(_TempTexture);
            return _TempTexture;
        }

        public int Get_TextureID(Texture _Texture)
        {
            return RenderTextures.FindIndex(_T => _T == _Texture);
        }
    }
}
