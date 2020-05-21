namespace ShortnewsBot {
    partial class MainForm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegisterAccount = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslViewsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStopViewGenerator = new System.Windows.Forms.Button();
            this.btnStartViewGenerator = new System.Windows.Forms.Button();
            this.tbShortnewsViewUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStopRating = new System.Windows.Forms.Button();
            this.btnStartRating = new System.Windows.Forms.Button();
            this.tbShortnewsRatingUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegisterAccount);
            this.groupBox1.Controls.Add(this.tbUserName);
            this.groupBox1.Controls.Add(this.tbMail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrierung";
            // 
            // btnRegisterAccount
            // 
            this.btnRegisterAccount.Location = new System.Drawing.Point(18, 101);
            this.btnRegisterAccount.Name = "btnRegisterAccount";
            this.btnRegisterAccount.Size = new System.Drawing.Size(269, 23);
            this.btnRegisterAccount.TabIndex = 4;
            this.btnRegisterAccount.Text = "Registrieren";
            this.btnRegisterAccount.UseVisualStyleBackColor = true;
            this.btnRegisterAccount.Click += new System.EventHandler(this.btnRegisterAccount_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(96, 60);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(191, 20);
            this.tbUserName.TabIndex = 3;
            this.tbUserName.Text = "Example2016";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(96, 32);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(191, 20);
            this.tbMail.TabIndex = 2;
            this.tbMail.Text = "example@example.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Benutzername";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "eMail";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Controls.Add(this.btnStopViewGenerator);
            this.groupBox2.Controls.Add(this.btnStartViewGenerator);
            this.groupBox2.Controls.Add(this.tbShortnewsViewUrl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Views";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslViewsCount});
            this.statusStrip1.Location = new System.Drawing.Point(3, 99);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(298, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "Views: ";
            // 
            // tsslViewsCount
            // 
            this.tsslViewsCount.Name = "tsslViewsCount";
            this.tsslViewsCount.Size = new System.Drawing.Size(13, 17);
            this.tsslViewsCount.Text = "0";
            // 
            // btnStopViewGenerator
            // 
            this.btnStopViewGenerator.Location = new System.Drawing.Point(151, 67);
            this.btnStopViewGenerator.Name = "btnStopViewGenerator";
            this.btnStopViewGenerator.Size = new System.Drawing.Size(136, 23);
            this.btnStopViewGenerator.TabIndex = 5;
            this.btnStopViewGenerator.Text = "Stop";
            this.btnStopViewGenerator.UseVisualStyleBackColor = true;
            this.btnStopViewGenerator.Click += new System.EventHandler(this.btnStopViewGenerator_Click);
            // 
            // btnStartViewGenerator
            // 
            this.btnStartViewGenerator.Location = new System.Drawing.Point(18, 67);
            this.btnStartViewGenerator.Name = "btnStartViewGenerator";
            this.btnStartViewGenerator.Size = new System.Drawing.Size(127, 23);
            this.btnStartViewGenerator.TabIndex = 4;
            this.btnStartViewGenerator.Text = "Start";
            this.btnStartViewGenerator.UseVisualStyleBackColor = true;
            this.btnStartViewGenerator.Click += new System.EventHandler(this.btnStartViewGenerator_Click);
            // 
            // tbShortnewsViewUrl
            // 
            this.tbShortnewsViewUrl.Location = new System.Drawing.Point(18, 41);
            this.tbShortnewsViewUrl.Name = "tbShortnewsViewUrl";
            this.tbShortnewsViewUrl.Size = new System.Drawing.Size(269, 20);
            this.tbShortnewsViewUrl.TabIndex = 2;
            this.tbShortnewsViewUrl.Text = "http://www.shortnews.de/id/1206253/nicht-mehr-komplett-kostenfrei-bezahlschranke-" +
    "bei-spiegel-online";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Shortnews-URL";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.statusStrip2);
            this.groupBox3.Controls.Add(this.btnStopRating);
            this.groupBox3.Controls.Add(this.btnStartRating);
            this.groupBox3.Controls.Add(this.tbShortnewsRatingUrl);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 124);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bewertungen";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip2.Location = new System.Drawing.Point(3, 99);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(298, 22);
            this.statusStrip2.TabIndex = 6;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel2.Text = "Views: ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel3.Text = "0";
            // 
            // btnStopRating
            // 
            this.btnStopRating.Location = new System.Drawing.Point(151, 67);
            this.btnStopRating.Name = "btnStopRating";
            this.btnStopRating.Size = new System.Drawing.Size(136, 23);
            this.btnStopRating.TabIndex = 5;
            this.btnStopRating.Text = "Stop";
            this.btnStopRating.UseVisualStyleBackColor = true;
            // 
            // btnStartRating
            // 
            this.btnStartRating.Location = new System.Drawing.Point(18, 67);
            this.btnStartRating.Name = "btnStartRating";
            this.btnStartRating.Size = new System.Drawing.Size(127, 23);
            this.btnStartRating.TabIndex = 4;
            this.btnStartRating.Text = "Start";
            this.btnStartRating.UseVisualStyleBackColor = true;
            this.btnStartRating.Click += new System.EventHandler(this.btnStartRating_Click);
            // 
            // tbShortnewsRatingUrl
            // 
            this.tbShortnewsRatingUrl.Location = new System.Drawing.Point(18, 41);
            this.tbShortnewsRatingUrl.Name = "tbShortnewsRatingUrl";
            this.tbShortnewsRatingUrl.Size = new System.Drawing.Size(269, 20);
            this.tbShortnewsRatingUrl.TabIndex = 2;
            this.tbShortnewsRatingUrl.Text = "http://www.shortnews.de/id/1206491/todesfall-mit-autopilot-sind-tesla-autos-toedl" +
    "iche-gefahren";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Shortnews-URL";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 435);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "ShortnewsBot";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRegisterAccount;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStopViewGenerator;
        private System.Windows.Forms.Button btnStartViewGenerator;
        private System.Windows.Forms.TextBox tbShortnewsViewUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslViewsCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button btnStopRating;
        private System.Windows.Forms.Button btnStartRating;
        private System.Windows.Forms.TextBox tbShortnewsRatingUrl;
        private System.Windows.Forms.Label label3;
    }
}

