using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using LittleWormEngine;
using LittleWormEngine.Utility;

namespace LittleWorm
{
    public partial class Inspector : Form
    {
        public Inspector()
        {
            //InitializeComponent();
            CustomInitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditorCore.SelectingGameObject = Core.GameObjects.Find(_x => _x.Name == GameObjectDropDown.Text);
            ComponentDropDown.Items.Clear();
            foreach (LittleWormEngine.Component _Component in EditorCore.SelectingGameObject.Components)
            {
                ComponentDropDown.Items.Add(_Component.GetType().Name);
            }

            if (EditorCore.SelectingComponent != null)
            {
                ComponentDropDown.SelectedItem = EditorCore.SelectingComponent.GetType().Name;
            }
            Update_Component();
        }

        Thread Inspector_Thread;
        private void Inspector_Load(object sender, EventArgs e)
        {
            foreach (GameObject _GameObject in Core.GameObjects)
            {
                GameObjectDropDown.Items.Add(_GameObject.Name);
            }
            Hide_AllPanel();
            Inspector_Thread = new Thread(Inspector_Update);
            Inspector_Thread.Start();
        }

        long Frame_Num = 0;
        void Inspector_Update()
        {
            while (true)
            {
                if (Core.Frame_Num > Frame_Num)
                {
                    Frame_Num = Core.Frame_Num;
                    if (EditorCore.SelectingComponent != null)
                    {
                        if (Need_Update(EditorCore.SelectingComponent.GetType().Name))
                        {
                            MethodInvoker _temp_Invoke = delegate () { Update_Component("Transformation"); Check_Mouse(); };
                            Invoke(_temp_Invoke);
                        }
                    }
                }
            }
        }

        bool Need_Update(string _Name)
        {
            switch (_Name)
            {
                case "Transform":
                    return true;
                case "MeshRenderer":
                    return true;
            }
            return false;
        }
        bool Changing_Component = false;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changing_Component = true;
            if (EditorCore.SelectingComponent != null)
            {
                Hide_Panel(EditorCore.SelectingComponent.GetType().Name);
            }
            EditorCore.SelectingComponent = EditorCore.SelectingGameObject.Components.Find(_x => _x.GetType().Name == ComponentDropDown.Text);
            Show_Panel(EditorCore.SelectingComponent.GetType().Name);
            Set_Component();
            Changing_Component = false;
        }

        void Hide_Panel(string _Name)
        {
            switch (_Name)
            {
                case "Transform":
                    TransformGroupBox.Enabled = false;
                    TransformGroupBox.Hide();
                    break;
                case "MeshRenderer":
                    MeshRendererGroupBox.Enabled = false;
                    MeshRendererGroupBox.Hide();
                    break;
            }
        }

        void Hide_AllPanel()
        {
            TransformGroupBox.Enabled = false;
            TransformGroupBox.Hide();
            MeshRendererGroupBox.Enabled = false;
            MeshRendererGroupBox.Hide();
        }

        void Show_Panel(string _Name)
        {
            switch (_Name)
            {
                case "Transform":
                    TransformGroupBox.Enabled = true;
                    TransformGroupBox.Show();
                    break;
                case "MeshRenderer":
                    MeshRendererGroupBox.Enabled = true;
                    MeshRendererGroupBox.Show();
                    break;
            }
        }

        void Set_Component()
        {
            switch (EditorCore.SelectingComponent.GetType().Name)
            {
                case "Transform":
                    GuiUtility.Find_Control("Positionx", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.x;
                    GuiUtility.Find_Control("Positiony", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.y;
                    GuiUtility.Find_Control("Positionz", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.z;
                    GuiUtility.Find_Control("Rotationx", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.x;
                    GuiUtility.Find_Control("Rotationy", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.y;
                    GuiUtility.Find_Control("Rotationz", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.z;
                    GuiUtility.Find_Control("Scalex", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.x;
                    GuiUtility.Find_Control("Scaley", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.y;
                    GuiUtility.Find_Control("Scalez", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.z;
                    break;
                case "MeshRenderer":
                    MeshDropDown.Items.Clear();
                    foreach (string _MeshFileName in ResourceLoader.Get_AllFiles("Models"))
                    {
                        List<string> _temp = ResourceLoader.Split(_MeshFileName, '\\');
                        MeshDropDown.Items.Add(_temp[_temp.Count - 1]);
                    }
                    MeshDropDown.SelectedItem = EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().MeshFileName;

                    TextureDropDown.Items.Clear();
                    foreach (string _MeshFileName in ResourceLoader.Get_AllFiles("Textures"))
                    {
                        List<string> _temp = ResourceLoader.Split(_MeshFileName, '\\');
                        TextureDropDown.Items.Add(_temp[_temp.Count - 1]);
                    }
                    TextureDropDown.SelectedItem = EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().TextureFileName;
                    break;
            }
        }

        bool Mouse_Down = false;
        static Vector2 MouseMovement = new Vector2(Vector2.Zero);
        static Vector2 LastMousePos = new Vector2(Vector2.Zero);
        static Vector2 NowMousePos = new Vector2(Vector2.Zero);
        void Check_Mouse()
        {
            Label _temp = new Label();

            switch (EditorCore.SelectingComponent.GetType().Name)
            {
                case "Transform":
                    _temp = GuiUtility.Captured_Label(TransformGroupBox.Controls);
                    break;
                case "MeshRenderer":
                    _temp = GuiUtility.Captured_Label(MeshRendererGroupBox.Controls);
                    break;
            }

            if (_temp != null)
            {
                if (!Mouse_Down)
                {
                    Mouse_Down = true;
                    MouseMovement = new Vector2(Vector2.Zero);
                    LastMousePos = new Vector2(MousePosition.X, MousePosition.Y);
                    NowMousePos = new Vector2(MousePosition.X, MousePosition.Y);
                }
                NowMousePos = new Vector2(MousePosition.X, MousePosition.Y);
                MouseMovement = (NowMousePos - LastMousePos) * Time.DeltaTime;
                LastMousePos = new Vector2(MousePosition.X, MousePosition.Y);
                MouseMovement.y *= -1;
                Debugger.Text = _temp.Name;
                float _Output = 0;
                switch (_temp.Name)
                {
                    case "PosxLabel":
                        if (float.TryParse(Positionx.Text, out _Output))
                        {
                            Positionx.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "PosyLabel":
                        if (float.TryParse(Positiony.Text, out _Output))
                        {
                            Positiony.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "PoszLabel":
                        if (float.TryParse(Positionz.Text, out _Output))
                        {
                            Positionz.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "RotxLabel":
                        if (float.TryParse(Rotationx.Text, out _Output))
                        {
                            Rotationx.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "RotyLabel":
                        if (float.TryParse(Rotationy.Text, out _Output))
                        {
                            Rotationy.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "RotzLabel":
                        if (float.TryParse(Rotationz.Text, out _Output))
                        {
                            Rotationz.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "ScaxLabel":
                        if (float.TryParse(Scalex.Text, out _Output))
                        {
                            Scalex.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "ScayLabel":
                        if (float.TryParse(Scaley.Text, out _Output))
                        {
                            Scaley.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "ScazLabel":
                        if (float.TryParse(Scalez.Text, out _Output))
                        {
                            Scalez.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "OffSetxLabel":
                        if (float.TryParse(OffSetx.Text, out _Output))
                        {
                            OffSetx.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "OffSetyLabel":
                        if (float.TryParse(OffSety.Text, out _Output))
                        {
                            OffSety.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                    case "OffSetzLabel":
                        if (float.TryParse(OffSetz.Text, out _Output))
                        {
                            OffSetz.Text = "" + (_Output + MouseMovement.x * 10);
                        }
                        break;
                }
            }
            else
            {
                if (Mouse_Down)
                {
                    Mouse_Down = false;
                }
            }
        }

        void Update_Component()
        {
            if (EditorCore.SelectingGameObject == null || EditorCore.SelectingComponent == null)
            {
                return;
            }
            switch (EditorCore.SelectingComponent.GetType().Name)
            {
                case "Transform":
                    if (!User_Typing_Num && !GuiUtility.Is_Focused(TransformGroupBox.Controls))
                    {
                        GuiUtility.Find_Control("Positionx", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.x;
                        GuiUtility.Find_Control("Positiony", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.y;
                        GuiUtility.Find_Control("Positionz", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.z;
                        GuiUtility.Find_Control("Rotationx", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.x;
                        GuiUtility.Find_Control("Rotationy", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.y;
                        GuiUtility.Find_Control("Rotationz", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.z;
                        GuiUtility.Find_Control("Scalex", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.x;
                        GuiUtility.Find_Control("Scaley", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.y;
                        GuiUtility.Find_Control("Scalez", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.z;
                    }
                    break;
                case "MeshRenderer":
                    MeshDropDown.Items.Clear();
                    foreach (string _MeshFileName in ResourceLoader.Get_AllFiles("Models"))
                    {
                        List<string> _temp = ResourceLoader.Split(_MeshFileName, '\\');
                        MeshDropDown.Items.Add(_temp[_temp.Count - 1]);
                    }
                    MeshDropDown.SelectedItem = EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().MeshFileName;

                    TextureDropDown.Items.Clear();
                    foreach (string _MeshFileName in ResourceLoader.Get_AllFiles("Textures"))
                    {
                        List<string> _temp = ResourceLoader.Split(_MeshFileName, '\\');
                        TextureDropDown.Items.Add(_temp[_temp.Count - 1]);
                    }
                    TextureDropDown.SelectedItem = EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().TextureFileName;
                    GuiUtility.Find_Control("OffSetx", MeshRendererGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().OffSet.x;
                    GuiUtility.Find_Control("OffSety", MeshRendererGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().OffSet.y;
                    GuiUtility.Find_Control("OffSetz", MeshRendererGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().OffSet.z;
                    break;
            }
        }

        void Update_Component(string _Request)
        {
            if (EditorCore.SelectingGameObject == null || EditorCore.SelectingComponent == null)
            {
                return;
            }
            switch (EditorCore.SelectingComponent.GetType().Name)
            {
                case "Transform":
                    if (!User_Typing_Num && !GuiUtility.Is_Focused(TransformGroupBox.Controls))
                    {
                        GuiUtility.Find_Control("Positionx", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.x;
                        GuiUtility.Find_Control("Positiony", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.y;
                        GuiUtility.Find_Control("Positionz", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Position.z;
                        GuiUtility.Find_Control("Rotationx", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.x;
                        GuiUtility.Find_Control("Rotationy", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.y;
                        GuiUtility.Find_Control("Rotationz", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Rotation.z;
                        GuiUtility.Find_Control("Scalex", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.x;
                        GuiUtility.Find_Control("Scaley", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.y;
                        GuiUtility.Find_Control("Scalez", TransformGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<Transform>().Scale.z;
                    }
                    break;
                case "MeshRenderer":
                    switch (_Request)
                    {
                        case "Transformation":
                            if (!User_Typing_Num && !GuiUtility.Is_Focused(MeshRendererGroupBox.Controls))
                            {
                                GuiUtility.Find_Control("OffSetx", MeshRendererGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().OffSet.x;
                                GuiUtility.Find_Control("OffSety", MeshRendererGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().OffSet.y;
                                GuiUtility.Find_Control("OffSetz", MeshRendererGroupBox.Controls).Text = "" + EditorCore.SelectingGameObject.GetComponent<MeshRenderer>().OffSet.z;
                            }
                            break;
                    }
                    break;
            }
        }

        bool User_Typing_Num = false;
        private void Position_TextChanged(object sender, EventArgs e)
        {
            if(EditorCore.SelectingComponent.GetType().Name == "Transform" && !Changing_Component)
            {
                try
                {
                    (EditorCore.SelectingComponent as Transform).Position = new Vector3(float.Parse(Positionx.Text), float.Parse(Positiony.Text), float.Parse(Positionz.Text));
                    User_Typing_Num = false;
                }
                catch
                {
                    User_Typing_Num = true;
                }
            }
        }
        private void Rotation_TextChanged(object sender, EventArgs e)
        {
            if (EditorCore.SelectingComponent.GetType().Name == "Transform" && !Changing_Component)
            {
                try
                {
                    (EditorCore.SelectingComponent as Transform).Rotation = new Vector3(float.Parse(Rotationx.Text), float.Parse(Rotationy.Text), float.Parse(Rotationz.Text));
                    User_Typing_Num = false;
                }
                catch 
                {
                    User_Typing_Num = true;
                }
            }
        }
        private void Scale_TextChanged(object sender, EventArgs e)
        {
            if (EditorCore.SelectingComponent.GetType().Name == "Transform" && !Changing_Component)
            {
                try
                {
                    (EditorCore.SelectingComponent as Transform).Scale = new Vector3(float.Parse(Scalex.Text), float.Parse(Scaley.Text), float.Parse(Scalez.Text));
                    User_Typing_Num = false;
                }
                catch
                {
                    User_Typing_Num = true;
                }
            }
        }
        private void OffSet_TextChanged(object sender, EventArgs e)
        {
            if (EditorCore.SelectingComponent.GetType().Name == "MeshRenderer" && !Changing_Component)
            {
                try
                {
                    (EditorCore.SelectingComponent as MeshRenderer).OffSet = new Vector3(float.Parse(OffSetx.Text), float.Parse(OffSety.Text), float.Parse(OffSetz.Text));
                    User_Typing_Num = false;
                }
                catch
                {
                    User_Typing_Num = true;
                }
            }
        }

        private void MeshDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            (EditorCore.SelectingComponent as MeshRenderer).MeshFileName = MeshDropDown.Text;
        }

        private void TextureDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            (EditorCore.SelectingComponent as MeshRenderer).TextureFileName = TextureDropDown.Text;
        }
    }
}
