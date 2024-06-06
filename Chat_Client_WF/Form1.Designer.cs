namespace Chat_Client_WF
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
            this.label1 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.AutorButton = new System.Windows.Forms.Button();
            this.Users = new System.Windows.Forms.ListBox();
            this.Messages = new System.Windows.Forms.ListBox();
            this.MessageSend = new System.Windows.Forms.TextBox();
            this.NameLab = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите свой логин:";
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(243, 45);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(140, 20);
            this.LoginBox.TabIndex = 1;
            // 
            // AutorButton
            // 
            this.AutorButton.Location = new System.Drawing.Point(209, 87);
            this.AutorButton.Name = "AutorButton";
            this.AutorButton.Size = new System.Drawing.Size(93, 36);
            this.AutorButton.TabIndex = 2;
            this.AutorButton.Text = "Авторизация";
            this.AutorButton.UseVisualStyleBackColor = true;
            this.AutorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Users
            // 
            this.Users.FormattingEnabled = true;
            this.Users.Location = new System.Drawing.Point(7, 14);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(149, 199);
            this.Users.TabIndex = 3;
            this.Users.Visible = false;
            this.Users.SelectedIndexChanged += new System.EventHandler(this.Selected);
            // 
            // Messages
            // 
            this.Messages.Enabled = false;
            this.Messages.FormattingEnabled = true;
            this.Messages.Location = new System.Drawing.Point(162, 13);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(363, 199);
            this.Messages.TabIndex = 4;
            this.Messages.Visible = false;
            // 
            // MessageSend
            // 
            this.MessageSend.Location = new System.Drawing.Point(73, 246);
            this.MessageSend.MaximumSize = new System.Drawing.Size(400, 50);
            this.MessageSend.MinimumSize = new System.Drawing.Size(400, 50);
            this.MessageSend.Multiline = true;
            this.MessageSend.Name = "MessageSend";
            this.MessageSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageSend.Size = new System.Drawing.Size(400, 50);
            this.MessageSend.TabIndex = 5;
            this.MessageSend.Visible = false;
            // 
            // NameLab
            // 
            this.NameLab.AutoSize = true;
            this.NameLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLab.Location = new System.Drawing.Point(4, 247);
            this.NameLab.Name = "NameLab";
            this.NameLab.Size = new System.Drawing.Size(40, 16);
            this.NameLab.TabIndex = 7;
            this.NameLab.Text = "Кому";
            this.NameLab.Visible = false;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(479, 246);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(46, 49);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Visible = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 316);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.NameLab);
            this.Controls.Add(this.MessageSend);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.AutorButton);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SuperDruperChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Button AutorButton;
        private System.Windows.Forms.ListBox Users;
        private System.Windows.Forms.ListBox Messages;
        private System.Windows.Forms.TextBox MessageSend;
        private System.Windows.Forms.Label NameLab;
        private System.Windows.Forms.Button SendButton;
    }
}

