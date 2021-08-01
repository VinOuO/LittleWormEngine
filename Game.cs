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
    public static void Start()
    {
        GameObject Floor = new GameObject("Floor");
        Floor.AddComponent<Transform>();
        Floor.transform.Position.y = -10;
        Floor.transform.Scale.x = 1000;
        Floor.transform.Scale.z = 1000;
        Floor.AddComponent<MeshRenderer>();
        Floor.GetComponent<MeshRenderer>().Set("Floor.obj", "Tex4.png");
        DesignerHandler.AddGameObject(Floor);
        GameObject.Find("Ashe").AddCustomComponent<Test>();
        Floor.AddCustomComponent<Test>();
        /*
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
        */
        GameObject TeaTAble = new GameObject("TeaTAble");
        TeaTAble.AddComponent<Transform>();
        TeaTAble.transform.Position.x = 3f;
        TeaTAble.transform.Position.y = -7.3f;
        TeaTAble.transform.Position.z = -8.6f;
        TeaTAble.AddComponent<MeshRenderer>();
        TeaTAble.GetComponent<MeshRenderer>().Set("TeaTAble.obj", "Crate.jpg");
        DesignerHandler.AddGameObject(TeaTAble);
        TeaTAble.AddCustomComponent<Test>();

        GameObject Light = Core.Create_Prefab("LightCamera");
        Light.Name = "Light";
        Core.LightCamera = Light.GetComponent<Camera>();
    }

    public static void Update()
    {
        
    }

    public static void End()
    {

    }
}
