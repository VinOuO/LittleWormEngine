using System;
using System.Collections.Generic;
using BulletSharp;
using System.IO;
using LittleWormEngine.Utility;

namespace LittleWormEngine
{
    class PhysicsWorld
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

        public static void Start_Simulation()
        {
            Simulation();
            Clean_World();
        }

        public static void Set_PhysicWorld()
        {
            Init_Physic_World();
            Create_Colliders();
            InisReady = true;
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
                            if(_Gameobject.Name == "Box" || _Gameobject.Name == "Ashe")
                            {
                                Create_Box(_Gameobject, (_Component as BoxCollider).HalfSize);
                            }
                            else
                            {
                                Create_GhostBox(_Gameobject, (_Component as BoxCollider).HalfSize);
                            }
                            break;
                    }
                }
            }
        }

        static void Add_PairTests()
        {
            //dynamicsWorld.ContactPairTest(Get_Rigibody(GameObject.Find("Ashe")), Get_Rigibody(GameObject.Find("Box")), new ContactSensorCallback());
            List<CollisionObject> _Used = new List<CollisionObject>();
            foreach (CollisionObject _objA in dynamicsWorld.CollisionObjectArray)
            {
                _Used.Add(_objA);
                foreach (CollisionObject _objB in dynamicsWorld.CollisionObjectArray)
                {
                    if (!_Used.Contains(_objB) && _objA != _objB)
                    {
                        //dynamicsWorld.ContactPairTest(_objA, _objB, new ContactSensorCallback());
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
            //dynamicsWorld.Broadphase.OverlappingPairCache.SetInternalGhostPairCallback(new GhostPairCallback());
            dynamicsWorld.PairCache.SetInternalGhostPairCallback(new GhostPairCallback());
            //---init
            dynamicsWorld.Gravity = new BulletSharp.Math.Vector3(0, -5, 0);

            //---create the ground
            CollisionShape groundShape = new BoxShape(99999999, 10, 10);
            collisionShapes.Add(groundShape);
            BulletSharp.Math.Matrix groundTransform = BulletSharp.Math.Matrix.Identity;
            groundTransform.Origin = new BulletSharp.Math.Vector3(0, -60, 0);

            float mass = 0;
            //rigidbody is dynamic if and only if mass is non zero, otherwise static
            bool isDynamic = (mass == 0 ? true : false);

            BulletSharp.Math.Vector3 localInertia = new BulletSharp.Math.Vector3(0, 0, 0);
            if (isDynamic)
                groundShape.CalculateLocalInertia(mass, out localInertia);

            //using motionstate is optional, it provides interpolation capabilities, and only synchronizes 'active' objects
            DefaultMotionState myMotionState = new DefaultMotionState(groundTransform);
            RigidBodyConstructionInfo rbInfo = new RigidBodyConstructionInfo(mass, myMotionState, groundShape, localInertia);
            BulletSharp.RigidBody body = new BulletSharp.RigidBody(rbInfo);

            //add the body to the dynamics world
            dynamicsWorld.AddRigidBody(body);
            //---create the ground
        }


        public static CollisionShape Create_CapsuleShape(LittleWormEngine.Utility.Vector2 _RadiusHeight)
        {
            return new CapsuleShape(_RadiusHeight.x * btWorldtoLWWorldScale, _RadiusHeight.y * btWorldtoLWWorldScale);
        }

        public static CollisionShape Create_BoxShape(LittleWormEngine.Utility.Vector3 _HalfSize)
        {
            return new BoxShape(_HalfSize.x * btWorldtoLWWorldScale, _HalfSize.y * btWorldtoLWWorldScale, _HalfSize.z * btWorldtoLWWorldScale);
        }

        static List<BulletSharp.RigidBody> Rigidbodys = new List<BulletSharp.RigidBody>();
        public static void Create_Box(GameObject _GameObject, LittleWormEngine.Utility.Vector3 _HalfSize) //Use this to design collider component
        {
            CollisionShape colShape = Create_BoxShape(_HalfSize);
            collisionShapes.Add(colShape);

            //---create a dynamic rigidbody
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
            BulletSharp.RigidBody body = new BulletSharp.RigidBody(rbInfo);
            body.UserObject = _GameObject;
            dynamicsWorld.AddRigidBody(body);
            Rigidbodys.Add(body);
            //---create a dynamic rigidbody
        }

        public static void Create_GhostBox(GameObject _GameObject, LittleWormEngine.Utility.Vector3 _HalfSize) //Use this to design collider component
        {
            CollisionShape colShape = Create_BoxShape(_HalfSize);
            collisionShapes.Add(colShape);

            //---create a Ghost
            BulletSharp.Math.Matrix startTransform;
            startTransform = BulletSharp.Math.Matrix.Identity;
            startTransform.Origin = new BulletSharp.Math.Vector3(_GameObject.transform.Position.x, _GameObject.transform.Position.y, _GameObject.transform.Position.z) * btWorldtoLWWorldScale;
            GhostObject GObj = new GhostObject();
            GObj.CollisionShape = colShape;
            GObj.WorldTransform = startTransform;
            GObj.UserObject = _GameObject;
            GObj.CollisionFlags = CollisionFlags.NoContactResponse;
            dynamicsWorld.AddCollisionObject(GObj, CollisionFilterGroups.SensorTrigger, CollisionFilterGroups.AllFilter & ~CollisionFilterGroups.SensorTrigger);
            //dynamicsWorld.AddCollisionObject(GObj);
            //---create a Ghost
        }

        public static void Create_Capsule(GameObject _GameObject, LittleWormEngine.Utility.Vector2 _RadiusHeight) //Use this to design collider component
        {
            CollisionShape colShape = Create_CapsuleShape(_RadiusHeight);
            collisionShapes.Add(colShape);

            //---create a dynamic rigidbody
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
            BulletSharp.RigidBody body = new BulletSharp.RigidBody(rbInfo);
            body.UserObject = _GameObject;
            dynamicsWorld.AddRigidBody(body);
            Rigidbodys.Add(body);
            //---create a dynamic rigidbody
        }

        public static void Create_CapsuleBox(GameObject _GameObject, LittleWormEngine.Utility.Vector2 _RadiusHeight) //Use this to design collider component
        {
            CollisionShape colShape = Create_CapsuleShape(_RadiusHeight);
            collisionShapes.Add(colShape);

            //---create a Ghost
            BulletSharp.Math.Matrix startTransform;
            startTransform = BulletSharp.Math.Matrix.Identity;
            startTransform.Origin = new BulletSharp.Math.Vector3(_GameObject.transform.Position.x, _GameObject.transform.Position.y, _GameObject.transform.Position.z) * btWorldtoLWWorldScale;
            GhostObject GObj = new GhostObject();
            GObj.CollisionShape = colShape;
            GObj.WorldTransform = startTransform;
            GObj.UserObject = _GameObject;
            GObj.CollisionFlags = CollisionFlags.NoContactResponse;
            dynamicsWorld.AddCollisionObject(GObj, CollisionFilterGroups.SensorTrigger, CollisionFilterGroups.AllFilter & ~CollisionFilterGroups.SensorTrigger);
            //dynamicsWorld.AddCollisionObject(GObj);
            //---create a Ghost
        }

        public static CollisionObject Get_CollisionObject(GameObject _GameObject)
        {
            foreach (CollisionObject _Cobj in dynamicsWorld.CollisionObjectArray)
            {
                if (_Cobj.UserObject == null)
                {
                    continue;
                }
                if ((_Cobj.UserObject as GameObject) == _GameObject)
                {
                    return _Cobj;
                }
            }
            return null;
        }

        public static BulletSharp.RigidBody Get_Rigibody(GameObject _GameObject)
        {
            foreach(CollisionObject _Cobj in dynamicsWorld.CollisionObjectArray)
            {
                if(_Cobj.UserObject == null)
                {
                    continue;
                }
                if((_Cobj.UserObject as GameObject) == _GameObject)
                {
                    return BulletSharp.RigidBody.Upcast(_Cobj);
                }
            }
            return null;
        }

        static ContactSensorCallback CallisionCallBack;
        static void Simulation()
        {
            while (true)
            {
                if(Core.Physics_Simulation_Time != 0)
                {
                    Core.Physics_Simulation_Time = 0;
                    dynamicsWorld.StepSimulation(Time.DeltaTime * 1000);
                    for (int i = dynamicsWorld.NumCollisionObjects - 1; i >= 1; i--)
                    {
                        CollisionObject obj = dynamicsWorld.CollisionObjectArray[i];
                        BulletSharp.RigidBody body = BulletSharp.RigidBody.Upcast(obj);
                        BulletSharp.Math.Matrix trans;
                        GhostObject ghost = GhostObject.Upcast(obj);
                        if (body != null && body.MotionState != null)
                        {
                            trans = body.MotionState.WorldTransform;
                            GameObject _Temp = (body.UserObject as GameObject);
                            if (body.UserObject != null)
                            {
                                _Temp.transform.Position = new Vector3(trans.Origin.X, trans.Origin.Y, trans.Origin.Z) / btWorldtoLWWorldScale;
                            }
                        }
                        else if (ghost != null)
                        {
                            lock ((ghost.UserObject as GameObject).CollidingGameObjects)
                            {
                                List<GameObject> _TempGameObjects = (ghost.UserObject as GameObject).CollidingGameObjects;
                                _TempGameObjects.Clear();
                                foreach (CollisionObject _Obj in ghost.OverlappingPairs)
                                {
                                    if (_Obj.UserObject != null)
                                    {
                                        _TempGameObjects.Add(_Obj.UserObject as GameObject);
                                    }
                                }
                            }
                        }
                    }

                    List<CollisionObject> _Objs = new List<CollisionObject>();
                    foreach (BulletSharp.RigidBody _RigA in Rigidbodys)
                    {
                        foreach (BulletSharp.RigidBody _RigB in Rigidbodys)
                        {
                            if (_RigA != _RigB)
                            {
                                dynamicsWorld.ContactPairTest(_RigA, _RigB, new ContactSensorCallback(_Objs));
                            }
                        }

                        lock ((_RigA.UserObject as GameObject).CollidingGameObjects)
                        {
                            List<GameObject> _TempGameObjects = (_RigA.UserObject as GameObject).CollidingGameObjects;
                            _TempGameObjects.Clear();
                            foreach (CollisionObject _Obj in _Objs)
                            {
                                if (_Obj.UserObject != null)
                                {
                                    _TempGameObjects.Add(_Obj.UserObject as GameObject);
                                }
                            }
                        }
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
                BulletSharp.RigidBody body = BulletSharp.RigidBody.Upcast(obj);
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
