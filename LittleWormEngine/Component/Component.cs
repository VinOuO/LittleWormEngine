using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine
{
    interface Component
    {
        GameObject Attaching_GameObject { get; set; }
        string Tag { get; set; }
        void Start();
        void Update(string _Type);
    }
}
