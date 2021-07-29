using System;
using System.Collections.Generic;
using System.Linq;
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
        public static string Mode = "Game";
        public static string SceneName = "Scene_Debug" + ".lws";
        public static Camera MainCamera;
        public static int Width = 1050;
        public static int Height = 1050;
        public static long Frame_Cap = 5000;
        public static bool Is_Running;
        public static Window The_GameWindow;
        public static Camera The_Camera;
        public static List<GameObject> GameObjects = new List<GameObject>();
        public static List<GameObject> AddingGameObjects = new List<GameObject>();
        public static List<GameObject> DeletingGameObjects = new List<GameObject>();
        public static List<GameObject> Prefabs = new List<GameObject>();
        public static uint Mesh_Num = 0;
        public static long Frame_Num = 0;
        static Thread Editor_Thread, Physics_Thread;
        public static float Physics_Simulation_Time = 0;
        public static List<ModifyingGameObjectInfo> ModifyingGameObjectInfos = new List<ModifyingGameObjectInfo>();

        public static void Start()
        {
            Create_Scene(SceneName);
            Game.Start();
            Glfw.SetCursorPositionCallback(The_GameWindow,Input.Check_Cursor_Position);
            The_Camera = Get_Camera();
            PhysicsWorld.Set_PhysicWorld();
            while (!PhysicsWorld.InisReady)
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
                    Physics_Thread = new Thread(PhysicsWorld.Start_Simulation);
                    Physics_Thread.Start();
                    break;
            }

            Start_GameObjects_Components(GameObjects);

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
                    Physics_Simulation_Time = Time.DeltaTime;
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
                            Update_GameObjects();
                            break;
                        case "Editor":
                            Input.Update(The_GameWindow);
                            DesignerHandler.Editor_Mode_Check_Input();
                            Modify_GameObjects();
                            break;
                    }

                    Run_GameObjects_Components(GameObjects);
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

        static void Modify_GameObjects()
        {
            ModifyingGameObjectInfo _Temp_Info;
            while(ModifyingGameObjectInfos.Count > 0)
            {
                if(ModifyingGameObjectInfos[0].RemovingComponent == null)
                {
                    RemoveGameObject(ModifyingGameObjectInfos[0].ModifyingGameObject);
                }
                else
                {
                    ModifyingGameObjectInfos[0].ModifyingGameObject.RemoveComponent(ModifyingGameObjectInfos[0].RemovingComponent);
                }
                ModifyingGameObjectInfos.RemoveAt(0);
            }
        }

        static void Start_GameObjects_Components(List<GameObject> _GameObjects)
        {
            switch (Mode)
            {
                case "Game":
                    foreach (GameObject _GameObject in _GameObjects)
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
                    foreach (GameObject _GameObject in _GameObjects)
                    {
                        foreach (Component _Component in _GameObject.Components)
                        {
                            _Component.Start();
                        }
                    }
                    break;
            }
        }

        static void Run_GameObjects_Components(List<GameObject> _GameObjects)
        {
            switch (Mode)
            {
                case "Game":
                    foreach (GameObject _GameObject in _GameObjects)
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
                    foreach (GameObject _GameObject in _GameObjects)
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
            MeshRenderer.Inis_ShadowMapping();
            foreach (GameObject _GameObject in GameObjects)
            {
                foreach (Component _Component in _GameObject.RenderComponents)
                {
                    _Component.Update("Rendering");
                }
            }
            MeshRenderer.Show_ShadowMap();
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
            foreach (string _SceneInfo in _SceneInfos)
            {
                switch (ResourceLoader.Split(_SceneInfo, '_')[0])
                {
                    case "GameObject":
                        GameObject _GameObject = new GameObject();
                        _GameObject.Name = ResourceLoader.Split(_SceneInfo, '_')[1];
                        List<string> _GameObjectInfos = ResourceLoader.Load_File(@"Save\GameObject\" + _SceneInfo + ".lwobj");
                        foreach (string _GameObjectInfo in _GameObjectInfos)
                        {
                            List<string> _LineInfos = ResourceLoader.Split(_GameObjectInfo, ' ');
                            switch (_LineInfos[0])
                            {
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
                                case "BoxCollider":
                                    _GameObject.AddComponent<BoxCollider>();
                                    _GameObject.GetComponent<BoxCollider>().Is_Trigger = bool.Parse(_LineInfos[1]);
                                    _GameObject.GetComponent<BoxCollider>().Is_Static = bool.Parse(_LineInfos[2]);
                                    _GameObject.GetComponent<BoxCollider>().OffSet = new Vector3(float.Parse(_LineInfos[3]), float.Parse(_LineInfos[4]), float.Parse(_LineInfos[5]));
                                    _GameObject.GetComponent<BoxCollider>().Set_BoxColiiderSize(new Vector3(float.Parse(_LineInfos[6]), float.Parse(_LineInfos[7]), float.Parse(_LineInfos[8])));
                                    break;
                                case "CapsuleCollider":
                                    _GameObject.AddComponent<CapsuleCollider>();
                                    _GameObject.GetComponent<CapsuleCollider>().Is_Trigger = bool.Parse(_LineInfos[1]);
                                    _GameObject.GetComponent<CapsuleCollider>().Is_Static = bool.Parse(_LineInfos[2]);
                                    _GameObject.GetComponent<CapsuleCollider>().OffSet = new Vector3(float.Parse(_LineInfos[3]), float.Parse(_LineInfos[4]), float.Parse(_LineInfos[5]));
                                    _GameObject.GetComponent<CapsuleCollider>().Set_CapsuleColliderSize(new Vector2(float.Parse(_LineInfos[6]), float.Parse(_LineInfos[7])));
                                    break;
                                case "Custom":
                                    _GameObject.AddCustomComponent(Type.GetType(_LineInfos[1]));
                                    break;
                            }
                        }
                        GameObjects.Add(_GameObject);
                        break;
                }

            }
        }

        static void Update_GameObjects()
        {
            if(AddingGameObjects.Count > 0)
            {
                Start_GameObjects_Components(AddingGameObjects);
                while (AddingGameObjects.Count > 0)
                {
                    GameObjects.Add(AddingGameObjects[0]);
                    AddingGameObjects.RemoveAt(0);
                }
            }

            while (DeletingGameObjects.Count > 0)
            {
                GameObjects.Remove(DeletingGameObjects[0]);
                DeletingGameObjects.RemoveAt(0);
            }
        }

        public static GameObject Create_Prefab(string _PrefabName)
        {
            GameObject _GameObject = new GameObject();
            _GameObject.Name = _PrefabName;
            List<string> _GameObjectInfos = ResourceLoader.Load_File(@"Save\Prefab\Prefab_" + _PrefabName + ".lwobj");
            foreach (string _GameObjectInfo in _GameObjectInfos)
            {
                List<string> _LineInfos = ResourceLoader.Split(_GameObjectInfo, ' ');
                switch (_LineInfos[0])
                {
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
                    case "BoxCollider":
                        _GameObject.AddComponent<BoxCollider>();
                        _GameObject.GetComponent<BoxCollider>().Is_Trigger = bool.Parse(_LineInfos[1]);
                        _GameObject.GetComponent<BoxCollider>().Is_Static = bool.Parse(_LineInfos[2]);
                        _GameObject.GetComponent<BoxCollider>().OffSet = new Vector3(float.Parse(_LineInfos[3]), float.Parse(_LineInfos[4]), float.Parse(_LineInfos[5]));
                        _GameObject.GetComponent<BoxCollider>().Set_BoxColiiderSize(new Vector3(float.Parse(_LineInfos[6]), float.Parse(_LineInfos[7]), float.Parse(_LineInfos[8])));
                        break;
                    case "CapsuleCollider":
                        _GameObject.AddComponent<CapsuleCollider>();
                        _GameObject.GetComponent<CapsuleCollider>().Is_Trigger = bool.Parse(_LineInfos[1]);
                        _GameObject.GetComponent<CapsuleCollider>().Is_Static = bool.Parse(_LineInfos[2]);
                        _GameObject.GetComponent<CapsuleCollider>().OffSet = new Vector3(float.Parse(_LineInfos[3]), float.Parse(_LineInfos[4]), float.Parse(_LineInfos[5]));
                        _GameObject.GetComponent<CapsuleCollider>().Set_CapsuleColliderSize(new Vector2(float.Parse(_LineInfos[6]), float.Parse(_LineInfos[7])));
                        break;
                    case "Custom":
                        _GameObject.AddCustomComponent(Type.GetType(_LineInfos[1]));
                        break;
                }
            }
            AddingGameObjects.Add(_GameObject);
            return _GameObject;
        }

        public static void Delet_GameObject(GameObject _GameObject)
        {
            DeletingGameObjects.Add(_GameObject);
        }

        public static List<string> Get_Components()
        {
            List<string> _Temp_Components = new List<string>();
            System.Reflection.Assembly _Assembly = System.Reflection.Assembly.GetEntryAssembly();
            foreach (System.Reflection.TypeInfo _TypeInfo in _Assembly.DefinedTypes)
            {
                if (_TypeInfo.ImplementedInterfaces.Contains(typeof(Component)) && !_TypeInfo.IsAbstract)
                {
                    _Temp_Components.Add(_TypeInfo.Name);
                    //Debug.Log(_TypeInfo.FullName);
                }
            }
            return _Temp_Components;
        }

        public static void RemoveGameObject(GameObject _GameObject)
        {
            GameObjects.Remove(_GameObject);
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
                    //The_GameWindow = GameWindow.Create_Window("Game");
                    break;
                case "Editor":
                    The_GameWindow = GameWindow.Create_Window(Width, Height, "Scene");
                    break;
            }
            RenderUtility.InitGraphics();
            Start();
        }
        
    }

    class ModifyingGameObjectInfo
    {
        public GameObject ModifyingGameObject;
        public string RemovingComponent;

        public ModifyingGameObjectInfo(GameObject _ModifyingGameObject, string _RemovingComponent)
        {
            ModifyingGameObject = _ModifyingGameObject;
            RemovingComponent = _RemovingComponent;
        }

        public ModifyingGameObjectInfo(GameObject _ModifyingGameObject)
        {
            ModifyingGameObject = _ModifyingGameObject;
        }
    }
}
