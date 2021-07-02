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
        public static List<Component> Colliders; 
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
            Console.WriteLine("PW");
            Create_Colliders();
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
                            Create_Box(_Gameobject);
                            break;
                    }
                }
            }
        }

        static void Init_Physic_World()
        {
            //---init
            Colliders = new List<Component>();
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
            dynamicsWorld.AddRigidBody(body);
            //---create a dynamic rigidbody
        }

        public static CollisionShape Creat_Box(Component _BoxCollider, LittleWormEngine.Utility.Vector3 _HalfSize) //Use this to design collider component
        {
            //---create a dynamic rigidbody
            CollisionShape colShape = new BoxShape(_HalfSize.x * btWorldtoLWWorldScale, _HalfSize.y * btWorldtoLWWorldScale, _HalfSize.z * btWorldtoLWWorldScale);
            //CollisionShape colShape = new SphereShape(1);
            collisionShapes.Add(colShape);
            Colliders.Add(_BoxCollider);
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

            startTransform.Origin = new BulletSharp.Math.Vector3(_BoxCollider.Attaching_GameObject.transform.Position.x, _BoxCollider.Attaching_GameObject.transform.Position.y, _BoxCollider.Attaching_GameObject.transform.Position.z) * btWorldtoLWWorldScale;

            //using motionstate is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
            DefaultMotionState myMotionState = new DefaultMotionState(startTransform);
            RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, colShape, localInertia);
            RigidBody body = new RigidBody(rbInfo);
            dynamicsWorld.AddRigidBody(body);
            //---create a dynamic rigidbody
            return colShape;
        }
        public static float _x = 1;
        static void Simulation()
        {
            bool _r = false;

            for (int i = 0; i > -1; i++)
            {
                dynamicsWorld.StepSimulation(1.0f / 60.0f, 10);

                //print positions of all objects
                for (int j = dynamicsWorld.NumCollisionObjects - 1; j >= 0; j--)
                {
                    CollisionObject obj = dynamicsWorld.CollisionObjectArray[j];
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
                    /*
                    if (j == 1)
                    {
                        Colliders[0].Attaching_GameObject.transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                        //((GameObject)obj.UserObject).transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                        //Console.WriteLine(j + "pos : (" + trans.Origin.X + ", " + trans.Origin.Y + ", " + trans.Origin.Z + ")");
                        body.Activate(true);
                        body.LinearVelocity = new BulletSharp.Math.Vector3(_x, 0, 0);
                    }
                    if (j == 2)
                    {
                        Colliders[1].Attaching_GameObject.transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                        //Console.WriteLine(j + "pos : (" + trans.Origin.X + ", " + trans.Origin.Y + ", " + trans.Origin.Z + ")");
                        //body.LinearVelocity = new BulletSharp.Math.Vector3(_x, 0, 0);
                    }
                    */
                    
                    if (j == 1)
                    {
                        GameObject.Find("Box").transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                        //Console.WriteLine(j + "pos : (" + trans.Origin.X + ", " + trans.Origin.Y + ", " + trans.Origin.Z + ")");
                        body.Activate(true);
                        body.LinearVelocity = new BulletSharp.Math.Vector3(_x, 0, 0);
                    }
                    if (j == 2)
                    {
                        GameObject.Find("Ashe").transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                        //Console.WriteLine(j + "pos : (" + trans.Origin.X + ", " + trans.Origin.Y + ", " + trans.Origin.Z + ")");
                        //body.LinearVelocity = new BulletSharp.Math.Vector3(_x, 0, 0);
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
