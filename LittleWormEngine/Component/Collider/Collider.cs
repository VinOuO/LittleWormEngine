using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;
using GLFW;
using static OpenGL.GL;

namespace LittleWormEngine
{
    abstract class Collider : Component
    {
        public GameObject Attaching_GameObject { get; set; }
        public string Tag { get; set; }
        public bool Started = false;
        public Vector3 OffSet { get; set; }
        public RigidBody Attaching_Rigibody { get; set; }
        public List<GameObject> CollidingGameObjects = new List<GameObject>();
        public bool Is_Trigger { get; set; }

        public void Start()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Set_Mesh(ColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
                    break;
                case "Game":
                    Debug.Log(Attaching_GameObject.Name);
                    PhysicsWorld.Create_Collider(this);
                    Attaching_Rigibody = new RigidBody(PhysicsWorld.Get_Rigibody(Attaching_GameObject));
                    Attaching_GameObject.ColliderComponent = this;
                    if (Attaching_Rigibody.Is_Static)
                    {
                        Attaching_Rigibody.Set_Static();
                    }
                    break;
            }
            Started = true;
        }

        public void Update(string _Type)
        {
            if (!Started)
            {
                Start();
            }

            if (ColliderSize_Changed)
            {
                ColliderSize_Changed = false;
                Modify_Collider();
            }

            switch (_Type)
            {
                case "Rendering":
                    glUseProgram(RenderShader.Program);
                    glBindVertexArray(RenderMesh.Vao);
                    RenderShader.SetUniform("transform", Attaching_GameObject.GetComponent<Transform>().GetProjectdTransformwithoutScale(OffSet));
                    Draw();
                    break;
            }

            lock (Attaching_GameObject.CollidingGameObjects)
            {
                foreach (GameObject _GameObject in Attaching_GameObject.CollidingGameObjects)
                {
                    if (!CollidingGameObjects.Contains(_GameObject))
                    {
                        CollidingGameObjects.Add(_GameObject);
                        foreach (CustomComponent _CustomComponent in Attaching_GameObject.CustomComponents)
                        {
                            _CustomComponent.OnCollitionEnter(_GameObject);
                        }
                    }
                }

                List<GameObject> _To_be_Remove = new List<GameObject>();
                foreach (GameObject _GameObject in CollidingGameObjects)
                {
                    if (Attaching_GameObject.CollidingGameObjects.Contains(_GameObject))
                    {
                        foreach (CustomComponent _CustomComponent in Attaching_GameObject.CustomComponents)
                        {
                            _CustomComponent.OnCollitionStay(_GameObject);
                        }
                    }
                    else
                    {
                        _To_be_Remove.Add(_GameObject);
                        foreach (CustomComponent _CustomComponent in Attaching_GameObject.CustomComponents)
                        {
                            _CustomComponent.OnCollitionExit(_GameObject);
                        }
                    }
                }

                foreach (GameObject _GameObject in _To_be_Remove)
                {
                    CollidingGameObjects.Remove(_GameObject);
                }
            }

        }

        public void Set_Position(Vector3 _Pos)
        {
            PhysicsWorld.Set_ObjectPosition(Attaching_GameObject, _Pos);
        }

        public unsafe void Draw()
        {
            glEnableVertexAttribArray(0);

            glDrawElements(GL_TRIANGLES, RenderMesh.Indices.Length, GL_UNSIGNED_INT, NULL);

            glDisableVertexAttribArray(0);
        }

        public bool ColliderSize_Changed = false;
        public abstract void Set_ColliderSize(List<object> _Size_Parameters);

        protected void Modify_Collider()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Set_Mesh(ColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
                    break;
                case "Game":
                    if (PhysicsWorld.Get_Rigibody(Attaching_GameObject) != null)
                    {
                        PhysicsWorld.Get_Rigibody(Attaching_GameObject).CollisionShape = Create_Shape();
                    }
                    break;
            }
        }

        public string MeshFileName;
        public string TextureFileName;
        public Mesh RenderMesh { get; set; }
        public Texture RenderTexture { get; set; }
        public Shader RenderShader { get; set; }

        public void Set_Mesh(Mesh _RenderMesh, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderShader = _RenderShader;
            RenderShader.AddUniform("transform");
        }

        protected abstract Mesh ColliderMesh();
        protected abstract BulletSharp.CollisionShape Create_Shape();
    }
}
