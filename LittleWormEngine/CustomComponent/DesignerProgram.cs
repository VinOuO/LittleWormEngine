﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine
{
    abstract class DesignerProgram : CustomComponent
    {
        public GameObject Attaching_GameObject { get; set; }
        public abstract void Start();
        public abstract void Update();


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