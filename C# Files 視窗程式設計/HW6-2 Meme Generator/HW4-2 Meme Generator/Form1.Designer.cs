namespace HW4_2_Meme_Generator
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BiaoFont = new System.Windows.Forms.RadioButton();
            this.WeiFont = new System.Windows.Forms.RadioButton();
            this.XinFont = new System.Windows.Forms.RadioButton();
            this.FontBox = new System.Windows.Forms.GroupBox();
            this.PositionBox = new System.Windows.Forms.GroupBox();
            this.DR = new System.Windows.Forms.RadioButton();
            this.DM = new System.Windows.Forms.RadioButton();
            this.DL = new System.Windows.Forms.RadioButton();
            this.TR = new System.Windows.Forms.RadioButton();
            this.TL = new System.Windows.Forms.RadioButton();
            this.TM = new System.Windows.Forms.RadioButton();
            this.Bold = new System.Windows.Forms.CheckBox();
            this.Italic = new System.Windows.Forms.CheckBox();
            this.TextVal = new System.Windows.Forms.RichTextBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeVal = new System.Windows.Forms.TextBox();
            this.TextLabel = new System.Windows.Forms.Label();
            this.MemeText = new System.Windows.Forms.Label();
            this.PrevPic = new System.Windows.Forms.Button();
            this.NextPic = new System.Windows.Forms.Button();
            this.MemePics = new System.Windows.Forms.ImageList(this.components);
            this.MemePic = new System.Windows.Forms.PictureBox();
            this.FontBox.SuspendLayout();
            this.PositionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemePic)).BeginInit();
            this.SuspendLayout();
            // 
            // BiaoFont
            // 
            this.BiaoFont.AutoSize = true;
            this.BiaoFont.Location = new System.Drawing.Point(6, 31);
            this.BiaoFont.Name = "BiaoFont";
            this.BiaoFont.Size = new System.Drawing.Size(67, 18);
            this.BiaoFont.TabIndex = 1;
            this.BiaoFont.TabStop = true;
            this.BiaoFont.Text = "標楷體";
            this.BiaoFont.UseVisualStyleBackColor = true;
            this.BiaoFont.CheckedChanged += new System.EventHandler(this.BiaoFont_CheckedChanged);
            // 
            // WeiFont
            // 
            this.WeiFont.AutoSize = true;
            this.WeiFont.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.WeiFont.Location = new System.Drawing.Point(6, 67);
            this.WeiFont.Name = "WeiFont";
            this.WeiFont.Size = new System.Drawing.Size(96, 22);
            this.WeiFont.TabIndex = 2;
            this.WeiFont.TabStop = true;
            this.WeiFont.Text = "微軟正黑體";
            this.WeiFont.UseVisualStyleBackColor = true;
            this.WeiFont.CheckedChanged += new System.EventHandler(this.WeiFont_CheckedChanged);
            // 
            // XinFont
            // 
            this.XinFont.AutoSize = true;
            this.XinFont.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this.XinFont.Location = new System.Drawing.Point(152, 31);
            this.XinFont.Name = "XinFont";
            this.XinFont.Size = new System.Drawing.Size(85, 18);
            this.XinFont.TabIndex = 3;
            this.XinFont.TabStop = true;
            this.XinFont.Text = "新細明體";
            this.XinFont.UseVisualStyleBackColor = true;
            this.XinFont.CheckedChanged += new System.EventHandler(this.XinFont_CheckedChanged);
            // 
            // FontBox
            // 
            this.FontBox.Controls.Add(this.BiaoFont);
            this.FontBox.Controls.Add(this.WeiFont);
            this.FontBox.Controls.Add(this.XinFont);
            this.FontBox.Font = new System.Drawing.Font("標楷體", 10F);
            this.FontBox.Location = new System.Drawing.Point(502, 68);
            this.FontBox.Name = "FontBox";
            this.FontBox.Size = new System.Drawing.Size(272, 100);
            this.FontBox.TabIndex = 4;
            this.FontBox.TabStop = false;
            this.FontBox.Text = "字體";
            // 
            // PositionBox
            // 
            this.PositionBox.Controls.Add(this.DR);
            this.PositionBox.Controls.Add(this.DM);
            this.PositionBox.Controls.Add(this.DL);
            this.PositionBox.Controls.Add(this.TR);
            this.PositionBox.Controls.Add(this.TL);
            this.PositionBox.Controls.Add(this.TM);
            this.PositionBox.Font = new System.Drawing.Font("標楷體", 10F);
            this.PositionBox.Location = new System.Drawing.Point(502, 242);
            this.PositionBox.Name = "PositionBox";
            this.PositionBox.Size = new System.Drawing.Size(272, 100);
            this.PositionBox.TabIndex = 4;
            this.PositionBox.TabStop = false;
            this.PositionBox.Text = "位置";
            // 
            // DR
            // 
            this.DR.AutoSize = true;
            this.DR.Location = new System.Drawing.Point(181, 67);
            this.DR.Name = "DR";
            this.DR.Size = new System.Drawing.Size(53, 18);
            this.DR.TabIndex = 6;
            this.DR.TabStop = true;
            this.DR.Text = "下右";
            this.DR.UseVisualStyleBackColor = true;
            this.DR.CheckedChanged += new System.EventHandler(this.DR_CheckedChanged);
            // 
            // DM
            // 
            this.DM.AutoSize = true;
            this.DM.Location = new System.Drawing.Point(94, 67);
            this.DM.Name = "DM";
            this.DM.Size = new System.Drawing.Size(53, 18);
            this.DM.TabIndex = 5;
            this.DM.TabStop = true;
            this.DM.Text = "下中";
            this.DM.UseVisualStyleBackColor = true;
            this.DM.CheckedChanged += new System.EventHandler(this.DM_CheckedChanged);
            // 
            // DL
            // 
            this.DL.AutoSize = true;
            this.DL.Location = new System.Drawing.Point(6, 67);
            this.DL.Name = "DL";
            this.DL.Size = new System.Drawing.Size(53, 18);
            this.DL.TabIndex = 4;
            this.DL.TabStop = true;
            this.DL.Text = "下左";
            this.DL.UseVisualStyleBackColor = true;
            this.DL.CheckedChanged += new System.EventHandler(this.DL_CheckedChanged);
            // 
            // TR
            // 
            this.TR.AutoSize = true;
            this.TR.Location = new System.Drawing.Point(181, 36);
            this.TR.Name = "TR";
            this.TR.Size = new System.Drawing.Size(53, 18);
            this.TR.TabIndex = 3;
            this.TR.TabStop = true;
            this.TR.Text = "上右";
            this.TR.UseVisualStyleBackColor = true;
            this.TR.CheckedChanged += new System.EventHandler(this.TR_CheckedChanged);
            // 
            // TL
            // 
            this.TL.AutoSize = true;
            this.TL.Location = new System.Drawing.Point(6, 36);
            this.TL.Name = "TL";
            this.TL.Size = new System.Drawing.Size(53, 18);
            this.TL.TabIndex = 2;
            this.TL.TabStop = true;
            this.TL.Text = "上左";
            this.TL.UseVisualStyleBackColor = true;
            this.TL.CheckedChanged += new System.EventHandler(this.TL_CheckedChanged);
            // 
            // TM
            // 
            this.TM.AutoSize = true;
            this.TM.Location = new System.Drawing.Point(94, 36);
            this.TM.Name = "TM";
            this.TM.Size = new System.Drawing.Size(53, 18);
            this.TM.TabIndex = 1;
            this.TM.TabStop = true;
            this.TM.Text = "上中";
            this.TM.UseVisualStyleBackColor = true;
            this.TM.CheckedChanged += new System.EventHandler(this.TM_CheckedChanged);
            // 
            // Bold
            // 
            this.Bold.AutoSize = true;
            this.Bold.Font = new System.Drawing.Font("標楷體", 10F, System.Drawing.FontStyle.Bold);
            this.Bold.Location = new System.Drawing.Point(522, 197);
            this.Bold.Name = "Bold";
            this.Bold.Size = new System.Drawing.Size(56, 18);
            this.Bold.TabIndex = 5;
            this.Bold.Text = "粗體";
            this.Bold.UseVisualStyleBackColor = true;
            this.Bold.CheckedChanged += new System.EventHandler(this.Bold_CheckedChanged);
            // 
            // Italic
            // 
            this.Italic.AutoSize = true;
            this.Italic.Font = new System.Drawing.Font("標楷體", 10F, System.Drawing.FontStyle.Italic);
            this.Italic.Location = new System.Drawing.Point(662, 198);
            this.Italic.Name = "Italic";
            this.Italic.Size = new System.Drawing.Size(54, 18);
            this.Italic.TabIndex = 6;
            this.Italic.Text = "斜體";
            this.Italic.UseVisualStyleBackColor = true;
            this.Italic.CheckedChanged += new System.EventHandler(this.Italic_CheckedChanged);
            // 
            // TextVal
            // 
            this.TextVal.Font = new System.Drawing.Font("標楷體", 10F);
            this.TextVal.Location = new System.Drawing.Point(502, 432);
            this.TextVal.Name = "TextVal";
            this.TextVal.Size = new System.Drawing.Size(272, 83);
            this.TextVal.TabIndex = 7;
            this.TextVal.Text = "";
            this.TextVal.TextChanged += new System.EventHandler(this.TextVal_TextChanged);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("標楷體", 10F);
            this.SizeLabel.Location = new System.Drawing.Point(523, 366);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(70, 14);
            this.SizeLabel.TabIndex = 8;
            this.SizeLabel.Text = "字體大小:";
            // 
            // SizeVal
            // 
            this.SizeVal.Font = new System.Drawing.Font("新細明體", 10F);
            this.SizeVal.Location = new System.Drawing.Point(606, 363);
            this.SizeVal.Name = "SizeVal";
            this.SizeVal.Size = new System.Drawing.Size(100, 23);
            this.SizeVal.TabIndex = 9;
            this.SizeVal.TextChanged += new System.EventHandler(this.SizeVal_TextChanged);
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.TextLabel.Location = new System.Drawing.Point(612, 403);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(48, 16);
            this.TextLabel.TabIndex = 10;
            this.TextLabel.Text = "文字:";
            // 
            // MemeText
            // 
            this.MemeText.Font = new System.Drawing.Font("新細明體", 32F);
            this.MemeText.Location = new System.Drawing.Point(12, 20);
            this.MemeText.Name = "MemeText";
            this.MemeText.Size = new System.Drawing.Size(456, 411);
            this.MemeText.TabIndex = 11;
            this.MemeText.Text = "label1";
            // 
            // PrevPic
            // 
            this.PrevPic.Font = new System.Drawing.Font("標楷體", 10F);
            this.PrevPic.Location = new System.Drawing.Point(76, 480);
            this.PrevPic.Name = "PrevPic";
            this.PrevPic.Size = new System.Drawing.Size(75, 23);
            this.PrevPic.TabIndex = 13;
            this.PrevPic.Text = "上一張";
            this.PrevPic.UseVisualStyleBackColor = true;
            this.PrevPic.Click += new System.EventHandler(this.PrevPic_Click);
            // 
            // NextPic
            // 
            this.NextPic.Font = new System.Drawing.Font("標楷體", 10F);
            this.NextPic.Location = new System.Drawing.Point(286, 481);
            this.NextPic.Name = "NextPic";
            this.NextPic.Size = new System.Drawing.Size(75, 23);
            this.NextPic.TabIndex = 14;
            this.NextPic.Text = "下一張";
            this.NextPic.UseVisualStyleBackColor = true;
            this.NextPic.Click += new System.EventHandler(this.NextPic_Click);
            // 
            // MemePics
            // 
            this.MemePics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MemePics.ImageStream")));
            this.MemePics.TransparentColor = System.Drawing.Color.Transparent;
            this.MemePics.Images.SetKeyName(0, "pic_01.png");
            this.MemePics.Images.SetKeyName(1, "pic_02.png");
            this.MemePics.Images.SetKeyName(2, "pic_03.png");
            this.MemePics.Images.SetKeyName(3, "pic_04.png");
            this.MemePics.Images.SetKeyName(4, "pic_05.png");
            // 
            // MemePic
            // 
            this.MemePic.Location = new System.Drawing.Point(20, 68);
            this.MemePic.Name = "MemePic";
            this.MemePic.Size = new System.Drawing.Size(438, 312);
            this.MemePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MemePic.TabIndex = 15;
            this.MemePic.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.MemePic);
            this.Controls.Add(this.NextPic);
            this.Controls.Add(this.PrevPic);
            this.Controls.Add(this.MemeText);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.SizeVal);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.TextVal);
            this.Controls.Add(this.Italic);
            this.Controls.Add(this.Bold);
            this.Controls.Add(this.PositionBox);
            this.Controls.Add(this.FontBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FontBox.ResumeLayout(false);
            this.FontBox.PerformLayout();
            this.PositionBox.ResumeLayout(false);
            this.PositionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton BiaoFont;
        private System.Windows.Forms.RadioButton WeiFont;
        private System.Windows.Forms.RadioButton XinFont;
        private System.Windows.Forms.GroupBox FontBox;
        private System.Windows.Forms.GroupBox PositionBox;
        private System.Windows.Forms.RadioButton DR;
        private System.Windows.Forms.RadioButton DM;
        private System.Windows.Forms.RadioButton DL;
        private System.Windows.Forms.RadioButton TR;
        private System.Windows.Forms.RadioButton TL;
        private System.Windows.Forms.RadioButton TM;
        private System.Windows.Forms.CheckBox Bold;
        private System.Windows.Forms.CheckBox Italic;
        private System.Windows.Forms.RichTextBox TextVal;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TextBox SizeVal;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label MemeText;
        private System.Windows.Forms.Button PrevPic;
        private System.Windows.Forms.Button NextPic;
        private System.Windows.Forms.ImageList MemePics;
        private System.Windows.Forms.PictureBox MemePic;
    }
}

