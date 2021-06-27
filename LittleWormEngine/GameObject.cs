using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine
{
    class GameObject
    {
        public string Name;
        public List<Component> RenderComponents = new List<Component>();
        public List<Component> Components = new List<Component>();
        public List<CustomComponent> CustomComponents = new List<CustomComponent>();

        public Transform transform { get { return GetComponent<Transform>() as Transform; } set { } }

        public GameObject() { }

        public GameObject(string _Name)
        {
            Name = _Name;
        }

        public void AddComponent<T>() where T : Component
        {
            Component _Adding_Component = (Component)Activator.CreateInstance(typeof(T));
            _Adding_Component.Attaching_GameObject = this;
            Components.Add(_Adding_Component);
            if (_Adding_Component.Tag == "Renderer")
            {
                RenderComponents.Add(_Adding_Component);
            }
        }

        public T GetComponent<T>() where T : Component
        {
            if (Components.Exists(_x => _x is T))
            {
                return (T)Components.Find(_x => _x is T);
            }
            else
            {
                return (T)(Component)null;
            }
        }

        public void AddCustomComponent<T>() where T : CustomComponent
        {
            CustomComponent _Adding_Component = (CustomComponent)Activator.CreateInstance(typeof(T));
            _Adding_Component.Attaching_GameObject = this;
            CustomComponents.Add(_Adding_Component);
        }

        public void AddCustomComponent(Type _T)
        {
            CustomComponent _Adding_Component = (CustomComponent)Activator.CreateInstance(_T);
            _Adding_Component.Attaching_GameObject = this;
            CustomComponents.Add(_Adding_Component);
        }

        public T GetCustomComponent<T>() where T : CustomComponent
        {
            if (CustomComponents.Exists(_x => _x is T))
            {
                return (T)CustomComponents.Find(_x => _x is T);
            }
            else
            {
                return (T)(CustomComponent)null;
            }
        }

        public static GameObject Find(string _GameObject_Name)
        {
            foreach (GameObject _GameObject in Core.GameObjects)
            {
                if(_GameObject.Name == _GameObject_Name)
                {
                    return _GameObject;
                }
            }
            return null;
        }
    }
}
