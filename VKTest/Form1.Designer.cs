﻿
namespace VKTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.txt_otkeda = new System.Windows.Forms.TextBox();
            this.txt_kyda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_offset = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GroupAva = new System.Windows.Forms.PictureBox();
            this.GroupName = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupAva)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1085, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Получить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Название,
            this.Text,
            this.image,
            this.ID_image,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(9, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 100;
            this.dataGridView1.Size = new System.Drawing.Size(711, 625);
            this.dataGridView1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1085, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "Отправить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_count
            // 
            this.txt_count.Location = new System.Drawing.Point(473, 61);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(60, 20);
            this.txt_count.TabIndex = 10;
            this.txt_count.Text = "10";
            this.txt_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_otkeda
            // 
            this.txt_otkeda.Location = new System.Drawing.Point(473, 9);
            this.txt_otkeda.Name = "txt_otkeda";
            this.txt_otkeda.Size = new System.Drawing.Size(60, 20);
            this.txt_otkeda.TabIndex = 11;
            this.txt_otkeda.Text = "67908441";
            this.txt_otkeda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_otkeda.Visible = false;
            // 
            // txt_kyda
            // 
            this.txt_kyda.Location = new System.Drawing.Point(473, 35);
            this.txt_kyda.Name = "txt_kyda";
            this.txt_kyda.Size = new System.Drawing.Size(60, 20);
            this.txt_kyda.TabIndex = 12;
            this.txt_kyda.Text = "193939494";
            this.txt_kyda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Откуда";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Куда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Кол-во";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Корый час";
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(473, 87);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(60, 20);
            this.txt_time.TabIndex = 18;
            this.txt_time.Text = "0";
            this.txt_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Сдвиг";
            // 
            // txt_offset
            // 
            this.txt_offset.Location = new System.Drawing.Point(620, 9);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(100, 20);
            this.txt_offset.TabIndex = 20;
            this.txt_offset.Text = "1";
            this.txt_offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "12";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(726, 112);
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(129, 20);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "193939494,67908441";
            // 
            // GroupAva
            // 
            this.GroupAva.Location = new System.Drawing.Point(9, 9);
            this.GroupAva.Margin = new System.Windows.Forms.Padding(0);
            this.GroupAva.Name = "GroupAva";
            this.GroupAva.Size = new System.Drawing.Size(100, 100);
            this.GroupAva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GroupAva.TabIndex = 4;
            this.GroupAva.TabStop = false;
            this.GroupAva.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupName.AutoSize = true;
            this.GroupName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupName.Location = new System.Drawing.Point(112, 9);
            this.GroupName.Name = "GroupName";
            this.GroupName.Size = new System.Drawing.Size(66, 25);
            this.GroupName.TabIndex = 2;
            this.GroupName.Text = "label1";
            this.GroupName.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(726, 138);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(129, 204);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "193939494,\n67908441\n";
            // 
            // Select
            // 
            this.Select.FillWeight = 59.22294F;
            this.Select.HeaderText = "Check";
            this.Select.Name = "Select";
            this.Select.Width = 55;
            // 
            // Название
            // 
            this.Название.FillWeight = 58.17741F;
            this.Название.HeaderText = "post_id";
            this.Название.Name = "Название";
            this.Название.Width = 158;
            // 
            // Text
            // 
            this.Text.FillWeight = 59.31092F;
            this.Text.HeaderText = "text_Column";
            this.Text.Name = "Text";
            this.Text.Width = 161;
            // 
            // image
            // 
            this.image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.image.FillWeight = 303.6336F;
            this.image.HeaderText = "image_Column";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.image.Name = "image";
            this.image.Width = 82;
            // 
            // ID_image
            // 
            this.ID_image.FillWeight = 58.74139F;
            this.ID_image.HeaderText = "ID";
            this.ID_image.Name = "ID_image";
            this.ID_image.ReadOnly = true;
            this.ID_image.Width = 55;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Дата";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 749);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_offset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_kyda);
            this.Controls.Add(this.txt_count);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GroupAva);
            this.Controls.Add(this.GroupName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_otkeda);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupAva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.TextBox txt_otkeda;
        private System.Windows.Forms.TextBox txt_kyda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_offset;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox GroupAva;
        private System.Windows.Forms.Label GroupName;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
