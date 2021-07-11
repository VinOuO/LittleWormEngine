using System;
using System.Collections.Generic;
using System.Text;
using BulletSharp;

namespace LittleWormEngine
{
    class ContactSensorCallback : ContactResultCallback
    {
        List<CollisionObject> Objs;
        public ContactSensorCallback(List<CollisionObject> _Objs)
        {
            Objs = _Objs;
        }

        public override float AddSingleResult(ManifoldPoint cp,
            CollisionObjectWrapper colObj0, int partId0, int index0,
            CollisionObjectWrapper colObj1, int partId1, int index1)
        {
            Objs.Add(colObj1.CollisionObject);
            return 0;
        }
    }
}