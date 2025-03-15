namespace WinFormsApp1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(40, 34);
            button1.Name = "button1";
            button1.Size = new Size(384, 29);
            button1.TabIndex = 0;
            button1.Text = "Vai dar Ruim (Exception Sem Tratamento)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(40, 81);
            button2.Name = "button2";
            button2.Size = new Size(384, 29);
            button2.TabIndex = 1;
            button2.Text = "Salvar Dados? (Exception Com Tratamento)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(120, 142);
            button3.Name = "button3";
            button3.Size = new Size(213, 29);
            button3.TabIndex = 2;
            button3.Text = "Mudar Temperatura";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(40, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(74, 27);
            textBox1.TabIndex = 3;
            textBox1.Text = "15";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 183);
            label1.Name = "label1";
            label1.Size = new Size(189, 20);
            label1.TabIndex = 4;
            label1.Text = "A temperatura atual é 15ºC";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Label label1;
    }
}
