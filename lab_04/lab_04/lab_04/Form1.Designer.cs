namespace lab_04
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonStandard = new System.Windows.Forms.RadioButton();
            this.radioButtonCanonic = new System.Windows.Forms.RadioButton();
            this.radioButtonBresenham = new System.Windows.Forms.RadioButton();
            this.radioButtonParametric = new System.Windows.Forms.RadioButton();
            this.radioButtonMiddle = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDrawOne = new System.Windows.Forms.Button();
            this.textBoxRY1 = new System.Windows.Forms.TextBox();
            this.textBoxRX1 = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDrawMany = new System.Windows.Forms.Button();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxDRX = new System.Windows.Forms.TextBox();
            this.textBoxRY2 = new System.Windows.Forms.TextBox();
            this.textBoxRX2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonChooseColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonEllipse = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(16, 32);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1023, 722);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.radioButtonMiddle);
            this.groupBox1.Controls.Add(this.radioButtonParametric);
            this.groupBox1.Controls.Add(this.radioButtonBresenham);
            this.groupBox1.Controls.Add(this.radioButtonCanonic);
            this.groupBox1.Controls.Add(this.radioButtonStandard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1076, 158);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(323, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Алгоритм";
            // 
            // radioButtonStandard
            // 
            this.radioButtonStandard.AutoSize = true;
            this.radioButtonStandard.Location = new System.Drawing.Point(9, 28);
            this.radioButtonStandard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonStandard.Name = "radioButtonStandard";
            this.radioButtonStandard.Size = new System.Drawing.Size(115, 21);
            this.radioButtonStandard.TabIndex = 0;
            this.radioButtonStandard.Text = "Стандартный";
            this.radioButtonStandard.UseVisualStyleBackColor = true;
            // 
            // radioButtonCanonic
            // 
            this.radioButtonCanonic.AutoSize = true;
            this.radioButtonCanonic.Checked = true;
            this.radioButtonCanonic.Location = new System.Drawing.Point(9, 62);
            this.radioButtonCanonic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonCanonic.Name = "radioButtonCanonic";
            this.radioButtonCanonic.Size = new System.Drawing.Size(195, 21);
            this.radioButtonCanonic.TabIndex = 1;
            this.radioButtonCanonic.TabStop = true;
            this.radioButtonCanonic.Text = "Каноническое уравнение";
            this.radioButtonCanonic.UseVisualStyleBackColor = true;
            // 
            // radioButtonBresenham
            // 
            this.radioButtonBresenham.AutoSize = true;
            this.radioButtonBresenham.Location = new System.Drawing.Point(8, 161);
            this.radioButtonBresenham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonBresenham.Name = "radioButtonBresenham";
            this.radioButtonBresenham.Size = new System.Drawing.Size(97, 21);
            this.radioButtonBresenham.TabIndex = 2;
            this.radioButtonBresenham.Text = "Брезенхем";
            this.radioButtonBresenham.UseVisualStyleBackColor = true;
            // 
            // radioButtonParametric
            // 
            this.radioButtonParametric.AutoSize = true;
            this.radioButtonParametric.Location = new System.Drawing.Point(9, 95);
            this.radioButtonParametric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonParametric.Name = "radioButtonParametric";
            this.radioButtonParametric.Size = new System.Drawing.Size(220, 21);
            this.radioButtonParametric.TabIndex = 3;
            this.radioButtonParametric.Text = "Параметрическое уравнение";
            this.radioButtonParametric.UseVisualStyleBackColor = true;
            // 
            // radioButtonMiddle
            // 
            this.radioButtonMiddle.AutoSize = true;
            this.radioButtonMiddle.Location = new System.Drawing.Point(9, 128);
            this.radioButtonMiddle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonMiddle.Name = "radioButtonMiddle";
            this.radioButtonMiddle.Size = new System.Drawing.Size(125, 21);
            this.radioButtonMiddle.TabIndex = 4;
            this.radioButtonMiddle.Text = "Средняя точка";
            this.radioButtonMiddle.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(1076, 493);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(328, 183);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDrawOne);
            this.tabPage1.Controls.Add(this.textBoxRY1);
            this.tabPage1.Controls.Add(this.textBoxRX1);
            this.tabPage1.Controls.Add(this.textBoxY);
            this.tabPage1.Controls.Add(this.textBoxX);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(320, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Примитив";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDrawOne
            // 
            this.buttonDrawOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrawOne.Location = new System.Drawing.Point(20, 97);
            this.buttonDrawOne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDrawOne.Name = "buttonDrawOne";
            this.buttonDrawOne.Size = new System.Drawing.Size(277, 32);
            this.buttonDrawOne.TabIndex = 8;
            this.buttonDrawOne.Text = "Нарисовать";
            this.buttonDrawOne.UseVisualStyleBackColor = true;
            this.buttonDrawOne.Click += new System.EventHandler(this.buttonDrawOne_Click);
            // 
            // textBoxRY1
            // 
            this.textBoxRY1.Location = new System.Drawing.Point(204, 54);
            this.textBoxRY1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRY1.Name = "textBoxRY1";
            this.textBoxRY1.Size = new System.Drawing.Size(81, 22);
            this.textBoxRY1.TabIndex = 7;
            this.textBoxRY1.Text = "50";
            // 
            // textBoxRX1
            // 
            this.textBoxRX1.Location = new System.Drawing.Point(65, 52);
            this.textBoxRX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRX1.Name = "textBoxRX1";
            this.textBoxRX1.Size = new System.Drawing.Size(81, 22);
            this.textBoxRX1.TabIndex = 6;
            this.textBoxRX1.Text = "100";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(204, 11);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(81, 22);
            this.textBoxY.TabIndex = 5;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(65, 9);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(81, 22);
            this.textBoxX.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(167, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ry";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(21, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Rx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(159, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDrawMany);
            this.tabPage2.Controls.Add(this.textBoxN);
            this.tabPage2.Controls.Add(this.textBoxDRX);
            this.tabPage2.Controls.Add(this.textBoxRY2);
            this.tabPage2.Controls.Add(this.textBoxRX2);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(320, 154);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Спектр";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDrawMany
            // 
            this.buttonDrawMany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrawMany.Location = new System.Drawing.Point(17, 98);
            this.buttonDrawMany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDrawMany.Name = "buttonDrawMany";
            this.buttonDrawMany.Size = new System.Drawing.Size(276, 31);
            this.buttonDrawMany.TabIndex = 17;
            this.buttonDrawMany.Text = "Нарисовать";
            this.buttonDrawMany.UseVisualStyleBackColor = true;
            this.buttonDrawMany.Click += new System.EventHandler(this.buttonDrawMany_Click);
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(204, 54);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(81, 23);
            this.textBoxN.TabIndex = 16;
            this.textBoxN.Text = "5";
            // 
            // textBoxDRX
            // 
            this.textBoxDRX.Location = new System.Drawing.Point(65, 52);
            this.textBoxDRX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDRX.Name = "textBoxDRX";
            this.textBoxDRX.Size = new System.Drawing.Size(81, 23);
            this.textBoxDRX.TabIndex = 15;
            this.textBoxDRX.Text = "50";
            // 
            // textBoxRY2
            // 
            this.textBoxRY2.Location = new System.Drawing.Point(204, 11);
            this.textBoxRY2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRY2.Name = "textBoxRY2";
            this.textBoxRY2.Size = new System.Drawing.Size(81, 23);
            this.textBoxRY2.TabIndex = 14;
            this.textBoxRY2.Text = "50";
            // 
            // textBoxRX2
            // 
            this.textBoxRX2.Location = new System.Drawing.Point(65, 9);
            this.textBoxRX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRX2.Name = "textBoxRX2";
            this.textBoxRX2.Size = new System.Drawing.Size(81, 23);
            this.textBoxRX2.TabIndex = 13;
            this.textBoxRX2.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(167, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "N";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 52);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "dRx";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(159, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Ry";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(21, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "Rx";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.buttonChooseColor);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel3.Location = new System.Drawing.Point(1079, 380);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 105);
            this.panel3.TabIndex = 17;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(1097, 708);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(276, 27);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(21, 57);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(178, 21);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Рисовать цветом фона";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonChooseColor
            // 
            this.buttonChooseColor.BackColor = System.Drawing.Color.Black;
            this.buttonChooseColor.Location = new System.Drawing.Point(156, 21);
            this.buttonChooseColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(100, 28);
            this.buttonChooseColor.TabIndex = 10;
            this.buttonChooseColor.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(17, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Цвет линии";
            // 
            // radioButtonCircle
            // 
            this.radioButtonCircle.AutoSize = true;
            this.radioButtonCircle.Checked = true;
            this.radioButtonCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonCircle.Location = new System.Drawing.Point(17, 33);
            this.radioButtonCircle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonCircle.Name = "radioButtonCircle";
            this.radioButtonCircle.Size = new System.Drawing.Size(105, 21);
            this.radioButtonCircle.TabIndex = 18;
            this.radioButtonCircle.TabStop = true;
            this.radioButtonCircle.Text = "Окружность";
            this.radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // radioButtonEllipse
            // 
            this.radioButtonEllipse.AutoSize = true;
            this.radioButtonEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEllipse.Location = new System.Drawing.Point(17, 62);
            this.radioButtonEllipse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonEllipse.Name = "radioButtonEllipse";
            this.radioButtonEllipse.Size = new System.Drawing.Size(74, 21);
            this.radioButtonEllipse.TabIndex = 19;
            this.radioButtonEllipse.Text = "Эллипс";
            this.radioButtonEllipse.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.radioButtonCircle);
            this.groupBox2.Controls.Add(this.radioButtonEllipse);
            this.groupBox2.Location = new System.Drawing.Point(1076, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Примитив";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 805);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.canvas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Лабораторная №4 Окружности, эллипсы";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonMiddle;
        private System.Windows.Forms.RadioButton radioButtonParametric;
        private System.Windows.Forms.RadioButton radioButtonBresenham;
        private System.Windows.Forms.RadioButton radioButtonCanonic;
        private System.Windows.Forms.RadioButton radioButtonStandard;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonDrawOne;
        private System.Windows.Forms.TextBox textBoxRY1;
        private System.Windows.Forms.TextBox textBoxRX1;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDrawMany;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox textBoxDRX;
        private System.Windows.Forms.TextBox textBoxRY2;
        private System.Windows.Forms.TextBox textBoxRX2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonChooseColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonCircle;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

