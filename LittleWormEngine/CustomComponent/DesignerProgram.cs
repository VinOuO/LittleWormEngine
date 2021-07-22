using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine
{
    abstract class DesignerProgram : CustomComponent
    {
        public GameObject Attaching_GameObject { get; set; }
        public string Name { get { return Attaching_GameObject.Name; } set{ Attaching_GameObject.Name = value; } }
        public abstract void Start();
        public abstract void Update();
        public virtual void OnCollitionEnter(GameObject _Other) { }
        public virtual void OnCollitionStay(GameObject _Other) { }
        public virtual void OnCollitionExit(GameObject _Other) { }
        public Transform transform { get { return GetComponent<Transform>(); } }

        public GameObject Instantiate(string _PrefabName)
        {
            return Core.Create_Prefab(_PrefabName);
        }

        public T GetComponent<T>() where T : Component
        {
            if (Attaching_GameObject.Components.Exists(_x => _x is T))
            {
                return (T)Attaching_GameObject.Components.Find(_x => _x is T);
            }
            else
            {
                return (T)(Component)null;
            }
        }

        public T GetCustomComponent<T>() where T : CustomComponent
        {
            if (Attaching_GameObject.CustomComponents.Exists(_x => _x is T))
            {
                return (T)Attaching_GameObject.CustomComponents.Find(_x => _x is T);
            }
            else
            {
                return (T)(CustomComponent)null;
            }
        }
    }
}
