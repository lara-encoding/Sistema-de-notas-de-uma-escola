namespace WinFormsApp1
{
    partial class Form2
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
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(46, 101);
            button1.Name = "button1";
            button1.Size = new Size(144, 82);
            button1.TabIndex = 0;
            button1.Text = "1ºG";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(319, 23);
            label1.Name = "label1";
            label1.Size = new Size(152, 54);
            label1.TabIndex = 1;
            label1.Text = "Turmas";
            // 
            // button2
            // 
            button2.Location = new Point(319, 101);
            button2.Name = "button2";
            button2.Size = new Size(144, 82);
            button2.TabIndex = 2;
            button2.Text = "2ºG";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(46, 225);
            button3.Name = "button3";
            button3.Size = new Size(144, 82);
            button3.TabIndex = 3;
            button3.Text = "1ºA";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(319, 225);
            button4.Name = "button4";
            button4.Size = new Size(144, 82);
            button4.TabIndex = 4;
            button4.Text = "2ºA";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(598, 101);
            button5.Name = "button5";
            button5.Size = new Size(144, 82);
            button5.TabIndex = 5;
            button5.Text = "3ºG";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(598, 225);
            button6.Name = "button6";
            button6.Size = new Size(144, 82);
            button6.TabIndex = 6;
            button6.Text = "3ºA";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(46, 346);
            button7.Name = "button7";
            button7.Size = new Size(144, 82);
            button7.TabIndex = 7;
            button7.Text = "1ºC";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(319, 346);
            button8.Name = "button8";
            button8.Size = new Size(144, 82);
            button8.TabIndex = 8;
            button8.Text = "2ºC";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(598, 346);
            button9.Name = "button9";
            button9.Size = new Size(144, 82);
            button9.TabIndex = 9;
            button9.Text = "3ºC";
            button9.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}