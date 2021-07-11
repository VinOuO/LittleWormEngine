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
        GameObject.Find("TestObj").AddCustomComponent<Test>();
        GameObject.Find("Box").AddCustomComponent<Test>();
        /*
        GameObject Collider_Mesh = new GameObject("TestObj");
        Collider_Mesh.AddComponent<Transform>();
        Collider_Mesh.AddComponent<BoxCollider>();
        Collider_Mesh.AddCustomComponent<Test_Collider>();
        DesignerHandler.AddGameObject(Collider_Mesh);
        
        GameObject.Find("Box").AddComponent<BoxCollider>();
        GameObject.Find("Ashe").AddComponent<BoxCollider>();
        */
        /*
        GameObject Cam = new GameObject("Camera");
        Cam.AddComponent<Camera>();
        Cam.AddComponent<Transform>();
        Cam.AddCustomComponent<Test>();
        DesignerHandler.Add_GameObject(Cam);
        
        GameObject gameObject2 = new GameObject("Model2");
        gameObject2.AddComponent<Transform>();
        gameObject2.AddComponent<MeshRenderer>();
        gameObject2.AddCustomComponent<Test_Mesh2>();
        DesignerHandler.Add_GameObject(gameObject2);
        
        GameObject gameObject = new GameObject("Model");
        gameObject.AddComponent<Transform>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.AddCustomComponent<Test_Mesh>();
        DesignerHandler.Add_GameObject(gameObject);
        */
    }

    public static void Update()
    {
        
    }

    public static void End()
    {

    }
}
