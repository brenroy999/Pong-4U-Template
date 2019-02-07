namespace Pong
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.gameUpdateLoop = new System.Windows.Forms.Timer(this.components);
			this.startLabel = new System.Windows.Forms.Label();
			this.scoreLabel = new System.Windows.Forms.Label();
			this.p1Bar = new System.Windows.Forms.ProgressBar();
			this.p2Bar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// gameUpdateLoop
			// 
			this.gameUpdateLoop.Interval = 16;
			this.gameUpdateLoop.Tick += new System.EventHandler(this.gameUpdateLoop_Tick);
			// 
			// startLabel
			// 
			this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startLabel.ForeColor = System.Drawing.Color.White;
			this.startLabel.Location = new System.Drawing.Point(105, 114);
			this.startLabel.Name = "startLabel";
			this.startLabel.Size = new System.Drawing.Size(410, 93);
			this.startLabel.TabIndex = 0;
			this.startLabel.Text = "Press Space To Start";
			this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scoreLabel
			// 
			this.scoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
			this.scoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scoreLabel.ForeColor = System.Drawing.Color.White;
			this.scoreLabel.Location = new System.Drawing.Point(105, 21);
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(410, 93);
			this.scoreLabel.TabIndex = 1;
			this.scoreLabel.Text = "0                    0";
			this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.scoreLabel.Visible = false;
			// 
			// p1Bar
			// 
			this.p1Bar.Location = new System.Drawing.Point(110, 21);
			this.p1Bar.Name = "p1Bar";
			this.p1Bar.Size = new System.Drawing.Size(100, 10);
			this.p1Bar.TabIndex = 2;
			// 
			// p2Bar
			// 
			this.p2Bar.Location = new System.Drawing.Point(406, 21);
			this.p2Bar.Name = "p2Bar";
			this.p2Bar.Size = new System.Drawing.Size(100, 10);
			this.p2Bar.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(616, 450);
			this.Controls.Add(this.p2Bar);
			this.Controls.Add(this.p1Bar);
			this.Controls.Add(this.scoreLabel);
			this.Controls.Add(this.startLabel);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pong";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameUpdateLoop;
        private System.Windows.Forms.Label startLabel;
		private System.Windows.Forms.Label scoreLabel;
		private System.Windows.Forms.ProgressBar p1Bar;
		private System.Windows.Forms.ProgressBar p2Bar;
	}
}

