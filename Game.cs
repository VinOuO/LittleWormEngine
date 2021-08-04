﻿using System;
using System.Collections.Generic;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine;
using LittleWormEngine.Utility;
using LittleWormEngine.Renderer;
using LittleWormEngine.Mathematics;

class Game
{
    public static void Start()
    {
        /*
        GameObject Ground = new GameObject("Ground");
        Ground.AddComponent<Transform>();
        Ground.transform.Position.y = -10;
        Ground.transform.Scale.x = 1000;
        Ground.transform.Scale.z = 1000;
        Ground.AddComponent<MeshRenderer>();
        Ground.GetComponent<MeshRenderer>().Set("Ground.obj", "Tex4.png");
        DesignerHandler.AddGameObject(Ground);
        */
        /*
        GameObject.Find("Ashe").AddCustomComponent<Test>();
        Floor.AddCustomComponent<Test>();
        GameObject Wall = new GameObject("Wall");
        Wall.AddComponent<Transform>();
        Wall.transform.Position.x = -19;
        Wall.transform.Rotation.y = 30;
        Wall.transform.Scale.y = 1000;
        Wall.transform.Scale.z = 1000;
        Wall.AddComponent<MeshRenderer>();
        Wall.GetComponent<MeshRenderer>().Set("Floor.obj", "Tex4.png");
        DesignerHandler.AddGameObject(Wall);
        Wall.AddCustomComponent<Test>();
        GameObject TeaTAble = new GameObject("TeaTAble");
        TeaTAble.AddComponent<Transform>();
        TeaTAble.transform.Position.x = 3f;
        TeaTAble.transform.Position.y = -7.3f;
        TeaTAble.transform.Position.z = -8.6f;
        TeaTAble.AddComponent<MeshRenderer>();
        TeaTAble.GetComponent<MeshRenderer>().Set("TeaTAble.obj", "Crate.jpg");
        DesignerHandler.AddGameObject(TeaTAble);
        TeaTAble.AddCustomComponent<Test>();
        */
        GameObject Light = Core.Create_Prefab("LightCamera");
        Light.Name = "Light";
        Core.LightCamera = Light.GetComponent<Camera>();
        GameObject.Find("Wall").GetCustomComponent<Test>().UnderWorldTexture = "Wall_Under.png";
        GameObject.Find("Picture").GetCustomComponent<Test>().UnderWorldTexture = "Picture_Under.png";
        GameObject.Find("Door").GetCustomComponent<Test>().UnderWorldTexture = "Door_Under.png";
        GameObject.Find("Bed").GetCustomComponent<Test>().UnderWorldTexture = "Bed_Under.png";
        GameObject.Find("Floor").GetCustomComponent<Test>().UnderWorldTexture = "Floor_Under.png";
        GameObject.Find("Closet").GetCustomComponent<Test>().UnderWorldTexture = "Closet_Under.png";
    }

    public static void Update()
    {
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
