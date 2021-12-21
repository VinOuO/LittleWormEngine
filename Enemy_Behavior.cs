using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine;
using LittleWormEngine.Mathematics;
using LittleWormEngine.Utility;

class Enemy_Behavior:DesignerProgram
{
    ~Enemy_Behavior()
    {
        Debug.Log("Enemy Bye");
    }
    GameObject Cam;
    float Start_Time = 0;
    public override void Start()
    {
        Start_Time = Time.PresentTime();
        Cam = GameObject.Find("Camera");
    }

    public override void Update()
    {
        if (Is_Graunded)
        {
            Vector3 _Temp = Cam.transform.Position - transform.Position;
            _Temp.y = 0;
            GetComponent<BoxCollider>().Attaching_Rigidbody.Set_LinearVelocity(_Temp.Normalize() * Time.DeltaTime * 10000);
        }
        Face_Cam();

        if(Vector3.Distance(Cam.transform.Position, transform.Position) < 10)
        {
            Debug.Log("Hit Camera");
            ReSpawn();
        }
    }

    public void ReSpawn()
    {
        Debug.Log("Move");
        Vector3 _Temp = Vector3.Right * Matrix3.RotateY(LWRandom.Range() * 36) * 50 + Cam.transform.Position;
        transform.Position = new Vector3(_Temp.x, transform.Position.y, _Temp.z);
    }

    void Face_Cam()
    {
        transform.Rotation.y = (float)Math_of_Rotation.YAngle_between(Vector3.Left, (Cam.transform.Position - transform.Position));
    }

    bool Is_Graunded = false;
    public override void OnCollisionEnter(GameObject _Other)
    {
        if (_Other.Name == "Floor")
        {
            Is_Graunded = true;
        }
        if (_Other.Name == "Camera")
        {
            Debug.Log("Collided with Cam");
            Attaching_GameObject.Remove();
        }
    }
    public override void OnCollisionExit(GameObject _Other)
    {
        if (_Other.Name == "Floor")
        {
            Is_Graunded = false;
        }
    }
}

