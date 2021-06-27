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
    }
}
