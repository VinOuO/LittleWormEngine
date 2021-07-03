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
        /*
        GetComponent<MeshRenderer>().Set(ResourceLoader.Load_Mesh("Cube3.obj"), ResourceLoader.Load_Texture("crate.jpg"));
        GetComponent<Transform>().Scale *= 1f;
        GetComponent<Transform>().Rotation.y = 0;
        GetComponent<Transform>().Position.z = 5f;
        GetComponent<Transform>().Position.y = 0;
        GetComponent<Transform>().Position.x = 0;
        */
    }

    override public void Update()
    {
        //Console.WriteLine("Name: " + (PhysicWorld.Get_Rigibody(Attaching_GameObject).UserObject as GameObject).Name);

        //Console.WriteLine("_x: " + PhysicWorld._x);
        BulletSharp.RigidBody _Body = PhysicWorld.Get_Rigibody(Attaching_GameObject);
        if (_Body != null)
            lock (_Body)
            {
                Console.WriteLine("Name: " + (_Body.UserObject as GameObject).Name);
                //PhysicWorld.Apply_LinearVelocity(Attaching_GameObject);
                _Body.Activate(true);
                _Body.LinearVelocity = new BulletSharp.Math.Vector3(PhysicWorld._x, 0, 0);
            }
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

