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
    }

    public static void Update()
    {
        
    }

    public static void End()
    {

    }
}
