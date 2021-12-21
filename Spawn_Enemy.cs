using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Mathematics;
using LittleWormEngine.Utility;

class Spawn_Enemy : DesignerProgram
{
    float Last_Spawn_Time;
    public override void Start()
    {
        Last_Spawn_Time = Time.PresentTime() - 10;
        Spawn(new Vector3(1, 0, 0) * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + transform.Position);
        Spawn(new Vector3(1, 0, 0) * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + transform.Position);
        Spawn(new Vector3(1, 0, 0) * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + transform.Position);
        Spawn(new Vector3(1, 0, 0) * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + transform.Position);
        Spawn(new Vector3(1, 0, 0) * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + transform.Position);

    }

    public override void Update()
    {
        /*
        if(Time.PresentTime() - Last_Spawn_Time > 10)
        {
            Spawn(new Vector3(1, 0, 0) * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + transform.Position);
            Last_Spawn_Time = Time.PresentTime();
            Debug.Log("Spawn_Enemy");
        }
        */
    }
    
    void Spawn(Vector3 _Pos)
    {
        GameObject _Temp = Instantiate("Enemy");
        _Temp.transform.Position = _Pos;
        _Temp.AddCustomComponent<Enemy_Behavior>();
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

