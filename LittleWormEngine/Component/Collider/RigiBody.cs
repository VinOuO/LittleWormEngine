using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Utility;
namespace LittleWormEngine
{
    class RigidBody
    {
        public Collider Attaching_Collider;
        public BulletSharp.RigidBody Rig;
        float Mass;

        public RigidBody(BulletSharp.RigidBody _Rig)
        {
            Rig = _Rig;
            Mass = _Rig.InvMass;
        }

        public void Set_LinearVelocity(Vector3 _Vector)
        {
            Rig.Activate(true);
            Rig.LinearVelocity = new BulletSharp.Math.Vector3(_Vector.x, _Vector.y, _Vector.z);
        }

        public void Set_Static(bool _Value)
        {
            if (_Value)
            {
                Rig.SetMassProps(0, new BulletSharp.Math.Vector3(0, 0, 0));
                Attaching_Collider.Is_Static = true;
            }
            else
            {
                Rig.SetMassProps(Mass, new BulletSharp.Math.Vector3(0, 0, 0));
                Attaching_Collider.Is_Static = false;
            }
        }
    }
}
