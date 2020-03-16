namespace BlockstateCreator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Generate = new System.Windows.Forms.Button();
            this.ModID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextureStyle = new System.Windows.Forms.ComboBox();
            this.IsItem = new System.Windows.Forms.CheckBox();
            this.TopLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SingleBlockstate = new System.Windows.Forms.RadioButton();
            this.BatchMode = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.ChangeResourceButton = new System.Windows.Forms.Button();
            this.SetBatchLocation = new System.Windows.Forms.Button();
            this.Resource = new System.Windows.Forms.TextBox();
            this.PathOfBatch = new System.Windows.Forms.TextBox();
            this.EntityName = new System.Windows.Forms.TextBox();
            this.EntityNameLabel = new System.Windows.Forms.Label();
            this.HasSnowVariant = new System.Windows.Forms.CheckBox();
            this.backTexture = new System.Windows.Forms.PictureBox();
            this.rightTexture = new System.Windows.Forms.PictureBox();
            this.downTexture = new System.Windows.Forms.PictureBox();
            this.frontTexture = new System.Windows.Forms.PictureBox();
            this.LeftTexture = new System.Windows.Forms.PictureBox();
            this.upTexture = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.idNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.backTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(577, 364);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(211, 74);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generate BlockState";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.GenerateBlockstate_Click);
            // 
            // ModID
            // 
            this.ModID.Location = new System.Drawing.Point(652, 28);
            this.ModID.Name = "ModID";
            this.ModID.Size = new System.Drawing.Size(136, 20);
            this.ModID.TabIndex = 1;
            this.ModID.TextChanged += new System.EventHandler(this.ModID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mod ID:";
            // 
            // TextureStyle
            // 
            this.TextureStyle.FormattingEnabled = true;
            this.TextureStyle.Items.AddRange(new object[] {
            "CubeAll",
            "Grass",
            "WoodLog",
            "Bush",
            "Pane",
            "FramedPane",
            "Food",
            "Item",
            "PickAxe",
            "Axe",
            "Sword"});
            this.TextureStyle.Location = new System.Drawing.Point(652, 246);
            this.TextureStyle.Name = "TextureStyle";
            this.TextureStyle.Size = new System.Drawing.Size(136, 21);
            this.TextureStyle.TabIndex = 3;
            this.TextureStyle.SelectedIndexChanged += new System.EventHandler(this.TextureStyle_SelectedIndexChanged);
            // 
            // IsItem
            // 
            this.IsItem.AutoSize = true;
            this.IsItem.Location = new System.Drawing.Point(652, 200);
            this.IsItem.Name = "IsItem";
            this.IsItem.Size = new System.Drawing.Size(70, 17);
            this.IsItem.TabIndex = 4;
            this.IsItem.Text = "Item Only";
            this.IsItem.UseVisualStyleBackColor = true;
            this.IsItem.CheckedChanged += new System.EventHandler(this.IsItem_CheckedChanged);
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Location = new System.Drawing.Point(69, 74);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(26, 13);
            this.TopLabel.TabIndex = 11;
            this.TopLabel.Text = "Top";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Front";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Bottom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Right";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Back";
            // 
            // SingleBlockstate
            // 
            this.SingleBlockstate.AutoSize = true;
            this.SingleBlockstate.Location = new System.Drawing.Point(734, 70);
            this.SingleBlockstate.Name = "SingleBlockstate";
            this.SingleBlockstate.Size = new System.Drawing.Size(54, 17);
            this.SingleBlockstate.TabIndex = 17;
            this.SingleBlockstate.TabStop = true;
            this.SingleBlockstate.Text = "Single";
            this.SingleBlockstate.UseVisualStyleBackColor = true;
            this.SingleBlockstate.CheckedChanged += new System.EventHandler(this.SingleBlockstate_CheckedChanged);
            // 
            // BatchMode
            // 
            this.BatchMode.AutoSize = true;
            this.BatchMode.Location = new System.Drawing.Point(652, 70);
            this.BatchMode.Name = "BatchMode";
            this.BatchMode.Size = new System.Drawing.Size(53, 17);
            this.BatchMode.TabIndex = 18;
            this.BatchMode.TabStop = true;
            this.BatchMode.Text = "Batch";
            this.BatchMode.UseVisualStyleBackColor = true;
            this.BatchMode.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Current Resource:";
            // 
            // ChangeResourceButton
            // 
            this.ChangeResourceButton.Location = new System.Drawing.Point(45, 25);
            this.ChangeResourceButton.Name = "ChangeResourceButton";
            this.ChangeResourceButton.Size = new System.Drawing.Size(111, 23);
            this.ChangeResourceButton.TabIndex = 20;
            this.ChangeResourceButton.Text = "Change Resource";
            this.ChangeResourceButton.UseVisualStyleBackColor = true;
            this.ChangeResourceButton.Click += new System.EventHandler(this.ChangeResourceButton_Click);
            // 
            // SetBatchLocation
            // 
            this.SetBatchLocation.Location = new System.Drawing.Point(652, 135);
            this.SetBatchLocation.Name = "SetBatchLocation";
            this.SetBatchLocation.Size = new System.Drawing.Size(136, 28);
            this.SetBatchLocation.TabIndex = 22;
            this.SetBatchLocation.Text = "Select Batch location";
            this.SetBatchLocation.UseVisualStyleBackColor = true;
            this.SetBatchLocation.Click += new System.EventHandler(this.SetBatchLocation_Click);
            // 
            // Resource
            // 
            this.Resource.Location = new System.Drawing.Point(163, 27);
            this.Resource.Name = "Resource";
            this.Resource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Resource.Size = new System.Drawing.Size(168, 20);
            this.Resource.TabIndex = 23;
            // 
            // PathOfBatch
            // 
            this.PathOfBatch.Location = new System.Drawing.Point(652, 174);
            this.PathOfBatch.Name = "PathOfBatch";
            this.PathOfBatch.Size = new System.Drawing.Size(136, 20);
            this.PathOfBatch.TabIndex = 24;
            this.PathOfBatch.TextChanged += new System.EventHandler(this.PathOfBatch_TextChanged);
            // 
            // EntityName
            // 
            this.EntityName.Location = new System.Drawing.Point(652, 106);
            this.EntityName.Name = "EntityName";
            this.EntityName.Size = new System.Drawing.Size(136, 20);
            this.EntityName.TabIndex = 25;
            this.EntityName.TextChanged += new System.EventHandler(this.EntityName_TextChanged);
            // 
            // EntityNameLabel
            // 
            this.EntityNameLabel.AutoSize = true;
            this.EntityNameLabel.Location = new System.Drawing.Point(582, 109);
            this.EntityNameLabel.Name = "EntityNameLabel";
            this.EntityNameLabel.Size = new System.Drawing.Size(64, 13);
            this.EntityNameLabel.TabIndex = 26;
            this.EntityNameLabel.Text = "Entity Name";
            // 
            // HasSnowVariant
            // 
            this.HasSnowVariant.AutoSize = true;
            this.HasSnowVariant.Location = new System.Drawing.Point(652, 223);
            this.HasSnowVariant.Name = "HasSnowVariant";
            this.HasSnowVariant.Size = new System.Drawing.Size(133, 17);
            this.HasSnowVariant.TabIndex = 28;
            this.HasSnowVariant.Text = "Append to entitydb.xml";
            this.HasSnowVariant.UseVisualStyleBackColor = true;
            this.HasSnowVariant.CheckedChanged += new System.EventHandler(this.AppendToXML_CheckedChanged);
            // 
            // backTexture
            // 
            this.backTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backTexture.Location = new System.Drawing.Point(255, 187);
            this.backTexture.Name = "backTexture";
            this.backTexture.Size = new System.Drawing.Size(76, 73);
            this.backTexture.TabIndex = 10;
            this.backTexture.TabStop = false;
            this.backTexture.Click += new System.EventHandler(this.backTexture_Click);
            // 
            // rightTexture
            // 
            this.rightTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightTexture.Location = new System.Drawing.Point(153, 187);
            this.rightTexture.Name = "rightTexture";
            this.rightTexture.Size = new System.Drawing.Size(76, 73);
            this.rightTexture.TabIndex = 9;
            this.rightTexture.TabStop = false;
            this.rightTexture.Click += new System.EventHandler(this.rightTexture_Click);
            // 
            // downTexture
            // 
            this.downTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.downTexture.Location = new System.Drawing.Point(45, 187);
            this.downTexture.Name = "downTexture";
            this.downTexture.Size = new System.Drawing.Size(76, 73);
            this.downTexture.TabIndex = 8;
            this.downTexture.TabStop = false;
            this.downTexture.Click += new System.EventHandler(this.downTexture_Click);
            // 
            // frontTexture
            // 
            this.frontTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontTexture.Location = new System.Drawing.Point(255, 90);
            this.frontTexture.Name = "frontTexture";
            this.frontTexture.Size = new System.Drawing.Size(76, 73);
            this.frontTexture.TabIndex = 7;
            this.frontTexture.TabStop = false;
            this.frontTexture.Click += new System.EventHandler(this.frontTexture_Click);
            // 
            // LeftTexture
            // 
            this.LeftTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftTexture.Location = new System.Drawing.Point(153, 90);
            this.LeftTexture.Name = "LeftTexture";
            this.LeftTexture.Size = new System.Drawing.Size(76, 73);
            this.LeftTexture.TabIndex = 6;
            this.LeftTexture.TabStop = false;
            this.LeftTexture.Click += new System.EventHandler(this.LeftTexture_Click);
            // 
            // upTexture
            // 
            this.upTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upTexture.Location = new System.Drawing.Point(45, 90);
            this.upTexture.Name = "upTexture";
            this.upTexture.Size = new System.Drawing.Size(76, 73);
            this.upTexture.TabIndex = 5;
            this.upTexture.TabStop = false;
            this.upTexture.Click += new System.EventHandler(this.UpTexture_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(561, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Picture Directory";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(602, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Start Id:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // idNumber
            // 
            this.idNumber.Location = new System.Drawing.Point(652, 283);
            this.idNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.idNumber.Name = "idNumber";
            this.idNumber.Size = new System.Drawing.Size(53, 20);
            this.idNumber.TabIndex = 31;
            this.idNumber.ValueChanged += new System.EventHandler(this.idNumber_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.HasSnowVariant);
            this.Controls.Add(this.EntityNameLabel);
            this.Controls.Add(this.EntityName);
            this.Controls.Add(this.PathOfBatch);
            this.Controls.Add(this.Resource);
            this.Controls.Add(this.SetBatchLocation);
            this.Controls.Add(this.ChangeResourceButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BatchMode);
            this.Controls.Add(this.SingleBlockstate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.backTexture);
            this.Controls.Add(this.rightTexture);
            this.Controls.Add(this.downTexture);
            this.Controls.Add(this.frontTexture);
            this.Controls.Add(this.LeftTexture);
            this.Controls.Add(this.upTexture);
            this.Controls.Add(this.IsItem);
            this.Controls.Add(this.TextureStyle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModID);
            this.Controls.Add(this.Generate);
            this.Name = "Form1";
            this.Text = "Minecraft Blockstate Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox ModID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TextureStyle;
        private System.Windows.Forms.CheckBox IsItem;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton SingleBlockstate;
        private System.Windows.Forms.RadioButton BatchMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ChangeResourceButton;
        private System.Windows.Forms.Button SetBatchLocation;
        private System.Windows.Forms.TextBox Resource;
        private System.Windows.Forms.TextBox PathOfBatch;
        private System.Windows.Forms.TextBox EntityName;
        private System.Windows.Forms.Label EntityNameLabel;
        private System.Windows.Forms.CheckBox HasSnowVariant;
        private System.Windows.Forms.PictureBox backTexture;
        private System.Windows.Forms.PictureBox rightTexture;
        private System.Windows.Forms.PictureBox downTexture;
        private System.Windows.Forms.PictureBox frontTexture;
        private System.Windows.Forms.PictureBox LeftTexture;
        private System.Windows.Forms.PictureBox upTexture;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown idNumber;
    }
}

