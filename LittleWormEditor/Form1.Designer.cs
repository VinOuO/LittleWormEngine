
namespace LittleWorm
{
    partial class Inspector
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void CustomInitializeComponent()
        {
            this.GameObjectDropDown = new System.Windows.Forms.ComboBox();
            this.GameObjectLabel = new System.Windows.Forms.Label();
            this.ComponentLabel = new System.Windows.Forms.Label();
            this.ComponentDropDown = new System.Windows.Forms.ComboBox();
            this.TransformGroupBox = new System.Windows.Forms.GroupBox();
            this.ScazLabel = new System.Windows.Forms.Label();
            this.ScayLabel = new System.Windows.Forms.Label();
            this.ScaxLabel = new System.Windows.Forms.Label();
            this.RotzLabel = new System.Windows.Forms.Label();
            this.RotyLabel = new System.Windows.Forms.Label();
            this.RotxLabel = new System.Windows.Forms.Label();
            this.PoszLabel = new System.Windows.Forms.Label();
            this.PosyLabel = new System.Windows.Forms.Label();
            this.PosxLabel = new System.Windows.Forms.Label();
            this.Scalez = new System.Windows.Forms.TextBox();
            this.Scaley = new System.Windows.Forms.TextBox();
            this.Scalex = new System.Windows.Forms.TextBox();
            this.Rotationz = new System.Windows.Forms.TextBox();
            this.Rotationy = new System.Windows.Forms.TextBox();
            this.Rotationx = new System.Windows.Forms.TextBox();
            this.Positionz = new System.Windows.Forms.TextBox();
            this.Positiony = new System.Windows.Forms.TextBox();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.RotationLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.Positionx = new System.Windows.Forms.TextBox();
            this.MeshRendererGroupBox = new System.Windows.Forms.GroupBox();
            this.OffSetzLabel = new System.Windows.Forms.Label();
            this.OffSetyLabel = new System.Windows.Forms.Label();
            this.OffSetxLabel = new System.Windows.Forms.Label();
            this.OffSetz = new System.Windows.Forms.TextBox();
            this.OffSety = new System.Windows.Forms.TextBox();
            this.OffSetx = new System.Windows.Forms.TextBox();
            this.OffSetLabel = new System.Windows.Forms.Label();
            this.TextureDropDown = new System.Windows.Forms.ComboBox();
            this.MeshDropDown = new System.Windows.Forms.ComboBox();
            this.TextureLabel = new System.Windows.Forms.Label();
            this.MeshLabel = new System.Windows.Forms.Label();
            this.Debugger = new System.Windows.Forms.Label();
            this.AddGameObject = new System.Windows.Forms.TextBox();
            this.AddGameObjectLabel = new System.Windows.Forms.Label();
            this.AddComponentDropDown = new System.Windows.Forms.ComboBox();
            this.AddComponentLabel = new System.Windows.Forms.Label();
            this.AddGObjBut = new System.Windows.Forms.Button();
            this.AddCmpBut = new System.Windows.Forms.Button();
            this.RemoveGObjBut = new System.Windows.Forms.Button();
            this.SetPrefabBut = new System.Windows.Forms.Button();
            this.RemoveCmpBut = new System.Windows.Forms.Button();
            this.TransformGroupBox.SuspendLayout();
            this.MeshRendererGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameObjectDropDown
            // 
            this.GameObjectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameObjectDropDown.FormattingEnabled = true;
            this.GameObjectDropDown.Location = new System.Drawing.Point(491, 11);
            this.GameObjectDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.GameObjectDropDown.Name = "GameObjectDropDown";
            this.GameObjectDropDown.Size = new System.Drawing.Size(159, 23);
            this.GameObjectDropDown.TabIndex = 0;
            this.GameObjectDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GameObjectLabel
            // 
            this.GameObjectLabel.AutoSize = true;
            this.GameObjectLabel.Location = new System.Drawing.Point(412, 14);
            this.GameObjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GameObjectLabel.Name = "GameObjectLabel";
            this.GameObjectLabel.Size = new System.Drawing.Size(79, 15);
            this.GameObjectLabel.TabIndex = 1;
            this.GameObjectLabel.Text = "GameObject";
            // 
            // ComponentLabel
            // 
            this.ComponentLabel.AutoSize = true;
            this.ComponentLabel.Location = new System.Drawing.Point(415, 67);
            this.ComponentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ComponentLabel.Name = "ComponentLabel";
            this.ComponentLabel.Size = new System.Drawing.Size(75, 15);
            this.ComponentLabel.TabIndex = 2;
            this.ComponentLabel.Text = "Component";
            // 
            // ComponentDropDown
            // 
            this.ComponentDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComponentDropDown.FormattingEnabled = true;
            this.ComponentDropDown.Location = new System.Drawing.Point(491, 64);
            this.ComponentDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.ComponentDropDown.Name = "ComponentDropDown";
            this.ComponentDropDown.Size = new System.Drawing.Size(159, 23);
            this.ComponentDropDown.TabIndex = 3;
            this.ComponentDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // TransformGroupBox
            // 
            this.TransformGroupBox.Controls.Add(this.ScazLabel);
            this.TransformGroupBox.Controls.Add(this.ScayLabel);
            this.TransformGroupBox.Controls.Add(this.ScaxLabel);
            this.TransformGroupBox.Controls.Add(this.RotzLabel);
            this.TransformGroupBox.Controls.Add(this.RotyLabel);
            this.TransformGroupBox.Controls.Add(this.RotxLabel);
            this.TransformGroupBox.Controls.Add(this.PoszLabel);
            this.TransformGroupBox.Controls.Add(this.PosyLabel);
            this.TransformGroupBox.Controls.Add(this.PosxLabel);
            this.TransformGroupBox.Controls.Add(this.Scalez);
            this.TransformGroupBox.Controls.Add(this.Scaley);
            this.TransformGroupBox.Controls.Add(this.Scalex);
            this.TransformGroupBox.Controls.Add(this.Rotationz);
            this.TransformGroupBox.Controls.Add(this.Rotationy);
            this.TransformGroupBox.Controls.Add(this.Rotationx);
            this.TransformGroupBox.Controls.Add(this.Positionz);
            this.TransformGroupBox.Controls.Add(this.Positiony);
            this.TransformGroupBox.Controls.Add(this.ScaleLabel);
            this.TransformGroupBox.Controls.Add(this.RotationLabel);
            this.TransformGroupBox.Controls.Add(this.PositionLabel);
            this.TransformGroupBox.Controls.Add(this.Positionx);
            this.TransformGroupBox.Location = new System.Drawing.Point(412, 125);
            this.TransformGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.TransformGroupBox.Name = "TransformGroupBox";
            this.TransformGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.TransformGroupBox.Size = new System.Drawing.Size(499, 313);
            this.TransformGroupBox.TabIndex = 4;
            this.TransformGroupBox.TabStop = false;
            this.TransformGroupBox.Text = "Transform";
            // 
            // ScazLabel
            // 
            this.ScazLabel.AutoSize = true;
            this.ScazLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScazLabel.Location = new System.Drawing.Point(243, 128);
            this.ScazLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScazLabel.Name = "ScazLabel";
            this.ScazLabel.Size = new System.Drawing.Size(17, 20);
            this.ScazLabel.TabIndex = 20;
            this.ScazLabel.Text = "z";
            // 
            // ScayLabel
            // 
            this.ScayLabel.AutoSize = true;
            this.ScayLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScayLabel.Location = new System.Drawing.Point(153, 128);
            this.ScayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScayLabel.Name = "ScayLabel";
            this.ScayLabel.Size = new System.Drawing.Size(17, 20);
            this.ScayLabel.TabIndex = 19;
            this.ScayLabel.Text = "y";
            // 
            // ScaxLabel
            // 
            this.ScaxLabel.AutoSize = true;
            this.ScaxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScaxLabel.Location = new System.Drawing.Point(66, 128);
            this.ScaxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScaxLabel.Name = "ScaxLabel";
            this.ScaxLabel.Size = new System.Drawing.Size(17, 20);
            this.ScaxLabel.TabIndex = 18;
            this.ScaxLabel.Text = "x";
            // 
            // RotzLabel
            // 
            this.RotzLabel.AutoSize = true;
            this.RotzLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotzLabel.Location = new System.Drawing.Point(243, 83);
            this.RotzLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotzLabel.Name = "RotzLabel";
            this.RotzLabel.Size = new System.Drawing.Size(17, 20);
            this.RotzLabel.TabIndex = 17;
            this.RotzLabel.Text = "z";
            // 
            // RotyLabel
            // 
            this.RotyLabel.AutoSize = true;
            this.RotyLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotyLabel.Location = new System.Drawing.Point(153, 83);
            this.RotyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotyLabel.Name = "RotyLabel";
            this.RotyLabel.Size = new System.Drawing.Size(17, 20);
            this.RotyLabel.TabIndex = 16;
            this.RotyLabel.Text = "y";
            // 
            // RotxLabel
            // 
            this.RotxLabel.AutoSize = true;
            this.RotxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotxLabel.Location = new System.Drawing.Point(66, 83);
            this.RotxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotxLabel.Name = "RotxLabel";
            this.RotxLabel.Size = new System.Drawing.Size(17, 20);
            this.RotxLabel.TabIndex = 15;
            this.RotxLabel.Text = "x";
            // 
            // PoszLabel
            // 
            this.PoszLabel.AutoSize = true;
            this.PoszLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PoszLabel.Location = new System.Drawing.Point(243, 39);
            this.PoszLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PoszLabel.Name = "PoszLabel";
            this.PoszLabel.Size = new System.Drawing.Size(17, 20);
            this.PoszLabel.TabIndex = 14;
            this.PoszLabel.Text = "z";
            // 
            // PosyLabel
            // 
            this.PosyLabel.AutoSize = true;
            this.PosyLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PosyLabel.Location = new System.Drawing.Point(153, 39);
            this.PosyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PosyLabel.Name = "PosyLabel";
            this.PosyLabel.Size = new System.Drawing.Size(17, 20);
            this.PosyLabel.TabIndex = 13;
            this.PosyLabel.Text = "y";
            // 
            // PosxLabel
            // 
            this.PosxLabel.AutoSize = true;
            this.PosxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PosxLabel.Location = new System.Drawing.Point(66, 39);
            this.PosxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PosxLabel.Name = "PosxLabel";
            this.PosxLabel.Size = new System.Drawing.Size(17, 20);
            this.PosxLabel.TabIndex = 12;
            this.PosxLabel.Text = "x";
            // 
            // Scalez
            // 
            this.Scalez.Location = new System.Drawing.Point(265, 126);
            this.Scalez.Margin = new System.Windows.Forms.Padding(2);
            this.Scalez.Name = "Scalez";
            this.Scalez.Size = new System.Drawing.Size(49, 23);
            this.Scalez.TabIndex = 11;
            this.Scalez.TextChanged += new System.EventHandler(this.Scale_TextChanged);
            // 
            // Scaley
            // 
            this.Scaley.Location = new System.Drawing.Point(175, 126);
            this.Scaley.Margin = new System.Windows.Forms.Padding(2);
            this.Scaley.Name = "Scaley";
            this.Scaley.Size = new System.Drawing.Size(49, 23);
            this.Scaley.TabIndex = 10;
            this.Scaley.TextChanged += new System.EventHandler(this.Scale_TextChanged);
            // 
            // Scalex
            // 
            this.Scalex.Location = new System.Drawing.Point(88, 126);
            this.Scalex.Margin = new System.Windows.Forms.Padding(2);
            this.Scalex.Name = "Scalex";
            this.Scalex.Size = new System.Drawing.Size(49, 23);
            this.Scalex.TabIndex = 9;
            this.Scalex.TextChanged += new System.EventHandler(this.Scale_TextChanged);
            // 
            // Rotationz
            // 
            this.Rotationz.Location = new System.Drawing.Point(265, 81);
            this.Rotationz.Margin = new System.Windows.Forms.Padding(2);
            this.Rotationz.Name = "Rotationz";
            this.Rotationz.Size = new System.Drawing.Size(49, 23);
            this.Rotationz.TabIndex = 8;
            this.Rotationz.TextChanged += new System.EventHandler(this.Rotation_TextChanged);
            // 
            // Rotationy
            // 
            this.Rotationy.Location = new System.Drawing.Point(175, 81);
            this.Rotationy.Margin = new System.Windows.Forms.Padding(2);
            this.Rotationy.Name = "Rotationy";
            this.Rotationy.Size = new System.Drawing.Size(49, 23);
            this.Rotationy.TabIndex = 7;
            this.Rotationy.TextChanged += new System.EventHandler(this.Rotation_TextChanged);
            // 
            // Rotationx
            // 
            this.Rotationx.Location = new System.Drawing.Point(88, 81);
            this.Rotationx.Margin = new System.Windows.Forms.Padding(2);
            this.Rotationx.Name = "Rotationx";
            this.Rotationx.Size = new System.Drawing.Size(49, 23);
            this.Rotationx.TabIndex = 6;
            this.Rotationx.TextChanged += new System.EventHandler(this.Rotation_TextChanged);
            // 
            // Positionz
            // 
            this.Positionz.Location = new System.Drawing.Point(265, 38);
            this.Positionz.Margin = new System.Windows.Forms.Padding(2);
            this.Positionz.Name = "Positionz";
            this.Positionz.Size = new System.Drawing.Size(49, 23);
            this.Positionz.TabIndex = 5;
            this.Positionz.TextChanged += new System.EventHandler(this.Position_TextChanged);
            // 
            // Positiony
            // 
            this.Positiony.Location = new System.Drawing.Point(175, 38);
            this.Positiony.Margin = new System.Windows.Forms.Padding(2);
            this.Positiony.Name = "Positiony";
            this.Positiony.Size = new System.Drawing.Size(49, 23);
            this.Positiony.TabIndex = 4;
            this.Positiony.TextChanged += new System.EventHandler(this.Position_TextChanged);
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(11, 129);
            this.ScaleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(37, 15);
            this.ScaleLabel.TabIndex = 3;
            this.ScaleLabel.Text = "Scale";
            // 
            // RotationLabel
            // 
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.Location = new System.Drawing.Point(11, 84);
            this.RotationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(56, 15);
            this.RotationLabel.TabIndex = 2;
            this.RotationLabel.Text = "Rotation";
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(11, 43);
            this.PositionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(52, 15);
            this.PositionLabel.TabIndex = 1;
            this.PositionLabel.Text = "Position";
            // 
            // Positionx
            // 
            this.Positionx.Location = new System.Drawing.Point(88, 38);
            this.Positionx.Margin = new System.Windows.Forms.Padding(2);
            this.Positionx.Name = "Positionx";
            this.Positionx.Size = new System.Drawing.Size(49, 23);
            this.Positionx.TabIndex = 0;
            this.Positionx.TextChanged += new System.EventHandler(this.Position_TextChanged);
            // 
            // MeshRendererGroupBox
            // 
            this.MeshRendererGroupBox.Controls.Add(this.OffSetzLabel);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetyLabel);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetxLabel);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetz);
            this.MeshRendererGroupBox.Controls.Add(this.OffSety);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetx);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetLabel);
            this.MeshRendererGroupBox.Controls.Add(this.TextureDropDown);
            this.MeshRendererGroupBox.Controls.Add(this.MeshDropDown);
            this.MeshRendererGroupBox.Controls.Add(this.TextureLabel);
            this.MeshRendererGroupBox.Controls.Add(this.MeshLabel);
            this.MeshRendererGroupBox.Location = new System.Drawing.Point(412, 125);
            this.MeshRendererGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.MeshRendererGroupBox.Name = "MeshRendererGroupBox";
            this.MeshRendererGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.MeshRendererGroupBox.Size = new System.Drawing.Size(499, 313);
            this.MeshRendererGroupBox.TabIndex = 12;
            this.MeshRendererGroupBox.TabStop = false;
            this.MeshRendererGroupBox.Text = "MeshRenderer";
            // 
            // OffSetzLabel
            // 
            this.OffSetzLabel.AutoSize = true;
            this.OffSetzLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSetzLabel.Location = new System.Drawing.Point(310, 101);
            this.OffSetzLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetzLabel.Name = "OffSetzLabel";
            this.OffSetzLabel.Size = new System.Drawing.Size(17, 20);
            this.OffSetzLabel.TabIndex = 27;
            this.OffSetzLabel.Text = "z";
            // 
            // OffSetyLabel
            // 
            this.OffSetyLabel.AutoSize = true;
            this.OffSetyLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSetyLabel.Location = new System.Drawing.Point(219, 101);
            this.OffSetyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetyLabel.Name = "OffSetyLabel";
            this.OffSetyLabel.Size = new System.Drawing.Size(17, 20);
            this.OffSetyLabel.TabIndex = 26;
            this.OffSetyLabel.Text = "y";
            // 
            // OffSetxLabel
            // 
            this.OffSetxLabel.AutoSize = true;
            this.OffSetxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSetxLabel.Location = new System.Drawing.Point(132, 101);
            this.OffSetxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetxLabel.Name = "OffSetxLabel";
            this.OffSetxLabel.Size = new System.Drawing.Size(17, 20);
            this.OffSetxLabel.TabIndex = 25;
            this.OffSetxLabel.Text = "x";
            // 
            // OffSetz
            // 
            this.OffSetz.Location = new System.Drawing.Point(331, 99);
            this.OffSetz.Margin = new System.Windows.Forms.Padding(2);
            this.OffSetz.Name = "OffSetz";
            this.OffSetz.Size = new System.Drawing.Size(49, 23);
            this.OffSetz.TabIndex = 24;
            this.OffSetz.TextChanged += new System.EventHandler(this.OffSet_TextChanged);
            // 
            // OffSety
            // 
            this.OffSety.Location = new System.Drawing.Point(241, 99);
            this.OffSety.Margin = new System.Windows.Forms.Padding(2);
            this.OffSety.Name = "OffSety";
            this.OffSety.Size = new System.Drawing.Size(49, 23);
            this.OffSety.TabIndex = 23;
            this.OffSety.TextChanged += new System.EventHandler(this.OffSet_TextChanged);
            // 
            // OffSetx
            // 
            this.OffSetx.Location = new System.Drawing.Point(154, 99);
            this.OffSetx.Margin = new System.Windows.Forms.Padding(2);
            this.OffSetx.Name = "OffSetx";
            this.OffSetx.Size = new System.Drawing.Size(49, 23);
            this.OffSetx.TabIndex = 22;
            this.OffSetx.TextChanged += new System.EventHandler(this.OffSet_TextChanged);
            // 
            // OffSetLabel
            // 
            this.OffSetLabel.AutoSize = true;
            this.OffSetLabel.Location = new System.Drawing.Point(77, 103);
            this.OffSetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetLabel.Name = "OffSetLabel";
            this.OffSetLabel.Size = new System.Drawing.Size(43, 15);
            this.OffSetLabel.TabIndex = 21;
            this.OffSetLabel.Text = "OffSet";
            // 
            // TextureDropDown
            // 
            this.TextureDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextureDropDown.FormattingEnabled = true;
            this.TextureDropDown.Location = new System.Drawing.Point(311, 32);
            this.TextureDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.TextureDropDown.Name = "TextureDropDown";
            this.TextureDropDown.Size = new System.Drawing.Size(118, 23);
            this.TextureDropDown.TabIndex = 3;
            this.TextureDropDown.SelectedIndexChanged += new System.EventHandler(this.TextureDropDown_SelectedIndexChanged);
            // 
            // MeshDropDown
            // 
            this.MeshDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeshDropDown.FormattingEnabled = true;
            this.MeshDropDown.Location = new System.Drawing.Point(54, 32);
            this.MeshDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.MeshDropDown.Name = "MeshDropDown";
            this.MeshDropDown.Size = new System.Drawing.Size(118, 23);
            this.MeshDropDown.TabIndex = 2;
            this.MeshDropDown.SelectedIndexChanged += new System.EventHandler(this.MeshDropDown_SelectedIndexChanged);
            // 
            // TextureLabel
            // 
            this.TextureLabel.AutoSize = true;
            this.TextureLabel.Location = new System.Drawing.Point(260, 35);
            this.TextureLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextureLabel.Name = "TextureLabel";
            this.TextureLabel.Size = new System.Drawing.Size(49, 15);
            this.TextureLabel.TabIndex = 1;
            this.TextureLabel.Text = "Texture";
            // 
            // MeshLabel
            // 
            this.MeshLabel.AutoSize = true;
            this.MeshLabel.Location = new System.Drawing.Point(12, 35);
            this.MeshLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MeshLabel.Name = "MeshLabel";
            this.MeshLabel.Size = new System.Drawing.Size(38, 15);
            this.MeshLabel.TabIndex = 0;
            this.MeshLabel.Text = "Mesh";
            // 
            // Debugger
            // 
            this.Debugger.AutoSize = true;
            this.Debugger.Location = new System.Drawing.Point(11, 423);
            this.Debugger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Debugger.Name = "Debugger";
            this.Debugger.Size = new System.Drawing.Size(31, 15);
            this.Debugger.TabIndex = 13;
            this.Debugger.Text = "AAA";
            // 
            // AddGameObject
            // 
            this.AddGameObject.Location = new System.Drawing.Point(129, 11);
            this.AddGameObject.Margin = new System.Windows.Forms.Padding(2);
            this.AddGameObject.Name = "AddGameObject";
            this.AddGameObject.Size = new System.Drawing.Size(75, 23);
            this.AddGameObject.TabIndex = 0;
            // 
            // AddGameObjectLabel
            // 
            this.AddGameObjectLabel.AutoSize = true;
            this.AddGameObjectLabel.Location = new System.Drawing.Point(22, 14);
            this.AddGameObjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddGameObjectLabel.Name = "AddGameObjectLabel";
            this.AddGameObjectLabel.Size = new System.Drawing.Size(103, 15);
            this.AddGameObjectLabel.TabIndex = 1;
            this.AddGameObjectLabel.Text = "AddGameObject";
            // 
            // AddComponentDropDown
            // 
            this.AddComponentDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddComponentDropDown.FormattingEnabled = true;
            this.AddComponentDropDown.Location = new System.Drawing.Point(129, 67);
            this.AddComponentDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.AddComponentDropDown.Name = "AddComponentDropDown";
            this.AddComponentDropDown.Size = new System.Drawing.Size(159, 23);
            this.AddComponentDropDown.TabIndex = 0;
            this.AddComponentDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox_AddCom_SelectedIndexChanged);
            // 
            // AddComponentLabel
            // 
            this.AddComponentLabel.AutoSize = true;
            this.AddComponentLabel.Location = new System.Drawing.Point(24, 70);
            this.AddComponentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddComponentLabel.Name = "AddComponentLabel";
            this.AddComponentLabel.Size = new System.Drawing.Size(99, 15);
            this.AddComponentLabel.TabIndex = 1;
            this.AddComponentLabel.Text = "AddComponent";
            // 
            // AddGObjBut
            // 
            this.AddGObjBut.Location = new System.Drawing.Point(209, 11);
            this.AddGObjBut.Name = "AddGObjBut";
            this.AddGObjBut.Size = new System.Drawing.Size(51, 23);
            this.AddGObjBut.TabIndex = 14;
            this.AddGObjBut.Text = "Add";
            this.AddGObjBut.UseVisualStyleBackColor = true;
            this.AddGObjBut.Click += new System.EventHandler(this.AddGObjBut_Click);
            // 
            // AddCmpBut
            // 
            this.AddCmpBut.Location = new System.Drawing.Point(293, 67);
            this.AddCmpBut.Name = "AddCmpBut";
            this.AddCmpBut.Size = new System.Drawing.Size(49, 23);
            this.AddCmpBut.TabIndex = 15;
            this.AddCmpBut.Text = "Add";
            this.AddCmpBut.UseVisualStyleBackColor = true;
            this.AddCmpBut.Click += new System.EventHandler(this.AddCmpBut_Click);
            // 
            // RemoveGObjBut
            // 
            this.RemoveGObjBut.Location = new System.Drawing.Point(664, 11);
            this.RemoveGObjBut.Name = "RemoveGObjBut";
            this.RemoveGObjBut.Size = new System.Drawing.Size(75, 23);
            this.RemoveGObjBut.TabIndex = 16;
            this.RemoveGObjBut.Text = "Remove";
            this.RemoveGObjBut.UseVisualStyleBackColor = true;
            this.RemoveGObjBut.Click += new System.EventHandler(this.RemoveGObjBut_Click);
            // 
            // SetPrefabBut
            // 
            this.SetPrefabBut.Location = new System.Drawing.Point(755, 10);
            this.SetPrefabBut.Name = "SetPrefabBut";
            this.SetPrefabBut.Size = new System.Drawing.Size(99, 23);
            this.SetPrefabBut.TabIndex = 17;
            this.SetPrefabBut.Text = "Set as Prefab";
            this.SetPrefabBut.UseVisualStyleBackColor = true;
            this.SetPrefabBut.Click += new System.EventHandler(this.SetPrefabBut_Click);
            // 
            // RemoveCmpBut
            // 
            this.RemoveCmpBut.Location = new System.Drawing.Point(664, 64);
            this.RemoveCmpBut.Name = "RemoveCmpBut";
            this.RemoveCmpBut.Size = new System.Drawing.Size(75, 23);
            this.RemoveCmpBut.TabIndex = 18;
            this.RemoveCmpBut.Text = "Remove";
            this.RemoveCmpBut.UseVisualStyleBackColor = true;
            this.RemoveCmpBut.Click += new System.EventHandler(this.RemoveCmpBut_Click);
            // 
            // Inspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 457);
            this.Controls.Add(this.RemoveCmpBut);
            this.Controls.Add(this.SetPrefabBut);
            this.Controls.Add(this.RemoveGObjBut);
            this.Controls.Add(this.AddCmpBut);
            this.Controls.Add(this.AddGObjBut);
            this.Controls.Add(this.AddComponentLabel);
            this.Controls.Add(this.AddComponentDropDown);
            this.Controls.Add(this.AddGameObjectLabel);
            this.Controls.Add(this.AddGameObject);
            this.Controls.Add(this.Debugger);
            this.Controls.Add(this.MeshRendererGroupBox);
            this.Controls.Add(this.TransformGroupBox);
            this.Controls.Add(this.ComponentDropDown);
            this.Controls.Add(this.ComponentLabel);
            this.Controls.Add(this.GameObjectLabel);
            this.Controls.Add(this.GameObjectDropDown);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inspector";
            this.Text = "Inspector";
            this.Load += new System.EventHandler(this.Inspector_Load);
            this.TransformGroupBox.ResumeLayout(false);
            this.TransformGroupBox.PerformLayout();
            this.MeshRendererGroupBox.ResumeLayout(false);
            this.MeshRendererGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameObjectDropDown = new System.Windows.Forms.ComboBox();
            this.GameObjectLabel = new System.Windows.Forms.Label();
            this.ComponentLabel = new System.Windows.Forms.Label();
            this.ComponentDropDown = new System.Windows.Forms.ComboBox();
            this.TransformGroupBox = new System.Windows.Forms.GroupBox();
            this.ScazLabel = new System.Windows.Forms.Label();
            this.ScayLabel = new System.Windows.Forms.Label();
            this.ScaxLabel = new System.Windows.Forms.Label();
            this.RotzLabel = new System.Windows.Forms.Label();
            this.RotyLabel = new System.Windows.Forms.Label();
            this.RotxLabel = new System.Windows.Forms.Label();
            this.PoszLabel = new System.Windows.Forms.Label();
            this.PosyLabel = new System.Windows.Forms.Label();
            this.PosxLabel = new System.Windows.Forms.Label();
            this.Scalez = new System.Windows.Forms.TextBox();
            this.Scaley = new System.Windows.Forms.TextBox();
            this.Scalex = new System.Windows.Forms.TextBox();
            this.Rotationz = new System.Windows.Forms.TextBox();
            this.Rotationy = new System.Windows.Forms.TextBox();
            this.Rotationx = new System.Windows.Forms.TextBox();
            this.Positionz = new System.Windows.Forms.TextBox();
            this.Positiony = new System.Windows.Forms.TextBox();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.RotationLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.Positionx = new System.Windows.Forms.TextBox();
            this.MeshRendererGroupBox = new System.Windows.Forms.GroupBox();
            this.OffSetzLabel = new System.Windows.Forms.Label();
            this.OffSetyLabel = new System.Windows.Forms.Label();
            this.OffSetxLabel = new System.Windows.Forms.Label();
            this.OffSetz = new System.Windows.Forms.TextBox();
            this.OffSety = new System.Windows.Forms.TextBox();
            this.OffSetx = new System.Windows.Forms.TextBox();
            this.OffSetLabel = new System.Windows.Forms.Label();
            this.TextureDropDown = new System.Windows.Forms.ComboBox();
            this.MeshDropDown = new System.Windows.Forms.ComboBox();
            this.TextureLabel = new System.Windows.Forms.Label();
            this.MeshLabel = new System.Windows.Forms.Label();
            this.Debugger = new System.Windows.Forms.Label();
            this.AddGameObject = new System.Windows.Forms.TextBox();
            this.AddGameObjectLabel = new System.Windows.Forms.Label();
            this.AddComponentDropDown = new System.Windows.Forms.ComboBox();
            this.AddComponentLabel = new System.Windows.Forms.Label();
            this.AddGObjBut = new System.Windows.Forms.Button();
            this.AddCmpBut = new System.Windows.Forms.Button();
            this.RemoveGObjBut = new System.Windows.Forms.Button();
            this.SetPrefabBut = new System.Windows.Forms.Button();
            this.RemoveCmpBut = new System.Windows.Forms.Button();
            this.TransformGroupBox.SuspendLayout();
            this.MeshRendererGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameObjectDropDown
            // 
            this.GameObjectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameObjectDropDown.FormattingEnabled = true;
            this.GameObjectDropDown.Location = new System.Drawing.Point(491, 11);
            this.GameObjectDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.GameObjectDropDown.Name = "GameObjectDropDown";
            this.GameObjectDropDown.Size = new System.Drawing.Size(159, 23);
            this.GameObjectDropDown.TabIndex = 0;
            this.GameObjectDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GameObjectLabel
            // 
            this.GameObjectLabel.AutoSize = true;
            this.GameObjectLabel.Location = new System.Drawing.Point(412, 14);
            this.GameObjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GameObjectLabel.Name = "GameObjectLabel";
            this.GameObjectLabel.Size = new System.Drawing.Size(79, 15);
            this.GameObjectLabel.TabIndex = 1;
            this.GameObjectLabel.Text = "GameObject";
            // 
            // ComponentLabel
            // 
            this.ComponentLabel.AutoSize = true;
            this.ComponentLabel.Location = new System.Drawing.Point(415, 67);
            this.ComponentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ComponentLabel.Name = "ComponentLabel";
            this.ComponentLabel.Size = new System.Drawing.Size(75, 15);
            this.ComponentLabel.TabIndex = 2;
            this.ComponentLabel.Text = "Component";
            // 
            // ComponentDropDown
            // 
            this.ComponentDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComponentDropDown.FormattingEnabled = true;
            this.ComponentDropDown.Location = new System.Drawing.Point(491, 64);
            this.ComponentDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.ComponentDropDown.Name = "ComponentDropDown";
            this.ComponentDropDown.Size = new System.Drawing.Size(159, 23);
            this.ComponentDropDown.TabIndex = 3;
            this.ComponentDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // TransformGroupBox
            // 
            this.TransformGroupBox.Controls.Add(this.ScazLabel);
            this.TransformGroupBox.Controls.Add(this.ScayLabel);
            this.TransformGroupBox.Controls.Add(this.ScaxLabel);
            this.TransformGroupBox.Controls.Add(this.RotzLabel);
            this.TransformGroupBox.Controls.Add(this.RotyLabel);
            this.TransformGroupBox.Controls.Add(this.RotxLabel);
            this.TransformGroupBox.Controls.Add(this.PoszLabel);
            this.TransformGroupBox.Controls.Add(this.PosyLabel);
            this.TransformGroupBox.Controls.Add(this.PosxLabel);
            this.TransformGroupBox.Controls.Add(this.Scalez);
            this.TransformGroupBox.Controls.Add(this.Scaley);
            this.TransformGroupBox.Controls.Add(this.Scalex);
            this.TransformGroupBox.Controls.Add(this.Rotationz);
            this.TransformGroupBox.Controls.Add(this.Rotationy);
            this.TransformGroupBox.Controls.Add(this.Rotationx);
            this.TransformGroupBox.Controls.Add(this.Positionz);
            this.TransformGroupBox.Controls.Add(this.Positiony);
            this.TransformGroupBox.Controls.Add(this.ScaleLabel);
            this.TransformGroupBox.Controls.Add(this.RotationLabel);
            this.TransformGroupBox.Controls.Add(this.PositionLabel);
            this.TransformGroupBox.Controls.Add(this.Positionx);
            this.TransformGroupBox.Location = new System.Drawing.Point(412, 125);
            this.TransformGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.TransformGroupBox.Name = "TransformGroupBox";
            this.TransformGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.TransformGroupBox.Size = new System.Drawing.Size(499, 313);
            this.TransformGroupBox.TabIndex = 4;
            this.TransformGroupBox.TabStop = false;
            this.TransformGroupBox.Text = "Transform";
            // 
            // ScazLabel
            // 
            this.ScazLabel.AutoSize = true;
            this.ScazLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScazLabel.Location = new System.Drawing.Point(243, 128);
            this.ScazLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScazLabel.Name = "ScazLabel";
            this.ScazLabel.Size = new System.Drawing.Size(17, 20);
            this.ScazLabel.TabIndex = 20;
            this.ScazLabel.Text = "z";
            // 
            // ScayLabel
            // 
            this.ScayLabel.AutoSize = true;
            this.ScayLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScayLabel.Location = new System.Drawing.Point(153, 128);
            this.ScayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScayLabel.Name = "ScayLabel";
            this.ScayLabel.Size = new System.Drawing.Size(17, 20);
            this.ScayLabel.TabIndex = 19;
            this.ScayLabel.Text = "y";
            // 
            // ScaxLabel
            // 
            this.ScaxLabel.AutoSize = true;
            this.ScaxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScaxLabel.Location = new System.Drawing.Point(66, 128);
            this.ScaxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScaxLabel.Name = "ScaxLabel";
            this.ScaxLabel.Size = new System.Drawing.Size(17, 20);
            this.ScaxLabel.TabIndex = 18;
            this.ScaxLabel.Text = "x";
            // 
            // RotzLabel
            // 
            this.RotzLabel.AutoSize = true;
            this.RotzLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotzLabel.Location = new System.Drawing.Point(243, 83);
            this.RotzLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotzLabel.Name = "RotzLabel";
            this.RotzLabel.Size = new System.Drawing.Size(17, 20);
            this.RotzLabel.TabIndex = 17;
            this.RotzLabel.Text = "z";
            // 
            // RotyLabel
            // 
            this.RotyLabel.AutoSize = true;
            this.RotyLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotyLabel.Location = new System.Drawing.Point(153, 83);
            this.RotyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotyLabel.Name = "RotyLabel";
            this.RotyLabel.Size = new System.Drawing.Size(17, 20);
            this.RotyLabel.TabIndex = 16;
            this.RotyLabel.Text = "y";
            // 
            // RotxLabel
            // 
            this.RotxLabel.AutoSize = true;
            this.RotxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RotxLabel.Location = new System.Drawing.Point(66, 83);
            this.RotxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotxLabel.Name = "RotxLabel";
            this.RotxLabel.Size = new System.Drawing.Size(17, 20);
            this.RotxLabel.TabIndex = 15;
            this.RotxLabel.Text = "x";
            // 
            // PoszLabel
            // 
            this.PoszLabel.AutoSize = true;
            this.PoszLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PoszLabel.Location = new System.Drawing.Point(243, 39);
            this.PoszLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PoszLabel.Name = "PoszLabel";
            this.PoszLabel.Size = new System.Drawing.Size(17, 20);
            this.PoszLabel.TabIndex = 14;
            this.PoszLabel.Text = "z";
            // 
            // PosyLabel
            // 
            this.PosyLabel.AutoSize = true;
            this.PosyLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PosyLabel.Location = new System.Drawing.Point(153, 39);
            this.PosyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PosyLabel.Name = "PosyLabel";
            this.PosyLabel.Size = new System.Drawing.Size(17, 20);
            this.PosyLabel.TabIndex = 13;
            this.PosyLabel.Text = "y";
            // 
            // PosxLabel
            // 
            this.PosxLabel.AutoSize = true;
            this.PosxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PosxLabel.Location = new System.Drawing.Point(66, 39);
            this.PosxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PosxLabel.Name = "PosxLabel";
            this.PosxLabel.Size = new System.Drawing.Size(17, 20);
            this.PosxLabel.TabIndex = 12;
            this.PosxLabel.Text = "x";
            // 
            // Scalez
            // 
            this.Scalez.Location = new System.Drawing.Point(265, 126);
            this.Scalez.Margin = new System.Windows.Forms.Padding(2);
            this.Scalez.Name = "Scalez";
            this.Scalez.Size = new System.Drawing.Size(49, 23);
            this.Scalez.TabIndex = 11;
            this.Scalez.TextChanged += new System.EventHandler(this.Scale_TextChanged);
            // 
            // Scaley
            // 
            this.Scaley.Location = new System.Drawing.Point(175, 126);
            this.Scaley.Margin = new System.Windows.Forms.Padding(2);
            this.Scaley.Name = "Scaley";
            this.Scaley.Size = new System.Drawing.Size(49, 23);
            this.Scaley.TabIndex = 10;
            this.Scaley.TextChanged += new System.EventHandler(this.Scale_TextChanged);
            // 
            // Scalex
            // 
            this.Scalex.Location = new System.Drawing.Point(88, 126);
            this.Scalex.Margin = new System.Windows.Forms.Padding(2);
            this.Scalex.Name = "Scalex";
            this.Scalex.Size = new System.Drawing.Size(49, 23);
            this.Scalex.TabIndex = 9;
            this.Scalex.TextChanged += new System.EventHandler(this.Scale_TextChanged);
            // 
            // Rotationz
            // 
            this.Rotationz.Location = new System.Drawing.Point(265, 81);
            this.Rotationz.Margin = new System.Windows.Forms.Padding(2);
            this.Rotationz.Name = "Rotationz";
            this.Rotationz.Size = new System.Drawing.Size(49, 23);
            this.Rotationz.TabIndex = 8;
            this.Rotationz.TextChanged += new System.EventHandler(this.Rotation_TextChanged);
            // 
            // Rotationy
            // 
            this.Rotationy.Location = new System.Drawing.Point(175, 81);
            this.Rotationy.Margin = new System.Windows.Forms.Padding(2);
            this.Rotationy.Name = "Rotationy";
            this.Rotationy.Size = new System.Drawing.Size(49, 23);
            this.Rotationy.TabIndex = 7;
            this.Rotationy.TextChanged += new System.EventHandler(this.Rotation_TextChanged);
            // 
            // Rotationx
            // 
            this.Rotationx.Location = new System.Drawing.Point(88, 81);
            this.Rotationx.Margin = new System.Windows.Forms.Padding(2);
            this.Rotationx.Name = "Rotationx";
            this.Rotationx.Size = new System.Drawing.Size(49, 23);
            this.Rotationx.TabIndex = 6;
            this.Rotationx.TextChanged += new System.EventHandler(this.Rotation_TextChanged);
            // 
            // Positionz
            // 
            this.Positionz.Location = new System.Drawing.Point(265, 38);
            this.Positionz.Margin = new System.Windows.Forms.Padding(2);
            this.Positionz.Name = "Positionz";
            this.Positionz.Size = new System.Drawing.Size(49, 23);
            this.Positionz.TabIndex = 5;
            this.Positionz.TextChanged += new System.EventHandler(this.Position_TextChanged);
            // 
            // Positiony
            // 
            this.Positiony.Location = new System.Drawing.Point(175, 38);
            this.Positiony.Margin = new System.Windows.Forms.Padding(2);
            this.Positiony.Name = "Positiony";
            this.Positiony.Size = new System.Drawing.Size(49, 23);
            this.Positiony.TabIndex = 4;
            this.Positiony.TextChanged += new System.EventHandler(this.Position_TextChanged);
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(11, 129);
            this.ScaleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(37, 15);
            this.ScaleLabel.TabIndex = 3;
            this.ScaleLabel.Text = "Scale";
            // 
            // RotationLabel
            // 
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.Location = new System.Drawing.Point(11, 84);
            this.RotationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(56, 15);
            this.RotationLabel.TabIndex = 2;
            this.RotationLabel.Text = "Rotation";
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(11, 43);
            this.PositionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(52, 15);
            this.PositionLabel.TabIndex = 1;
            this.PositionLabel.Text = "Position";
            // 
            // Positionx
            // 
            this.Positionx.Location = new System.Drawing.Point(88, 38);
            this.Positionx.Margin = new System.Windows.Forms.Padding(2);
            this.Positionx.Name = "Positionx";
            this.Positionx.Size = new System.Drawing.Size(49, 23);
            this.Positionx.TabIndex = 0;
            this.Positionx.TextChanged += new System.EventHandler(this.Position_TextChanged);
            // 
            // MeshRendererGroupBox
            // 
            this.MeshRendererGroupBox.Controls.Add(this.OffSetzLabel);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetyLabel);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetxLabel);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetz);
            this.MeshRendererGroupBox.Controls.Add(this.OffSety);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetx);
            this.MeshRendererGroupBox.Controls.Add(this.OffSetLabel);
            this.MeshRendererGroupBox.Controls.Add(this.TextureDropDown);
            this.MeshRendererGroupBox.Controls.Add(this.MeshDropDown);
            this.MeshRendererGroupBox.Controls.Add(this.TextureLabel);
            this.MeshRendererGroupBox.Controls.Add(this.MeshLabel);
            this.MeshRendererGroupBox.Location = new System.Drawing.Point(412, 125);
            this.MeshRendererGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.MeshRendererGroupBox.Name = "MeshRendererGroupBox";
            this.MeshRendererGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.MeshRendererGroupBox.Size = new System.Drawing.Size(499, 313);
            this.MeshRendererGroupBox.TabIndex = 12;
            this.MeshRendererGroupBox.TabStop = false;
            this.MeshRendererGroupBox.Text = "MeshRenderer";
            // 
            // OffSetzLabel
            // 
            this.OffSetzLabel.AutoSize = true;
            this.OffSetzLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSetzLabel.Location = new System.Drawing.Point(310, 101);
            this.OffSetzLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetzLabel.Name = "OffSetzLabel";
            this.OffSetzLabel.Size = new System.Drawing.Size(17, 20);
            this.OffSetzLabel.TabIndex = 27;
            this.OffSetzLabel.Text = "z";
            // 
            // OffSetyLabel
            // 
            this.OffSetyLabel.AutoSize = true;
            this.OffSetyLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSetyLabel.Location = new System.Drawing.Point(219, 101);
            this.OffSetyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetyLabel.Name = "OffSetyLabel";
            this.OffSetyLabel.Size = new System.Drawing.Size(17, 20);
            this.OffSetyLabel.TabIndex = 26;
            this.OffSetyLabel.Text = "y";
            // 
            // OffSetxLabel
            // 
            this.OffSetxLabel.AutoSize = true;
            this.OffSetxLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSetxLabel.Location = new System.Drawing.Point(132, 101);
            this.OffSetxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetxLabel.Name = "OffSetxLabel";
            this.OffSetxLabel.Size = new System.Drawing.Size(17, 20);
            this.OffSetxLabel.TabIndex = 25;
            this.OffSetxLabel.Text = "x";
            // 
            // OffSetz
            // 
            this.OffSetz.Location = new System.Drawing.Point(331, 99);
            this.OffSetz.Margin = new System.Windows.Forms.Padding(2);
            this.OffSetz.Name = "OffSetz";
            this.OffSetz.Size = new System.Drawing.Size(49, 23);
            this.OffSetz.TabIndex = 24;
            this.OffSetz.TextChanged += new System.EventHandler(this.OffSet_TextChanged);
            // 
            // OffSety
            // 
            this.OffSety.Location = new System.Drawing.Point(241, 99);
            this.OffSety.Margin = new System.Windows.Forms.Padding(2);
            this.OffSety.Name = "OffSety";
            this.OffSety.Size = new System.Drawing.Size(49, 23);
            this.OffSety.TabIndex = 23;
            this.OffSety.TextChanged += new System.EventHandler(this.OffSet_TextChanged);
            // 
            // OffSetx
            // 
            this.OffSetx.Location = new System.Drawing.Point(154, 99);
            this.OffSetx.Margin = new System.Windows.Forms.Padding(2);
            this.OffSetx.Name = "OffSetx";
            this.OffSetx.Size = new System.Drawing.Size(49, 23);
            this.OffSetx.TabIndex = 22;
            this.OffSetx.TextChanged += new System.EventHandler(this.OffSet_TextChanged);
            // 
            // OffSetLabel
            // 
            this.OffSetLabel.AutoSize = true;
            this.OffSetLabel.Location = new System.Drawing.Point(77, 103);
            this.OffSetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OffSetLabel.Name = "OffSetLabel";
            this.OffSetLabel.Size = new System.Drawing.Size(43, 15);
            this.OffSetLabel.TabIndex = 21;
            this.OffSetLabel.Text = "OffSet";
            // 
            // TextureDropDown
            // 
            this.TextureDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextureDropDown.FormattingEnabled = true;
            this.TextureDropDown.Location = new System.Drawing.Point(311, 32);
            this.TextureDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.TextureDropDown.Name = "TextureDropDown";
            this.TextureDropDown.Size = new System.Drawing.Size(118, 23);
            this.TextureDropDown.TabIndex = 3;
            this.TextureDropDown.SelectedIndexChanged += new System.EventHandler(this.TextureDropDown_SelectedIndexChanged);
            // 
            // MeshDropDown
            // 
            this.MeshDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeshDropDown.FormattingEnabled = true;
            this.MeshDropDown.Location = new System.Drawing.Point(54, 32);
            this.MeshDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.MeshDropDown.Name = "MeshDropDown";
            this.MeshDropDown.Size = new System.Drawing.Size(118, 23);
            this.MeshDropDown.TabIndex = 2;
            this.MeshDropDown.SelectedIndexChanged += new System.EventHandler(this.MeshDropDown_SelectedIndexChanged);
            // 
            // TextureLabel
            // 
            this.TextureLabel.AutoSize = true;
            this.TextureLabel.Location = new System.Drawing.Point(260, 35);
            this.TextureLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextureLabel.Name = "TextureLabel";
            this.TextureLabel.Size = new System.Drawing.Size(49, 15);
            this.TextureLabel.TabIndex = 1;
            this.TextureLabel.Text = "Texture";
            // 
            // MeshLabel
            // 
            this.MeshLabel.AutoSize = true;
            this.MeshLabel.Location = new System.Drawing.Point(12, 35);
            this.MeshLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MeshLabel.Name = "MeshLabel";
            this.MeshLabel.Size = new System.Drawing.Size(38, 15);
            this.MeshLabel.TabIndex = 0;
            this.MeshLabel.Text = "Mesh";
            // 
            // Debugger
            // 
            this.Debugger.AutoSize = true;
            this.Debugger.Location = new System.Drawing.Point(11, 423);
            this.Debugger.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Debugger.Name = "Debugger";
            this.Debugger.Size = new System.Drawing.Size(31, 15);
            this.Debugger.TabIndex = 13;
            this.Debugger.Text = "AAA";
            // 
            // AddGameObject
            // 
            this.AddGameObject.Location = new System.Drawing.Point(129, 11);
            this.AddGameObject.Margin = new System.Windows.Forms.Padding(2);
            this.AddGameObject.Name = "AddGameObject";
            this.AddGameObject.Size = new System.Drawing.Size(75, 23);
            this.AddGameObject.TabIndex = 0;
            // 
            // AddGameObjectLabel
            // 
            this.AddGameObjectLabel.AutoSize = true;
            this.AddGameObjectLabel.Location = new System.Drawing.Point(22, 14);
            this.AddGameObjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddGameObjectLabel.Name = "AddGameObjectLabel";
            this.AddGameObjectLabel.Size = new System.Drawing.Size(103, 15);
            this.AddGameObjectLabel.TabIndex = 1;
            this.AddGameObjectLabel.Text = "AddGameObject";
            // 
            // AddComponentDropDown
            // 
            this.AddComponentDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddComponentDropDown.FormattingEnabled = true;
            this.AddComponentDropDown.Location = new System.Drawing.Point(129, 67);
            this.AddComponentDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.AddComponentDropDown.Name = "AddComponentDropDown";
            this.AddComponentDropDown.Size = new System.Drawing.Size(159, 23);
            this.AddComponentDropDown.TabIndex = 0;
            this.AddComponentDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox_AddCom_SelectedIndexChanged);
            // 
            // AddComponentLabel
            // 
            this.AddComponentLabel.AutoSize = true;
            this.AddComponentLabel.Location = new System.Drawing.Point(24, 70);
            this.AddComponentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddComponentLabel.Name = "AddComponentLabel";
            this.AddComponentLabel.Size = new System.Drawing.Size(99, 15);
            this.AddComponentLabel.TabIndex = 1;
            this.AddComponentLabel.Text = "AddComponent";
            // 
            // AddGObjBut
            // 
            this.AddGObjBut.Location = new System.Drawing.Point(209, 11);
            this.AddGObjBut.Name = "AddGObjBut";
            this.AddGObjBut.Size = new System.Drawing.Size(51, 23);
            this.AddGObjBut.TabIndex = 14;
            this.AddGObjBut.Text = "Add";
            this.AddGObjBut.UseVisualStyleBackColor = true;
            this.AddGObjBut.Click += new System.EventHandler(this.AddGObjBut_Click);
            // 
            // AddCmpBut
            // 
            this.AddCmpBut.Location = new System.Drawing.Point(293, 67);
            this.AddCmpBut.Name = "AddCmpBut";
            this.AddCmpBut.Size = new System.Drawing.Size(49, 23);
            this.AddCmpBut.TabIndex = 15;
            this.AddCmpBut.Text = "Add";
            this.AddCmpBut.UseVisualStyleBackColor = true;
            this.AddCmpBut.Click += new System.EventHandler(this.AddCmpBut_Click);
            // 
            // RemoveGObjBut
            // 
            this.RemoveGObjBut.Location = new System.Drawing.Point(664, 11);
            this.RemoveGObjBut.Name = "RemoveGObjBut";
            this.RemoveGObjBut.Size = new System.Drawing.Size(75, 23);
            this.RemoveGObjBut.TabIndex = 16;
            this.RemoveGObjBut.Text = "Remove";
            this.RemoveGObjBut.UseVisualStyleBackColor = true;
            this.RemoveGObjBut.Click += new System.EventHandler(this.RemoveGObjBut_Click);
            // 
            // SetPrefabBut
            // 
            this.SetPrefabBut.Location = new System.Drawing.Point(755, 10);
            this.SetPrefabBut.Name = "SetPrefabBut";
            this.SetPrefabBut.Size = new System.Drawing.Size(99, 23);
            this.SetPrefabBut.TabIndex = 17;
            this.SetPrefabBut.Text = "Set as Prefab";
            this.SetPrefabBut.UseVisualStyleBackColor = true;
            this.SetPrefabBut.Click += new System.EventHandler(this.SetPrefabBut_Click);
            // 
            // RemoveCmpBut
            // 
            this.RemoveCmpBut.Location = new System.Drawing.Point(664, 64);
            this.RemoveCmpBut.Name = "RemoveCmpBut";
            this.RemoveCmpBut.Size = new System.Drawing.Size(75, 23);
            this.RemoveCmpBut.TabIndex = 18;
            this.RemoveCmpBut.Text = "Remove";
            this.RemoveCmpBut.UseVisualStyleBackColor = true;
            this.RemoveCmpBut.Click += new System.EventHandler(this.RemoveCmpBut_Click);
            // 
            // Inspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 457);
            this.Controls.Add(this.RemoveCmpBut);
            this.Controls.Add(this.SetPrefabBut);
            this.Controls.Add(this.RemoveGObjBut);
            this.Controls.Add(this.AddCmpBut);
            this.Controls.Add(this.AddGObjBut);
            this.Controls.Add(this.AddComponentLabel);
            this.Controls.Add(this.AddComponentDropDown);
            this.Controls.Add(this.AddGameObjectLabel);
            this.Controls.Add(this.AddGameObject);
            this.Controls.Add(this.Debugger);
            this.Controls.Add(this.MeshRendererGroupBox);
            this.Controls.Add(this.TransformGroupBox);
            this.Controls.Add(this.ComponentDropDown);
            this.Controls.Add(this.ComponentLabel);
            this.Controls.Add(this.GameObjectLabel);
            this.Controls.Add(this.GameObjectDropDown);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inspector";
            this.Text = "Inspector";
            this.Load += new System.EventHandler(this.Inspector_Load);
            this.TransformGroupBox.ResumeLayout(false);
            this.TransformGroupBox.PerformLayout();
            this.MeshRendererGroupBox.ResumeLayout(false);
            this.MeshRendererGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox GameObjectDropDown;
        private System.Windows.Forms.Label GameObjectLabel;
        private System.Windows.Forms.Label ComponentLabel;
        private System.Windows.Forms.ComboBox ComponentDropDown;
        private System.Windows.Forms.GroupBox TransformGroupBox;
        private System.Windows.Forms.Label ScaleLabel;
        private System.Windows.Forms.Label RotationLabel;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TextBox Positionx;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox Scaley;
        private System.Windows.Forms.TextBox Scalex;
        private System.Windows.Forms.TextBox Rotationz;
        private System.Windows.Forms.TextBox Rotationy;
        private System.Windows.Forms.TextBox Rotationx;
        private System.Windows.Forms.TextBox Positionz;
        private System.Windows.Forms.TextBox Positiony;
        private System.Windows.Forms.TextBox Poxz;
        private System.Windows.Forms.TextBox Scalez;
        private System.Windows.Forms.GroupBox MeshRendererGroupBox;
        private System.Windows.Forms.Label TextureLabel;
        private System.Windows.Forms.Label MeshLabel;
        private System.Windows.Forms.TextBox Texturetext;
        private System.Windows.Forms.ComboBox TextureDropDown;
        private System.Windows.Forms.ComboBox MeshDropDown;
        private System.Windows.Forms.Label ScazLabel;
        private System.Windows.Forms.Label ScayLabel;
        private System.Windows.Forms.Label ScaxLabel;
        private System.Windows.Forms.Label RotzLabel;
        private System.Windows.Forms.Label RotyLabel;
        private System.Windows.Forms.Label RotxLabel;
        private System.Windows.Forms.Label PoszLabel;
        private System.Windows.Forms.Label PosyLabel;
        private System.Windows.Forms.Label PosxLabel;
        private System.Windows.Forms.Label Debugger;
        private System.Windows.Forms.Label OffSetzLabel;
        private System.Windows.Forms.Label OffSetyLabel;
        private System.Windows.Forms.Label OffSetxLabel;
        private System.Windows.Forms.TextBox OffSetz;
        private System.Windows.Forms.TextBox OffSety;
        private System.Windows.Forms.TextBox OffSetx;
        private System.Windows.Forms.Label OffSetLabel;
        private System.Windows.Forms.TextBox AddGameObject;
        private System.Windows.Forms.Label AddGameObjectLabel;
        private System.Windows.Forms.ComboBox AddComponentDropDown;
        private System.Windows.Forms.Label AddComponentLabel;
        private System.Windows.Forms.Button AddGObjBut;
        private System.Windows.Forms.Button AddCmpBut;
        private System.Windows.Forms.Button RemoveGObjBut;
        private System.Windows.Forms.Button SetPrefabBut;
        private System.Windows.Forms.Button RemoveCmpBut;
    }


}

