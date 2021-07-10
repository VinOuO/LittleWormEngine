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

        }
        Vector3 _temp, Light_Dir = new Vector3(1, 0, 0);
        public void Update(string _Type)
        {
            switch (_Type)
            {
                case "Rendering":
                    glBindTexture(GL_TEXTURE_2D, RenderTexture.TexID);
                    glUseProgram(RenderShader.Program);
                    glBindVertexArray(RenderMesh.Vao);
                    RenderShader.SetUniform("transform", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(OffSet));
                    RenderShader.SetUniform("cam_pos", Core.The_Camera.Attaching_GameObject.transform.Position);
                    Light_Dir = Matrix3.RotateY(30 * Time.DeltaTime) * Light_Dir;
                    _temp = Matrix3.RotateX(-Attaching_GameObject.GetComponent<Transform>().Rotation.x) * (Matrix3.RotateY(-Attaching_GameObject.GetComponent<Transform>().Rotation.y) * (Matrix3.RotateZ(-Attaching_GameObject.GetComponent<Transform>().Rotation.z) * Light_Dir.Normalize()));
                    RenderShader.SetUniform("light_angle", _temp);
                    Draw();
                    break;
            }
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
        public Shader RenderShader { get; set; }
        public MeshRenderer()
        {
            Tag = "Renderer";
            OffSet = Vector3.Zero;
        }

        public void Set(Mesh _RenderMesh, Texture _RenderTexture, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderTexture = _RenderTexture;
            RenderShader = _RenderShader;
        }

        public void Set(string _MeshFileName, string _TextureFileName)
        {
            MeshFileName = _MeshFileName;
            TextureFileName = _TextureFileName;
            RenderMesh = ResourceLoader.Load_Mesh(_MeshFileName);
            RenderTexture = ResourceLoader.Load_Texture(_TextureFileName);
            RenderShader = new Shader("BasicVertex.vs", "", "BasicFragment.fs");
            RenderShader.AddUniform("transform");
            RenderShader.AddUniform("cam_pos");
            RenderShader.AddUniform("light_angle");
        }
    }
}
