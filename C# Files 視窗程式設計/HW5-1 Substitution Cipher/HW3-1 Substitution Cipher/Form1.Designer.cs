namespace HW3_1_Substitution_Cipher
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
            this.subBtn = new System.Windows.Forms.Button();
            this.enBtn = new System.Windows.Forms.Button();
            this.deBtn = new System.Windows.Forms.Button();
            this.hisBtn = new System.Windows.Forms.Button();
            this.conBtn = new System.Windows.Forms.Button();
            this.rndBtn = new System.Windows.Forms.Button();
            this.Head = new System.Windows.Forms.Label();
            this.plaintextLabel = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.errorMes = new System.Windows.Forms.Label();
            this.labelUp = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.textBoxUp = new System.Windows.Forms.TextBox();
            this.textBoxDown = new System.Windows.Forms.TextBox();
            this.historyTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // subBtn
            // 
            this.subBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.subBtn.Location = new System.Drawing.Point(597, 48);
            this.subBtn.Name = "subBtn";
            this.subBtn.Size = new System.Drawing.Size(105, 47);
            this.subBtn.TabIndex = 0;
            this.subBtn.Text = "替換表";
            this.subBtn.UseVisualStyleBackColor = true;
            this.subBtn.Click += new System.EventHandler(this.subBtn_Click);
            // 
            // enBtn
            // 
            this.enBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.enBtn.Location = new System.Drawing.Point(597, 115);
            this.enBtn.Name = "enBtn";
            this.enBtn.Size = new System.Drawing.Size(105, 42);
            this.enBtn.TabIndex = 1;
            this.enBtn.Text = "加密";
            this.enBtn.UseVisualStyleBackColor = true;
            this.enBtn.Click += new System.EventHandler(this.enBtn_Click);
            // 
            // deBtn
            // 
            this.deBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.deBtn.Location = new System.Drawing.Point(597, 176);
            this.deBtn.Name = "deBtn";
            this.deBtn.Size = new System.Drawing.Size(105, 37);
            this.deBtn.TabIndex = 2;
            this.deBtn.Text = "解密";
            this.deBtn.UseVisualStyleBackColor = true;
            this.deBtn.Click += new System.EventHandler(this.deBtn_Click);
            // 
            // hisBtn
            // 
            this.hisBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.hisBtn.Location = new System.Drawing.Point(597, 245);
            this.hisBtn.Name = "hisBtn";
            this.hisBtn.Size = new System.Drawing.Size(105, 40);
            this.hisBtn.TabIndex = 3;
            this.hisBtn.Text = "歷史紀錄";
            this.hisBtn.UseVisualStyleBackColor = true;
            this.hisBtn.Click += new System.EventHandler(this.hisBtn_Click);
            // 
            // conBtn
            // 
            this.conBtn.Font = new System.Drawing.Font("標楷體", 9F);
            this.conBtn.Location = new System.Drawing.Point(447, 305);
            this.conBtn.Name = "conBtn";
            this.conBtn.Size = new System.Drawing.Size(100, 32);
            this.conBtn.TabIndex = 4;
            this.conBtn.Text = "確認";
            this.conBtn.UseVisualStyleBackColor = true;
            this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
            // 
            // rndBtn
            // 
            this.rndBtn.Font = new System.Drawing.Font("標楷體", 9F);
            this.rndBtn.Location = new System.Drawing.Point(447, 254);
            this.rndBtn.Name = "rndBtn";
            this.rndBtn.Size = new System.Drawing.Size(100, 31);
            this.rndBtn.TabIndex = 5;
            this.rndBtn.Text = "隨機生成";
            this.rndBtn.UseVisualStyleBackColor = true;
            this.rndBtn.Click += new System.EventHandler(this.rndBtn_Click);
            // 
            // Head
            // 
            this.Head.AutoSize = true;
            this.Head.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Head.Location = new System.Drawing.Point(34, 36);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(79, 21);
            this.Head.TabIndex = 6;
            this.Head.Text = "替換表";
            // 
            // plaintextLabel
            // 
            this.plaintextLabel.AutoSize = true;
            this.plaintextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plaintextLabel.Location = new System.Drawing.Point(56, 98);
            this.plaintextLabel.Name = "plaintextLabel";
            this.plaintextLabel.Size = new System.Drawing.Size(490, 20);
            this.plaintextLabel.TabIndex = 7;
            this.plaintextLabel.Text = "ABCKEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(56, 203);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(490, 22);
            this.keyBox.TabIndex = 10;
            // 
            // errorMes
            // 
            this.errorMes.AutoSize = true;
            this.errorMes.Font = new System.Drawing.Font("標楷體", 12F);
            this.errorMes.Location = new System.Drawing.Point(53, 269);
            this.errorMes.Name = "errorMes";
            this.errorMes.Size = new System.Drawing.Size(88, 16);
            this.errorMes.TabIndex = 11;
            this.errorMes.Text = "替換表合法";
            // 
            // labelUp
            // 
            this.labelUp.AutoSize = true;
            this.labelUp.Font = new System.Drawing.Font("標楷體", 12F);
            this.labelUp.Location = new System.Drawing.Point(35, 101);
            this.labelUp.Name = "labelUp";
            this.labelUp.Size = new System.Drawing.Size(56, 16);
            this.labelUp.TabIndex = 12;
            this.labelUp.Text = "label1";
            // 
            // labelDown
            // 
            this.labelDown.AutoSize = true;
            this.labelDown.Font = new System.Drawing.Font("標楷體", 12F);
            this.labelDown.Location = new System.Drawing.Point(35, 209);
            this.labelDown.Name = "labelDown";
            this.labelDown.Size = new System.Drawing.Size(56, 16);
            this.labelDown.TabIndex = 13;
            this.labelDown.Text = "label2";
            // 
            // textBoxUp
            // 
            this.textBoxUp.Location = new System.Drawing.Point(115, 96);
            this.textBoxUp.Name = "textBoxUp";
            this.textBoxUp.Size = new System.Drawing.Size(431, 22);
            this.textBoxUp.TabIndex = 14;
            // 
            // textBoxDown
            // 
            this.textBoxDown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDown.Location = new System.Drawing.Point(115, 203);
            this.textBoxDown.Name = "textBoxDown";
            this.textBoxDown.ReadOnly = true;
            this.textBoxDown.Size = new System.Drawing.Size(431, 22);
            this.textBoxDown.TabIndex = 15;
            // 
            // historyTxt
            // 
            this.historyTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.historyTxt.Font = new System.Drawing.Font("標楷體", 12F);
            this.historyTxt.Location = new System.Drawing.Point(38, 81);
            this.historyTxt.Name = "historyTxt";
            this.historyTxt.ReadOnly = true;
            this.historyTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.historyTxt.Size = new System.Drawing.Size(508, 256);
            this.historyTxt.TabIndex = 16;
            this.historyTxt.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 378);
            this.Controls.Add(this.historyTxt);
            this.Controls.Add(this.textBoxDown);
            this.Controls.Add(this.textBoxUp);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelUp);
            this.Controls.Add(this.errorMes);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.plaintextLabel);
            this.Controls.Add(this.Head);
            this.Controls.Add(this.rndBtn);
            this.Controls.Add(this.conBtn);
            this.Controls.Add(this.hisBtn);
            this.Controls.Add(this.deBtn);
            this.Controls.Add(this.enBtn);
            this.Controls.Add(this.subBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button subBtn;
        private System.Windows.Forms.Button enBtn;
        private System.Windows.Forms.Button deBtn;
        private System.Windows.Forms.Button hisBtn;
        private System.Windows.Forms.Button conBtn;
        private System.Windows.Forms.Button rndBtn;
        private System.Windows.Forms.Label Head;
        private System.Windows.Forms.Label plaintextLabel;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Label errorMes;
        private System.Windows.Forms.Label labelUp;
        private System.Windows.Forms.Label labelDown;
        private System.Windows.Forms.TextBox textBoxUp;
        private System.Windows.Forms.TextBox textBoxDown;
        private System.Windows.Forms.RichTextBox historyTxt;
    }
}

