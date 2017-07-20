namespace InstaFame.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearProxies = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.checkLikeComment = new System.Windows.Forms.CheckBox();
            this.numericProxySwitch = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.checkRemember = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tsBottom = new System.Windows.Forms.ToolStrip();
            this.lblFollowers = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFollowersGained = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUnfollowUsers = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.txtQueries = new System.Windows.Forms.RichTextBox();
            this.lstScrapedUsers = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tsUnfollowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProxySwitch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tsBottom.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericTimeout);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnClearProxies);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.checkLikeComment);
            this.groupBox2.Controls.Add(this.numericProxySwitch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(308, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // btnClearProxies
            // 
            this.btnClearProxies.Location = new System.Drawing.Point(147, 129);
            this.btnClearProxies.Name = "btnClearProxies";
            this.btnClearProxies.Size = new System.Drawing.Size(130, 23);
            this.btnClearProxies.TabIndex = 5;
            this.btnClearProxies.Text = "Clear Proxies";
            this.btnClearProxies.UseVisualStyleBackColor = true;
            this.btnClearProxies.Click += new System.EventHandler(this.btnClearProxies_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(16, 129);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(130, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import Proxies";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // checkLikeComment
            // 
            this.checkLikeComment.AutoSize = true;
            this.checkLikeComment.Location = new System.Drawing.Point(16, 108);
            this.checkLikeComment.Name = "checkLikeComment";
            this.checkLikeComment.Size = new System.Drawing.Size(156, 17);
            this.checkLikeComment.TabIndex = 2;
            this.checkLikeComment.Text = "Like and comment on posts";
            this.checkLikeComment.UseVisualStyleBackColor = true;
            // 
            // numericProxySwitch
            // 
            this.numericProxySwitch.Location = new System.Drawing.Point(16, 43);
            this.numericProxySwitch.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericProxySwitch.Name = "numericProxySwitch";
            this.numericProxySwitch.Size = new System.Drawing.Size(261, 20);
            this.numericProxySwitch.TabIndex = 2;
            this.numericProxySwitch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Switch proxy after every (x) actions";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(16, 43);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(256, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 84);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(256, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // checkRemember
            // 
            this.checkRemember.AutoSize = true;
            this.checkRemember.Location = new System.Drawing.Point(16, 114);
            this.checkRemember.Name = "checkRemember";
            this.checkRemember.Size = new System.Drawing.Size(95, 17);
            this.checkRemember.TabIndex = 1;
            this.checkRemember.Text = "Remember Me";
            this.checkRemember.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(181, 110);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(91, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.checkRemember);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // tsBottom
            // 
            this.tsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFollowers,
            this.toolStripSeparator2,
            this.lblFollowersGained,
            this.toolStripSeparator3,
            this.lblStatus});
            this.tsBottom.Location = new System.Drawing.Point(0, 539);
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(610, 25);
            this.tsBottom.TabIndex = 2;
            this.tsBottom.Text = "toolStrip1";
            // 
            // lblFollowers
            // 
            this.lblFollowers.Name = "lblFollowers";
            this.lblFollowers.Size = new System.Drawing.Size(69, 22);
            this.lblFollowers.Text = "Followers: 0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblFollowersGained
            // 
            this.lblFollowersGained.Name = "lblFollowersGained";
            this.lblFollowersGained.Size = new System.Drawing.Size(109, 22);
            this.lblFollowersGained.Text = "Followers Gained: 0";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(113, 22);
            this.lblStatus.Text = "Status: Not Running";
            // 
            // lstUsers
            // 
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstUsers.FullRowSelect = true;
            this.lstUsers.GridLines = true;
            this.lstUsers.Location = new System.Drawing.Point(308, 176);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(288, 291);
            this.lstUsers.TabIndex = 3;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Follows You?";
            this.columnHeader2.Width = 140;
            // 
            // btnUnfollowUsers
            // 
            this.btnUnfollowUsers.Location = new System.Drawing.Point(308, 473);
            this.btnUnfollowUsers.Name = "btnUnfollowUsers";
            this.btnUnfollowUsers.Size = new System.Drawing.Size(288, 23);
            this.btnUnfollowUsers.TabIndex = 4;
            this.btnUnfollowUsers.Text = "Unfollow all who follow you";
            this.btnUnfollowUsers.UseVisualStyleBackColor = true;
            this.btnUnfollowUsers.Click += new System.EventHandler(this.btnUnfollowUsers_Click);
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(14, 176);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(288, 100);
            this.txtComments.TabIndex = 5;
            this.txtComments.Text = "add\ncomment\nlist\nhere";
            // 
            // txtQueries
            // 
            this.txtQueries.Location = new System.Drawing.Point(14, 282);
            this.txtQueries.Name = "txtQueries";
            this.txtQueries.Size = new System.Drawing.Size(288, 100);
            this.txtQueries.TabIndex = 6;
            this.txtQueries.Text = "queries\nfor\nuser\nsearch\nhere";
            // 
            // lstScrapedUsers
            // 
            this.lstScrapedUsers.FormattingEnabled = true;
            this.lstScrapedUsers.Location = new System.Drawing.Point(14, 401);
            this.lstScrapedUsers.Name = "lstScrapedUsers";
            this.lstScrapedUsers.Size = new System.Drawing.Size(288, 95);
            this.lstScrapedUsers.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scraped Users";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUpdate,
            this.tsUnfollowAll});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // tsUpdate
            // 
            this.tsUpdate.Name = "tsUpdate";
            this.tsUpdate.Size = new System.Drawing.Size(139, 22);
            this.tsUpdate.Text = "Update";
            this.tsUpdate.Click += new System.EventHandler(this.tsUpdate_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(14, 502);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(126, 502);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(106, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(16, 82);
            this.numericTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(261, 20);
            this.numericTimeout.TabIndex = 6;
            this.numericTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Timeout (seconds)";
            // 
            // tsUnfollowAll
            // 
            this.tsUnfollowAll.Name = "tsUnfollowAll";
            this.tsUnfollowAll.Size = new System.Drawing.Size(139, 22);
            this.tsUnfollowAll.Text = "Unfollow All";
            this.tsUnfollowAll.Click += new System.EventHandler(this.tsUnfollowAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 564);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstScrapedUsers);
            this.Controls.Add(this.txtQueries);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnUnfollowUsers);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.tsBottom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "InstaFame by @distancexd - www.github.com/distancexd";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProxySwitch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsBottom.ResumeLayout(false);
            this.tsBottom.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericProxySwitch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkLikeComment;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox checkRemember;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsBottom;
        private System.Windows.Forms.ToolStripLabel lblFollowers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblFollowersGained;
        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnUnfollowUsers;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.RichTextBox txtQueries;
        private System.Windows.Forms.ListBox lstScrapedUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsUpdate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClearProxies;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem tsUnfollowAll;
    }
}