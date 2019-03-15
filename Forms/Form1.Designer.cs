namespace Forms
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerBG = new System.Windows.Forms.Timer(this.components);
            this.overlabel = new System.Windows.Forms.Label();
            this.playagain = new System.Windows.Forms.Label();
            this.pressspace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerBG
            // 
            this.timerBG.Enabled = true;
            this.timerBG.Interval = 15;
            this.timerBG.Tick += new System.EventHandler(this.TimerBG_Tick);
            // 
            // overlabel
            // 
            this.overlabel.AutoSize = true;
            this.overlabel.BackColor = System.Drawing.Color.Transparent;
            this.overlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overlabel.Location = new System.Drawing.Point(48, 175);
            this.overlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.overlabel.Name = "overlabel";
            this.overlabel.Size = new System.Drawing.Size(339, 69);
            this.overlabel.TabIndex = 0;
            this.overlabel.Text = "Game Over";
            // 
            // playagain
            // 
            this.playagain.AutoSize = true;
            this.playagain.BackColor = System.Drawing.Color.Transparent;
            this.playagain.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playagain.Location = new System.Drawing.Point(9, 227);
            this.playagain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playagain.Name = "playagain";
            this.playagain.Size = new System.Drawing.Size(416, 91);
            this.playagain.TabIndex = 1;
            this.playagain.Text = "Play Again";
            this.playagain.Click += new System.EventHandler(this.playagain_Click);
            // 
            // pressspace
            // 
            this.pressspace.AutoSize = true;
            this.pressspace.BackColor = System.Drawing.Color.Transparent;
            this.pressspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressspace.Location = new System.Drawing.Point(103, 313);
            this.pressspace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pressspace.Name = "pressspace";
            this.pressspace.Size = new System.Drawing.Size(245, 42);
            this.pressspace.TabIndex = 2;
            this.pressspace.Text = "(press space)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 688);
            this.Controls.Add(this.pressspace);
            this.Controls.Add(this.playagain);
            this.Controls.Add(this.overlabel);
            this.MaximumSize = new System.Drawing.Size(479, 735);
            this.MinimumSize = new System.Drawing.Size(479, 735);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerBG;
        private System.Windows.Forms.Label overlabel;
        private System.Windows.Forms.Label playagain;
        private System.Windows.Forms.Label pressspace;
    }
}

