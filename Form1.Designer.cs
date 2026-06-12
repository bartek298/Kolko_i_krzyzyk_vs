namespace Kolko_i_krzyzyk
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            NumericSize = new NumericUpDown();
            label2 = new Label();
            NumericWinLength = new NumericUpDown();
            btnStart = new Button();
            GamePanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)NumericSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericWinLength).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "Rozmiar planszy(N)";
            label1.Click += label1_Click;
            // 
            // NumericSize
            // 
            NumericSize.Location = new Point(12, 44);
            NumericSize.Name = "NumericSize";
            NumericSize.Size = new Size(150, 27);
            NumericSize.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 21);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 2;
            label2.Text = "ZnakiDoWygranej";
            // 
            // NumericWinLength
            // 
            NumericWinLength.Location = new Point(183, 44);
            NumericWinLength.Name = "NumericWinLength";
            NumericWinLength.Size = new Size(150, 27);
            NumericWinLength.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.Info;
            btnStart.Font = new Font("Segoe UI Historic", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnStart.ForeColor = Color.Crimson;
            btnStart.Location = new Point(381, 31);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(138, 40);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start/Reset";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // GamePanel
            // 
            GamePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GamePanel.Location = new Point(12, 77);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(808, 413);
            GamePanel.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 495);
            Controls.Add(GamePanel);
            Controls.Add(btnStart);
            Controls.Add(NumericWinLength);
            Controls.Add(label2);
            Controls.Add(NumericSize);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)NumericSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericWinLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown NumericSize;
        private Label label2;
        private NumericUpDown NumericWinLength;
        private Button btnStart;
        private Panel GamePanel;
    }
}