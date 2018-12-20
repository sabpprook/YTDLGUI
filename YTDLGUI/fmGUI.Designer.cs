namespace YTDLGUI
{
    partial class fmGUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUrls = new System.Windows.Forms.Label();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioVWebm = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioVMP4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioVDefault = new MaterialSkin.Controls.MaterialRadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboAQuality = new System.Windows.Forms.ComboBox();
            this.comboAFormat = new System.Windows.Forms.ComboBox();
            this.labelAQuality = new System.Windows.Forms.Label();
            this.labelAFormat = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonUpdate = new MaterialSkin.Controls.MaterialFlatButton();
            this.comboMaxRes = new System.Windows.Forms.ComboBox();
            this.labelMaxRes = new System.Windows.Forms.Label();
            this.labelPlaylist = new System.Windows.Forms.Label();
            this.checkMaxRes = new MaterialSkin.Controls.MaterialCheckBox();
            this.checkPlaylist = new MaterialSkin.Controls.MaterialCheckBox();
            this.textURL = new System.Windows.Forms.TextBox();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.labelFolder = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClear = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAbort = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonDownload = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUrls
            // 
            this.labelUrls.AutoSize = true;
            this.labelUrls.BackColor = System.Drawing.Color.Transparent;
            this.labelUrls.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelUrls.ForeColor = System.Drawing.Color.Firebrick;
            this.labelUrls.Location = new System.Drawing.Point(12, 73);
            this.labelUrls.Name = "labelUrls";
            this.labelUrls.Size = new System.Drawing.Size(69, 19);
            this.labelUrls.TabIndex = 0;
            this.labelUrls.Text = "網址清單";
            // 
            // tabSelector
            // 
            this.tabSelector.BaseTabControl = this.tabControl;
            this.tabSelector.Depth = 0;
            this.tabSelector.Location = new System.Drawing.Point(483, 67);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(305, 30);
            this.tabSelector.TabIndex = 2;
            this.tabSelector.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Depth = 0;
            this.tabControl.Location = new System.Drawing.Point(483, 103);
            this.tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(305, 142);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.radioVWebm);
            this.tabPage1.Controls.Add(this.radioVMP4);
            this.tabPage1.Controls.Add(this.radioVDefault);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 116);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "VIDEO";
            // 
            // radioVWebm
            // 
            this.radioVWebm.AutoSize = true;
            this.radioVWebm.Depth = 0;
            this.radioVWebm.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioVWebm.Location = new System.Drawing.Point(11, 79);
            this.radioVWebm.Margin = new System.Windows.Forms.Padding(0);
            this.radioVWebm.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioVWebm.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioVWebm.Name = "radioVWebm";
            this.radioVWebm.Ripple = true;
            this.radioVWebm.Size = new System.Drawing.Size(161, 30);
            this.radioVWebm.TabIndex = 2;
            this.radioVWebm.TabStop = true;
            this.radioVWebm.Tag = "2";
            this.radioVWebm.Text = "Webm [webm + opus]";
            this.radioVWebm.UseVisualStyleBackColor = true;
            this.radioVWebm.CheckedChanged += new System.EventHandler(this.radioVideoFormat_CheckedChanged);
            // 
            // radioVMP4
            // 
            this.radioVMP4.AutoSize = true;
            this.radioVMP4.Depth = 0;
            this.radioVMP4.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioVMP4.Location = new System.Drawing.Point(11, 41);
            this.radioVMP4.Margin = new System.Windows.Forms.Padding(0);
            this.radioVMP4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioVMP4.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioVMP4.Name = "radioVMP4";
            this.radioVMP4.Ripple = true;
            this.radioVMP4.Size = new System.Drawing.Size(136, 30);
            this.radioVMP4.TabIndex = 1;
            this.radioVMP4.TabStop = true;
            this.radioVMP4.Tag = "1";
            this.radioVMP4.Text = "MP4 [h264 + aac]";
            this.radioVMP4.UseVisualStyleBackColor = true;
            this.radioVMP4.CheckedChanged += new System.EventHandler(this.radioVideoFormat_CheckedChanged);
            // 
            // radioVDefault
            // 
            this.radioVDefault.AutoSize = true;
            this.radioVDefault.Checked = true;
            this.radioVDefault.Depth = 0;
            this.radioVDefault.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioVDefault.Location = new System.Drawing.Point(11, 3);
            this.radioVDefault.Margin = new System.Windows.Forms.Padding(0);
            this.radioVDefault.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioVDefault.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioVDefault.Name = "radioVDefault";
            this.radioVDefault.Ripple = true;
            this.radioVDefault.Size = new System.Drawing.Size(73, 30);
            this.radioVDefault.TabIndex = 0;
            this.radioVDefault.TabStop = true;
            this.radioVDefault.Tag = "0";
            this.radioVDefault.Text = "Default";
            this.radioVDefault.UseVisualStyleBackColor = true;
            this.radioVDefault.CheckedChanged += new System.EventHandler(this.radioVideoFormat_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.comboAQuality);
            this.tabPage2.Controls.Add(this.comboAFormat);
            this.tabPage2.Controls.Add(this.labelAQuality);
            this.tabPage2.Controls.Add(this.labelAFormat);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(297, 116);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AUDIO";
            // 
            // comboAQuality
            // 
            this.comboAQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAQuality.FormattingEnabled = true;
            this.comboAQuality.Items.AddRange(new object[] {
            "96K",
            "128K",
            "192K",
            "256K",
            "320K"});
            this.comboAQuality.Location = new System.Drawing.Point(93, 49);
            this.comboAQuality.Name = "comboAQuality";
            this.comboAQuality.Size = new System.Drawing.Size(121, 26);
            this.comboAQuality.TabIndex = 11;
            this.comboAQuality.SelectedIndexChanged += new System.EventHandler(this.comboAQuality_SelectedIndexChanged);
            // 
            // comboAFormat
            // 
            this.comboAFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAFormat.FormattingEnabled = true;
            this.comboAFormat.Items.AddRange(new object[] {
            "best",
            "m4a",
            "mp3",
            "vorbis",
            "flac",
            "wav"});
            this.comboAFormat.Location = new System.Drawing.Point(93, 6);
            this.comboAFormat.Name = "comboAFormat";
            this.comboAFormat.Size = new System.Drawing.Size(121, 26);
            this.comboAFormat.TabIndex = 10;
            this.comboAFormat.SelectedIndexChanged += new System.EventHandler(this.comboAFormat_SelectedIndexChanged);
            // 
            // labelAQuality
            // 
            this.labelAQuality.AutoSize = true;
            this.labelAQuality.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAQuality.Location = new System.Drawing.Point(14, 52);
            this.labelAQuality.Name = "labelAQuality";
            this.labelAQuality.Size = new System.Drawing.Size(73, 19);
            this.labelAQuality.TabIndex = 9;
            this.labelAQuality.Text = "轉檔音質:";
            // 
            // labelAFormat
            // 
            this.labelAFormat.AutoSize = true;
            this.labelAFormat.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAFormat.Location = new System.Drawing.Point(14, 9);
            this.labelAFormat.Name = "labelAFormat";
            this.labelAFormat.Size = new System.Drawing.Size(73, 19);
            this.labelAFormat.TabIndex = 8;
            this.labelAFormat.Text = "轉檔格式:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.buttonUpdate);
            this.tabPage3.Controls.Add(this.comboMaxRes);
            this.tabPage3.Controls.Add(this.labelMaxRes);
            this.tabPage3.Controls.Add(this.labelPlaylist);
            this.tabPage3.Controls.Add(this.checkMaxRes);
            this.tabPage3.Controls.Add(this.checkPlaylist);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(297, 116);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "OPTION";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AutoSize = true;
            this.buttonUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.Depth = 0;
            this.buttonUpdate.Icon = null;
            this.buttonUpdate.Location = new System.Drawing.Point(85, 90);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Primary = true;
            this.buttonUpdate.Size = new System.Drawing.Size(125, 36);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "update binary";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // comboMaxRes
            // 
            this.comboMaxRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMaxRes.Enabled = false;
            this.comboMaxRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMaxRes.FormattingEnabled = true;
            this.comboMaxRes.Items.AddRange(new object[] {
            "360p",
            "480p",
            "720p",
            "1080p",
            "1440p",
            "2160p",
            "4320p"});
            this.comboMaxRes.Location = new System.Drawing.Point(160, 44);
            this.comboMaxRes.Name = "comboMaxRes";
            this.comboMaxRes.Size = new System.Drawing.Size(121, 26);
            this.comboMaxRes.TabIndex = 4;
            this.comboMaxRes.SelectedIndexChanged += new System.EventHandler(this.comboMaxRes_SelectedIndexChanged);
            // 
            // labelMaxRes
            // 
            this.labelMaxRes.AutoSize = true;
            this.labelMaxRes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMaxRes.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMaxRes.Location = new System.Drawing.Point(40, 47);
            this.labelMaxRes.Name = "labelMaxRes";
            this.labelMaxRes.Size = new System.Drawing.Size(114, 19);
            this.labelMaxRes.TabIndex = 3;
            this.labelMaxRes.Text = "影片最大解析度";
            this.labelMaxRes.Click += new System.EventHandler(this.labelMaxRes_Click);
            // 
            // labelPlaylist
            // 
            this.labelPlaylist.AutoSize = true;
            this.labelPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPlaylist.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPlaylist.Location = new System.Drawing.Point(40, 9);
            this.labelPlaylist.Name = "labelPlaylist";
            this.labelPlaylist.Size = new System.Drawing.Size(99, 19);
            this.labelPlaylist.TabIndex = 2;
            this.labelPlaylist.Text = "下載播放清單";
            this.labelPlaylist.Click += new System.EventHandler(this.labelPlaylist_Click);
            // 
            // checkMaxRes
            // 
            this.checkMaxRes.AutoSize = true;
            this.checkMaxRes.Depth = 0;
            this.checkMaxRes.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkMaxRes.Location = new System.Drawing.Point(11, 41);
            this.checkMaxRes.Margin = new System.Windows.Forms.Padding(0);
            this.checkMaxRes.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkMaxRes.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkMaxRes.Name = "checkMaxRes";
            this.checkMaxRes.Ripple = true;
            this.checkMaxRes.Size = new System.Drawing.Size(26, 30);
            this.checkMaxRes.TabIndex = 1;
            this.checkMaxRes.UseVisualStyleBackColor = true;
            this.checkMaxRes.CheckedChanged += new System.EventHandler(this.checkMaxRes_CheckedChanged);
            // 
            // checkPlaylist
            // 
            this.checkPlaylist.AutoSize = true;
            this.checkPlaylist.Depth = 0;
            this.checkPlaylist.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkPlaylist.Location = new System.Drawing.Point(11, 3);
            this.checkPlaylist.Margin = new System.Windows.Forms.Padding(0);
            this.checkPlaylist.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkPlaylist.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkPlaylist.Name = "checkPlaylist";
            this.checkPlaylist.Ripple = true;
            this.checkPlaylist.Size = new System.Drawing.Size(26, 30);
            this.checkPlaylist.TabIndex = 0;
            this.checkPlaylist.UseVisualStyleBackColor = true;
            // 
            // textURL
            // 
            this.textURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.textURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textURL.ForeColor = System.Drawing.Color.White;
            this.textURL.Location = new System.Drawing.Point(12, 99);
            this.textURL.Multiline = true;
            this.textURL.Name = "textURL";
            this.textURL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textURL.Size = new System.Drawing.Size(457, 146);
            this.textURL.TabIndex = 4;
            // 
            // textFolder
            // 
            this.textFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFolder.Location = new System.Drawing.Point(12, 282);
            this.textFolder.Name = "textFolder";
            this.textFolder.ReadOnly = true;
            this.textFolder.Size = new System.Drawing.Size(457, 22);
            this.textFolder.TabIndex = 5;
            this.textFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textFolder_MouseClick);
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.BackColor = System.Drawing.Color.Transparent;
            this.labelFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFolder.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelFolder.ForeColor = System.Drawing.Color.Firebrick;
            this.labelFolder.Location = new System.Drawing.Point(12, 256);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(113, 19);
            this.labelFolder.TabIndex = 6;
            this.labelFolder.Text = "下載位置 (開啟)";
            this.labelFolder.Click += new System.EventHandler(this.labelFolder_Click);
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(12, 318);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(776, 170);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "檔案大小";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "下載進度";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下載速度";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "剩餘時間";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "狀態";
            this.columnHeader6.Width = 80;
            // 
            // buttonClear
            // 
            this.buttonClear.AutoSize = true;
            this.buttonClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.Depth = 0;
            this.buttonClear.Icon = null;
            this.buttonClear.Location = new System.Drawing.Point(725, 268);
            this.buttonClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Primary = true;
            this.buttonClear.Size = new System.Drawing.Size(63, 36);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAbort
            // 
            this.buttonAbort.AutoSize = true;
            this.buttonAbort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAbort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAbort.Depth = 0;
            this.buttonAbort.Enabled = false;
            this.buttonAbort.Icon = global::YTDLGUI.Properties.Resources.abort;
            this.buttonAbort.Location = new System.Drawing.Point(620, 268);
            this.buttonAbort.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Primary = true;
            this.buttonAbort.Size = new System.Drawing.Size(93, 36);
            this.buttonAbort.TabIndex = 9;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.AutoSize = true;
            this.buttonDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDownload.Depth = 0;
            this.buttonDownload.Icon = global::YTDLGUI.Properties.Resources.download;
            this.buttonDownload.Location = new System.Drawing.Point(483, 268);
            this.buttonDownload.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Primary = true;
            this.buttonDownload.Size = new System.Drawing.Size(124, 36);
            this.buttonDownload.TabIndex = 8;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAuthor.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAuthor.ForeColor = System.Drawing.Color.Firebrick;
            this.labelAuthor.Location = new System.Drawing.Point(400, 73);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(69, 19);
            this.labelAuthor.TabIndex = 11;
            this.labelAuthor.Text = "程式作者";
            this.labelAuthor.Click += new System.EventHandler(this.labelAuthor_Click);
            // 
            // fmGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.textFolder);
            this.Controls.Add(this.textURL);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.labelUrls);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmGUI";
            this.Opacity = 0.95D;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube-dl GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmGUI_FormClosed);
            this.Load += new System.EventHandler(this.fmGUI_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUrls;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private MaterialSkin.Controls.MaterialTabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textURL;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.ListView listView;
        private MaterialSkin.Controls.MaterialRadioButton radioVDefault;
        private MaterialSkin.Controls.MaterialRadioButton radioVWebm;
        private MaterialSkin.Controls.MaterialRadioButton radioVMP4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private MaterialSkin.Controls.MaterialCheckBox checkPlaylist;
        private MaterialSkin.Controls.MaterialCheckBox checkMaxRes;
        private System.Windows.Forms.Label labelPlaylist;
        private System.Windows.Forms.Label labelMaxRes;
        private System.Windows.Forms.ComboBox comboMaxRes;
        private System.Windows.Forms.Label labelAFormat;
        private System.Windows.Forms.Label labelAQuality;
        private System.Windows.Forms.ComboBox comboAFormat;
        private System.Windows.Forms.ComboBox comboAQuality;
        private MaterialSkin.Controls.MaterialRaisedButton buttonDownload;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAbort;
        private MaterialSkin.Controls.MaterialRaisedButton buttonClear;
        private MaterialSkin.Controls.MaterialFlatButton buttonUpdate;
        private System.Windows.Forms.Label labelAuthor;
    }
}

