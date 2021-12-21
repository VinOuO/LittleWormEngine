using System;
using System.Collections.Generic;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Game
{
    static float Timer = 1;
    static float Timer2 = 1;
    static int Counter = 0;
    static int Max_Counter = 6;
    public static int Light_On = 1;
    public static void Start()
    {
        GameObject Light = Core.Create_Prefab("LightCamera");
        Light.Name = "Light";
        Core.LightCamera = Light.GetComponent<Camera>();
        GameObject.Find("Wall").GetCustomComponent<Test>().UnderWorldTexture = "Wall_Under.png";
        GameObject.Find("Picture").GetCustomComponent<Test>().UnderWorldTexture = "Picture_Under.png";
        GameObject.Find("Door").GetCustomComponent<Test>().UnderWorldTexture = "Door_Under.png";
        GameObject.Find("Bed").GetCustomComponent<Test>().UnderWorldTexture = "Bed_Under.png";
        GameObject.Find("Floor").GetCustomComponent<Test>().UnderWorldTexture = "Floor_Under.png";
        GameObject.Find("Closet").GetCustomComponent<Test>().UnderWorldTexture = "Closet_Under.png";
        Cam = GameObject.Find("Camera");
    }
    static GameObject Cam;
    public static void Update()
    {
        if (Time.time > Timer && Counter == -1)
        {
            Timer = Time.time + LWRandom.Range()/2;
            Counter = 0;
            Max_Counter = (int)LWRandom.Range();
        }

        if (Time.time > Timer2 && Counter >= 0)
        {
            Timer2 = Time.time + 0.05f;
            if (Counter < Max_Counter)
            {
                Light_On *= (Counter % 2 == 0 ? -1 : 1);
                Counter++;
            }
            else
            {
                Light_On = 1;
                Counter = -1;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            Cam.transform.Position += Camera.Main.ForwardDir * Time.DeltaTime * 50;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Cam.transform.Position -= Camera.Main.ForwardDir * Time.DeltaTime * 50;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Cam.transform.Position -= Camera.Main.RightDir * Time.DeltaTime * 50;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Cam.transform.Position += Camera.Main.RightDir * Time.DeltaTime * 50;
        }
        if (Input.GetKey(KeyCode.Up))
        {
            GameObject.Find("Ground").transform.Position.y += Time.DeltaTime * 50;
        }
        if (Input.GetKey(KeyCode.Down))
        {
            GameObject.Find("Ground").transform.Position.y -= Time.DeltaTime * 50;
        }
        switch (Core.Mode)
        {
            case "Editor":

                break;
            case "Game":
                if (Camera.Get_MousePos().x > 0.8f)
                {
                    Camera.Main.transform.Rotation.y += Time.DeltaTime * 50;
                }
                else if (Camera.Get_MousePos().x < -0.8f)
                {
                    Camera.Main.transform.Rotation.y -= Time.DeltaTime * 50;
                }
                break;
        }


    }

    public static void End()
    {

    }
}
