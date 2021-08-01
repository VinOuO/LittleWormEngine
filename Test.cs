using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test : DesignerProgram
{
    Vector4 De1, De2;
    override public void Start()
    {
        //Camera.Main.Attaching_GameObject.transform.Position = Vector3.Zero;
        //Inis_Shader();
    }
    int i = 1;
    Texture _Test;
    Vector4 _Temp_Vec4;
    Vector3 _Temp_Vec3;
    override public void Update()
    {
        //_Temp_Vec4 = (new Vector4(Camera.Main.Get_MouseDir() * 10, 1) * Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(Vector3.Zero));
        //transform.Position = new Vector3(_Temp_Vec4.x, _Temp_Vec4.y, _Temp_Vec4.z);
        //transform.Position = Camera.Main.Get_MouseDir() * 10;
        //transform.Position.z = 5;

        //GetComponent<MeshRenderer>().RenderShader.SetUniform("Camera_Pos", Camera.Main.Attaching_GameObject.transform.Position);
        //GetComponent<MeshRenderer>().RenderShader.SetUniform("FlashLightDir", Camera.Main.Get_MouseDir());

        //GetComponent<MeshRenderer>().RenderShader.SetUniform("NPTransform", GetComponent<Transform>().GetTransform(GetComponent<MeshRenderer>().OffSet));
        //GetComponent<MeshRenderer>().RenderShader.SetUniform("Transform", GetComponent<Transform>().GetProjectdTransform(GetComponent<MeshRenderer>().OffSet));
        return;
        if (Input.GetKey(KeyCode.Up))
        {
            //GetComponent<Transform>().Position.y += 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Down))
        {
            //GetComponent<Transform>().Position.y -= 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Left))
        {
            GetComponent<Transform>().Position.x -= 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Right))
        {
            GetComponent<Transform>().Position.x += 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().Position.z += 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().Position.z -= 20f * Time.DeltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Any))
        {
            //Debug.Log(transform.Position);
        }

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
        _Test = _MR.Add_Texture("Tex2.png");
        _MR.Set_Shader("UnderWorldVertex.vs", "", "UnderWorldFragment.fs");
        _MR.RenderShader.AddUniform("Transform");
        _MR.RenderShader.AddUniform("NPTransform");
        _MR.RenderShader.AddUniform("FlashLightDir");
        _MR.RenderShader.AddUniform("Camera_Pos");
        //_MR.RenderShader.AddUniform("Light_Angle");
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

