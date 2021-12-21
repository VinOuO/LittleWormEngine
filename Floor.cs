using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;

class Floor : DesignerProgram
{
    public override void Start()
    {
        Inis_Shader();
    }

    public override void Update()
    {
        
    }
    public void Inis_Shader()
    {
        MeshRenderer _MR = GetComponent<MeshRenderer>();
        _MR.Set_Shader("BasicVertex.vs", "", "RepeatFragment.fs");
        _MR.RenderShader.AddUniform("transform");
        _MR.RenderShader.AddUniform("nptransform");
        _MR.RenderShader.AddUniform("cam_pos");
        _MR.RenderShader.AddUniform("light_angle");
        _MR.RenderShader.AddUniform("sampler");
        _MR.RenderShader.AddUniform("Repeat_Num");
        _MR.RenderShader.AddUniform("light_angle");
        _MR.RenderShader.SetUniform("Repeat_Num", 100f);
        _MR.RenderShader.SetUniform("light_angle", Vector3.Up);
    }

    public override void ShaderUniformUpdate()
    {
        MeshRenderer _MR = GetComponent<MeshRenderer>();
        _MR.RenderShader.SetUniform("transform", GetComponent<Transform>().GetProjectdTransform(GetComponent<MeshRenderer>().OffSet));
        _MR.RenderShader.SetUniform("nptransform", GetComponent<Transform>().GetTransform(GetComponent<MeshRenderer>().OffSet));
        _MR.RenderShader.SetUniform("cam_pos", Camera.Main.Attaching_GameObject.transform.Position);
        //_MR.RenderShader.SetUniform("Repeat_Num", 100f);
    }
}
