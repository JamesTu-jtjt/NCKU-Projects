namespace HW7_1_2048
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
            this.Points = new System.Windows.Forms.Label();
            this.Num = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.EasyBtn = new System.Windows.Forms.Button();
            this.NormalBtn = new System.Windows.Forms.Button();
            this.pVal = new System.Windows.Forms.Label();
            this.nVal = new System.Windows.Forms.Label();
            this.tVal = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Points
            // 
            this.Points.AutoSize = true;
            this.Points.Location = new System.Drawing.Point(455, 96);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(59, 12);
            this.Points.TabIndex = 39;
            this.Points.Text = "你的分數: ";
            // 
            // Num
            // 
            this.Num.AutoSize = true;
            this.Num.Location = new System.Drawing.Point(455, 139);
            this.Num.Name = "Num";
            this.Num.Size = new System.Drawing.Size(59, 12);
            this.Num.TabIndex = 40;
            this.Num.Text = "當前數字: ";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(455, 179);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(59, 12);
            this.Time.TabIndex = 41;
            this.Time.Text = "倒數計時: ";
            // 
            // EasyBtn
            // 
            this.EasyBtn.Location = new System.Drawing.Point(250, 156);
            this.EasyBtn.Name = "EasyBtn";
            this.EasyBtn.Size = new System.Drawing.Size(75, 23);
            this.EasyBtn.TabIndex = 42;
            this.EasyBtn.Text = "button1";
            this.EasyBtn.UseVisualStyleBackColor = true;
            this.EasyBtn.Click += new System.EventHandler(this.EasyBtn_Click);
            // 
            // NormalBtn
            // 
            this.NormalBtn.Location = new System.Drawing.Point(250, 216);
            this.NormalBtn.Name = "NormalBtn";
            this.NormalBtn.Size = new System.Drawing.Size(75, 23);
            this.NormalBtn.TabIndex = 43;
            this.NormalBtn.Text = "button2";
            this.NormalBtn.UseVisualStyleBackColor = true;
            this.NormalBtn.Click += new System.EventHandler(this.NormalBtn_Click);
            // 
            // pVal
            // 
            this.pVal.AutoSize = true;
            this.pVal.Location = new System.Drawing.Point(511, 96);
            this.pVal.Name = "pVal";
            this.pVal.Size = new System.Drawing.Size(33, 12);
            this.pVal.TabIndex = 44;
            this.pVal.Text = "label1";
            // 
            // nVal
            // 
            this.nVal.AutoSize = true;
            this.nVal.Location = new System.Drawing.Point(511, 139);
            this.nVal.Name = "nVal";
            this.nVal.Size = new System.Drawing.Size(33, 12);
            this.nVal.TabIndex = 45;
            this.nVal.Text = "label2";
            // 
            // tVal
            // 
            this.tVal.AutoSize = true;
            this.tVal.Location = new System.Drawing.Point(511, 179);
            this.tVal.Name = "tVal";
            this.tVal.Size = new System.Drawing.Size(33, 12);
            this.tVal.TabIndex = 46;
            this.tVal.Text = "label3";
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
            this.ClientSize = new System.Drawing.Size(592, 444);
            this.Controls.Add(this.tVal);
            this.Controls.Add(this.nVal);
            this.Controls.Add(this.pVal);
            this.Controls.Add(this.NormalBtn);
            this.Controls.Add(this.EasyBtn);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Num);
            this.Controls.Add(this.Points);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Points;
        private System.Windows.Forms.Label Num;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Button EasyBtn;
        private System.Windows.Forms.Button NormalBtn;
        private System.Windows.Forms.Label pVal;
        private System.Windows.Forms.Label nVal;
        private System.Windows.Forms.Label tVal;
        private System.Windows.Forms.Timer timer;
    }
}

