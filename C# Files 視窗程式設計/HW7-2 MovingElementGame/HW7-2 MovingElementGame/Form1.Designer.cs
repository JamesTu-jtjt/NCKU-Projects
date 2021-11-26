namespace HW7_2_MovingElementGame
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
            this.Choose = new System.Windows.Forms.Label();
            this.WaterRb = new System.Windows.Forms.RadioButton();
            this.FireRb = new System.Windows.Forms.RadioButton();
            this.WoodRb = new System.Windows.Forms.RadioButton();
            this.StartBtn = new System.Windows.Forms.Button();
            this.ElementL = new System.Windows.Forms.Label();
            this.PointsL = new System.Windows.Forms.Label();
            this.TimeL = new System.Windows.Forms.Label();
            this.EVal = new System.Windows.Forms.Label();
            this.PVal = new System.Windows.Forms.Label();
            this.TVal = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Choose
            // 
            this.Choose.AutoSize = true;
            this.Choose.Location = new System.Drawing.Point(241, 100);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(77, 12);
            this.Choose.TabIndex = 0;
            this.Choose.Text = "選擇初始屬性";
            // 
            // WaterRb
            // 
            this.WaterRb.AutoSize = true;
            this.WaterRb.Location = new System.Drawing.Point(243, 136);
            this.WaterRb.Name = "WaterRb";
            this.WaterRb.Size = new System.Drawing.Size(35, 16);
            this.WaterRb.TabIndex = 1;
            this.WaterRb.TabStop = true;
            this.WaterRb.Text = "水";
            this.WaterRb.UseVisualStyleBackColor = true;
            // 
            // FireRb
            // 
            this.FireRb.AutoSize = true;
            this.FireRb.Location = new System.Drawing.Point(243, 158);
            this.FireRb.Name = "FireRb";
            this.FireRb.Size = new System.Drawing.Size(35, 16);
            this.FireRb.TabIndex = 2;
            this.FireRb.TabStop = true;
            this.FireRb.Text = "火";
            this.FireRb.UseVisualStyleBackColor = true;
            // 
            // WoodRb
            // 
            this.WoodRb.AutoSize = true;
            this.WoodRb.Location = new System.Drawing.Point(243, 180);
            this.WoodRb.Name = "WoodRb";
            this.WoodRb.Size = new System.Drawing.Size(35, 16);
            this.WoodRb.TabIndex = 3;
            this.WoodRb.TabStop = true;
            this.WoodRb.Text = "木";
            this.WoodRb.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(243, 212);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "開始";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // ElementL
            // 
            this.ElementL.AutoSize = true;
            this.ElementL.Location = new System.Drawing.Point(459, 49);
            this.ElementL.Name = "ElementL";
            this.ElementL.Size = new System.Drawing.Size(56, 12);
            this.ElementL.TabIndex = 5;
            this.ElementL.Text = "目前屬性:";
            // 
            // PointsL
            // 
            this.PointsL.AutoSize = true;
            this.PointsL.Location = new System.Drawing.Point(459, 71);
            this.PointsL.Name = "PointsL";
            this.PointsL.Size = new System.Drawing.Size(56, 12);
            this.PointsL.TabIndex = 6;
            this.PointsL.Text = "目前分數:";
            // 
            // TimeL
            // 
            this.TimeL.AutoSize = true;
            this.TimeL.Location = new System.Drawing.Point(459, 100);
            this.TimeL.Name = "TimeL";
            this.TimeL.Size = new System.Drawing.Size(56, 12);
            this.TimeL.TabIndex = 7;
            this.TimeL.Text = "剩餘時間:";
            // 
            // EVal
            // 
            this.EVal.AutoSize = true;
            this.EVal.Location = new System.Drawing.Point(521, 49);
            this.EVal.Name = "EVal";
            this.EVal.Size = new System.Drawing.Size(17, 12);
            this.EVal.TabIndex = 8;
            this.EVal.Text = "水";
            // 
            // PVal
            // 
            this.PVal.AutoSize = true;
            this.PVal.Location = new System.Drawing.Point(521, 71);
            this.PVal.Name = "PVal";
            this.PVal.Size = new System.Drawing.Size(11, 12);
            this.PVal.TabIndex = 9;
            this.PVal.Text = "0";
            // 
            // TVal
            // 
            this.TVal.AutoSize = true;
            this.TVal.Location = new System.Drawing.Point(521, 100);
            this.TVal.Name = "TVal";
            this.TVal.Size = new System.Drawing.Size(17, 12);
            this.TVal.TabIndex = 10;
            this.TVal.Text = "60";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.TVal);
            this.Controls.Add(this.PVal);
            this.Controls.Add(this.EVal);
            this.Controls.Add(this.TimeL);
            this.Controls.Add(this.PointsL);
            this.Controls.Add(this.ElementL);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.WoodRb);
            this.Controls.Add(this.FireRb);
            this.Controls.Add(this.WaterRb);
            this.Controls.Add(this.Choose);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Choose;
        private System.Windows.Forms.RadioButton WaterRb;
        private System.Windows.Forms.RadioButton FireRb;
        private System.Windows.Forms.RadioButton WoodRb;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label ElementL;
        private System.Windows.Forms.Label PointsL;
        private System.Windows.Forms.Label TimeL;
        private System.Windows.Forms.Label EVal;
        private System.Windows.Forms.Label PVal;
        private System.Windows.Forms.Label TVal;
        private System.Windows.Forms.Timer timer;
    }
}

