using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;
namespace LittleWormEngine
{
    class RigidBody
    {
        BulletSharp.RigidBody Rig;
        public bool Is_Static = false;

        public RigidBody(BulletSharp.RigidBody _Rig)
        {
            Rig = _Rig;
        }

        public void Set_LinearVelocity(Vector3 _Vector)
        {
            Rig.Activate(true);
            Rig.LinearVelocity = new BulletSharp.Math.Vector3(_Vector.x, _Vector.y, _Vector.z);
        }

        public void Set_Static()
        {
            Rig.SetMassProps(0, new BulletSharp.Math.Vector3(0, 0, 0));
        }
    }
}
