namespace YTDLPGUI
{
    partial class fmBinary
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            progressBar3 = new ProgressBar();
            progressBar2 = new ProgressBar();
            progressBar1 = new ProgressBar();
            panelTitle = new Panel();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 36);
            label1.Margin = new Padding(3, 25, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "yt-dlp:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 81);
            label2.Margin = new Padding(3, 25, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "FFmpeg:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(79, 126);
            label3.Margin = new Padding(3, 25, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 2;
            label3.Text = "Deno:";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 185);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(progressBar3);
            panel2.Controls.Add(progressBar2);
            panel2.Controls.Add(progressBar1);
            panel2.Location = new Point(148, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 185);
            panel2.TabIndex = 7;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(3, 126);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(150, 23);
            progressBar3.TabIndex = 2;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(3, 81);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(150, 23);
            progressBar2.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(3, 36);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(150, 23);
            progressBar1.TabIndex = 0;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.Firebrick;
            panelTitle.Controls.Add(label4);
            panelTitle.Location = new Point(0, 0);
            panelTitle.Margin = new Padding(0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(380, 60);
            panelTitle.TabIndex = 8;
            panelTitle.MouseDown += panelTitle_MouseDown;
            panelTitle.MouseMove += panelTitle_MouseMove;
            panelTitle.MouseUp += panelTitle_MouseUp;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 19);
            label4.Margin = new Padding(3, 0, 3, 15);
            label4.Name = "label4";
            label4.Size = new Size(96, 26);
            label4.TabIndex = 0;
            label4.Text = "下載檔案";
            // 
            // fmBinary
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(380, 260);
            Controls.Add(panelTitle);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmBinary";
            Opacity = 0.95D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Minimized;
            Load += fmBinary_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private ProgressBar progressBar1;
        private ProgressBar progressBar3;
        private ProgressBar progressBar2;
        private Panel panelTitle;
        private Label label4;
    }
}