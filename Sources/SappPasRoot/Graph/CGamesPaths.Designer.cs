namespace SappPasRoot.Graph
{
    partial class CGamesPaths
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "e",
            "e\""}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "e",
            "r"}, -1);
            this.boxLog = new System.Windows.Forms.RichTextBox();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAppPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelTop = new System.Windows.Forms.Panel();
            this.flpGames = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titChooseFolder = new System.Windows.Forms.Label();
            this.tbMainPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btSimul = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.tlpInfos = new System.Windows.Forms.TableLayoutPanel();
            this.labPName = new System.Windows.Forms.Label();
            this.titPlatform = new System.Windows.Forms.Label();
            this.titCPath = new System.Windows.Forms.Label();
            this.tboxHOldPath = new System.Windows.Forms.TextBox();
            this.titCRPath = new System.Windows.Forms.Label();
            this.tboxROldPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpInfos.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxLog
            // 
            this.boxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxLog.Location = new System.Drawing.Point(12, 510);
            this.boxLog.Name = "boxLog";
            this.boxLog.Size = new System.Drawing.Size(518, 83);
            this.boxLog.TabIndex = 1;
            this.boxLog.Text = "";
            // 
            // colID
            // 
            this.colID.Text = "Game.Id";
            this.colID.Width = 207;
            // 
            // colAppPath
            // 
            this.colAppPath.Text = "LaunchBox.Bd.Id";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.AutoArrange = false;
            this.listView1.BackColor = System.Drawing.SystemColors.Info;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTitle,
            this.colAppPath,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(700, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(172, 86);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 248;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ThemeVideopath";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "RootFolder";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ConfigurationPath";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ConfigurationCommandLine";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PlatformClearLogoImagePath";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "DosBoxConfiguraation path";
            // 
            // panelTop
            // 
            this.panelTop.AutoSize = true;
            this.panelTop.Controls.Add(this.flpGames);
            this.panelTop.Controls.Add(this.listView1);
            this.panelTop.Controls.Add(this.tableLayoutPanel1);
            this.panelTop.Controls.Add(this.tlpInfos);
            this.panelTop.Location = new System.Drawing.Point(22, 12);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(990, 544);
            this.panelTop.TabIndex = 6;
            // 
            // flpGames
            // 
            this.flpGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpGames.AutoScroll = true;
            this.flpGames.BackColor = System.Drawing.Color.DarkGreen;
            this.flpGames.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpGames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGames.Location = new System.Drawing.Point(3, 160);
            this.flpGames.MinimumSize = new System.Drawing.Size(760, 200);
            this.flpGames.Name = "flpGames";
            this.flpGames.Size = new System.Drawing.Size(984, 384);
            this.flpGames.TabIndex = 1;
            this.flpGames.WrapContents = false;
            this.flpGames.MouseHover += new System.EventHandler(this.flpGames_MouseHover);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.titChooseFolder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMainPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 120);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 33);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // titChooseFolder
            // 
            this.titChooseFolder.AutoSize = true;
            this.titChooseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.titChooseFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titChooseFolder.Location = new System.Drawing.Point(3, 5);
            this.titChooseFolder.Name = "titChooseFolder";
            this.titChooseFolder.Padding = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.titChooseFolder.Size = new System.Drawing.Size(167, 25);
            this.titChooseFolder.TabIndex = 6;
            this.titChooseFolder.Text = "Choose a New Folder:";
            // 
            // tbMainPath
            // 
            this.tbMainPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMainPath.Location = new System.Drawing.Point(176, 8);
            this.tbMainPath.MaximumSize = new System.Drawing.Size(400, 4);
            this.tbMainPath.MinimumSize = new System.Drawing.Size(4, 20);
            this.tbMainPath.Name = "tbMainPath";
            this.tbMainPath.Size = new System.Drawing.Size(270, 20);
            this.tbMainPath.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btBrowse);
            this.flowLayoutPanel1.Controls.Add(this.btSimul);
            this.flowLayoutPanel1.Controls.Add(this.btApply);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(452, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 27);
            this.flowLayoutPanel1.TabIndex = 26;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btBrowse
            // 
            this.btBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btBrowse.Location = new System.Drawing.Point(3, 3);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.TabIndex = 0;
            this.btBrowse.Text = "Browse ...";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // btSimul
            // 
            this.btSimul.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSimul.Location = new System.Drawing.Point(84, 3);
            this.btSimul.Name = "btSimul";
            this.btSimul.Size = new System.Drawing.Size(75, 23);
            this.btSimul.TabIndex = 13;
            this.btSimul.Text = "Simulate...";
            this.btSimul.UseVisualStyleBackColor = true;
            this.btSimul.Click += new System.EventHandler(this.btSimul_Click);
            // 
            // btApply
            // 
            this.btApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btApply.Location = new System.Drawing.Point(165, 3);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(75, 23);
            this.btApply.TabIndex = 14;
            this.btApply.Text = "Apply...";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Visible = false;
            // 
            // tlpInfos
            // 
            this.tlpInfos.AutoSize = true;
            this.tlpInfos.ColumnCount = 2;
            this.tlpInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInfos.Controls.Add(this.labPName, 1, 0);
            this.tlpInfos.Controls.Add(this.titPlatform, 0, 0);
            this.tlpInfos.Controls.Add(this.titCPath, 0, 1);
            this.tlpInfos.Controls.Add(this.tboxHOldPath, 1, 1);
            this.tlpInfos.Controls.Add(this.titCRPath, 0, 2);
            this.tlpInfos.Controls.Add(this.tboxROldPath, 1, 2);
            this.tlpInfos.Location = new System.Drawing.Point(0, 20);
            this.tlpInfos.Name = "tlpInfos";
            this.tlpInfos.RowCount = 3;
            this.tlpInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpInfos.Size = new System.Drawing.Size(334, 90);
            this.tlpInfos.TabIndex = 2;
            // 
            // labPName
            // 
            this.labPName.AutoSize = true;
            this.labPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.labPName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labPName.Location = new System.Drawing.Point(214, 0);
            this.labPName.MinimumSize = new System.Drawing.Size(0, 20);
            this.labPName.Name = "labPName";
            this.labPName.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labPName.Size = new System.Drawing.Size(99, 20);
            this.labPName.TabIndex = 3;
            this.labPName.Text = "PlatformName";
            this.labPName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titPlatform
            // 
            this.titPlatform.AutoSize = true;
            this.titPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.titPlatform.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titPlatform.Location = new System.Drawing.Point(3, 0);
            this.titPlatform.Name = "titPlatform";
            this.titPlatform.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.titPlatform.Size = new System.Drawing.Size(65, 19);
            this.titPlatform.TabIndex = 2;
            this.titPlatform.Text = "Platform:";
            this.titPlatform.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titCPath
            // 
            this.titCPath.AutoSize = true;
            this.titCPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.titCPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titCPath.Location = new System.Drawing.Point(3, 30);
            this.titCPath.Name = "titCPath";
            this.titCPath.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.titCPath.Size = new System.Drawing.Size(149, 19);
            this.titCPath.TabIndex = 4;
            this.titCPath.Text = "Current Platform Path:";
            this.titCPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tboxHOldPath
            // 
            this.tboxHOldPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxHOldPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxHOldPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tboxHOldPath.Location = new System.Drawing.Point(217, 35);
            this.tboxHOldPath.Margin = new System.Windows.Forms.Padding(6, 5, 3, 3);
            this.tboxHOldPath.MinimumSize = new System.Drawing.Size(0, 20);
            this.tboxHOldPath.Name = "tboxHOldPath";
            this.tboxHOldPath.ReadOnly = true;
            this.tboxHOldPath.Size = new System.Drawing.Size(114, 13);
            this.tboxHOldPath.TabIndex = 5;
            this.tboxHOldPath.Text = "HarLink";
            this.tboxHOldPath.WordWrap = false;
            this.tboxHOldPath.TextChanged += new System.EventHandler(this.ResizeTextBox);
            // 
            // titCRPath
            // 
            this.titCRPath.AutoSize = true;
            this.titCRPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.titCRPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titCRPath.Location = new System.Drawing.Point(3, 60);
            this.titCRPath.Name = "titCRPath";
            this.titCRPath.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.titCRPath.Size = new System.Drawing.Size(205, 19);
            this.titCRPath.TabIndex = 7;
            this.titCRPath.Text = "Current Relative Platform Path:";
            this.titCRPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tboxROldPath
            // 
            this.tboxROldPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxROldPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tboxROldPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tboxROldPath.Location = new System.Drawing.Point(217, 65);
            this.tboxROldPath.Margin = new System.Windows.Forms.Padding(6, 5, 3, 3);
            this.tboxROldPath.MinimumSize = new System.Drawing.Size(0, 20);
            this.tboxROldPath.Name = "tboxROldPath";
            this.tboxROldPath.ReadOnly = true;
            this.tboxROldPath.Size = new System.Drawing.Size(114, 13);
            this.tboxROldPath.TabIndex = 9;
            this.tboxROldPath.Text = "RelatLink";
            this.tboxROldPath.WordWrap = false;
            this.tboxROldPath.TextChanged += new System.EventHandler(this.ResizeTextBox);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1107, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // CGamesPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 605);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.boxLog);
            this.Controls.Add(this.panelTop);
            this.Name = "CGamesPaths";
            this.Text = "TempoChangePathsJeux";
            this.Load += new System.EventHandler(this.CGamesPaths_Load);
            this.Shown += new System.EventHandler(this.CGamesPaths_Shown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tlpInfos.ResumeLayout(false);
            this.tlpInfos.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox boxLog;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colAppPath;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flpGames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titChooseFolder;
        protected internal System.Windows.Forms.TextBox tbMainPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TableLayoutPanel tlpInfos;
        private System.Windows.Forms.Label labPName;
        private System.Windows.Forms.Label titPlatform;
        private System.Windows.Forms.Label titCPath;
        protected internal System.Windows.Forms.TextBox tboxHOldPath;
        private System.Windows.Forms.Label titCRPath;
        protected internal System.Windows.Forms.TextBox tboxROldPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btSimul;
        private System.Windows.Forms.Button btApply;
    }
}