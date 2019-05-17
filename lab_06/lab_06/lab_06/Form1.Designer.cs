namespace lab_06
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
            this.checkBoxDelay = new System.Windows.Forms.CheckBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.buttonFill = new System.Windows.Forms.Button();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonColorFill = new System.Windows.Forms.Button();
            this.canvasBase = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxDelay);
            this.groupBox1.Controls.Add(this.textBoxDelay);
            this.groupBox1.Controls.Add(this.labelLocation);
            this.groupBox1.Controls.Add(this.buttonFill);
            this.groupBox1.Controls.Add(this.pictureBoxColor);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonColorFill);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1268, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 761);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // checkBoxDelay
            // 
            this.checkBoxDelay.AutoSize = true;
            this.checkBoxDelay.Location = new System.Drawing.Point(127, 343);
            this.checkBoxDelay.Name = "checkBoxDelay";
            this.checkBoxDelay.Size = new System.Drawing.Size(77, 17);
            this.checkBoxDelay.TabIndex = 10;
            this.checkBoxDelay.Text = "Задержка";
            this.checkBoxDelay.UseVisualStyleBackColor = true;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(0, 308);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(215, 20);
            this.textBoxDelay.TabIndex = 9;
            // 
            // labelLocation
            // 
            this.labelLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLocation.AutoSize = true;
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Location = new System.Drawing.Point(6, 112);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(35, 13);
            this.labelLocation.TabIndex = 3;
            this.labelLocation.Text = "label1";
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(0, 31);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(215, 23);
            this.buttonFill.TabIndex = 2;
            this.buttonFill.Text = "Залить";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Location = new System.Drawing.Point(0, 186);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(215, 25);
            this.pictureBoxColor.TabIndex = 7;
            this.pictureBoxColor.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(0, 69);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(215, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonColorFill
            // 
            this.buttonColorFill.Location = new System.Drawing.Point(0, 144);
            this.buttonColorFill.Name = "buttonColorFill";
            this.buttonColorFill.Size = new System.Drawing.Size(215, 23);
            this.buttonColorFill.TabIndex = 6;
            this.buttonColorFill.Text = "Цвет заливки";
            this.buttonColorFill.UseVisualStyleBackColor = true;
            this.buttonColorFill.Click += new System.EventHandler(this.buttonColorFill_Click);
            // 
            // canvasBase
            // 
            this.canvasBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasBase.BackColor = System.Drawing.Color.White;
            this.canvasBase.Location = new System.Drawing.Point(6, 12);
            this.canvasBase.MaximumSize = new System.Drawing.Size(1237, 737);
            this.canvasBase.Name = "canvasBase";
            this.canvasBase.Size = new System.Drawing.Size(1237, 737);
            this.canvasBase.TabIndex = 9;
            this.canvasBase.TabStop = false;
            this.canvasBase.Click += new System.EventHandler(this.canvasBase_Click);
            this.canvasBase.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasBase_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 761);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canvasBase);
            this.MaximumSize = new System.Drawing.Size(1500, 800);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "Form1";
            this.Text = "Winterpuma lab_06 Затравка";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxDelay;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonColorFill;
        private System.Windows.Forms.PictureBox canvasBase;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

