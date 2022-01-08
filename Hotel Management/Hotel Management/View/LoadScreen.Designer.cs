
namespace Hotel_Management.View
{
    partial class LoadScreen
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressCirc = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ProgressCirc);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 376);
            this.panel1.TabIndex = 0;
            // 
            // ProgressCirc
            // 
            this.ProgressCirc.Animated = false;
            this.ProgressCirc.AnimationInterval = 1;
            this.ProgressCirc.AnimationSpeed = 1;
            this.ProgressCirc.BackColor = System.Drawing.Color.Transparent;
            this.ProgressCirc.CircleMargin = 10;
            this.ProgressCirc.Font = new System.Drawing.Font("Maiandra GD", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressCirc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProgressCirc.IsPercentage = false;
            this.ProgressCirc.LineProgressThickness = 10;
            this.ProgressCirc.LineThickness = 10;
            this.ProgressCirc.Location = new System.Drawing.Point(127, 77);
            this.ProgressCirc.Name = "ProgressCirc";
            this.ProgressCirc.ProgressAnimationSpeed = 200;
            this.ProgressCirc.ProgressBackColor = System.Drawing.SystemColors.Control;
            this.ProgressCirc.ProgressColor = System.Drawing.Color.Blue;
            this.ProgressCirc.ProgressColor2 = System.Drawing.Color.Cyan;
            this.ProgressCirc.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.ProgressCirc.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Gradient;
            this.ProgressCirc.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Flat;
            this.ProgressCirc.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ProgressCirc.Size = new System.Drawing.Size(223, 223);
            this.ProgressCirc.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.ProgressCirc.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.ProgressCirc.SubScriptText = "";
            this.ProgressCirc.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.ProgressCirc.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.ProgressCirc.SuperScriptText = "";
            this.ProgressCirc.TabIndex = 16;
            this.ProgressCirc.Text = "0";
            this.ProgressCirc.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ProgressCirc.ValueByTransition = 0;
            this.ProgressCirc.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.panel1;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(91, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(294, 29);
            this.label8.TabIndex = 17;
            this.label8.Text = "Hotel Management System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(140, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Developped By Prog_Pedrao";
            // 
            // LoadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadsScreen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.UI.WinForms.BunifuCircleProgress ProgressCirc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
    }
}