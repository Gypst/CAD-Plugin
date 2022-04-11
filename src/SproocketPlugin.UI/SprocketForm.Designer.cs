namespace SprocketPlugin.UI
{
    partial class SprocketForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SprocketForm));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BuildBtn = new System.Windows.Forms.Button();
            this.Schema = new System.Windows.Forms.PictureBox();
            this.ToothCountLabel = new System.Windows.Forms.Label();
            this.ToothCountTextBox = new System.Windows.Forms.TextBox();
            this.MinMaxToothCountLabel = new System.Windows.Forms.Label();
            this.ToothHeightLabel = new System.Windows.Forms.Label();
            this.MinMaxToothHeightLabel = new System.Windows.Forms.Label();
            this.ThicknessLabel = new System.Windows.Forms.Label();
            this.ThicknessTextBox = new System.Windows.Forms.TextBox();
            this.MinMaxToothTgicknessLabel = new System.Windows.Forms.Label();
            this.OuterDiameterLabel = new System.Windows.Forms.Label();
            this.InnerDiameterLabel = new System.Windows.Forms.Label();
            this.InnerDiameterTextBox = new System.Windows.Forms.TextBox();
            this.OuterDiameterTextBox = new System.Windows.Forms.TextBox();
            this.MinMaxOuterDiameterLabel = new System.Windows.Forms.Label();
            this.MinMaxInnerDiameter = new System.Windows.Forms.Label();
            this.ToothHeightTextBox = new System.Windows.Forms.TextBox();
            this.ToothTopRadiusRatioLabel = new System.Windows.Forms.Label();
            this.ToothTopRadiusRatioTextBox = new System.Windows.Forms.TextBox();
            this.MinMaxToothTopRadiusRatioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Schema)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // BuildBtn
            // 
            this.BuildBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BuildBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuildBtn.Location = new System.Drawing.Point(78, 285);
            this.BuildBtn.Name = "BuildBtn";
            this.BuildBtn.Size = new System.Drawing.Size(95, 23);
            this.BuildBtn.TabIndex = 7;
            this.BuildBtn.Text = "Построить";
            this.BuildBtn.UseVisualStyleBackColor = true;
            this.BuildBtn.Click += new System.EventHandler(this.BuildBtn_Click);
            // 
            // Schema
            // 
            this.Schema.Image = ((System.Drawing.Image)(resources.GetObject("Schema.Image")));
            this.Schema.Location = new System.Drawing.Point(250, 12);
            this.Schema.Name = "Schema";
            this.Schema.Size = new System.Drawing.Size(370, 257);
            this.Schema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Schema.TabIndex = 75;
            this.Schema.TabStop = false;
            // 
            // ToothCountLabel
            // 
            this.ToothCountLabel.AutoSize = true;
            this.ToothCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToothCountLabel.Location = new System.Drawing.Point(12, 185);
            this.ToothCountLabel.Name = "ToothCountLabel";
            this.ToothCountLabel.Size = new System.Drawing.Size(87, 15);
            this.ToothCountLabel.TabIndex = 79;
            this.ToothCountLabel.Text = "Число зубьев:";
            // 
            // ToothCountTextBox
            // 
            this.ToothCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToothCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToothCountTextBox.Location = new System.Drawing.Point(17, 202);
            this.ToothCountTextBox.Name = "ToothCountTextBox";
            this.ToothCountTextBox.Size = new System.Drawing.Size(56, 21);
            this.ToothCountTextBox.TabIndex = 5;
            this.ToothCountTextBox.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // MinMaxToothCountLabel
            // 
            this.MinMaxToothCountLabel.AutoSize = true;
            this.MinMaxToothCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinMaxToothCountLabel.Location = new System.Drawing.Point(92, 204);
            this.MinMaxToothCountLabel.Name = "MinMaxToothCountLabel";
            this.MinMaxToothCountLabel.Size = new System.Drawing.Size(65, 15);
            this.MinMaxToothCountLabel.TabIndex = 81;
            this.MinMaxToothCountLabel.Text = "(5 - 30 шт)";
            // 
            // ToothHeightLabel
            // 
            this.ToothHeightLabel.AutoSize = true;
            this.ToothHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToothHeightLabel.Location = new System.Drawing.Point(12, 141);
            this.ToothHeightLabel.Name = "ToothHeightLabel";
            this.ToothHeightLabel.Size = new System.Drawing.Size(88, 15);
            this.ToothHeightLabel.TabIndex = 76;
            this.ToothHeightLabel.Text = "Высота зуба t:";
            // 
            // MinMaxToothHeightLabel
            // 
            this.MinMaxToothHeightLabel.AutoSize = true;
            this.MinMaxToothHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinMaxToothHeightLabel.Location = new System.Drawing.Point(92, 162);
            this.MinMaxToothHeightLabel.Name = "MinMaxToothHeightLabel";
            this.MinMaxToothHeightLabel.Size = new System.Drawing.Size(145, 15);
            this.MinMaxToothHeightLabel.TabIndex = 78;
            this.MinMaxToothHeightLabel.Text = "(от 1 до 20% диаметра)";
            // 
            // ThicknessLabel
            // 
            this.ThicknessLabel.AutoSize = true;
            this.ThicknessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThicknessLabel.Location = new System.Drawing.Point(14, 99);
            this.ThicknessLabel.Name = "ThicknessLabel";
            this.ThicknessLabel.Size = new System.Drawing.Size(131, 15);
            this.ThicknessLabel.TabIndex = 88;
            this.ThicknessLabel.Text = "Толщина пластины T:";
            // 
            // ThicknessTextBox
            // 
            this.ThicknessTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThicknessTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThicknessTextBox.Location = new System.Drawing.Point(17, 117);
            this.ThicknessTextBox.Name = "ThicknessTextBox";
            this.ThicknessTextBox.Size = new System.Drawing.Size(56, 21);
            this.ThicknessTextBox.TabIndex = 3;
            this.ThicknessTextBox.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // MinMaxToothTgicknessLabel
            // 
            this.MinMaxToothTgicknessLabel.AutoSize = true;
            this.MinMaxToothTgicknessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinMaxToothTgicknessLabel.Location = new System.Drawing.Point(92, 120);
            this.MinMaxToothTgicknessLabel.Name = "MinMaxToothTgicknessLabel";
            this.MinMaxToothTgicknessLabel.Size = new System.Drawing.Size(67, 15);
            this.MinMaxToothTgicknessLabel.TabIndex = 90;
            this.MinMaxToothTgicknessLabel.Text = "(5 - 50 мм)";
            // 
            // OuterDiameterLabel
            // 
            this.OuterDiameterLabel.AutoSize = true;
            this.OuterDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OuterDiameterLabel.Location = new System.Drawing.Point(12, 15);
            this.OuterDiameterLabel.Name = "OuterDiameterLabel";
            this.OuterDiameterLabel.Size = new System.Drawing.Size(205, 15);
            this.OuterDiameterLabel.TabIndex = 82;
            this.OuterDiameterLabel.Text = "Диаметр наружной окружности D:";
            // 
            // InnerDiameterLabel
            // 
            this.InnerDiameterLabel.AutoSize = true;
            this.InnerDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InnerDiameterLabel.Location = new System.Drawing.Point(12, 57);
            this.InnerDiameterLabel.Name = "InnerDiameterLabel";
            this.InnerDiameterLabel.Size = new System.Drawing.Size(220, 15);
            this.InnerDiameterLabel.TabIndex = 83;
            this.InnerDiameterLabel.Text = "Диаметр внутренней окружности Di:";
            // 
            // InnerDiameterTextBox
            // 
            this.InnerDiameterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InnerDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InnerDiameterTextBox.Location = new System.Drawing.Point(17, 75);
            this.InnerDiameterTextBox.Name = "InnerDiameterTextBox";
            this.InnerDiameterTextBox.Size = new System.Drawing.Size(56, 21);
            this.InnerDiameterTextBox.TabIndex = 2;
            this.InnerDiameterTextBox.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // OuterDiameterTextBox
            // 
            this.OuterDiameterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OuterDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OuterDiameterTextBox.Location = new System.Drawing.Point(17, 33);
            this.OuterDiameterTextBox.Name = "OuterDiameterTextBox";
            this.OuterDiameterTextBox.Size = new System.Drawing.Size(56, 21);
            this.OuterDiameterTextBox.TabIndex = 1;
            this.OuterDiameterTextBox.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // MinMaxOuterDiameterLabel
            // 
            this.MinMaxOuterDiameterLabel.AutoSize = true;
            this.MinMaxOuterDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinMaxOuterDiameterLabel.Location = new System.Drawing.Point(92, 35);
            this.MinMaxOuterDiameterLabel.Name = "MinMaxOuterDiameterLabel";
            this.MinMaxOuterDiameterLabel.Size = new System.Drawing.Size(81, 15);
            this.MinMaxOuterDiameterLabel.TabIndex = 86;
            this.MinMaxOuterDiameterLabel.Text = "(50 - 500 мм)";
            // 
            // MinMaxInnerDiameter
            // 
            this.MinMaxInnerDiameter.AutoSize = true;
            this.MinMaxInnerDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinMaxInnerDiameter.Location = new System.Drawing.Point(92, 77);
            this.MinMaxInnerDiameter.Name = "MinMaxInnerDiameter";
            this.MinMaxInnerDiameter.Size = new System.Drawing.Size(81, 15);
            this.MinMaxInnerDiameter.TabIndex = 87;
            this.MinMaxInnerDiameter.Text = "(25 - 250 мм)";
            // 
            // ToothHeightTextBox
            // 
            this.ToothHeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToothHeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToothHeightTextBox.Location = new System.Drawing.Point(17, 159);
            this.ToothHeightTextBox.Name = "ToothHeightTextBox";
            this.ToothHeightTextBox.Size = new System.Drawing.Size(56, 21);
            this.ToothHeightTextBox.TabIndex = 4;
            this.ToothHeightTextBox.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // ToothTopRadiusRatioLabel
            // 
            this.ToothTopRadiusRatioLabel.AutoSize = true;
            this.ToothTopRadiusRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToothTopRadiusRatioLabel.Location = new System.Drawing.Point(12, 228);
            this.ToothTopRadiusRatioLabel.Name = "ToothTopRadiusRatioLabel";
            this.ToothTopRadiusRatioLabel.Size = new System.Drawing.Size(225, 15);
            this.ToothTopRadiusRatioLabel.TabIndex = 92;
            this.ToothTopRadiusRatioLabel.Text = "Коэффициент верхнего радиуса зуба";
            // 
            // ToothTopRadiusRatioTextBox
            // 
            this.ToothTopRadiusRatioTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToothTopRadiusRatioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToothTopRadiusRatioTextBox.Location = new System.Drawing.Point(17, 245);
            this.ToothTopRadiusRatioTextBox.Name = "ToothTopRadiusRatioTextBox";
            this.ToothTopRadiusRatioTextBox.Size = new System.Drawing.Size(56, 21);
            this.ToothTopRadiusRatioTextBox.TabIndex = 6;
            this.ToothTopRadiusRatioTextBox.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // MinMaxToothTopRadiusRatioLabel
            // 
            this.MinMaxToothTopRadiusRatioLabel.AutoSize = true;
            this.MinMaxToothTopRadiusRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinMaxToothTopRadiusRatioLabel.Location = new System.Drawing.Point(92, 247);
            this.MinMaxToothTopRadiusRatioLabel.Name = "MinMaxToothTopRadiusRatioLabel";
            this.MinMaxToothTopRadiusRatioLabel.Size = new System.Drawing.Size(59, 15);
            this.MinMaxToothTopRadiusRatioLabel.TabIndex = 93;
            this.MinMaxToothTopRadiusRatioLabel.Text = "(0,2 - 0,8)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(632, 326);
            this.Controls.Add(this.ToothTopRadiusRatioLabel);
            this.Controls.Add(this.ToothTopRadiusRatioTextBox);
            this.Controls.Add(this.MinMaxToothTopRadiusRatioLabel);
            this.Controls.Add(this.ToothHeightTextBox);
            this.Controls.Add(this.ThicknessLabel);
            this.Controls.Add(this.ThicknessTextBox);
            this.Controls.Add(this.MinMaxToothTgicknessLabel);
            this.Controls.Add(this.OuterDiameterLabel);
            this.Controls.Add(this.InnerDiameterLabel);
            this.Controls.Add(this.InnerDiameterTextBox);
            this.Controls.Add(this.OuterDiameterTextBox);
            this.Controls.Add(this.MinMaxOuterDiameterLabel);
            this.Controls.Add(this.MinMaxInnerDiameter);
            this.Controls.Add(this.ToothCountLabel);
            this.Controls.Add(this.ToothCountTextBox);
            this.Controls.Add(this.MinMaxToothCountLabel);
            this.Controls.Add(this.ToothHeightLabel);
            this.Controls.Add(this.MinMaxToothHeightLabel);
            this.Controls.Add(this.Schema);
            this.Controls.Add(this.BuildBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SprocketForm";
            this.Text = "Построение звёздочки";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Schema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BuildBtn;
        private System.Windows.Forms.PictureBox Schema;
        private System.Windows.Forms.Label ThicknessLabel;
        private System.Windows.Forms.TextBox ThicknessTextBox;
        private System.Windows.Forms.Label MinMaxToothTgicknessLabel;
        private System.Windows.Forms.Label OuterDiameterLabel;
        private System.Windows.Forms.Label InnerDiameterLabel;
        private System.Windows.Forms.TextBox InnerDiameterTextBox;
        private System.Windows.Forms.TextBox OuterDiameterTextBox;
        private System.Windows.Forms.Label MinMaxOuterDiameterLabel;
        private System.Windows.Forms.Label MinMaxInnerDiameter;
        private System.Windows.Forms.Label ToothCountLabel;
        private System.Windows.Forms.TextBox ToothCountTextBox;
        private System.Windows.Forms.Label MinMaxToothCountLabel;
        private System.Windows.Forms.Label ToothHeightLabel;
        private System.Windows.Forms.Label MinMaxToothHeightLabel;
        private System.Windows.Forms.TextBox ToothHeightTextBox;
        private System.Windows.Forms.Label ToothTopRadiusRatioLabel;
        private System.Windows.Forms.TextBox ToothTopRadiusRatioTextBox;
        private System.Windows.Forms.Label MinMaxToothTopRadiusRatioLabel;
    }
}

