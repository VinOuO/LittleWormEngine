using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Mathematics;
using LittleWormEngine.Utility;

class Bullet_Behavior : DesignerProgram
{
    ~Bullet_Behavior()
    {
        Debug.Log("Bullet Bye");
    }

    public Vector3 Movement = Vector3.Zero;
    float Spawn_Time = 0;
    public override void Start()
    {
        Spawn_Time = Time.PresentTime();
    }

    float Speed = 10;
    public override void Update()
    {
        if(Time.PresentTime() - Spawn_Time > 5)
        {
            Attaching_GameObject.Remove();
        }
        transform.Position += Movement * Time.DeltaTime * Speed;
    }

    public override void OnCollisionEnter(GameObject _Other)
    {
        if(_Other.Name == "Enemy")
        {
            Attaching_GameObject.Remove();
            _Other.GetCustomComponent<Enemy_Behavior>().ReSpawn();
            Debug.Log("Hit");
        }
    }
}

