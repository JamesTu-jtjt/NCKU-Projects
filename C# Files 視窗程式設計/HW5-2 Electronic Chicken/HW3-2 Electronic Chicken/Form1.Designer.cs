namespace HW3_2_Electronic_Chicken
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
            this.log = new System.Windows.Forms.RichTextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameBtn = new System.Windows.Forms.Button();
            this.feedBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.cleanBtn = new System.Windows.Forms.Button();
            this.docBtn = new System.Windows.Forms.Button();
            this.endDayBtn = new System.Windows.Forms.Button();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.moneyVal = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.healthLabel = new System.Windows.Forms.Label();
            this.healthVal = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.weightVal = new System.Windows.Forms.Label();
            this.satisfactionLabel = new System.Windows.Forms.Label();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventVal = new System.Windows.Forms.Label();
            this.satisVal = new System.Windows.Forms.Label();
            this.moodLabel = new System.Windows.Forms.Label();
            this.moodVal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.log.Font = new System.Drawing.Font("標楷體", 12F);
            this.log.Location = new System.Drawing.Point(12, 34);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.log.Size = new System.Drawing.Size(371, 343);
            this.log.TabIndex = 0;
            this.log.Text = "";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("標楷體", 12F);
            this.nameBox.Location = new System.Drawing.Point(12, 401);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(270, 27);
            this.nameBox.TabIndex = 2;
            // 
            // nameBtn
            // 
            this.nameBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.nameBtn.Location = new System.Drawing.Point(279, 401);
            this.nameBtn.Name = "nameBtn";
            this.nameBtn.Size = new System.Drawing.Size(104, 27);
            this.nameBtn.TabIndex = 3;
            this.nameBtn.Text = "輸入名字";
            this.nameBtn.UseVisualStyleBackColor = true;
            this.nameBtn.Click += new System.EventHandler(this.nameBtn_Click);
            // 
            // feedBtn
            // 
            this.feedBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.feedBtn.Location = new System.Drawing.Point(389, 354);
            this.feedBtn.Name = "feedBtn";
            this.feedBtn.Size = new System.Drawing.Size(96, 23);
            this.feedBtn.TabIndex = 4;
            this.feedBtn.Text = "餵食";
            this.feedBtn.UseVisualStyleBackColor = true;
            this.feedBtn.Click += new System.EventHandler(this.feedBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.playBtn.Location = new System.Drawing.Point(491, 354);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(94, 23);
            this.playBtn.TabIndex = 5;
            this.playBtn.Text = "玩耍";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // cleanBtn
            // 
            this.cleanBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.cleanBtn.Location = new System.Drawing.Point(591, 354);
            this.cleanBtn.Name = "cleanBtn";
            this.cleanBtn.Size = new System.Drawing.Size(96, 23);
            this.cleanBtn.TabIndex = 6;
            this.cleanBtn.Text = "打掃";
            this.cleanBtn.UseVisualStyleBackColor = true;
            this.cleanBtn.Click += new System.EventHandler(this.cleanBtn_Click);
            // 
            // docBtn
            // 
            this.docBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.docBtn.Location = new System.Drawing.Point(693, 354);
            this.docBtn.Name = "docBtn";
            this.docBtn.Size = new System.Drawing.Size(95, 23);
            this.docBtn.TabIndex = 7;
            this.docBtn.Text = "看醫生";
            this.docBtn.UseVisualStyleBackColor = true;
            this.docBtn.Click += new System.EventHandler(this.docBtn_Click);
            // 
            // endDayBtn
            // 
            this.endDayBtn.Font = new System.Drawing.Font("標楷體", 12F);
            this.endDayBtn.Location = new System.Drawing.Point(591, 399);
            this.endDayBtn.Name = "endDayBtn";
            this.endDayBtn.Size = new System.Drawing.Size(197, 23);
            this.endDayBtn.TabIndex = 8;
            this.endDayBtn.Text = "結束這天";
            this.endDayBtn.UseVisualStyleBackColor = true;
            this.endDayBtn.Click += new System.EventHandler(this.endDayBtn_Click);
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold);
            this.moneyLabel.Location = new System.Drawing.Point(408, 37);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(42, 16);
            this.moneyLabel.TabIndex = 9;
            this.moneyLabel.Text = "金錢";
            // 
            // moneyVal
            // 
            this.moneyVal.AutoSize = true;
            this.moneyVal.Font = new System.Drawing.Font("標楷體", 12F);
            this.moneyVal.Location = new System.Drawing.Point(431, 71);
            this.moneyVal.Name = "moneyVal";
            this.moneyVal.Size = new System.Drawing.Size(40, 16);
            this.moneyVal.TabIndex = 10;
            this.moneyVal.Text = "0 元";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold);
            this.statusLabel.Location = new System.Drawing.Point(408, 117);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 16);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "狀態";
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.healthLabel.Location = new System.Drawing.Point(431, 158);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(56, 16);
            this.healthLabel.TabIndex = 12;
            this.healthLabel.Text = "健康: ";
            // 
            // healthVal
            // 
            this.healthVal.AutoSize = true;
            this.healthVal.Font = new System.Drawing.Font("標楷體", 12F);
            this.healthVal.Location = new System.Drawing.Point(527, 158);
            this.healthVal.Name = "healthVal";
            this.healthVal.Size = new System.Drawing.Size(24, 16);
            this.healthVal.TabIndex = 13;
            this.healthVal.Text = "0%";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.weightLabel.Location = new System.Drawing.Point(431, 186);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(56, 16);
            this.weightLabel.TabIndex = 14;
            this.weightLabel.Text = "體重: ";
            // 
            // weightVal
            // 
            this.weightVal.AutoSize = true;
            this.weightVal.Font = new System.Drawing.Font("標楷體", 12F);
            this.weightVal.Location = new System.Drawing.Point(527, 186);
            this.weightVal.Name = "weightVal";
            this.weightVal.Size = new System.Drawing.Size(24, 16);
            this.weightVal.TabIndex = 15;
            this.weightVal.Text = "0g";
            // 
            // satisfactionLabel
            // 
            this.satisfactionLabel.AutoSize = true;
            this.satisfactionLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.satisfactionLabel.Location = new System.Drawing.Point(431, 219);
            this.satisfactionLabel.Name = "satisfactionLabel";
            this.satisfactionLabel.Size = new System.Drawing.Size(72, 16);
            this.satisfactionLabel.TabIndex = 16;
            this.satisfactionLabel.Text = "飽足感: ";
            // 
            // eventLabel
            // 
            this.eventLabel.AutoSize = true;
            this.eventLabel.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold);
            this.eventLabel.Location = new System.Drawing.Point(408, 279);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(42, 16);
            this.eventLabel.TabIndex = 17;
            this.eventLabel.Text = "事件";
            // 
            // eventVal
            // 
            this.eventVal.AutoSize = true;
            this.eventVal.Font = new System.Drawing.Font("標楷體", 12F);
            this.eventVal.Location = new System.Drawing.Point(446, 310);
            this.eventVal.Name = "eventVal";
            this.eventVal.Size = new System.Drawing.Size(104, 16);
            this.eventVal.TabIndex = 18;
            this.eventVal.Text = "請幫寵物取名";
            // 
            // satisVal
            // 
            this.satisVal.AutoSize = true;
            this.satisVal.Font = new System.Drawing.Font("標楷體", 12F);
            this.satisVal.Location = new System.Drawing.Point(527, 219);
            this.satisVal.Name = "satisVal";
            this.satisVal.Size = new System.Drawing.Size(24, 16);
            this.satisVal.TabIndex = 19;
            this.satisVal.Text = "0%";
            // 
            // moodLabel
            // 
            this.moodLabel.AutoSize = true;
            this.moodLabel.Font = new System.Drawing.Font("標楷體", 12F);
            this.moodLabel.Location = new System.Drawing.Point(431, 247);
            this.moodLabel.Name = "moodLabel";
            this.moodLabel.Size = new System.Drawing.Size(56, 16);
            this.moodLabel.TabIndex = 20;
            this.moodLabel.Text = "心情: ";
            // 
            // moodVal
            // 
            this.moodVal.AutoSize = true;
            this.moodVal.Font = new System.Drawing.Font("標楷體", 12F);
            this.moodVal.Location = new System.Drawing.Point(527, 247);
            this.moodVal.Name = "moodVal";
            this.moodVal.Size = new System.Drawing.Size(24, 16);
            this.moodVal.TabIndex = 21;
            this.moodVal.Text = "0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.moodVal);
            this.Controls.Add(this.moodLabel);
            this.Controls.Add(this.satisVal);
            this.Controls.Add(this.eventVal);
            this.Controls.Add(this.eventLabel);
            this.Controls.Add(this.satisfactionLabel);
            this.Controls.Add(this.weightVal);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.healthVal);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.moneyVal);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.endDayBtn);
            this.Controls.Add(this.docBtn);
            this.Controls.Add(this.cleanBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.feedBtn);
            this.Controls.Add(this.nameBtn);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.log);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button nameBtn;
        private System.Windows.Forms.Button feedBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button cleanBtn;
        private System.Windows.Forms.Button docBtn;
        private System.Windows.Forms.Button endDayBtn;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label moneyVal;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label healthVal;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label weightVal;
        private System.Windows.Forms.Label satisfactionLabel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.Label eventVal;
        private System.Windows.Forms.Label satisVal;
        private System.Windows.Forms.Label moodLabel;
        private System.Windows.Forms.Label moodVal;
    }
}

