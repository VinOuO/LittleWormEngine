using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;

namespace LittleWormEngine
{
    class GameObject
    {
        public string Name;
        public List<Component> RenderComponents = new List<Component>();
        public List<Component> Components = new List<Component>();
        public List<CustomComponent> CustomComponents = new List<CustomComponent>();

        public Transform transform { get { return GetComponent<Transform>(); } }

        public GameObject() { }

        public GameObject(string _Name)
        {
            Name = _Name;
        }

        public void Remove()
        {
            Core.GameObjects.Remove(this);
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

        public void RemoveComponent<T>() where T : Component
        {
            foreach (Component _Component in Components)
            {
                if (_Component.GetType().Name == typeof(T).Name)
                {
                    Components.Remove(_Component);
                    break;
                }
            }
            foreach (Component _Component in RenderComponents)
            {
                if (_Component.GetType().Name == typeof(T).Name)
                {
                    RenderComponents.Remove(_Component);
                    return;
                }
            }
        }

        public void RemoveComponent(string _T)
        {
            foreach (Component _Component in Components)
            {
                if (_Component.GetType().Name == _T)
                {
                    Components.Remove(_Component);
                    _Component.Attaching_GameObject = null;
                    break;
                }
            }
            foreach (Component _Component in RenderComponents)
            {
                if (_Component.GetType().Name == _T)
                {
                    RenderComponents.Remove(_Component);
                    return;
                }
            }
        }

        public void AddComponent(string _T)
        {
            Component _Adding_Component = (Component)Activator.CreateInstance(Type.GetType("LittleWormEngine." + _T));
            if (_Adding_Component == null)
            {
                return;
            }
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
                if (_GameObject.Name == _GameObject_Name)
                {
                    return _GameObject;
                }
            }
            return null;
        }

        public bool Is_Component_Attached(string _ComponentName)
        {
            foreach (Component _Component in Components)
            {
                if (_ComponentName == _Component.GetType().Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
