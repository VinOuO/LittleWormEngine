using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test_Mesh : DesignerProgram
{
    override public void Start()
    {
        /*
        GetComponent<MeshRenderer>().Set(ResourceLoader.Load_Mesh("Ashe2.obj"), ResourceLoader.Load_Texture("T_Ashe.png"));
        GetComponent<Transform>().Scale *= 0.03f;
        GetComponent<Transform>().Rotation.y = 180;
        GetComponent<Transform>().Position.z = 5f;
        GetComponent<Transform>().Position.y = -3;
        GetComponent<Transform>().Position.x = 0;
        */
        //GetComponent<BoxCollider>().Attaching_Rigibody.Set_Static();
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

