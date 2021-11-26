namespace HW4_1_Seven_Segment_Display
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
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.width = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.heightLabel.Location = new System.Drawing.Point(12, 84);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(24, 16);
            this.heightLabel.TabIndex = 0;
            this.heightLabel.Text = "高";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.widthLabel.Location = new System.Drawing.Point(12, 134);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(24, 16);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "寬";
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.inputLabel.Location = new System.Drawing.Point(12, 339);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(128, 16);
            this.inputLabel.TabIndex = 2;
            this.inputLabel.Text = "請輸數字(-9~99)";
            // 
            // height
            // 
            this.height.Font = new System.Drawing.Font("標楷體", 12F);
            this.height.Location = new System.Drawing.Point(42, 81);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(62, 27);
            this.height.TabIndex = 3;
            // 
            // width
            // 
            this.width.Font = new System.Drawing.Font("標楷體", 12F);
            this.width.Location = new System.Drawing.Point(42, 131);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(62, 27);
            this.width.TabIndex = 4;
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("標楷體", 12F);
            this.input.Location = new System.Drawing.Point(12, 368);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(126, 27);
            this.input.TabIndex = 5;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.confirmBtn.Location = new System.Drawing.Point(25, 183);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 6;
            this.confirmBtn.Text = "確定";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(200, 50);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(300, 400);
            this.btn1.TabIndex = 7;
            this.btn1.Text = "button1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(600, 50);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(300, 400);
            this.btn2.TabIndex = 8;
            this.btn2.Text = "button2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 469);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.input);
            this.Controls.Add(this.width);
            this.Controls.Add(this.height);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.heightLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
    }
}

