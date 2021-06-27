using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWormEngine.Renderer
{
    class Uniform
    {
        public string Name { get; set; }
        public int Location { get; set; }

        public Uniform(string _Name, int _Location)
        {
            Name = _Name;
            Location = _Location;
        }
    }
}
