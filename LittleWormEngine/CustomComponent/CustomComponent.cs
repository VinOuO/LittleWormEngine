using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine
{
    interface CustomComponent
    {
        GameObject Attaching_GameObject { get; set; }

        void Start();
        void Update();
        void OnCollitionEnter(GameObject _Other);
        void OnCollitionStay(GameObject _Other);
        void OnCollitionExit(GameObject _Other);
    }
}
