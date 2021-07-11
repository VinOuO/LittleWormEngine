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
        
    }

    override public void Update()
    {
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
        Debug.Log(_Other.Name + " Entered");
    }
    public override void OnCollitionExit(GameObject _Other)
    {
        Debug.Log(_Other.Name + " Exited");
    }
}

