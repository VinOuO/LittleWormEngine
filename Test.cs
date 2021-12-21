using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test : DesignerProgram
{
    public string UnderWorldTexture = "Tex2.png";
    override public void Start()
    {
        Inis_Shader();
    }

    override public void Update()
    {
        
    }

    public override void OnCollisionEnter(GameObject _Other)
    {
        Debug.Log(_Other.Name + " Entered " + Name);
    }
    public override void OnCollisionExit(GameObject _Other)
    {
        Debug.Log(_Other.Name + " Exited " + Name);
    }

    public void Inis_Shader()
    {
        MeshRenderer _MR = GetComponent<MeshRenderer>();
        _MR.Add_Texture(UnderWorldTexture);
        _MR.Set_Shader("UnderWorldVertex.vs", "", "UnderWorldFragment.fs");
        _MR.RenderShader.AddUniform("Transform");
        _MR.RenderShader.AddUniform("NPTransform");
        _MR.RenderShader.AddUniform("FlashLightDir");
        _MR.RenderShader.AddUniform("Camera_Pos");
        _MR.RenderShader.AddUniform("LightDir");
        _MR.RenderShader.AddUniform("CameraDir");
        _MR.RenderShader.AddUniform("NormalSampler");
        _MR.RenderShader.AddUniform("UnderWorldSampler");
        _MR.RenderShader.AddUniform("Light_On");
        _MR.RenderShader.SetUniform("NormalSampler", 0);
        _MR.RenderShader.SetUniform("UnderWorldSampler", 1);
        _MR.RenderShader.SetUniform("LightDir", Vector3.Left + Vector3.Up);
        _MR.RenderShader.SetUniform("Light_On", Game.Light_On);
    }

    public override void ShaderUniformUpdate()
    {
        MeshRenderer _MR = GetComponent<MeshRenderer>();
        
        _MR.RenderShader.SetUniform("Light_On", Game.Light_On);
        _MR.RenderShader.SetUniform("Camera_Pos", Camera.Main.Attaching_GameObject.transform.Position);
        _MR.RenderShader.SetUniform("FlashLightDir", Camera.Main.Get_MouseDir());
        _MR.RenderShader.SetUniform("NPTransform", GetComponent<Transform>().GetTransform(GetComponent<MeshRenderer>().OffSet));
        _MR.RenderShader.SetUniform("Transform", GetComponent<Transform>().GetProjectdTransform(GetComponent<MeshRenderer>().OffSet));
        _MR.RenderShader.SetUniform("CameraDir", Matrix3.RotateX(Camera.Main.transform.Rotation.x) * Matrix3.RotateY(Camera.Main.transform.Rotation.y) * Matrix3.RotateZ(Camera.Main.transform.Rotation.z) * Vector3.Forward);
    }
}

