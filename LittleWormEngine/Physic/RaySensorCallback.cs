using System;
using System.Collections.Generic;
using System.Text;
using BulletSharp;
using LittleWormEngine.Utility;
namespace LittleWormEngine
{
    class RaySensorCallback : RayResultCallback
    {
        CollisionObject Obj;

        public RaySensorCallback()
        {

        }

        public RaySensorCallback(CollisionObject _Obj)
        {
            Obj = _Obj;
        }

        public override float AddSingleResult(LocalRayResult rayResult, bool normalInWorldSpace)
        {
            Obj = CollisionObject;
            return 0;
        }
    }
}
