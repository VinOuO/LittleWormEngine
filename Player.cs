using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Utility;

class Player : DesignerProgram
{
    float Speed = 25;
    public override void Start()
    {

    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Position += Camera.Main.ForwardDir * Time.DeltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Position -= Camera.Main.ForwardDir * Time.DeltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Position -= Camera.Main.RightDir * Time.DeltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Position += Camera.Main.RightDir * Time.DeltaTime * Speed;
        }
        if (Input.GetKeyDown(MouseCode.Left))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject _Temp = Instantiate("Bullet");
        _Temp.transform.Position = transform.Position + Camera.Main.ForwardDir.Normalize() * 3;
        _Temp.AddCustomComponent<Bullet_Behavior>();
        _Temp.GetCustomComponent<Bullet_Behavior>().Movement = GetComponent<Camera>().Get_MouseDir().Normalize();
    }

    public override void OnCollisionEnter(GameObject _Other)
    {
        //Debug.Log(_Other.Name + " Entered " + Name);
    }
    public override void OnCollisionExit(GameObject _Other)
    {
        //Debug.Log(_Other.Name + " Exit " + Name);
    }
}

