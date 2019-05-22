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
            this.buttonEnterDot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonDelayNone = new System.Windows.Forms.RadioButton();
            this.radioButtonDelayLine = new System.Windows.Forms.RadioButton();
            this.radioButtonDeleyPix = new System.Windows.Forms.RadioButton();
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
            this.groupBox1.Controls.Add(this.buttonEnterDot);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxY);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonDelayNone);
            this.groupBox1.Controls.Add(this.radioButtonDelayLine);
            this.groupBox1.Controls.Add(this.radioButtonDeleyPix);
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
            // buttonEnterDot
            // 
            this.buttonEnterDot.Location = new System.Drawing.Point(0, 488);
            this.buttonEnterDot.Name = "buttonEnterDot";
            this.buttonEnterDot.Size = new System.Drawing.Size(215, 23);
            this.buttonEnterDot.TabIndex = 21;
            this.buttonEnterDot.Text = "Добавить вершину многоугольника";
            this.buttonEnterDot.UseVisualStyleBackColor = true;
            this.buttonEnterDot.Click += new System.EventHandler(this.buttonEnterDot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "x:";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(109, 444);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(72, 20);
            this.textBoxY.TabIndex = 17;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(31, 444);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(72, 20);
            this.textBoxX.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Задержка:";
            // 
            // radioButtonDelayNone
            // 
            this.radioButtonDelayNone.AutoSize = true;
            this.radioButtonDelayNone.Location = new System.Drawing.Point(6, 326);
            this.radioButtonDelayNone.Name = "radioButtonDelayNone";
            this.radioButtonDelayNone.Size = new System.Drawing.Size(97, 17);
            this.radioButtonDelayNone.TabIndex = 14;
            this.radioButtonDelayNone.TabStop = true;
            this.radioButtonDelayNone.Text = "Без задержки";
            this.radioButtonDelayNone.UseVisualStyleBackColor = true;
            // 
            // radioButtonDelayLine
            // 
            this.radioButtonDelayLine.AutoSize = true;
            this.radioButtonDelayLine.Location = new System.Drawing.Point(6, 303);
            this.radioButtonDelayLine.Name = "radioButtonDelayLine";
            this.radioButtonDelayLine.Size = new System.Drawing.Size(162, 17);
            this.radioButtonDelayLine.TabIndex = 13;
            this.radioButtonDelayLine.TabStop = true;
            this.radioButtonDelayLine.Text = "Изменения каждой строки";
            this.radioButtonDelayLine.UseVisualStyleBackColor = true;
            // 
            // radioButtonDeleyPix
            // 
            this.radioButtonDeleyPix.AutoSize = true;
            this.radioButtonDeleyPix.Location = new System.Drawing.Point(6, 280);
            this.radioButtonDeleyPix.Name = "radioButtonDeleyPix";
            this.radioButtonDeleyPix.Size = new System.Drawing.Size(174, 17);
            this.radioButtonDeleyPix.TabIndex = 12;
            this.radioButtonDeleyPix.TabStop = true;
            this.radioButtonDeleyPix.Text = "Изменения каждого пикселя";
            this.radioButtonDeleyPix.UseVisualStyleBackColor = true;
            // 
            // labelLocation
            // 
            this.labelLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLocation.AutoSize = true;
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Location = new System.Drawing.Point(3, 105);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(35, 13);
            this.labelLocation.TabIndex = 3;
            this.labelLocation.Text = "label1";
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(0, 529);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(215, 23);
            this.buttonFill.TabIndex = 2;
            this.buttonFill.Text = "Затравка";
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
            this.buttonClear.Location = new System.Drawing.Point(0, 54);
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
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonColorFill;
        private System.Windows.Forms.PictureBox canvasBase;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.RadioButton radioButtonDelayNone;
        private System.Windows.Forms.RadioButton radioButtonDelayLine;
        private System.Windows.Forms.RadioButton radioButtonDeleyPix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEnterDot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
    }
}

