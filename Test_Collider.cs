using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test_Collider : DesignerProgram
{
    override public void Start()
    {
        GetComponent<Transform>().Scale *= 2f;
    }

    override public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Transform>().Position.z -= 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Transform>().Position.z += 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().Position.y += 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().Position.y -= 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().Position.x -= 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().Position.x += 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Numpad6))
        {
            GetComponent<Transform>().Rotation.y += 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Numpad4))
        {
            GetComponent<Transform>().Rotation.y -= 20f * Time.DeltaTime;
        }
    }
}

