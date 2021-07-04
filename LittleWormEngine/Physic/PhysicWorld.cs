using System;
using System.Collections.Generic;
using System.Text;
using BulletSharp;
using System.IO;
using LittleWormEngine.Utility;

namespace LittleWormEngine
{
    class PhysicWorld
    {
        public static bool InisReady = false;
        //public static List<Component> Colliders; 
        public static BulletSharp.Math.Vector3 V = BulletSharp.Math.Vector3.Zero;
        static int btWorldtoLWWorldScale = 100;
        ///create 125 (5x5x5) dynamic objects
        const int ArraySizeX = 5, ArraySizeY = 5, ArraySizeZ = 5;

        ///scaling of the objects (0.1 = 20 centimeter boxes )
        const float StartPosX = -5;
        const float StartPosY = -5;
        const float StartPosZ = -3;

        static DefaultCollisionConfiguration collisionConfiguration;// = new DefaultCollisionConfiguration();

        ///use the default collision dispatcher. For parallel processing you can use a diffent dispatcher (see Extras/BulletMultiThreaded)
        static CollisionDispatcher dispatcher;// = new CollisionDispatcher(collisionConfiguration);
        ///btDbvtBroadphase is a good general purpose broadphase. You can also try out btAxis3Sweep.
        static BroadphaseInterface overlappingPairCache;// = new DbvtBroadphase();

        ///the default constraint solver. For parallel processing you can use a different solver (see Extras/BulletMultiThreaded)
        static SequentialImpulseConstraintSolver solver;// = new SequentialImpulseConstraintSolver();

        static DiscreteDynamicsWorld dynamicsWorld;// = new DiscreteDynamicsWorld(dispatcher, overlappingPairCache, solver, collisionConfiguration);
        static List<CollisionShape> collisionShapes;

        public static void Physic_Test()
        {
            Init_Physic_World();
            Create_Colliders();
            InisReady = true;
            Simulation();
            Clean_World();
        }

        static void Create_Colliders()
        {
            foreach(GameObject _Gameobject in Core.GameObjects)
            {
                foreach (Component _Component in _Gameobject.Components)
                {
                    switch (_Component.GetType().Name)
                    {
                        case "BoxCollider":
                            Create_Box(_Gameobject, (_Component as BoxCollider).HalfSize);
                            break;
                    }
                }
            }
        }

        static void Init_Physic_World()
        {
            //---init
            //Colliders = new List<Component>();
            collisionConfiguration = new DefaultCollisionConfiguration();
            dispatcher = new CollisionDispatcher(collisionConfiguration);
            overlappingPairCache = new DbvtBroadphase();
            solver = new SequentialImpulseConstraintSolver();
            dynamicsWorld = new DiscreteDynamicsWorld(dispatcher, overlappingPairCache, solver, collisionConfiguration);
            collisionShapes = new List<CollisionShape>();
            //---init
            dynamicsWorld.Gravity = new BulletSharp.Math.Vector3(0, -5, 0);

            //---create the ground
            CollisionShape groundShape = new BoxShape(99999999, 50, 50);
            collisionShapes.Add(groundShape);
            BulletSharp.Math.Matrix groundTransform = BulletSharp.Math.Matrix.Identity;
            groundTransform.Origin = new BulletSharp.Math.Vector3(0, -51, 0);

            float mass = 0;

            //rigidbody is dynamic if and only if mass is non zero, otherwise static
            bool isDynamic = (mass == 0 ? true : false);

            BulletSharp.Math.Vector3 localInertia = new BulletSharp.Math.Vector3(0, 0, 0);
            if (isDynamic)
                groundShape.CalculateLocalInertia(mass, out localInertia);

            //using motionstate is optional, it provides interpolation capabilities, and only synchronizes 'active' objects
            DefaultMotionState myMotionState = new DefaultMotionState(groundTransform);
            RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, groundShape, localInertia);
            RigidBody body = new RigidBody(rbInfo);

            //add the body to the dynamics world
            dynamicsWorld.AddRigidBody(body);
            //---create the ground
        }

        static void Create_Box(GameObject _Obj) //Use this to design collider component
        {
            Console.WriteLine(_Obj.Name);
            //---create a dynamic rigidbody
            CollisionShape colShape = new BoxShape(1 * 100, 1 * 100, 1 * 100);
            //CollisionShape colShape = new SphereShape(1);
            collisionShapes.Add(colShape);

            /// Create Dynamic Objects
            BulletSharp.Math.Matrix startTransform;
            startTransform = BulletSharp.Math.Matrix.Identity;

            float mass = 1;

            //rigidbody is dynamic if and only if mass is non zero, otherwise static
            bool isDynamic = (mass == 0 ? true : false);

            BulletSharp.Math.Vector3 localInertia = new BulletSharp.Math.Vector3(0, 0, 0);
            if (isDynamic)
            {
                colShape.CalculateLocalInertia(mass, out localInertia);
            }


            startTransform.Origin = new BulletSharp.Math.Vector3(_Obj.transform.Position.x, _Obj.transform.Position.y, _Obj.transform.Position.z) * 100;

            //using motionstate is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
            DefaultMotionState myMotionState = new DefaultMotionState(startTransform);
            RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, colShape, localInertia);
            RigidBody body = new RigidBody(rbInfo);
            body.UserObject = _Obj;
            dynamicsWorld.AddRigidBody(body);
            //---create a dynamic rigidbody
        }
        /*
        public static BulletSharp.RigidBody ReCreate_Rigibody(BulletSharp.RigidBody _OldRig)
        {
            BulletSharp.Math.Matrix startTransform;
            startTransform = BulletSharp.Math.Matrix.Identity;
            //using motionstate is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
            DefaultMotionState myMotionState = new DefaultMotionState();
            RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(1, _OldRig.MotionState, _OldRig.CollisionShape, _OldRig.LocalInertia);
            RigidBody body = new RigidBody(rbInfo);
            body.UserObject = _OldRig.UserObject;
            dynamicsWorld.AddRigidBody(body);
            dynamicsWorld.RemoveRigidBody(_OldRig);
            return body;
            //---create a dynamic rigidbody
        }
        */
        public static void Create_Box(GameObject _GameObject, LittleWormEngine.Utility.Vector3 _HalfSize) //Use this to design collider component
        {
            //---create a dynamic rigidbody
            CollisionShape colShape = new BoxShape(_HalfSize.x * btWorldtoLWWorldScale, _HalfSize.y * btWorldtoLWWorldScale, _HalfSize.z * btWorldtoLWWorldScale);
            //CollisionShape colShape = new SphereShape(1);
            collisionShapes.Add(colShape);
            colShape.UserObject = _GameObject;
            //Colliders.Add(_BoxCollider);
            /// Create Dynamic Objects
            BulletSharp.Math.Matrix startTransform;
            startTransform = BulletSharp.Math.Matrix.Identity;

            float mass = 1;

            //rigidbody is dynamic if and only if mass is non zero, otherwise static
            bool isDynamic = (mass == 0 ? true : false);

            BulletSharp.Math.Vector3 localInertia = new BulletSharp.Math.Vector3(0, 0, 0);
            if (isDynamic)
            {
                colShape.CalculateLocalInertia(mass, out localInertia);
            }

            startTransform.Origin = new BulletSharp.Math.Vector3(_GameObject.transform.Position.x, _GameObject.transform.Position.y, _GameObject.transform.Position.z) * btWorldtoLWWorldScale;

            //using motionstate is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
            DefaultMotionState myMotionState = new DefaultMotionState(startTransform);
            RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, colShape, localInertia);
            RigidBody body = new RigidBody(rbInfo);
            body.UserObject = _GameObject;
            dynamicsWorld.AddRigidBody(body);
            //---create a dynamic rigidbody
        }

        public static RigidBody Get_Rigibody(GameObject _GameObject)
        {
            foreach(CollisionObject _Cobj in dynamicsWorld.CollisionObjectArray)
            {
                if(_Cobj.UserObject == null)
                {
                    continue;
                }
                if((_Cobj.UserObject as GameObject) == _GameObject)
                {
                    return RigidBody.Upcast(_Cobj);
                }
            }
            return null;
        }

        static void Simulation()
        {
            bool _r = false;

            while (true)
            {
                dynamicsWorld.StepSimulation(Time.DeltaTime, 10);
                //print positions of all objects
                for (int i = dynamicsWorld.NumCollisionObjects - 1; i >= 0; i--)
                {
                    CollisionObject obj = dynamicsWorld.CollisionObjectArray[i];
                    RigidBody body = RigidBody.Upcast(obj);
                    BulletSharp.Math.Matrix trans;
                    if (body != null && body.MotionState != null)
                    {
                        trans = body.MotionState.WorldTransform;
                    }
                    else
                    {
                        trans = obj.WorldTransform;
                    }
                    GameObject _Temp = (obj.UserObject as GameObject);
                    if (obj.UserObject != null)
                    {
                        _Temp.transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                    }
                }

            }
        }

        static void Clean_World()
        {
            //remove the rigidbodies from the dynamics world and delete them
            for (int i = dynamicsWorld.NumCollisionObjects - 1; i >= 0; i--)
            {
                CollisionObject obj = dynamicsWorld.CollisionObjectArray[i];
                RigidBody body = RigidBody.Upcast(obj);
                if (body != null && body.MotionState != null)
                {
                    body.MotionState.Dispose();
                }
                dynamicsWorld.RemoveCollisionObject(obj);
                obj.Dispose();
            }

            //delete collision shapes
            for (int j = 0; j < collisionShapes.Count; j++)
            {
                CollisionShape shape = collisionShapes[j];
                collisionShapes.RemoveAt(j);
                shape.Dispose();
            }

            //delete dynamics world
            dynamicsWorld.Dispose();

            //delete solver
            solver.Dispose();

            //delete broadphase
            overlappingPairCache.Dispose();

            //delete dispatcher
            dispatcher.Dispose();

            collisionConfiguration.Dispose();
            //next line is optional: it will be cleared by the destructor when the array goes out of scope
            collisionShapes.Clear();
        }
    }
}
