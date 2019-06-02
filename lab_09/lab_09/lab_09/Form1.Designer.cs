namespace lab_09
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
            this.radioButtonLines = new System.Windows.Forms.RadioButton();
            this.radioButtonCutter = new System.Windows.Forms.RadioButton();
            this.labelLocation = new System.Windows.Forms.Label();
            this.buttonCut = new System.Windows.Forms.Button();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonColorCut = new System.Windows.Forms.Button();
            this.canvasBase = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonLines);
            this.groupBox1.Controls.Add(this.radioButtonCutter);
            this.groupBox1.Controls.Add(this.labelLocation);
            this.groupBox1.Controls.Add(this.buttonCut);
            this.groupBox1.Controls.Add(this.pictureBoxColor);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonColorCut);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1244, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 756);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // radioButtonLines
            // 
            this.radioButtonLines.AutoSize = true;
            this.radioButtonLines.Location = new System.Drawing.Point(9, 197);
            this.radioButtonLines.Name = "radioButtonLines";
            this.radioButtonLines.Size = new System.Drawing.Size(83, 17);
            this.radioButtonLines.TabIndex = 9;
            this.radioButtonLines.TabStop = true;
            this.radioButtonLines.Text = "Ввод линий";
            this.radioButtonLines.UseVisualStyleBackColor = true;
            // 
            // radioButtonCutter
            // 
            this.radioButtonCutter.AutoSize = true;
            this.radioButtonCutter.Location = new System.Drawing.Point(9, 174);
            this.radioButtonCutter.Name = "radioButtonCutter";
            this.radioButtonCutter.Size = new System.Drawing.Size(111, 17);
            this.radioButtonCutter.TabIndex = 8;
            this.radioButtonCutter.TabStop = true;
            this.radioButtonCutter.Text = "Ввод отсекателя";
            this.radioButtonCutter.UseVisualStyleBackColor = true;
            // 
            // labelLocation
            // 
            this.labelLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLocation.AutoSize = true;
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelLocation.Location = new System.Drawing.Point(6, 119);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(46, 17);
            this.labelLocation.TabIndex = 3;
            this.labelLocation.Text = "label1";
            // 
            // buttonCut
            // 
            this.buttonCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCut.Location = new System.Drawing.Point(1, 248);
            this.buttonCut.Name = "buttonCut";
            this.buttonCut.Size = new System.Drawing.Size(215, 23);
            this.buttonCut.TabIndex = 2;
            this.buttonCut.Text = "Отсечь";
            this.buttonCut.UseVisualStyleBackColor = true;
            this.buttonCut.Click += new System.EventHandler(this.buttonCut_Click);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Location = new System.Drawing.Point(1, 73);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(215, 25);
            this.pictureBoxColor.TabIndex = 7;
            this.pictureBoxColor.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonClear.Location = new System.Drawing.Point(1, 289);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(215, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonColorCut
            // 
            this.buttonColorCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonColorCut.Location = new System.Drawing.Point(0, 44);
            this.buttonColorCut.Name = "buttonColorCut";
            this.buttonColorCut.Size = new System.Drawing.Size(215, 23);
            this.buttonColorCut.TabIndex = 6;
            this.buttonColorCut.Text = "Цвет выделения";
            this.buttonColorCut.UseVisualStyleBackColor = true;
            this.buttonColorCut.Click += new System.EventHandler(this.buttonColorFill_Click);
            // 
            // canvasBase
            // 
            this.canvasBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasBase.BackColor = System.Drawing.Color.White;
            this.canvasBase.Location = new System.Drawing.Point(1, 12);
            this.canvasBase.MaximumSize = new System.Drawing.Size(1237, 737);
            this.canvasBase.Name = "canvasBase";
            this.canvasBase.Size = new System.Drawing.Size(1237, 732);
            this.canvasBase.TabIndex = 15;
            this.canvasBase.TabStop = false;
            this.canvasBase.Click += new System.EventHandler(this.canvasBase_Click);
            this.canvasBase.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasBase_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 756);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canvasBase);
            this.Name = "Form1";
            this.Text = "lab_09 Алгоритм отсечения Сазерленда-Ходжмана";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonLines;
        private System.Windows.Forms.RadioButton radioButtonCutter;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button buttonCut;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonColorCut;
        private System.Windows.Forms.PictureBox canvasBase;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

