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
        void OnCollisionEnter(GameObject _Other);
        void OnCollisionStay(GameObject _Other);
        void OnCollisionExit(GameObject _Other);
    }
}
