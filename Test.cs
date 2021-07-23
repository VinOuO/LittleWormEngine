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
        GetComponent<MeshRenderer>().Add_Texture("Tex2.png");
        GetComponent<MeshRenderer>().RenderShader.SetUniform("sampler", 0);
    }
    int i = 1;
    override public void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(Name + ": Change");
            GetComponent<MeshRenderer>().RenderShader.SetUniform("sampler", i = (i == 0 ? 1 : 0));
            Debug.Log("i: " + i);
        }

        return;
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
}

