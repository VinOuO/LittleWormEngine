using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Test_Mesh : DesignerProgram
{
    GameObject _Box;
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
        _Box = Instantiate("Box");
        _Box.Name = "Box2";
        _Box.transform.Position = new Vector3(-3, 1, 50);
        //
        //Attaching_GameObject.transform.Position = Vector3.Forward * 10;
    }
    Vector3 Povit = Vector3.Zero;
    override public void Update()
    {
        if (Input.GetKey(KeyCode.Up))
        {
            GetComponent<Transform>().Position.y += 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Down))
        {
            GetComponent<Transform>().Position.y -= 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Left))
        {
            GetComponent<Transform>().Rotation.y -= 20f * Time.DeltaTime;
        }
        if (Input.GetKey(KeyCode.Right))
        {
            GetComponent<Transform>().Rotation.y += 20f * Time.DeltaTime;
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
            Debug.Log("fov: " + Camera.Main.fov);
            Debug.Log(transform.Position);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Right))
        {
            _Box.transform.Position.x += 1;
            Debug.Log(_Box.transform.Position);
        }
        else if (Input.GetKeyDown(KeyCode.Left))
        {
            _Box.transform.Position.x -= 1;
            Debug.Log(_Box.transform.Position);
        }
        else if (Input.GetKeyDown(KeyCode.Up))
        {
            _Box.transform.Position.z += 1;
            Debug.Log(_Box.transform.Position);
        }
        else if (Input.GetKeyDown(KeyCode.Down))
        {
            _Box.transform.Position.z -= 1;
            Debug.Log(_Box.transform.Position);
        }
        */
        //_Box.transform.Position.x+=Time.DeltaTime * 1;
        if (Input.GetKeyDown(KeyCode.H))
        {
            _Box.transform.Position = Vector3.Up * 0 + Vector3.Left* 10;
            /*
            GameObject _Temp = PhysicsWorld.RayCastHitGameObject(Vector3.Up * 100 + Povit, Vector3.Down * 100 + Povit);
            if (_Temp != null)
            {
                Debug.Log("Has Hit: " + _Temp.Name);
            }
            */
        }
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

