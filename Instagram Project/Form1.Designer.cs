namespace Instagram_Project
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tmrCounter = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new SideWinderTab();
            this.tabAccountMain = new System.Windows.Forms.TabPage();
            this.tabSignIn = new System.Windows.Forms.TabPage();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.alertError = new SideWinderAlert();
            this.alertSuccess = new SideWinderAlert();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabBotMain = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.lblAccountsCount = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.lbURLS = new System.Windows.Forms.ListBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.numSleep = new System.Windows.Forms.NumericUpDown();
            this.tabScrape = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblScrapedCount = new System.Windows.Forms.Label();
            this.tbKeyWord = new System.Windows.Forms.TextBox();
            this.lbScrapedUsernames = new System.Windows.Forms.ListBox();
            this.numPageScape = new System.Windows.Forms.NumericUpDown();
            this.btnScrape = new System.Windows.Forms.Button();
            this.tbHtml = new System.Windows.Forms.TextBox();
            this.tabFollow = new System.Windows.Forms.TabPage();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.cbScraped = new System.Windows.Forms.RadioButton();
            this.cbImported = new System.Windows.Forms.RadioButton();
            this.btnFollow = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabSignIn.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleep)).BeginInit();
            this.tabScrape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageScape)).BeginInit();
            this.tabFollow.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "add-user-2-32.png");
            this.imgList.Images.SetKeyName(1, "contacts-32.png");
            this.imgList.Images.SetKeyName(2, "settings-5-32.png");
            this.imgList.Images.SetKeyName(3, "arrow-57-32.png");
            this.imgList.Images.SetKeyName(4, "target-audience-2-32.png");
            this.imgList.Images.SetKeyName(5, "target-audience-3-32.png");
            // 
            // tmrCounter
            // 
            this.tmrCounter.Tick += new System.EventHandler(this.tmrCounter_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabAccountMain);
            this.tabControl.Controls.Add(this.tabSignIn);
            this.tabControl.Controls.Add(this.tabBotMain);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabScrape);
            this.tabControl.Controls.Add(this.tabFollow);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ImageList = this.imgList;
            this.tabControl.ItemSize = new System.Drawing.Size(40, 170);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(548, 246);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabAccountMain
            // 
            this.tabAccountMain.BackColor = System.Drawing.Color.White;
            this.tabAccountMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabAccountMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.tabAccountMain.Location = new System.Drawing.Point(174, 4);
            this.tabAccountMain.Name = "tabAccountMain";
            this.tabAccountMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountMain.Size = new System.Drawing.Size(370, 238);
            this.tabAccountMain.TabIndex = 0;
            this.tabAccountMain.Tag = "Account";
            this.tabAccountMain.Text = "Account";
            // 
            // tabSignIn
            // 
            this.tabSignIn.BackColor = System.Drawing.Color.White;
            this.tabSignIn.Controls.Add(this.lblPass);
            this.tabSignIn.Controls.Add(this.lblUser);
            this.tabSignIn.Controls.Add(this.tbPass);
            this.tabSignIn.Controls.Add(this.tbUser);
            this.tabSignIn.Controls.Add(this.alertError);
            this.tabSignIn.Controls.Add(this.alertSuccess);
            this.tabSignIn.Controls.Add(this.btnLogin);
            this.tabSignIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.tabSignIn.ImageIndex = 0;
            this.tabSignIn.Location = new System.Drawing.Point(174, 4);
            this.tabSignIn.Name = "tabSignIn";
            this.tabSignIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignIn.Size = new System.Drawing.Size(370, 238);
            this.tabSignIn.TabIndex = 1;
            this.tabSignIn.Text = "Sign In";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(15, 100);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 19);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Password";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(15, 60);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(71, 19);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "Username";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(140, 97);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(213, 25);
            this.tbPass.TabIndex = 11;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(140, 57);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(213, 25);
            this.tbUser.TabIndex = 10;
            // 
            // alertError
            // 
            this.alertError.Alert = SideWinderAlert.Style.Warning;
            this.alertError.Centered = true;
            this.alertError.Field = false;
            this.alertError.Location = new System.Drawing.Point(6, 193);
            this.alertError.Name = "alertError";
            this.alertError.Size = new System.Drawing.Size(356, 37);
            this.alertError.TabIndex = 9;
            this.alertError.Visible = false;
            // 
            // alertSuccess
            // 
            this.alertSuccess.Alert = SideWinderAlert.Style.Success;
            this.alertSuccess.Centered = true;
            this.alertSuccess.Field = false;
            this.alertSuccess.Location = new System.Drawing.Point(6, 193);
            this.alertSuccess.Name = "alertSuccess";
            this.alertSuccess.Size = new System.Drawing.Size(356, 37);
            this.alertSuccess.TabIndex = 8;
            this.alertSuccess.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(278, 161);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 26);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tabBotMain
            // 
            this.tabBotMain.BackColor = System.Drawing.Color.White;
            this.tabBotMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabBotMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.tabBotMain.Location = new System.Drawing.Point(174, 4);
            this.tabBotMain.Name = "tabBotMain";
            this.tabBotMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabBotMain.Size = new System.Drawing.Size(370, 238);
            this.tabBotMain.TabIndex = 3;
            this.tabBotMain.Tag = "Bot";
            this.tabBotMain.Text = "Bot";
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.White;
            this.tabSettings.Controls.Add(this.lblAccountsCount);
            this.tabSettings.Controls.Add(this.lblImport);
            this.tabSettings.Controls.Add(this.btnImport);
            this.tabSettings.Controls.Add(this.lbURLS);
            this.tabSettings.Controls.Add(this.lblDelay);
            this.tabSettings.Controls.Add(this.numSleep);
            this.tabSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.tabSettings.ImageIndex = 2;
            this.tabSettings.Location = new System.Drawing.Point(174, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(370, 238);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            // 
            // lblAccountsCount
            // 
            this.lblAccountsCount.AutoSize = true;
            this.lblAccountsCount.Location = new System.Drawing.Point(17, 211);
            this.lblAccountsCount.Name = "lblAccountsCount";
            this.lblAccountsCount.Size = new System.Drawing.Size(0, 19);
            this.lblAccountsCount.TabIndex = 12;
            this.lblAccountsCount.Visible = false;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(17, 96);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(166, 19);
            this.lblImport.TabIndex = 7;
            this.lblImport.Text = "Import accounts to follow";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(276, 91);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 26);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lbURLS
            // 
            this.lbURLS.FormattingEnabled = true;
            this.lbURLS.ItemHeight = 17;
            this.lbURLS.Location = new System.Drawing.Point(336, 211);
            this.lbURLS.Name = "lbURLS";
            this.lbURLS.Size = new System.Drawing.Size(26, 21);
            this.lbURLS.TabIndex = 5;
            this.lbURLS.Visible = false;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(17, 38);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(237, 19);
            this.lblDelay.TabIndex = 1;
            this.lblDelay.Text = "Delay between follows in milliseconds";
            // 
            // numSleep
            // 
            this.numSleep.Location = new System.Drawing.Point(278, 36);
            this.numSleep.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numSleep.Name = "numSleep";
            this.numSleep.Size = new System.Drawing.Size(73, 25);
            this.numSleep.TabIndex = 0;
            this.numSleep.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            // 
            // tabScrape
            // 
            this.tabScrape.BackColor = System.Drawing.Color.White;
            this.tabScrape.Controls.Add(this.btnSave);
            this.tabScrape.Controls.Add(this.lblScrapedCount);
            this.tabScrape.Controls.Add(this.tbKeyWord);
            this.tabScrape.Controls.Add(this.lbScrapedUsernames);
            this.tabScrape.Controls.Add(this.numPageScape);
            this.tabScrape.Controls.Add(this.btnScrape);
            this.tabScrape.Controls.Add(this.tbHtml);
            this.tabScrape.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabScrape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.tabScrape.ImageIndex = 4;
            this.tabScrape.Location = new System.Drawing.Point(174, 4);
            this.tabScrape.Name = "tabScrape";
            this.tabScrape.Padding = new System.Windows.Forms.Padding(3);
            this.tabScrape.Size = new System.Drawing.Size(370, 238);
            this.tabScrape.TabIndex = 4;
            this.tabScrape.Text = "Scrape";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(278, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblScrapedCount
            // 
            this.lblScrapedCount.AutoSize = true;
            this.lblScrapedCount.Location = new System.Drawing.Point(16, 146);
            this.lblScrapedCount.Name = "lblScrapedCount";
            this.lblScrapedCount.Size = new System.Drawing.Size(0, 19);
            this.lblScrapedCount.TabIndex = 11;
            // 
            // tbKeyWord
            // 
            this.tbKeyWord.Location = new System.Drawing.Point(15, 20);
            this.tbKeyWord.Name = "tbKeyWord";
            this.tbKeyWord.Size = new System.Drawing.Size(207, 25);
            this.tbKeyWord.TabIndex = 10;
            // 
            // lbScrapedUsernames
            // 
            this.lbScrapedUsernames.FormattingEnabled = true;
            this.lbScrapedUsernames.ItemHeight = 17;
            this.lbScrapedUsernames.Location = new System.Drawing.Point(15, 54);
            this.lbScrapedUsernames.Name = "lbScrapedUsernames";
            this.lbScrapedUsernames.Size = new System.Drawing.Size(338, 89);
            this.lbScrapedUsernames.TabIndex = 9;
            // 
            // numPageScape
            // 
            this.numPageScape.Location = new System.Drawing.Point(228, 20);
            this.numPageScape.Name = "numPageScape";
            this.numPageScape.Size = new System.Drawing.Size(44, 25);
            this.numPageScape.TabIndex = 7;
            this.numPageScape.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnScrape
            // 
            this.btnScrape.Location = new System.Drawing.Point(278, 20);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(75, 25);
            this.btnScrape.TabIndex = 6;
            this.btnScrape.Text = "Scape";
            this.btnScrape.UseVisualStyleBackColor = true;
            this.btnScrape.Click += new System.EventHandler(this.btnScrape_Click);
            // 
            // tbHtml
            // 
            this.tbHtml.Location = new System.Drawing.Point(6, 222);
            this.tbHtml.Multiline = true;
            this.tbHtml.Name = "tbHtml";
            this.tbHtml.Size = new System.Drawing.Size(10, 10);
            this.tbHtml.TabIndex = 5;
            this.tbHtml.Visible = false;
            // 
            // tabFollow
            // 
            this.tabFollow.BackColor = System.Drawing.Color.White;
            this.tabFollow.Controls.Add(this.tbConsole);
            this.tabFollow.Controls.Add(this.cbScraped);
            this.tabFollow.Controls.Add(this.cbImported);
            this.tabFollow.Controls.Add(this.btnFollow);
            this.tabFollow.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabFollow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.tabFollow.ImageIndex = 3;
            this.tabFollow.Location = new System.Drawing.Point(174, 4);
            this.tabFollow.Name = "tabFollow";
            this.tabFollow.Padding = new System.Windows.Forms.Padding(3);
            this.tabFollow.Size = new System.Drawing.Size(370, 238);
            this.tabFollow.TabIndex = 5;
            this.tabFollow.Text = "Follow";
            // 
            // tbConsole
            // 
            this.tbConsole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsole.Location = new System.Drawing.Point(16, 47);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(346, 154);
            this.tbConsole.TabIndex = 9;
            // 
            // cbScraped
            // 
            this.cbScraped.AutoSize = true;
            this.cbScraped.Location = new System.Drawing.Point(158, 18);
            this.cbScraped.Name = "cbScraped";
            this.cbScraped.Size = new System.Drawing.Size(118, 23);
            this.cbScraped.TabIndex = 8;
            this.cbScraped.TabStop = true;
            this.cbScraped.Text = "Follow Scraped";
            this.cbScraped.UseVisualStyleBackColor = true;
            // 
            // cbImported
            // 
            this.cbImported.AutoSize = true;
            this.cbImported.Location = new System.Drawing.Point(16, 18);
            this.cbImported.Name = "cbImported";
            this.cbImported.Size = new System.Drawing.Size(127, 23);
            this.cbImported.TabIndex = 7;
            this.cbImported.TabStop = true;
            this.cbImported.Text = "Follow Imported";
            this.cbImported.UseVisualStyleBackColor = true;
            // 
            // btnFollow
            // 
            this.btnFollow.Location = new System.Drawing.Point(287, 207);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(75, 23);
            this.btnFollow.TabIndex = 4;
            this.btnFollow.Text = "Follow";
            this.btnFollow.UseVisualStyleBackColor = true;
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 246);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Instagram";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabSignIn.ResumeLayout(false);
            this.tabSignIn.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleep)).EndInit();
            this.tabScrape.ResumeLayout(false);
            this.tabScrape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageScape)).EndInit();
            this.tabFollow.ResumeLayout(false);
            this.tabFollow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SideWinderTab tabControl;
        private System.Windows.Forms.TabPage tabAccountMain;
        private System.Windows.Forms.TabPage tabSignIn;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private SideWinderAlert alertError;
        private SideWinderAlert alertSuccess;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TabPage tabBotMain;
        private System.Windows.Forms.NumericUpDown numSleep;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TabPage tabScrape;
        private System.Windows.Forms.TextBox tbHtml;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ListBox lbURLS;
        private System.Windows.Forms.TabPage tabFollow;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.NumericUpDown numPageScape;
        private System.Windows.Forms.ListBox lbScrapedUsernames;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox tbKeyWord;
        private System.Windows.Forms.Button btnFollow;
        private System.Windows.Forms.RadioButton cbScraped;
        private System.Windows.Forms.RadioButton cbImported;
        private System.Windows.Forms.Label lblScrapedCount;
        private System.Windows.Forms.Timer tmrCounter;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAccountsCount;
    }
}

