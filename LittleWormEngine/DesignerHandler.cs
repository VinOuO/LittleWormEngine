using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;

namespace LittleWormEngine
{
    class DesignerHandler
    {
        public static int ChoosingGameObjectID = 1;

        public static void AddGameObject(GameObject _GameObject)
        {
            Core.GameObjects.Add(_GameObject);
        }

        public static Vector2 MouseMovement = new Vector2(Vector2.Zero);
        static Vector2 LastMousePos = new Vector2(Vector2.Zero);
        static Vector2 NowMousePos = new Vector2(Vector2.Zero);

        public static void Editor_Mode_Check_Input()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ResourceLoader.Save_Scene();
                    foreach (GameObject _GameObject in Core.GameObjects)
                    {
                        ResourceLoader.Save_GameObjectFile(_GameObject);
                        //ResourceLoader.Save_GameObjectFile(_GameObject, "Transform");
                        //ResourceLoader.Save_GameObjectFile(_GameObject, "MeshRenderer");
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ChoosingGameObjectID++;
                ChoosingGameObjectID %= Core.GameObjects.Count;
                if(ChoosingGameObjectID == 0)
                {
                    ChoosingGameObjectID = 1;
                }
            }

            if (Input.GetKeyDown(MouseCode.Left))
            {
                MouseMovement = new Vector2(Vector2.Zero);
                LastMousePos = Input.MousePosition;
                NowMousePos = Input.MousePosition;
            }

            if (Input.GetKey(MouseCode.Left))
            {
                NowMousePos = Input.MousePosition;
                MouseMovement = (NowMousePos - LastMousePos) * Time.DeltaTime;
                LastMousePos = NowMousePos;
                MouseMovement.y *= -1;
                //Console.WriteLine("(" + MouseMovement.x + ", " + MouseMovement.y + ")");
            }
            
            if (Input.GetKey(KeyCode.Q))
            {
                Core.GameObjects[ChoosingGameObjectID].transform.Position.x += MouseMovement.x * 10;
                Core.GameObjects[ChoosingGameObjectID].transform.Position.y += MouseMovement.y * 10;
            }
            if (Input.GetKey(KeyCode.W))
            {
                Core.GameObjects[ChoosingGameObjectID].transform.Rotation.x += MouseMovement.x * 10;
                Core.GameObjects[ChoosingGameObjectID].transform.Rotation.y += MouseMovement.y * 10;
            }
        }
    }
}
