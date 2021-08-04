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
        GetComponent<MeshRenderer>().RenderShader.SetUniform("Camera_Pos", Camera.Main.Attaching_GameObject.transform.Position);
        GetComponent<MeshRenderer>().RenderShader.SetUniform("FlashLightDir", Camera.Main.Get_MouseDir());
    }

    public override void OnCollitionEnter(GameObject _Other)
    {
        Debug.Log(_Other.Name + " Entered " + Name);
    }
    public override void OnCollitionExit(GameObject _Other)
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
        _MR.RenderShader.AddUniform("NormalSampler");
        _MR.RenderShader.AddUniform("UnderWorldSampler");
        _MR.RenderShader.SetUniform("NormalSampler", 0);
        _MR.RenderShader.SetUniform("UnderWorldSampler", 1);
    }

    public override void ShaderUniformUpdate()
    {
        GetComponent<MeshRenderer>().RenderShader.SetUniform("NPTransform",GetComponent<Transform>().GetTransform(GetComponent<MeshRenderer>().OffSet));
        GetComponent<MeshRenderer>().RenderShader.SetUniform("Transform", GetComponent<Transform>().GetProjectdTransform(GetComponent<MeshRenderer>().OffSet));
    }
}

