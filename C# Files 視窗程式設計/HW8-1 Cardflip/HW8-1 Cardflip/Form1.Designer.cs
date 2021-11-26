namespace HW8_1_Cardflip
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
            this.RoundL = new System.Windows.Forms.Label();
            this.P2L = new System.Windows.Forms.Label();
            this.P1L = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RoundL
            // 
            this.RoundL.AutoSize = true;
            this.RoundL.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RoundL.Location = new System.Drawing.Point(327, 40);
            this.RoundL.Name = "RoundL";
            this.RoundL.Size = new System.Drawing.Size(137, 19);
            this.RoundL.TabIndex = 0;
            this.RoundL.Text = "第1回合 輪到P1";
            // 
            // P2L
            // 
            this.P2L.AutoSize = true;
            this.P2L.Font = new System.Drawing.Font("新細明體", 12F);
            this.P2L.Location = new System.Drawing.Point(12, 175);
            this.P2L.Name = "P2L";
            this.P2L.Size = new System.Drawing.Size(56, 16);
            this.P2L.TabIndex = 1;
            this.P2L.Text = "P2: 0分";
            // 
            // P1L
            // 
            this.P1L.AutoSize = true;
            this.P1L.Font = new System.Drawing.Font("新細明體", 12F);
            this.P1L.Location = new System.Drawing.Point(686, 175);
            this.P1L.Name = "P1L";
            this.P1L.Size = new System.Drawing.Size(56, 16);
            this.P1L.TabIndex = 2;
            this.P1L.Text = "P1: 0分";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(344, 189);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(102, 51);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "開始遊戲";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.P1L);
            this.Controls.Add(this.P2L);
            this.Controls.Add(this.RoundL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RoundL;
        private System.Windows.Forms.Label P2L;
        private System.Windows.Forms.Label P1L;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer timer;
    }
}

