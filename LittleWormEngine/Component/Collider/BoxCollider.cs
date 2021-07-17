using System;
using System.Collections.Generic;
using System.Text;
using LittleWormEngine.Renderer;
using LittleWormEngine.Utility;
using GLFW;
using static OpenGL.GL;

namespace LittleWormEngine
{
    class BoxCollider : Collider
    {
        #region Old Parameter
        /*
        public GameObject Attaching_GameObject { get; set; }
        public string Tag { get; set; }
        public bool Started = false;
        public Vector3 OffSet { get; set; }
        public RigiBody Attaching_Rigibody { get; set; }
        public List<GameObject> CollidingGameObjects = new List<GameObject>();
        */
        #endregion
        public Vector3 HalfSize { get; private set; }
        #region Old Start
        /*
        public override void Start()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Set_Mesh(ColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
                    break;
                case "Game":
                    Attaching_Rigibody = new RigiBody(PhysicsWorld.Get_Rigibody(Attaching_GameObject));
                    if (Attaching_Rigibody.Is_Static)
                    {
                        Attaching_Rigibody.Set_Static();
                    }
                    break;
            }
            Started = true;
        }
        */
        #endregion
        #region Old Update
        /*
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
        */
        #endregion

        public unsafe void Draw()
        {
            glEnableVertexAttribArray(0);

            glDrawElements(GL_TRIANGLES, RenderMesh.Indices.Length, GL_UNSIGNED_INT, NULL);

            glDisableVertexAttribArray(0);
        }

        public void Set_BoxColiiderSize(Vector3 _HalfSize)
        {
            List<object> _Parameters = new List<object>();
            _Parameters.Add(_HalfSize);
            Set_ColliderSize(_Parameters);
        }

        /// <summary>
        /// _Size_Parameters[0] = HalfSize
        /// </summary>
        /// <param name="_Size_Parameters"></param>
        public override void Set_ColliderSize(List<object> _Size_Parameters)
        {
            HalfSize = (Vector3)_Size_Parameters[0];
            ColliderSize_Changed = true;
        }

        #region Old Midify_Collider
        /*
        void Modify_Collider()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Set_Mesh(ColliderMesh(), new Shader("ColliderVertex.vs", "", "ColliderFragment.fs"));
                    break;
                case "Game":
                    if (PhysicsWorld.Get_Rigibody(Attaching_GameObject) != null)
                    {
                        PhysicsWorld.Get_Rigibody(Attaching_GameObject).CollisionShape = PhysicsWorld.Create_Box_Shape(HalfSize);
                    }
                    break;
            }
        }
        */
        #endregion

        public string MeshFileName;
        public string TextureFileName;
        public Mesh RenderMesh { get; set; }
        public Texture RenderTexture { get; set; }
        public Shader RenderShader { get; set; }

        public BoxCollider()
        {
            switch (Core.Mode)
            {
                case "Editor":
                    Tag = "Renderer";
                    break;
                case "Game":
                    Tag = "Collider";
                    break;
            }
            OffSet = Vector3.Zero;
            HalfSize = Vector3.One;
            Is_Trigger = false;
        }

        public void Set_Mesh(Mesh _RenderMesh, Shader _RenderShader)
        {
            RenderMesh = _RenderMesh;
            RenderShader = _RenderShader;
            RenderShader.AddUniform("transform");
        }

        protected override BulletSharp.CollisionShape Create_Shape()
        {
            return PhysicsWorld.Create_BoxShape(HalfSize);
        }        
        protected override Mesh ColliderMesh()
        {
            Mesh _Mesh = new Mesh();
            RenderUtility.MeshData _Temp = new RenderUtility.MeshData();
            float _Scaler = 0.05f;
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        Vector3 _Temp_Vec3 = new Vector3((i == 0 ? -1 : 1) * HalfSize.x, (j == 0 ? -1 : 1) * HalfSize.y, (k == 0 ? -1 : 1) * HalfSize.z);

                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(-_Temp_Vec3.x * 0.5f, 0, 0) + _Temp_Vec3, 1f * _Scaler));
                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(0, -_Temp_Vec3.y * 0.5f, 0) + _Temp_Vec3, 1f * _Scaler));
                        _Temp.Add_MeshData(RenderUtility.Get_LineMesh(_Temp_Vec3, new Vector3(0, 0, -_Temp_Vec3.z * 0.5f) + _Temp_Vec3, 1f * _Scaler));
                    }
                }
            }
            _Mesh.AddVertices(_Temp.Vertices, _Temp.Indices);
            return _Mesh;
        }
        
    }
}
