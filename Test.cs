using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test : DesignerProgram
{
    override public void Start()
    {
        Debug.Log(Name + ": Test");
        Inis_Shader();
    }
    int i = 1;
    Texture _Test;
    Vector4 _Temp_Vec4;
    override public void Update()
    {
        //_Temp_Vec4 = (new Vector4(Camera.Main.Get_MouseDir() * 10, 1) * Attaching_GameObject.GetComponent<Transform>().GetProjectdTransform(Vector3.Zero));
        //transform.Position = new Vector3(_Temp_Vec4.x, _Temp_Vec4.y, _Temp_Vec4.z);
        //transform.Position = Camera.Main.Get_MouseDir() * 10;
        
        GetComponent<MeshRenderer>().RenderShader.SetUniform("FlashLightDir", Camera.Main.Get_MouseDir());
        GetComponent<MeshRenderer>().RenderShader.SetUniform("nptransform", Attaching_GameObject.GetComponent<Transform>().GetTransform(Attaching_GameObject.GetComponent<MeshRenderer>().OffSet));
        if (Input.GetKeyDown(MouseCode.Left))
        {
            //Debug.Log(transform.Position);
            //Debug.Log(Camera.Main.Get_MouseDir());
        }

        return;
        GetComponent<MeshRenderer>().RenderShader.SetUniform("sampler", 0);

        if (Input.GetKeyDown(KeyCode.C) && false)
        {
            Debug.Log(Name + ": Change");
            i = (i == 0 ? 1 : 0);
            switch (i)
            {
                case 0:
                    GetComponent<MeshRenderer>().RenderShader.SetUniform("sampler", GetComponent<MeshRenderer>().Get_TextureID(_Test));
                    break;
                case 1:
                    GetComponent<MeshRenderer>().RenderShader.SetUniform("sampler", GetComponent<MeshRenderer>().Get_TextureID(GetComponent<MeshRenderer>().RenderTexture));
                    break;
            }

            Debug.Log("i: " + i);
        }
        if (Input.GetKey(KeyCode.Up))
        { 
            GetComponent<Transform>().Rotation.y += 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Down))
        {
            GetComponent<Transform>().Rotation.y -= 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Left))
        {
            GetComponent<Transform>().Position.x -= 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Right))
        {
            GetComponent<Transform>().Position.x += 20f * Time.DeltaTime;
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
        //_MR.Set_Shader("BasicVertex.vs", "", "BasicFragment.fs");
        _MR.RenderShader.AddUniform("transform");
        _MR.RenderShader.AddUniform("nptransform");
        _MR.RenderShader.AddUniform("FlashLightDir");
        _MR.RenderShader.AddUniform("cam_pos");
        _MR.RenderShader.AddUniform("light_angle");
        _MR.RenderShader.AddUniform("sampler");
        _MR.RenderShader.AddUniform("underworldsampler");
        _MR.RenderShader.SetUniform("sampler", 0);
        _MR.RenderShader.SetUniform("underworldsampler", 1);
    }
}

