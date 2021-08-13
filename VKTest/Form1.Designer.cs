
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
            this.btn_GroupWallGet = new System.Windows.Forms.Button();
            this.btn_WallPost = new System.Windows.Forms.Button();
            this.txt_GroupWallGetCount = new System.Windows.Forms.TextBox();
            this.txt_WallPostOwnerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_WallPostDay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_GroupWallGetOffset = new System.Windows.Forms.TextBox();
            this.txt_GroupWallGetOwnerID = new System.Windows.Forms.RichTextBox();
            this.txt_WallPostHours = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_SelectFolder = new System.Windows.Forms.TextBox();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.txt_BotLog = new System.Windows.Forms.RichTextBox();
            this.btn_BotStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txt_UserPhotoAlbumID = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UserPhotoOffset = new System.Windows.Forms.TextBox();
            this.txt_UserPhotoCount = new System.Windows.Forms.TextBox();
            this.txt_UserPhotoOwnerID = new System.Windows.Forms.TextBox();
            this.btn_UserPhotoGet = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lb_UserGroupCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_UserGroupOffset = new System.Windows.Forms.TextBox();
            this.txt_UserGroupCount = new System.Windows.Forms.TextBox();
            this.txt_UserGroupListOwnerID = new System.Windows.Forms.RichTextBox();
            this.txt_UserGroupUserID = new System.Windows.Forms.TextBox();
            this.btn_UserGroup = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GroupWallGet
            // 
            this.btn_GroupWallGet.Location = new System.Drawing.Point(6, 303);
            this.btn_GroupWallGet.Name = "btn_GroupWallGet";
            this.btn_GroupWallGet.Size = new System.Drawing.Size(100, 25);
            this.btn_GroupWallGet.TabIndex = 1;
            this.btn_GroupWallGet.Text = "Start";
            this.btn_GroupWallGet.UseVisualStyleBackColor = true;
            this.btn_GroupWallGet.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_WallPost
            // 
            this.btn_WallPost.Location = new System.Drawing.Point(6, 91);
            this.btn_WallPost.Name = "btn_WallPost";
            this.btn_WallPost.Size = new System.Drawing.Size(100, 25);
            this.btn_WallPost.TabIndex = 8;
            this.btn_WallPost.Text = "WallPost";
            this.btn_WallPost.UseVisualStyleBackColor = true;
            this.btn_WallPost.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_GroupWallGetCount
            // 
            this.txt_GroupWallGetCount.Location = new System.Drawing.Point(47, 251);
            this.txt_GroupWallGetCount.Name = "txt_GroupWallGetCount";
            this.txt_GroupWallGetCount.Size = new System.Drawing.Size(60, 20);
            this.txt_GroupWallGetCount.TabIndex = 10;
            this.txt_GroupWallGetCount.Text = "10";
            this.txt_GroupWallGetCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_WallPostOwnerID
            // 
            this.txt_WallPostOwnerID.Location = new System.Drawing.Point(6, 19);
            this.txt_WallPostOwnerID.Name = "txt_WallPostOwnerID";
            this.txt_WallPostOwnerID.Size = new System.Drawing.Size(60, 20);
            this.txt_WallPostOwnerID.TabIndex = 12;
            this.txt_WallPostOwnerID.Text = "193939494";
            this.txt_WallPostOwnerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Owner ID";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Куда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "+Час";
            // 
            // txt_WallPostDay
            // 
            this.txt_WallPostDay.Location = new System.Drawing.Point(89, 39);
            this.txt_WallPostDay.Name = "txt_WallPostDay";
            this.txt_WallPostDay.Size = new System.Drawing.Size(60, 20);
            this.txt_WallPostDay.TabIndex = 18;
            this.txt_WallPostDay.Text = "0";
            this.txt_WallPostDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Offset";
            // 
            // txt_GroupWallGetOffset
            // 
            this.txt_GroupWallGetOffset.Location = new System.Drawing.Point(47, 277);
            this.txt_GroupWallGetOffset.Name = "txt_GroupWallGetOffset";
            this.txt_GroupWallGetOffset.Size = new System.Drawing.Size(60, 20);
            this.txt_GroupWallGetOffset.TabIndex = 20;
            this.txt_GroupWallGetOffset.Text = "1";
            this.txt_GroupWallGetOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_GroupWallGetOwnerID
            // 
            this.txt_GroupWallGetOwnerID.Location = new System.Drawing.Point(6, 19);
            this.txt_GroupWallGetOwnerID.Name = "txt_GroupWallGetOwnerID";
            this.txt_GroupWallGetOwnerID.Size = new System.Drawing.Size(129, 208);
            this.txt_GroupWallGetOwnerID.TabIndex = 23;
            this.txt_GroupWallGetOwnerID.Text = "";
            // 
            // txt_WallPostHours
            // 
            this.txt_WallPostHours.Location = new System.Drawing.Point(89, 65);
            this.txt_WallPostHours.Name = "txt_WallPostHours";
            this.txt_WallPostHours.Size = new System.Drawing.Size(60, 20);
            this.txt_WallPostHours.TabIndex = 28;
            this.txt_WallPostHours.Text = "0";
            this.txt_WallPostHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "+День";
            // 
            // txt_SelectFolder
            // 
            this.txt_SelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SelectFolder.Location = new System.Drawing.Point(118, 15);
            this.txt_SelectFolder.Name = "txt_SelectFolder";
            this.txt_SelectFolder.Size = new System.Drawing.Size(300, 20);
            this.txt_SelectFolder.TabIndex = 33;
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(100, 23);
            this.btn_SelectFolder.TabIndex = 34;
            this.btn_SelectFolder.Text = "Select Folder";
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.button6_Click);
            // 
            // txt_BotLog
            // 
            this.txt_BotLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_BotLog.Location = new System.Drawing.Point(6, 40);
            this.txt_BotLog.MinimumSize = new System.Drawing.Size(390, 285);
            this.txt_BotLog.Name = "txt_BotLog";
            this.txt_BotLog.Size = new System.Drawing.Size(390, 286);
            this.txt_BotLog.TabIndex = 35;
            this.txt_BotLog.Text = "";
            // 
            // btn_BotStart
            // 
            this.btn_BotStart.Location = new System.Drawing.Point(6, 6);
            this.btn_BotStart.Name = "btn_BotStart";
            this.btn_BotStart.Size = new System.Drawing.Size(59, 28);
            this.btn_BotStart.TabIndex = 36;
            this.btn_BotStart.Text = "Start";
            this.btn_BotStart.UseVisualStyleBackColor = true;
            this.btn_BotStart.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.MinimumSize = new System.Drawing.Size(410, 357);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(410, 358);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_GroupWallGet);
            this.tabPage1.Controls.Add(this.txt_GroupWallGetCount);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_GroupWallGetOffset);
            this.tabPage1.Controls.Add(this.txt_GroupWallGetOwnerID);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(402, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Посты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txt_UserPhotoAlbumID);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.txt_UserPhotoOffset);
            this.tabPage4.Controls.Add(this.txt_UserPhotoCount);
            this.tabPage4.Controls.Add(this.txt_UserPhotoOwnerID);
            this.tabPage4.Controls.Add(this.btn_UserPhotoGet);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(402, 332);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Пользователь";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_UserPhotoAlbumID
            // 
            this.txt_UserPhotoAlbumID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_UserPhotoAlbumID.Location = new System.Drawing.Point(6, 113);
            this.txt_UserPhotoAlbumID.Name = "txt_UserPhotoAlbumID";
            this.txt_UserPhotoAlbumID.Size = new System.Drawing.Size(174, 213);
            this.txt_UserPhotoAlbumID.TabIndex = 7;
            this.txt_UserPhotoAlbumID.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Offset";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Count";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Owner ID";
            // 
            // txt_UserPhotoOffset
            // 
            this.txt_UserPhotoOffset.Location = new System.Drawing.Point(80, 87);
            this.txt_UserPhotoOffset.Name = "txt_UserPhotoOffset";
            this.txt_UserPhotoOffset.Size = new System.Drawing.Size(100, 20);
            this.txt_UserPhotoOffset.TabIndex = 3;
            this.txt_UserPhotoOffset.Text = "0";
            // 
            // txt_UserPhotoCount
            // 
            this.txt_UserPhotoCount.Location = new System.Drawing.Point(80, 61);
            this.txt_UserPhotoCount.Name = "txt_UserPhotoCount";
            this.txt_UserPhotoCount.Size = new System.Drawing.Size(100, 20);
            this.txt_UserPhotoCount.TabIndex = 2;
            this.txt_UserPhotoCount.Text = "1000";
            // 
            // txt_UserPhotoOwnerID
            // 
            this.txt_UserPhotoOwnerID.Location = new System.Drawing.Point(80, 35);
            this.txt_UserPhotoOwnerID.Name = "txt_UserPhotoOwnerID";
            this.txt_UserPhotoOwnerID.Size = new System.Drawing.Size(100, 20);
            this.txt_UserPhotoOwnerID.TabIndex = 1;
            // 
            // btn_UserPhotoGet
            // 
            this.btn_UserPhotoGet.Location = new System.Drawing.Point(6, 6);
            this.btn_UserPhotoGet.Name = "btn_UserPhotoGet";
            this.btn_UserPhotoGet.Size = new System.Drawing.Size(75, 23);
            this.btn_UserPhotoGet.TabIndex = 0;
            this.btn_UserPhotoGet.Text = "Скачать";
            this.btn_UserPhotoGet.UseVisualStyleBackColor = true;
            this.btn_UserPhotoGet.Click += new System.EventHandler(this.btn_UserPhotoGet_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lb_UserGroupCount);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.txt_UserGroupOffset);
            this.tabPage5.Controls.Add(this.txt_UserGroupCount);
            this.tabPage5.Controls.Add(this.txt_UserGroupListOwnerID);
            this.tabPage5.Controls.Add(this.txt_UserGroupUserID);
            this.tabPage5.Controls.Add(this.btn_UserGroup);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(402, 332);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Группы";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lb_UserGroupCount
            // 
            this.lb_UserGroupCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_UserGroupCount.AutoSize = true;
            this.lb_UserGroupCount.Location = new System.Drawing.Point(284, 82);
            this.lb_UserGroupCount.Name = "lb_UserGroupCount";
            this.lb_UserGroupCount.Size = new System.Drawing.Size(112, 13);
            this.lb_UserGroupCount.TabIndex = 7;
            this.lb_UserGroupCount.Text = "Group Count:  999999";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Offset";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Count";
            // 
            // txt_UserGroupOffset
            // 
            this.txt_UserGroupOffset.Location = new System.Drawing.Point(112, 61);
            this.txt_UserGroupOffset.Name = "txt_UserGroupOffset";
            this.txt_UserGroupOffset.Size = new System.Drawing.Size(100, 20);
            this.txt_UserGroupOffset.TabIndex = 4;
            this.txt_UserGroupOffset.Text = "0";
            // 
            // txt_UserGroupCount
            // 
            this.txt_UserGroupCount.Location = new System.Drawing.Point(112, 35);
            this.txt_UserGroupCount.Name = "txt_UserGroupCount";
            this.txt_UserGroupCount.Size = new System.Drawing.Size(100, 20);
            this.txt_UserGroupCount.TabIndex = 3;
            this.txt_UserGroupCount.Text = "1000";
            // 
            // txt_UserGroupListOwnerID
            // 
            this.txt_UserGroupListOwnerID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UserGroupListOwnerID.Location = new System.Drawing.Point(6, 98);
            this.txt_UserGroupListOwnerID.Name = "txt_UserGroupListOwnerID";
            this.txt_UserGroupListOwnerID.Size = new System.Drawing.Size(390, 228);
            this.txt_UserGroupListOwnerID.TabIndex = 2;
            this.txt_UserGroupListOwnerID.Text = "";
            // 
            // txt_UserGroupUserID
            // 
            this.txt_UserGroupUserID.Location = new System.Drawing.Point(6, 6);
            this.txt_UserGroupUserID.Name = "txt_UserGroupUserID";
            this.txt_UserGroupUserID.Size = new System.Drawing.Size(100, 20);
            this.txt_UserGroupUserID.TabIndex = 1;
            this.txt_UserGroupUserID.Text = "50870341";
            // 
            // btn_UserGroup
            // 
            this.btn_UserGroup.Location = new System.Drawing.Point(112, 6);
            this.btn_UserGroup.Name = "btn_UserGroup";
            this.btn_UserGroup.Size = new System.Drawing.Size(75, 23);
            this.btn_UserGroup.TabIndex = 0;
            this.btn_UserGroup.Text = "Start";
            this.btn_UserGroup.UseVisualStyleBackColor = true;
            this.btn_UserGroup.Click += new System.EventHandler(this.btn_UserGroup_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btn_WallPost);
            this.tabPage2.Controls.Add(this.txt_WallPostOwnerID);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txt_WallPostDay);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txt_WallPostHours);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(402, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Загрузить";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_BotStart);
            this.tabPage3.Controls.Add(this.txt_BotLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(402, 332);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Бот";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.txt_SelectFolder);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_SelectFolder);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_GroupWallGet;
        private System.Windows.Forms.Button btn_WallPost;
        private System.Windows.Forms.TextBox txt_GroupWallGetCount;
        private System.Windows.Forms.TextBox txt_WallPostOwnerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_WallPostDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_GroupWallGetOffset;
        private System.Windows.Forms.RichTextBox txt_GroupWallGetOwnerID;
        private System.Windows.Forms.TextBox txt_WallPostHours;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SelectFolder;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.RichTextBox txt_BotLog;
        private System.Windows.Forms.Button btn_BotStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txt_UserPhotoOwnerID;
        private System.Windows.Forms.Button btn_UserPhotoGet;
        private System.Windows.Forms.TextBox txt_UserPhotoOffset;
        private System.Windows.Forms.TextBox txt_UserPhotoCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txt_UserGroupCount;
        private System.Windows.Forms.RichTextBox txt_UserGroupListOwnerID;
        private System.Windows.Forms.TextBox txt_UserGroupUserID;
        private System.Windows.Forms.Button btn_UserGroup;
        private System.Windows.Forms.TextBox txt_UserGroupOffset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_UserGroupCount;
        private System.Windows.Forms.RichTextBox txt_UserPhotoAlbumID;
    }
}

