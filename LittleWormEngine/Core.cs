using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GLFW;
using static OpenGL.GL;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;
using LittleWorm;

namespace LittleWormEngine
{
    class Core
    {
        public static string Mode = "Editor";
        public static string SceneName = "Scene";
        public static int Width = 800;
        public static int Height = 640;
        public static long Frame_Cap = 5000;
        public static bool Is_Running;
        public static Window The_GameWindow;
        public static Camera The_Camera;
        public static List<GameObject> GameObjects = new List<GameObject>();
        public static uint Mesh_Num = 0;
        public static long Frame_Num = 0;
        static Thread Editor_Thread, Physic_Thread;

        public static void Start()
        {
            Create_Scene("Scene.lws");
            Game.Start();
            Glfw.SetCursorPositionCallback(The_GameWindow,Input.Check_Cursor_Position);
            The_Camera = Get_Camera();
            PhysicWorld.Set_PhysicWorld();
            while (!PhysicWorld.InisReady)
            {
                Thread.Sleep(1);
            }
            switch (Mode)
            {
                case "Editor":
                    Editor_Thread = new Thread(EditorCore.Start);
                    Editor_Thread.Start();
                    break;
                case "Game":
                    Physic_Thread = new Thread(PhysicWorld.Start_Simulation);
                    Physic_Thread.Start();
                    break;
            }

            Start_GameObjects_Components();

            if (!Is_Running)
            {
                Run();
            }
        }
        
        public static void Run()
        {
            Is_Running = true;
            double Min_Elapsed_Frame_Time = 1 / (double)Frame_Cap;
            long Last_Run_nTime = Time.Get_Time();
            long This_Run_nTime = Time.Get_Time();
            long Last_Frame_nTime = Time.Get_Time();
            long This_Frame_nTime = Time.Get_Time();
            long Passed_nTime = 0;
            double Unprossed_Time = 0;
            int FPS_Frame_Num = 0;
            long FPS_Passed_nTime = 0;

            while (Is_Running)
            {
                bool Start_Rendering = false;
                This_Run_nTime = Time.Get_Time();
                Passed_nTime = This_Run_nTime - Last_Run_nTime;
                Last_Run_nTime = Time.Get_Time();
                Unprossed_Time += Time.nano_to_Scend(Passed_nTime);
                FPS_Passed_nTime += Passed_nTime;

                while (Unprossed_Time > Min_Elapsed_Frame_Time)
                {
                    This_Frame_nTime = Time.Get_Time();
                    Time.PersiceDeltaTime = Time.nano_to_Scend(This_Frame_nTime - Last_Frame_nTime);
                    Time.DeltaTime = (float)Time.PersiceDeltaTime;
                    Last_Frame_nTime = Time.Get_Time();
                    Start_Rendering = true;
                    Unprossed_Time -= Min_Elapsed_Frame_Time;

                    if (Time.nano_to_Scend(FPS_Passed_nTime) > 0.5f)
                    {
                        //**********************************FPS
                        //Console.WriteLine(FPS_Frame_Num * 2);
                        //**********************************FPS
                        FPS_Passed_nTime = 0;
                        FPS_Frame_Num = 0;
                    }

                    switch (Mode)
                    {
                        case "Game":
                            Input.Update(The_GameWindow);
                            break;
                        case "Editor":
                            Input.Update(The_GameWindow);
                            DesignerHandler.Editor_Mode_Check_Input();
                            break;
                    }
                    Run_GameObjects_Components();
                    Game.Update();
                }
                
                if (Start_Rendering)
                {
                    switch (Mode)
                    {
                        case "Game":
                            Render(The_GameWindow);
                            break;
                        case "Editor":
                            Render(The_GameWindow);
                            break;
                    }
                    FPS_Frame_Num++;
                    Frame_Num++;
                }
                else
                {
                    Thread.Sleep(1);
                }

                if (GameWindow.Close_Requested(The_GameWindow))
                {
                    Stop();
                }
            }
        }

        static Camera Get_Camera()
        {
            foreach (GameObject _GameObject in GameObjects)
            {
                foreach (Component _Component in _GameObject.Components)
                {
                    if(_Component.GetType() == typeof(Camera))
                    {
                        return _Component as Camera;
                    }
                }
            }
            return null;
        }

        static void Start_GameObjects_Components()
        {
            switch (Mode)
            {
                case "Game":
                    foreach (GameObject _GameObject in GameObjects)
                    {
                        foreach (Component _Component in _GameObject.Components)
                        {
                            _Component.Start();
                        }
                        foreach (CustomComponent _Component in _GameObject.CustomComponents)
                        {
                            _Component.Start();
                        }
                    }
                    break;
                case "Editor":
                    foreach (GameObject _GameObject in GameObjects)
                    {
                        foreach (Component _Component in _GameObject.Components)
                        {
                            _Component.Start();
                        }
                        foreach (CustomComponent _Component in _GameObject.CustomComponents)
                        {
                            _Component.Start();
                        }
                    }
                    break;
            }
        }

        static void Run_GameObjects_Components()
        {
            switch (Mode)
            {
                case "Game":
                    foreach (GameObject _GameObject in GameObjects)
                    {
                        foreach (Component _Component in _GameObject.Components)
                        {
                            _Component.Update("Game");
                        }
                        foreach (CustomComponent _Component in _GameObject.CustomComponents)
                        {
                            _Component.Update();
                        }
                    }
                    break;
                case "Editor":
                    foreach (GameObject _GameObject in GameObjects)
                    {
                        foreach (Component _Component in _GameObject.Components)
                        {
                            _Component.Update("Editing");
                        }
                    }
                    break;
            }

            
        }

        static void Render_Meshes()
        {
            foreach (GameObject _GameObject in GameObjects)
            {
                foreach (Component _Component in _GameObject.RenderComponents)
                {
                    _Component.Update("Rendering");
                }
            }
        }

        public static uint Get_MeshID()
        {
            return Mesh_Num++;
        }

        public static void Stop()
        {
            if (Is_Running)
            {
                Is_Running = false;
                Clean();
            }
        }

        public static void Render(Window _Window)
        {
            RenderUtility.ClearScreen();
            Render_Meshes();
            GameWindow.Render(_Window);
        }

        public static void Clean()
        {
            Glfw.Terminate();
        }
        
        public static void Create_Scene(string _SceneName)
        {
            List<string> _SceneInfos = ResourceLoader.Load_File(@"Save\Scene\" + _SceneName);
            foreach(string _SceneInfo in _SceneInfos)
            {
                GameObject _GameObject = new GameObject();
                List<string> _GameObjectInfos = ResourceLoader.Load_File(@"Save\GameObject\" + _SceneInfo + ".lwobj");
                foreach (string _GameObjectInfo in _GameObjectInfos)
                {
                    List<string> _LineInfos = ResourceLoader.Split(_GameObjectInfo, ' ');
                    switch (_LineInfos[0])
                    {
                        case "Name":
                            _GameObject.Name = _LineInfos[1];
                            break;
                        case "Camera":
                            _GameObject.AddComponent<Camera>();
                            break;
                        case "Transform":
                            _GameObject.AddComponent<Transform>();
                            _GameObject.GetComponent<Transform>().Position = new Vector3(float.Parse(_LineInfos[1]), float.Parse(_LineInfos[2]), float.Parse(_LineInfos[3]));
                            _GameObject.GetComponent<Transform>().Rotation = new Vector3(float.Parse(_LineInfos[4]), float.Parse(_LineInfos[5]), float.Parse(_LineInfos[6]));
                            _GameObject.GetComponent<Transform>().Scale = new Vector3(float.Parse(_LineInfos[7]), float.Parse(_LineInfos[8]), float.Parse(_LineInfos[9]));
                            break;
                        case "MeshRenderer":
                            _GameObject.AddComponent<MeshRenderer>();
                            _GameObject.GetComponent<MeshRenderer>().Set(_LineInfos[1], _LineInfos[2]);
                            _GameObject.GetComponent<MeshRenderer>().OffSet = new Vector3(float.Parse(_LineInfos[3]), float.Parse(_LineInfos[4]), float.Parse(_LineInfos[5]));
                            break;
                        case "Custom":
                            _GameObject.AddCustomComponent(Type.GetType(_LineInfos[1]));
                            break;
                    }
                }
                DesignerHandler.AddGameObject(_GameObject);
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static extern void FreeConsole();

        static void Main()
        {
            AllocConsole();
            switch (Mode)
            {
                case "Game":
                    The_GameWindow = GameWindow.Create_Window(Width, Height, "Game");
                    //he_GameWindow = GameWindow.Create_Window("Game");
                    break;
                case "Editor":
                    The_GameWindow = GameWindow.Create_Window(Width, Height, "Scene");
                    break;
            }
            RenderUtility.InitGraphics();
            Start();
        }
        
    }
}
