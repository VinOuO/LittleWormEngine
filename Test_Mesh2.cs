using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test_Mesh2 : DesignerProgram
{
    override public void Start()
    {
        //GetComponent<BoxCollider>().Set_ColliderSize(new Vector3(2, 4, 2));
        /*
        GetComponent<MeshRenderer>().Set(ResourceLoader.Load_Mesh("Cube3.obj"), ResourceLoader.Load_Texture("crate.jpg"));
        GetComponent<Transform>().Scale *= 1f;
        GetComponent<Transform>().Rotation.y = 0;
        GetComponent<Transform>().Position.z = 5f;
        GetComponent<Transform>().Position.y = 0;
        GetComponent<Transform>().Position.x = 0;
        */
    }
    bool b = true;
    public int _x = 2;
    override public void Update()
    {
        //Debug.Log("??");
        //Console.WriteLine("Name: " + (PhysicWorld.Get_Rigibody(Attaching_GameObject).UserObject as GameObject).Name);

        //Console.WriteLine("_x: " + PhysicWorld._x);
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (GetComponent<BoxCollider>().Is_Static)
            {
                GetComponent<BoxCollider>().Attaching_Rigidbody.Set_Static(false);
            }
            else
            {
                GetComponent<BoxCollider>().Attaching_Rigidbody.Set_Static(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Right))
        {
            _x = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Left))
        {
            _x = -2;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T");
            transform.Position.y = 10;
        }
        GetComponent<BoxCollider>().Attaching_Rigidbody.Set_LinearVelocity(Vector3.Right * _x);
        /*
        if (Input.GetKey(KeyCode.T))
        {
            GetComponent<Transform>().Position.z -= 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Y))
        {
            GetComponent<Transform>().Position.z += 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Up))
        {
            GetComponent<Transform>().Position.y += 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Down))
        {
            GetComponent<Transform>().Position.y -= 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Left))
        {
            GetComponent<Transform>().Position.x -= 2f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Right))
        {
            GetComponent<Transform>().Position.x += 2f * Time.DeltaTime;
        }
        */
    }
}

