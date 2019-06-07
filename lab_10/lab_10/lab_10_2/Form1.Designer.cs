namespace lab_10_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxZ = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxYDelta = new System.Windows.Forms.TextBox();
            this.textBoxYEnd = new System.Windows.Forms.TextBox();
            this.textBoxYStart = new System.Windows.Forms.TextBox();
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxXDelta = new System.Windows.Forms.TextBox();
            this.textBoxXEnd = new System.Windows.Forms.TextBox();
            this.textBoxXSt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxZ.SuspendLayout();
            this.groupBoxX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonColor);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBoxZ);
            this.groupBox1.Controls.Add(this.groupBoxX);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.numericUpDownY);
            this.groupBox1.Controls.Add(this.numericUpDownZ);
            this.groupBox1.Controls.Add(this.numericUpDownX);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(996, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(343, 795);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(257, 598);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 22);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 574);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Step:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(180, 542);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 50);
            this.button7.TabIndex = 12;
            this.button7.Text = "Z";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(68, 654);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 11;
            this.button6.Text = "Z";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(180, 598);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 10;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(68, 598);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 9;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(124, 614);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 8;
            this.button3.Text = "Y";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(124, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Y";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBoxZ
            // 
            this.groupBoxZ.Controls.Add(this.label4);
            this.groupBoxZ.Controls.Add(this.label5);
            this.groupBoxZ.Controls.Add(this.label6);
            this.groupBoxZ.Controls.Add(this.textBoxYDelta);
            this.groupBoxZ.Controls.Add(this.textBoxYEnd);
            this.groupBoxZ.Controls.Add(this.textBoxYStart);
            this.groupBoxZ.Location = new System.Drawing.Point(29, 349);
            this.groupBoxZ.Name = "groupBoxZ";
            this.groupBoxZ.Size = new System.Drawing.Size(274, 100);
            this.groupBoxZ.TabIndex = 6;
            this.groupBoxZ.TabStop = false;
            this.groupBoxZ.Text = "Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Шаг";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Конец";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Начало";
            // 
            // textBoxYDelta
            // 
            this.textBoxYDelta.Location = new System.Drawing.Point(188, 62);
            this.textBoxYDelta.Name = "textBoxYDelta";
            this.textBoxYDelta.Size = new System.Drawing.Size(70, 22);
            this.textBoxYDelta.TabIndex = 2;
            this.textBoxYDelta.Text = "0,1";
            // 
            // textBoxYEnd
            // 
            this.textBoxYEnd.Location = new System.Drawing.Point(95, 62);
            this.textBoxYEnd.Name = "textBoxYEnd";
            this.textBoxYEnd.Size = new System.Drawing.Size(70, 22);
            this.textBoxYEnd.TabIndex = 1;
            this.textBoxYEnd.Text = "4";
            // 
            // textBoxYStart
            // 
            this.textBoxYStart.Location = new System.Drawing.Point(6, 62);
            this.textBoxYStart.Name = "textBoxYStart";
            this.textBoxYStart.Size = new System.Drawing.Size(70, 22);
            this.textBoxYStart.TabIndex = 0;
            this.textBoxYStart.Text = "-4";
            // 
            // groupBoxX
            // 
            this.groupBoxX.Controls.Add(this.label3);
            this.groupBoxX.Controls.Add(this.label2);
            this.groupBoxX.Controls.Add(this.label1);
            this.groupBoxX.Controls.Add(this.textBoxXDelta);
            this.groupBoxX.Controls.Add(this.textBoxXEnd);
            this.groupBoxX.Controls.Add(this.textBoxXSt);
            this.groupBoxX.Location = new System.Drawing.Point(29, 231);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Size = new System.Drawing.Size(274, 100);
            this.groupBoxX.TabIndex = 5;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Шаг";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Конец";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Начало";
            // 
            // textBoxXDelta
            // 
            this.textBoxXDelta.Location = new System.Drawing.Point(188, 62);
            this.textBoxXDelta.Name = "textBoxXDelta";
            this.textBoxXDelta.Size = new System.Drawing.Size(70, 22);
            this.textBoxXDelta.TabIndex = 2;
            this.textBoxXDelta.Text = "0,1";
            // 
            // textBoxXEnd
            // 
            this.textBoxXEnd.Location = new System.Drawing.Point(95, 62);
            this.textBoxXEnd.Name = "textBoxXEnd";
            this.textBoxXEnd.Size = new System.Drawing.Size(70, 22);
            this.textBoxXEnd.TabIndex = 1;
            this.textBoxXEnd.Text = "4";
            // 
            // textBoxXSt
            // 
            this.textBoxXSt.Location = new System.Drawing.Point(6, 62);
            this.textBoxXSt.Name = "textBoxXSt";
            this.textBoxXSt.Size = new System.Drawing.Size(70, 22);
            this.textBoxXSt.TabIndex = 0;
            this.textBoxXSt.Text = "-4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 712);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownY.Location = new System.Drawing.Point(117, 509);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(94, 22);
            this.numericUpDownY.TabIndex = 3;
            this.numericUpDownY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
            // 
            // numericUpDownZ
            // 
            this.numericUpDownZ.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownZ.Location = new System.Drawing.Point(217, 509);
            this.numericUpDownZ.Maximum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.numericUpDownZ.Name = "numericUpDownZ";
            this.numericUpDownZ.Size = new System.Drawing.Size(94, 22);
            this.numericUpDownZ.TabIndex = 2;
            this.numericUpDownZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownZ.ValueChanged += new System.EventHandler(this.numericUpDownZ_ValueChanged);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownX.Location = new System.Drawing.Point(11, 509);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            361,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(94, 22);
            this.numericUpDownX.TabIndex = 1;
            this.numericUpDownX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(30, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 177);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кривые";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 38);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(115, 21);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "sqrt(x*x + z*z)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(110, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "sin(x)+cos(z)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.radioButton2.Location = new System.Drawing.Point(6, 92);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(115, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "sin(x) * cos(z)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 119);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "x + z";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(24, 54);
            this.canvas.Margin = new System.Windows.Forms.Padding(4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(900, 700);
            this.canvas.TabIndex = 2;
            this.canvas.TabStop = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 146);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(153, 21);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Sin(x)^2 - Cos(z)^2 ";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.Black;
            this.buttonColor.Location = new System.Drawing.Point(251, 47);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(51, 50);
            this.buttonColor.TabIndex = 16;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 795);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxZ.ResumeLayout(false);
            this.groupBoxZ.PerformLayout();
            this.groupBoxX.ResumeLayout(false);
            this.groupBoxX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownZ;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.TextBox textBoxXDelta;
        private System.Windows.Forms.TextBox textBoxXEnd;
        private System.Windows.Forms.GroupBox groupBoxZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxYDelta;
        private System.Windows.Forms.TextBox textBoxYEnd;
        private System.Windows.Forms.TextBox textBoxYStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxXSt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

